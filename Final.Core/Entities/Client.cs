using System;
using System.Collections.Generic;
using System.Text;

namespace Final.Core.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phones { get; set; }
        public string Address { get; set; }
        public DateTime? AddedOn { get; set; }
        public ICollection<Interaction> Interactions { get; set; }
        
    }
}
