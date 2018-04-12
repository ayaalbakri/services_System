using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuestApp.Models
{
    public class LU_Treatment
    {
        public int id { get; set; }
        [Display(Name = "Title: ")]
        public string TreatmentTitle { get; set; }
        public string TreatmentDescription { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
//public enum TreatmentOption
//{
//    pain,
//    headech
//}
