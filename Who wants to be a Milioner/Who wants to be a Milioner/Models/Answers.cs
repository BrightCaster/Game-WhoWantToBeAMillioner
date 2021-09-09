using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Who_wants_to_be_a_Milioner.Models
{
    public class Answers
    { 
        [Key]
        public string Id { get; set; }
        public string answers { get; set; }
        public string Bool { get; set; }
        public string key { get; set; }
    }
}
