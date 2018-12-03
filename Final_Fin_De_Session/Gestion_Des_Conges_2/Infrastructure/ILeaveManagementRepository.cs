using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Des_Conges_2.Infrastructure
{
    public interface ILeaveManagementRepository
    {
        //public ILeaveManagementRepository()
        //    : base("name=ILeaveManagementRepository")
        //{
        //

        int InsertEmployee(LMEmployee employee);

        int InsertLeave(LMLeaveHistory leave);


        DbSet<LMEmployee> Employees { get; }
        DbSet<LMLeaveHistory> LeaveHistories { get; }
    }
}
