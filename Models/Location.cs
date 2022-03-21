using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingInChetu.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        public String City { get; set; }
        public String Description { get; set; }
    }
}
