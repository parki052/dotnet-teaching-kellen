using IntroToAPI.Data;
using IntroToAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        public DataSource DataSource = new DataSource();

        [HttpGet]
        public List<Student> GetStudents()
        {
            return DataSource.Students;
        }

        [HttpGet]
        [Route("{id}")]
        public Student GetStudentById(int id)
        {
            var student = DataSource.Students.SingleOrDefault(s => s.Id == id);

            return student;
        }

        [HttpGet]
        [Route("name/{name}")]
        public Student GetStudentByName(string name)
        {
            
            var student = DataSource.Students.SingleOrDefault(s => s.Name.ToLower() == name.ToLower());

            return student;
        }

        [HttpGet]
        [Route("age/{age}")]
        public Student GetStudentByAge(int age)
        {
            var student = DataSource.Students.SingleOrDefault(s => s.Age == age);

            return student;
        }

        [HttpDelete]
        [Route("{id}")]
        public string RemoveStudentById(int id)
        {
            var message = "";
            var student = DataSource.Students.SingleOrDefault(s => s.Id == id);

            if(student == null)
            {
                message = $"Error: student of id {id} not found.";
            }
            else
            {
                DataSource.Students.Remove(student);
                message = $"Student {student.Id}:{student.Name} removed.";
            }

            return message;
        }
    }
}
