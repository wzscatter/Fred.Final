using System;
using System.Collections.Generic;
using System.Text;

namespace Final.Core.Entities
{
    public class Interaction
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int EmployeeId { get; set; }
        public char InType { get; set; }
        public DateTime IntDate { get; set; }
        public string Remarks { get; set; }

        public Client Client { get; set; }
        public Employee Employee { get; set; }
    }
}
