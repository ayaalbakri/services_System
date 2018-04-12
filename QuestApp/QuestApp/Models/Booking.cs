using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuestApp.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        [Display(Name = "Booking Name")]
        [Required]
        [DataType(DataType.Text)]
         [ReadOnly(true)]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Mobile: ")]
        public int Mobile { get; set; }
        [Display(Name = "Notes: ")]
        public string Note { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email: ")]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date: ")]
        public DateTime BookedDate { get; set; }
        public bool IsDeleted { get; set; }
        public int treatmentId { get; set; }

        public LU_Treatment Treatment { get; set; }
        public int TimeSlotId { get; set; }
        public LU_TimeSlot TimeSlot { get; set; }


    }
}