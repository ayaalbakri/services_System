using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuestApp.Data;
using QuestApp.Models;
using QuestApp.Services;
using QuestApp.ViewModels;

namespace QuestApp.Controllers
{

    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        
        private readonly IBookingRepository _bookingRepository;
        private readonly ITreatmentRepository _TreatmentRepository;

        private AppDbContext _appDbContext;
        public EditViewModel EditViewModel = new EditViewModel();

        public HomeController(IBookingRepository bookingRepository,AppDbContext appDbContext)
        {
            this._bookingRepository = bookingRepository;
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Booking model,LU_Treatment models)
        {
            var obj = new Booking();
            obj.Name = model.Name;
            obj.Mobile = model.Mobile;
            obj.Email = model.Email;
            obj.Note = model.Note;
            obj.BookedDate = model.BookedDate;
            _bookingRepository.Add(obj);
            return View();
        }


        
        public IActionResult Create()
        {
            List<LU_Treatment> li = new List<LU_Treatment>();
            li = _appDbContext.Treatments.ToList();
            ViewBag.ListOfItems = li;
            List<LU_TimeSlot> lii = new List<LU_TimeSlot>();
            lii = _appDbContext.TimeSlots.ToList();
            ViewBag.ListOfTimes = lii;

            return View();
        }
        [HttpPost("AddBook")]
        public IActionResult Create([FromBody] Booking model)
        {
            var x = model;
           
            if (ModelState.IsValid)
            {
                var obj = new Booking();
                obj.Name = model.Name;
                obj.Mobile = model.Mobile;
                obj.Email = model.Email;
                obj.Note = model.Note;
                obj.BookedDate = model.BookedDate;
                _bookingRepository.Add(model);
                return Ok(model);
            }
            else {
                return NotFound();
            }
        }
        [Authorize]
        //GetAll Bookings
        public IActionResult Data()
        {
            var model = _bookingRepository.GetAll();
            return View(model);
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        [Authorize]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [HttpGet]
        public JsonResult Inf()
        {
          
                var model = _bookingRepository.GetAll();
            foreach (var obj in model)
            {
                var treatId = obj.treatmentId;
                //obj.Treatment = new LU_Treatment();
                obj.Treatment = _appDbContext.Treatments.Single(e => e.id == treatId);
                obj.TimeSlot = _appDbContext.TimeSlots.Single(e => e.Id == obj.TimeSlotId);
            }

            return Json(model);

        }


        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
           var model =  _bookingRepository.Get(id);
            //var treatId = model.treatmentId;
            model.Treatment = _appDbContext.Treatments.Single(e => e.id == model.treatmentId);
            model.TimeSlot = _appDbContext.TimeSlots.Single(e => e.Id == model.TimeSlotId);
            return new ObjectResult(model);
        }
        
        [HttpPost("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _bookingRepository.Delete(id);
            return Ok();

        }

        public IActionResult DeletePArtialView(int id)
        {
            return View();

        }

        //[HttpPost("{id}")]
        //public IActionResult Edit(int id, [FromBody] Booking book)
        //{
        //    List<LU_Treatment> li = new List<LU_Treatment>();
        //    li = _appDbContext.Treatments.ToList();
        //    ViewBag.ListOfItems = li;
        //    List<LU_TimeSlot> lii = new List<LU_TimeSlot>();
        //    lii = _appDbContext.TimeSlots.ToList();
        //    ViewBag.ListOfTimes = lii;
        //    var model = _bookingRepository.Get(id);
        //    EditViewModel.Name = model.Name;
        //    EditViewModel.Note = model.Note;
        //    EditViewModel.Mobile = model.Mobile;
        //    EditViewModel.Email = model.Email;
        //    EditViewModel.BookedDate = model.BookedDate;
        //    EditViewModel.BookingId = model.BookingId;
        //    EditViewModel.TimeSlotId = model.TimeSlotId;
        //    EditViewModel.treatmentId = model.treatmentId;
        //    return Ok(EditViewModel);
        //}

        [HttpPut("{id}")]
        public IActionResult EditUser(int id, [FromBody] Booking book)
        {
            var model = _bookingRepository.Edit(id, book);
            EditViewModel.Name = model.Name;
            EditViewModel.Note = model.Note;
            EditViewModel.Mobile = model.Mobile;
            EditViewModel.Email = model.Email;
            EditViewModel.BookedDate = model.BookedDate;
            return Ok(model);
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
