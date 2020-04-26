﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Model
{
    public class RegistrationModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "UserName Require"), MinLength(6),MaxLength(20)]
        public string UserName { get; set; }        
        [Required(ErrorMessage = "Passworrd Require"), MinLength(6), MaxLength(20)]
        public string Password { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Role { get; set; }
        public string Gender { get; set; }
        [Phone]
        public string PhoneNo { get; set; }       
    }
}
