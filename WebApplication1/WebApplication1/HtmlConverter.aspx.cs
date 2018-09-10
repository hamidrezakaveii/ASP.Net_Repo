using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class HtmlConverter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void convert_US_CAN(object sender, EventArgs e)
        {
            decimal USAmount = Decimal.Parse(us.Value);

            decimal euroAmount = USAmount * 0.85M;


            can.Value = euroAmount.ToString() + "$ CAN.";
            can.Disabled = true;

            cadDiv.InnerHtml = euroAmount.ToString() + "$ CAN.";
        }
    }
}