using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Model
{
    public class LoginModel
    {
        [Required (ErrorMessage ="UserName Require")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password Require")]
        public string Password { get; set; }
    }
}
