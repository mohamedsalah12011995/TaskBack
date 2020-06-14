using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyTaskDomain.DTO;
using MyTaskService.Interfaces;

namespace MyTaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        private IDepartmentService DepartmentService;

        public DepartmentController(IDepartmentService _DepartmentService)
        {
            DepartmentService = _DepartmentService;
        }

        // GET: api/GetDepartments
        [HttpGet]
        [Route("GetDepartments")]
        public IEnumerable<DepartmentDTO> GetDepartments()
        {
            return DepartmentService.GetDepartments();
        }

        // GET: api/GetDepartment/id
        [HttpGet("{id}", Name = "GetDepartment")]
        public DepartmentDTO GetDepartment(int id)
        {
            return DepartmentService.GetDepartment(id);
        }

        // POST: api/InsertOrUpdateDepartment/DepartmentDTO
        [HttpPost]
        [Route("InsertOrUpdateDepartment")]

        public DepartmentDTO InsertOrUpdateDepartment([FromBody] DepartmentDTO DepartmentDTO)
        {
            return DepartmentService.InsertOrUpdateDepartment(DepartmentDTO);

        }


        // DELETE: api/RemoveDepartment/id
        [HttpDelete("{id}" , Name = "RemoveDepartment")]
        public bool RemoveDepartment(int id)
        {
            return DepartmentService.RemoveDepartment(id); ;
        }
    }
}
