using QuestApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuestApp.ViewModels
{
    public class EditViewModel
    {
        public int BookingId { get; set; }
        [Display(Name = "Booking Name")]
        [Required]
        [DataType(DataType.Text)]
        
        public string Name { get; set; }
        [Required]
        [ReadOnly(true)]
        [Display(Name = "Mobile: ")]
        public int Mobile { get; set; }
        [ReadOnly(true)]
        [Display(Name = "Notes: ")]
        
        public string Note { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email: ")]
        [ReadOnly(true)]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date: ")]
        [ReadOnly(true)]
        public DateTime BookedDate { get; set; }
        public bool IsDeleted { get; set; }
        public int treatmentId { get; set; }
        public LU_Treatment Treatment { get; set; }
        
        public int TimeSlotId { get; set; }
        [ReadOnly(true)]
        public LU_TimeSlot TimeSlot { get; set; }



}
}
