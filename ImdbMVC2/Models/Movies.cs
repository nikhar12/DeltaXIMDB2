using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ImdbMVC2.Models
{
    public class Movies
    {
        public Movies()
        {
            Actors = new List<Actors>();
            producer = new Producer();
        }
        public int id { get; set; }

        [Required]
        [Display(Name ="Movie Name")]

        public string name { get; set; }

        [Required]
        [Display(Name = "Year of Release")]
        public int yor { get; set; }

        
        [Display(Name = "Plot")]
        [StringLength(300, ErrorMessage = "Plot should be within 300 chars")]
        public string plot { get; set; }

        
        public byte[] poster { get; set; }

        public string imgurl { get; set; }
        public ICollection<Actors> Actors { get; set; }
        public Producer producer { get; set; }

    }
}