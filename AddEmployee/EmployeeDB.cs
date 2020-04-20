namespace AddEmployee
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class EmployeeDB : DbContext
    {
        public EmployeeDB()
            : base("name=EmployeeDB")
        {
        }
         public virtual DbSet<Employee> Employees { get; set; }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public Department? Department { get; set; }
    }

    public enum Department
    {
        Management, Development, QualityControl, Production, Sales, Unknown
    }
}