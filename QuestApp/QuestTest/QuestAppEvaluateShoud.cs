using QuestApp.Models;
using System;
using Xunit;

namespace QuestTest
{
    public class QuestAppEvaluateShoud
    {
        [Fact]
        public void AcceptAddingBook()
        {
            var sut = new QuestAppEvaluateShoud();
            var Booking = new Booking { BookingId = 25478, Email = "AyaGhaleb@gmail.com",IsDeleted=false,Mobile=0792964089,Name="Aya",Note="",TimeSlotId=3,treatmentId=10 };
            
        }
        [Fact]
        public void FaildAddingBook()
        {
            var sut = new QuestAppEvaluateShoud();
            var Booking = new Booking { BookingId = 25478, Email = "AyaGhaleb", IsDeleted = false, Mobile = 0792964089, Name = "Aya", Note = "", TimeSlotId = 3, treatmentId = 10 };

        }
        [Fact]
        public void FaildEmailNewBook()
        {
            var sut = new QuestAppEvaluateShoud();
           var NewBooking = new Booking { BookingId = 2, Email = "AyaGhaleb", IsDeleted = false, Mobile = 0792964089, Name = "Aya", Note = "", TimeSlotId = 3, treatmentId = 10 };
            bool IsEmail = NewBooking.Email.Contains("@");
            Assert.True(IsEmail);
        }
        [Fact]
        public void FaildDateNewBook()
        {
          
            var sut = new QuestAppEvaluateShoud();
            var NewBooking = new Booking { BookingId = 2, Email = "AyaGhaleb", IsDeleted = false, Mobile = 0792964089, Name = "Aya", Note = "", TimeSlotId = 3, treatmentId = 10, BookedDate = new DateTime(3009, 8, 1, 0, 0, 0) };
        
            bool IsValidDate = NewBooking.BookedDate <= DateTime.Now.Date;
            Console.WriteLine("************************************", DateTime.Now.Date);
            Assert.True(IsValidDate);
        }
        [Fact]
        public void PassdDateNewBook()
        {

            var sut = new QuestAppEvaluateShoud();
            var NewBooking = new Booking { BookingId = 2, Email = "AyaGhaleb", IsDeleted = false, Mobile = 0792964089, Name = "Aya", Note = "", TimeSlotId = 3, treatmentId = 10, BookedDate = new DateTime(2017, 3, 1, 0, 0, 0) };

            bool IsValidDate = NewBooking.BookedDate <= DateTime.Now.Date;
            Assert.True(IsValidDate);
        }
        [Fact]
        public void FaildNameNewBook()
        {

            var sut = new QuestAppEvaluateShoud();
            var NewBooking = new Booking { BookingId = 2, Email = "AyaGhaleb", IsDeleted = false, Mobile = 0792964089, Name = "", Note = "", TimeSlotId = 3, treatmentId = 10, BookedDate = new DateTime(3009, 8, 1, 0, 0, 0) };

            bool IsValidDate = NewBooking.Name.Length  >1;
            Assert.True(IsValidDate);
        }
        [Fact]
        public void PassNameNewBook()
        {

            var sut = new QuestAppEvaluateShoud();
            var NewBooking = new Booking { BookingId = 2, Email = "AyaGhaleb", IsDeleted = false, Mobile = 0792964089, Name = "Aya", Note = "", TimeSlotId = 3, treatmentId = 10, BookedDate = new DateTime(3009, 8, 1, 0, 0, 0) };

            bool IsValidName = NewBooking.Name.Length > 1;
            Assert.True(IsValidName);
        }
        [Fact]
        public void PassSlotTimeIDNewBook()
        {

            var sut = new QuestAppEvaluateShoud();
            var NewBooking = new Booking { BookingId = 2, Email = "AyaGhaleb", IsDeleted = false, Mobile = 0792964089, Name = "Aya", Note = "", TimeSlotId = 3, treatmentId = 10, BookedDate = new DateTime(3009, 8, 1, 0, 0, 0) };

            bool IsValidSlotTimeID =NewBooking.TimeSlotId>0;
            Assert.True(IsValidSlotTimeID);
        }
        [Fact]
        public void FaildSlotTimeIDNewBook()
        {

            var sut = new QuestAppEvaluateShoud();
            var NewBooking = new Booking { BookingId = 2, Email = "AyaGhaleb", IsDeleted = false, Mobile = 0792964089, Name = "Aya", Note = "",  treatmentId = 10, BookedDate = new DateTime(3009, 8, 1, 0, 0, 0) };

            bool IsValidSlotTimeID = NewBooking.TimeSlotId > 0;
            Assert.True(IsValidSlotTimeID);
        }
    }
}
