using MaterialsApp.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        public Manager Manager { get; set; }

        public ApiController()
        {
            Manager = new ManagerFactory().GetManager();
        }

        [HttpGet]
        public void CheckResources()
        {

        }
    }
}
