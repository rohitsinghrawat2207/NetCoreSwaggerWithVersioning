using System;
using System.Collections.Generic;

namespace TestApi.Model
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public string? Name { get; set; }
        public string? Class { get; set; }
        public string? Grade { get; set; }
        public string? Division { get; set; }
    }
}
