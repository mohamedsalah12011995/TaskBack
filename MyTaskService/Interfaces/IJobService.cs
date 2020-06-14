using MyTaskDomain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTaskService.Interfaces
{
   public interface IJobService
    {
        List<JobDTO> GetJobs();
        JobDTO GetJob(int Id);
        JobDTO InsertOrUpdateJob(JobDTO jobDTO);
        bool RemoveJob(int Id);
    }
}
