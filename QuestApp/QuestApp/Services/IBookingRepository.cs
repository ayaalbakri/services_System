using QuestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestApp.Services
{
    public interface IBookingRepository
    {
        IEnumerable<Booking> GetAll();
        Booking Get(int id);

        Booking Add(Booking book);
        void Delete(int id);
         Booking Edit(int id, Booking book);
    }
}
