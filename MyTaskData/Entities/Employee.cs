using System;
using System.ComponentModel.DataAnnotations;

namespace MyTaskData.Entities
{
    public class Employee
    {
        [Key]
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
        public virtual Department Department { get; set; }
        public virtual Job Job { get; set; }
    }
}
