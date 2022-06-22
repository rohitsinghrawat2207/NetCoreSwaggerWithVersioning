using Microsoft.EntityFrameworkCore;
using TestApi.ServiceLayer;
using TestApi.ServiceLayer.Abstraction;
using TestApi.Repository.Abstraction;
using TestApi.Repository;


using TestApi.Model;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<StudentDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "Stellar Test Api",
        Description = "The APIs supporting the Stellar Test Api",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Stellar Industrial Supply",
            Email = "it@stellarindustrial.com",
            Url = new Uri("https://stellarindustrial.com")
        }
    });

});


builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
