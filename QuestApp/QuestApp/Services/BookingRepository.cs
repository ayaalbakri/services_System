using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuestApp.Models;
using QuestApp.Data;

namespace QuestApp.Services
{
    public class BookingRepository : IBookingRepository
    {
        private readonly AppDbContext _appDbContext;
       
        public BookingRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        

        public Booking Add(Booking book)
        {
            _appDbContext.Add(book);
            _appDbContext.SaveChanges();
            Console.WriteLine("  [Fact]napodiasddad", _appDbContext);
            return book;
        }

        public void Delete(int id)
        {
            var book = _appDbContext.Bookings.SingleOrDefault(m => m.BookingId == id);
            book.IsDeleted = true;
            _appDbContext.Bookings.Update(book);
            _appDbContext.SaveChanges();
        }

        public Booking Get(int id)
        {
            return _appDbContext.Bookings.FirstOrDefault(r => r.BookingId == id);
        }
        public Booking Edit(int id, Booking book)
        {
            var obj = _appDbContext.Bookings.FirstOrDefault(r => r.BookingId == id);
           
            obj.Note = book.Note;
            //obj.BookedDate = book.BookedDate;
            obj.TimeSlotId = book.TimeSlotId;
            obj.treatmentId = book.treatmentId;


            _appDbContext.Bookings.Update(obj);
            _appDbContext.SaveChanges();

            return book;

        }

        public IEnumerable<Booking> GetAll()
        {
            return _appDbContext.Bookings.ToList();
        }
    }
}
