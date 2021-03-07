using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Final.Core.Models.Request
{
    public class ClientRegisterRequestModel
    {
        [Required(ErrorMessage = "Phone cannot be empty")]
        [StringLength(30)]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }


        [Required(ErrorMessage = "Name cannot be empty")]
        [StringLength(50)]
        public string Name { get; set; }
       

        [DataType(DataType.Date)]
        public DateTime AddedOn { get; set; }

        [StringLength(100)]
        public string Address { get; set; }


        [Required]
        public int AddedBy { get; set; }
    }
}
