

using System;

namespace MyTaskDomain.DTO
{
   public class EmployeeDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Adress { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public string Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int JobId { get; set; }
        public int DepartmentId { get; set; }
        public DepartmentDTO Department { get; set; }
        public virtual JobDTO Job { get; set; }

    }
}
