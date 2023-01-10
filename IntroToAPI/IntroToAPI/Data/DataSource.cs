﻿using IntroToAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Response AddStudent(string name, int age)
        {
            var response = new Response();

            if(name == "")
            {
                response.Success = false;
                response.Message = "Error: a name must be provided";
            }
            else
            {
                var highestId = Students.Max(s => s.Id);
                var newStudent = new Student();

                newStudent.Name = name;
                newStudent.Age = age;
                newStudent.Id = highestId + 1;

                Students.Add(newStudent);

                response.Success = true;
                response.Message = $"Successfully added {name} to students";
            }

            return response;
        }
    }
}
