using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyTaskDomain.DTO;
using MyTaskService.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;

using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MyTaskAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IHostingEnvironment _hostingEnvironment;

        private IEmployeeService employeeService;

        public EmployeeController(IEmployeeService _employeeService)
        {
            employeeService = _employeeService;
        }

        // GET: api/GetEmployees
        [HttpGet]
        [Route("GetEmployees")]
        public IEnumerable<EmployeeDTO> GetEmployees()
        {
            return employeeService.GetEmployees();
        }

        // GET: api/GetEmployee/id
        [HttpGet]
        [Route("GetEmployee")]
        public EmployeeDTO GetEmployee(int id)
        {
            return employeeService.GetEmployee(id);
        }

        // POST: api/InsertOrUpdateEmployee/employeeDTO
        [HttpPost]
        [Route("InsertOrUpdateEmployee")]

        public EmployeeDTO InsertOrUpdateEmployee([FromBody] EmployeeDTO employeeDTO)
        {
            return employeeService.InsertOrUpdateEmployee(employeeDTO);

        }


        // DELETE: api/RemoveEmployee/id
        [HttpDelete]
        [Route("RemoveEmployee")]
        public bool RemoveEmployee(int id)
        {
            return employeeService.RemoveEmployee(id); ;
        }

    }
}
