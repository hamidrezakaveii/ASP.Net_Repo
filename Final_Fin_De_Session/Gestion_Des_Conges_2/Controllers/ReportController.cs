using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Gestion_Des_Conges_2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ReportController : ApiController
    {
        UserContextEntities context = new UserContextEntities();

        [Route("api/GetEmployees")]
        public IQueryable<LMEmployee> GetEmployees()
        {
            var listEmployee = context.LMEmployees.Select(s => s);


            return listEmployee;

        }


    }
}
