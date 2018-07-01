using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ImdbMVC2.Models
{
    public class Actors
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "Actor Name")]
        public string name { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string sex { get; set; }

        
        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime dob { get; set; }
        public string bio { get; set; }

        public ICollection<Movies> Movies { get; set; }
    }
}