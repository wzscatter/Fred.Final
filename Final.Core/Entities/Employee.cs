using System;
using System.Collections.Generic;
using System.Text;

namespace Final.Core.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Designation { get; set; }
        public ICollection<Interaction> Interactions { get; set; }
    }
}
