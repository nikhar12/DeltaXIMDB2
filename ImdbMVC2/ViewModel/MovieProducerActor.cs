using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImdbMVC2.Models;
using System.ComponentModel.DataAnnotations;

namespace ImdbMVC2.ViewModel
{
    public class MovieProducerActor
    {
        [Required]
        public Movies Movies { get; set; }
        [Display(Name ="All Producers")]

        [Required]
        public List<Producer> lProducer { get; set; }
        [Required]
        public List<int> selectedActorID { get; set; }

        [Required]
        [Display(Name = "All Actors")]
        public ICollection<Actors> lActors { get; set; }
        [Required]
        public int selectedProducerID { get; set; }
    }
}