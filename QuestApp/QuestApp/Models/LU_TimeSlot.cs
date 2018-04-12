using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuestApp.Models
{
    public class LU_TimeSlot
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Time Slot Title")]
        public int TimeSlotTitle { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
