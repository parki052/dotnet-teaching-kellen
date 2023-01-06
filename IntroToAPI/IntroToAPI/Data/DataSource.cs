using IntroToAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntroToAPI.Data
{
    public class DataSource
    {
        public List<Student> Students { get; set; } = new List<Student>()
        {
            new Student()
            {
                Id = 0,
                Name = "Sally",
                Age = 32
            },
            new Student()
            {
                Id = 1,
                Name = "Doug",
                Age = 16
            },
            new Student()
            {
                Id = 2,
                Name = "Brandon",
                Age = 55
            },
            new Student()
            {
                Id = 3,
                Name = "Jon",
                Age = 30
            }
        };
    }
}
