using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuestApp.Models;
using QuestApp.Data;

namespace QuestApp.Services
{
    public class TreatmentRepository : ITreatmentRepository
    {
        private readonly AppDbContext _appDbContext;
       
        public TreatmentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
     

      

        public Booking Get(int id)
        {
            return _appDbContext.Bookings.FirstOrDefault(r => r.BookingId == id);
        }
      
    }
}
