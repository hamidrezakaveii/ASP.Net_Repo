using Jour6_PreparationExamen.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jour6_PreparationExamen.Models
{
    public class Vote
    {

        public string Nom { get; set; }

        public IEnumerable<Activity> Activity { get { return Utils.GetInstance().GetListeActivity(); } set { }}


    }


}