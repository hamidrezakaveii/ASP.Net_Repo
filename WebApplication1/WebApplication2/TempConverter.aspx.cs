using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class TempConverter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void ButtonConvert_Click1(object sender, EventArgs e)
        {
            //code de convertion
            decimal USAmount = Decimal.Parse(value.Text);

            decimal euroAmount = USAmount * 0.85M;


            resultat.Text = euroAmount.ToString() + "$ CAN.";
            //resultat.Text = disb;

            res.InnerText = euroAmount.ToString() + "$ CAN.";
        }
    }
}