using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingInChetu.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public String Contactno { get; set; }
        public String EmailId { get; set; }
        public String Address { get; set; }
        public Location Location { get; set; }

    }
}
