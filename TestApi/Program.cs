using Microsoft.EntityFrameworkCore;
using TestApi.ServiceLayer;
using TestApi.ServiceLayer.Abstraction;
using TestApi.DataAccessLayer.Abstraction;
using TestApi.DataAccessLayer;
using TestApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using TestApi.Controllers.v1;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;
using Microsoft.Extensions.DependencyInjection;
using TestApi.Options;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using TestApi.Controllers.v2;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


#region DB Connection
builder.Services.AddDbContext<StudentDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
#endregion

#region API Versioning
builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = ApiVersion.Default;
    //options.ApiVersionReader = ApiVersionReader.Combine(new MediaTypeApiVersionReader("version"), new HeaderApiVersionReader("X-version"));
    ////new MediaTypeApiVersionReader("version");
    // new HeaderApiVersionReader("X-version");
    options.Conventions.Controller<StudentController>().HasApiVersion(1, 0);
    options.Conventions.Controller<StudentDBController>().HasApiVersion(2, 0);

    options.ReportApiVersions = true;
});
#endregion

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


#region Swagger
builder.Services.AddSwaggerGen();
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();
//builder.Services.AddSwaggerGen(options =>
//{
//    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
//    {
//        Version = "v1",
//        Title = "Demo Api",
//        Description = "The APIs supporting the Stellar Test Api",
//        Contact = new Microsoft.OpenApi.Models.OpenApiContact
//        {
//            Name = "Demo Version 1",
//            Email = "demo@gmail.com",
//            Url = new Uri("https://a.com")
//        }
//    });
//    options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
//    {
//        Version = "v2",
//        Title = "Demo Api Version 2",
//        Description = "The APIs supporting the Stellar Test Api",
//        Contact = new Microsoft.OpenApi.Models.OpenApiContact
//        {
//            Name = "Demo Version 2",
//            Email = "demo@gmail.com",
//            Url = new Uri("https://b.com")
//        }
//    });

//});


#endregion

builder.Services.AddVersionedApiExplorer(setup =>
{
    setup.GroupNameFormat = "'v'VVV";
    setup.SubstituteApiVersionInUrl = true;
});

builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IStudentDataAccessLayer, StudentDataAccessLayer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", "Demo APi Version "+description.ApiVersion.ToString());
        }
    });
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
