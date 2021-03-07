using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Final.Core.Models.Request
{
    public class InteractionCreateRequestModel
    {
        [Required(ErrorMessage = "ClientId cannot be empty")]
        public int ClientId { get; set; }

        [Required(ErrorMessage = "EmployeeId cannot be empty")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Interaction type cannot be empty")]
        public char Intype { get; set; }



        [DataType(DataType.Date)]
        public DateTime IntDate { get; set; }


        [StringLength(500)]
        public string Remarks { get; set; }
    }
}
