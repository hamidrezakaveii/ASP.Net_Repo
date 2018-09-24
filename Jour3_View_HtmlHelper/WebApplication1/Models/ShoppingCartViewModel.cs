using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jour3_View.Models
{
    public class ShoppingCartViewModel
    {
        public IEnumerable<Product> Products { get; set; }

        public decimal CartTotal { get; set; }

        public string Message { get; set; }


    }
}