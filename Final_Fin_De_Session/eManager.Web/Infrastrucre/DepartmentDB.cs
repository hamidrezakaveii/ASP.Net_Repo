using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using eManager.Domain;

namespace eManager.Web.Infrastrucre
{
    public class DepartmentDB : DbContext, IDepartmentDataSource
    {
        public DepartmentDB() :base("DefaultConnection")
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }


        IQueryable<Department> IDepartmentDataSource.Departments
        {
            get { return Departments; }
        }

        IQueryable<Employee> IDepartmentDataSource.Employees
        {
            get { return Employees; }
        }
    }
}