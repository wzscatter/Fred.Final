using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Final.Core.Models.Request
{
    public class EmployeeRegisterRequestModel
    {



        [Required(ErrorMessage = "Name cannot be empty")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "password cannot be empty")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} character", MinimumLength = 8)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[#$^+=!*()@%&]).{8,}$")]
        public string Password { get; set; }


        [StringLength(100)]
        public string Designation {get; set; }
    }
}
