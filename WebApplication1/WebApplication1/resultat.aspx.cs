﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Page.IsPostBack   ??

            HttpContext _context = HttpContext.Current;

            res.InnerHtml = "le montant " + Request.Form["us"] + " veut " + _context.Items["can"] + " $ CAN.";
        }
    }
}