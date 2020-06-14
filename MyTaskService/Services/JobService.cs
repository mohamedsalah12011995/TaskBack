
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MyTaskData;
using MyTaskData.Entities;
using MyTaskDomain;
using MyTaskDomain.DTO;
using MyTaskService.Interfaces;

namespace MyTaskService.Services
{
    public class JobService : BaseService, IJobService
    {
        public JobService(IMapper _mapper, MyTaskDbContext _dbContext)
        {
            mapper = _mapper;
            dbcontext = _dbContext;
        }

        public JobDTO GetJob(int Id)
        {
            var Job = dbcontext.Jobs.FirstOrDefault(f => f.Id == Id);
            ///cast entities to DTO 
            var JobDTO = mapper.Map<JobDTO>(Job);
            ///return DTO 
            return JobDTO;
        }

        public List<JobDTO> GetJobs()
        {
            var Job = dbcontext.Jobs.ToList();
            ///cast entities to DTO 
            var JobDTO = mapper.Map<List<JobDTO>>(Job);
            ///return DTO 
            return JobDTO;
        }

        public JobDTO InsertOrUpdateJob(JobDTO jobDTO)
        {
            if (jobDTO.Id > 0)  ///Update Job 
            {
                ///Get Job entity from database by id 
                var _Job = dbcontext.Jobs.Find(jobDTO.Id);
                if (_Job != null)   ///if Exist 
                {

                    try
                    {
                        ///Mapp new values from JobDTO to Job 
                        var mapped_Job = mapper.Map<JobDTO, Job>(jobDTO, _Job);
                        dbcontext.Jobs.Update(mapped_Job);
                        dbcontext.SaveChanges();

                        //  return true;
                        return jobDTO;
                    }
                    catch (Exception x)
                    {
                        return null;
                    }


                }
                else { return null; }
            }
            else
            {
                try
                {
                    var mappedJob = mapper.Map<Job>(jobDTO);
                    dbcontext.Jobs.Add(mappedJob);
                    dbcontext.SaveChanges();
                    // return inserted object ;
                    return jobDTO;
                }
                catch (Exception e)
                {
                    return null;
                    //return false; 
                }
            }
        }

        public bool RemoveJob(int Id)
        {
            try
            {
                ///get obj for delete 
                var Job = dbcontext.Jobs.Find(Id);

                ///remove obj from db context 
                dbcontext.Jobs.Remove(Job);

                ///save changes on database 
                dbcontext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
