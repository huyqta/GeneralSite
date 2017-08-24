using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AdminSite.Models
{
    public class AccountModel
    {
        [Display(Name = "Username")]
        [DataType(DataType.Text)]
        public string Username { get; set; }

		[Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
