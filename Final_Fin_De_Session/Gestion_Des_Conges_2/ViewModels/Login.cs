using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;

namespace Gestion_Des_Conges_2.Models
{
    public class Login
    {

        [Display(Name = "Email address:")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        public string Password { get; set; }

    }
}