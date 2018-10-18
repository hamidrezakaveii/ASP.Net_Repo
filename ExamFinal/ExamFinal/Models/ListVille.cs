using ExamFinal.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamFinal.Models
{
    public class ListVille
    {

        public IEnumerable<Ville> ListDeVille { get { return Utils.GetInstance().GetListeVille(); } set { } }

    }
}