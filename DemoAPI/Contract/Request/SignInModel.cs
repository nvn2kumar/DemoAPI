using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Contract.Request
{
    public class SignInModel
    {
        [Display(Name ="Email")]
        [Required(ErrorMessage ="Please enter your email")]
        public string Email { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter your password")]
        public string Pasword { get; set; }
    }
}
