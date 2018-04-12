using QuestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestApp.ViewModels
{
    public class BookingListViewModel
    {
        public List<Booking> Bookings { get; set; }

        public IEnumerable<LU_Treatment> Treatments { get; set; }
    }
}
