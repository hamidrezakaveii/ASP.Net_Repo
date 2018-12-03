using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace Gestion_Des_Conges_2.Infrastructure
{
    public class LeaveManagementRepositoryDb : DbContext, ILeaveManagementRepository
    {


        public LeaveManagementRepositoryDb() : base("name=" + nameof(LeaveManagementRepositoryDb))
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        private DbSet<LMEmployee> Employees { get; set; }
        private DbSet<LMLeaveHistory> LeaveHistories { get; set; }

        DbSet<LMEmployee> ILeaveManagementRepository.Employees
        {
            get { return Employees; }

            //set { Employees = value; }
        }

        DbSet<LMLeaveHistory> ILeaveManagementRepository.LeaveHistories
        {
            get { return LeaveHistories; }
            //set { LeaveHistories = value; }
        }

        public int InsertEmployee(LMEmployee employee)
        {
            int result = -1;
            
            try {

                Employees.AddOrUpdate(employee);
                result = this.SaveChanges();

                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }

                    throw;
                }

            if (result != -1)
            {
                result = 1;
            }

            return result;

        }

        public int InsertLeave(LMLeaveHistory leave)
        {
            int result = -1;
            


            try {

                LeaveHistories.AddOrUpdate(leave);
                result = this.SaveChanges();

                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }

                    throw;
                }


            if (result != -1)
            {
                result = 1;
            }

            return result;
        }
    }
}