using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyTaskDomain.DTO;
using MyTaskService.Interfaces;

namespace MyTaskAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {

        private IJobService JobService;

        public JobController(IJobService _JobService)
        {
            JobService = _JobService;
        }

        // GET: api/GetJobs
        [HttpGet]
        [Route("GetJobs")]
        public IEnumerable<JobDTO> GetJobs()
        {
            return JobService.GetJobs();
        }

        // GET: api/GetJob/id
        [HttpGet("{id}", Name = "GetJob")]
        public JobDTO GetJob(int id)
        {
            return JobService.GetJob(id);
        }

        // POST: api/InsertOrUpdateJob/JobDTO
        [HttpPost]
        [Route("InsertOrUpdateJob")]

        public JobDTO InsertOrUpdateJob([FromBody] JobDTO JobDTO)
        {
            return JobService.InsertOrUpdateJob(JobDTO);

        }


        // DELETE: api/RemoveJob/id
        [HttpDelete("{id}" , Name = "RemoveJob")]
        public bool RemoveJob(int id)
        {
            return JobService.RemoveJob(id); ;
        }
    }
}
