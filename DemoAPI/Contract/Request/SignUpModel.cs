using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Contract.Request
{
    public class SignUpModel
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please enter your email")]
        public string Email { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter your password")]
        public string Pasword { get; set; }
        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Please confirm your password")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Please Choose Gender")]
        public string Gender { get; set; }
    }
    
       
}
