using Microsoft.EntityFrameworkCore;
using System;

namespace Employee.DataAccessLayer.DBContexts
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
           : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed the database with dummy data

            modelBuilder.Entity<Employee>().HasKey(e => new { e.EmployeeID });

            Console.WriteLine("Seeding data to Employee table");

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Empcode = "1121055",
                    FirstName = "Shivendu",
                    LastName = "Srivastava",
                    LoginName = "shiv.sri",
                    Designation = "Consultant",
                    Doj = new DateTime(2021, 2, 2).ToString("dd-MMM-yyyy")
                },
               new Employee
               {
                   Empcode = "1135109",
                   FirstName = "Kinjalk",
                   LastName = "Tripathi",
                   LoginName = "kinj.tri",
                   Designation = "Sr. Business Analyst",
                   Doj = new DateTime(2020, 6, 8).ToString("dd-MMM-yyyy")
               },
               new Employee
               {
                   Empcode = "1156820",
                   FirstName = "Akrati",
                   LastName = "Bajpai",
                   LoginName = "akra.baj",
                   Designation = "Sr. Security Specialist",
                   Doj = new DateTime(2019, 4, 14).ToString("dd-MMM-yyyy")
               },
               new Employee
               {
                   Empcode = "1135820",
                   FirstName = "Raghav",
                   LastName = "Gowda",
                   LoginName = "ragh.gow",
                   Designation = "Sr. Finance Advisor",
                   Doj = new DateTime(2015, 5, 11).ToString("dd-MMM-yyyy")
               }
               );

            base.OnModelCreating(modelBuilder);
        }
    }
}
