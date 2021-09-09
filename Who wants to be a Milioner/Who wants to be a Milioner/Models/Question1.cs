using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Who_wants_to_be_a_Milioner.Models
{
    public class Question1
    {
        [Key]
        public string Id { get; set; }
        public string Question { get; set; }
    }
}
