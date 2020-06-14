using System;
using Microsoft.EntityFrameworkCore;
using MyTaskData.Entities;

namespace MyTaskData
{
    public class MyTaskDbContext: DbContext
    {
        public MyTaskDbContext(DbContextOptions<MyTaskDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Job> Jobs { get; set; }


        /// <summary>
        /// On Model Creating For Relathionship  configuration between DbSets 
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}
