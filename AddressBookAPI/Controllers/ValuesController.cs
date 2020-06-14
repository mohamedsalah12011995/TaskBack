using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyTaskData;
using MyTaskData.Entities;

namespace MyTaskService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly MyTaskDbContext _dbContext;

        public ValuesController(MyTaskDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            CreateDataInStartApp();
            return new string[] { "wellcome", "to my task" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


        public void CreateDataInStartApp()
        {

            List<Department> department = new List<Department>();
            var m = _dbContext.Departments.FirstOrDefault();
            if (m == null)
            {
                department = new List<Department> {
                new Department{Name = "Information tech"},
                new Department{Name = "Teaching"},
                new Department{Name = "Accounting"}};
                _dbContext.Departments.AddRange(department);
                _dbContext.SaveChanges();
            }

            List<Job> job = new List<Job>();
            var c = _dbContext.Jobs.FirstOrDefault();
            if (c == null)
            {
                job = new List<Job> {
                new Job{Name = "Develper"},
                new Job{Name = "Teacher"},
                new Job{Name = "Accountant"}};
                _dbContext.Jobs.AddRange(job);
                _dbContext.SaveChanges();
            }


        }

    }
}
