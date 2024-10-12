using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;
using System.Resources;
using TheMaxieInn.Data;
using TheMaxieInn.Models;
using TheMaxieInn.ViewModels;

namespace TheMaxieInn.Controllers
{
    public class ReservationController : Controller
    {
        private readonly AppDbContext _context;
        public ReservationController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult CreateReservation()
        {
            var model = new DogReservationViewModel
            {
                CheckInDate = DateTime.Now,
                CheckOutDate = DateTime.Now.AddDays(1)
            };

            return View(new DogReservationViewModel());
        }

        [HttpPost]
        public IActionResult CreateReservation(DogReservationViewModel reservationViewModel) 
        {
            if (ModelState.IsValid) 
            {
                var reservation = new DogReservation
                {
                    CheckInDate = reservationViewModel.CheckInDate,
                    CheckOutDate = reservationViewModel.CheckOutDate
                };

                _context.DogReservation.Add(reservation);
                _context.SaveChanges();

                return RedirectToAction("AddDogOwner", new { reservationId = reservation.ReservationId});
            }
            return View(reservationViewModel);
        }

        [HttpGet]
        public IActionResult AddDogOwner(int reservationId)
        {
            ViewBag.ReservationId = reservationId;
            return View(new DogOwnerViewModel());
        }

        [HttpPost]
        public IActionResult AddDogOwner(DogOwnerViewModel ownerViewModel, int reservationId)
        {
            if (ModelState.IsValid)
            {
                var owner = new DogOwner
                {
                    OwnerName = ownerViewModel.OwnerName,
                    Address = ownerViewModel.Address,
                    City = ownerViewModel.City,
                    State = ownerViewModel.State,
                    ZipCode = ownerViewModel.ZipCode,
                    Email = ownerViewModel.Email,
                    PhoneNumber = ownerViewModel.PhoneNumber,
                    ReservationId = reservationId
                };

                _context.DogOwner.Add(owner);
                _context.SaveChanges();

                return RedirectToAction("AddDogInformation", new { reservationId });
            }
            ViewBag.ReservationId = reservationId;
            return View(ownerViewModel);
        }

        [HttpGet]
        public IActionResult AddDogInformation(int reservationId) 
        {
            ViewBag.ReservationId = reservationId;
            return View(new DogInformationViewModel());
        }

        [HttpPost]
        public IActionResult AddDogInformation(DogInformationViewModel infoViewModel, int reservationId)
        {
            if (ModelState.IsValid)
            {
                var dogInfo = new DogInformation
                {
                    DogName = infoViewModel.DogName,
                    Breed = infoViewModel.Breed,
                    Sex = infoViewModel.Sex,
                    DateOfBirth = infoViewModel.DateOfBirth,
                    SpayedOrNeutered = infoViewModel.SpayedOrNeutered,
                    Vaccinated = infoViewModel.Vaccinated,
                    SpecialAccommodation = infoViewModel.SpecialAccommodation,
                    ReservationId = reservationId
                };

                _context.DogInformation.Add(dogInfo);
                _context.SaveChanges();

                return RedirectToAction("ReservationConfirmation", new { reservationId});
            }

            ViewBag.ReservationId = reservationId;
            return View(infoViewModel);
        }

        [HttpGet]
        public IActionResult ReservationConfirmation(int reservationId)
        {
            var reservation = _context.DogReservation.Find(reservationId);
            var owner = _context.DogOwner.FirstOrDefault(o => o.ReservationId == reservationId);
            var dog = _context.DogInformation.FirstOrDefault(i => i.ReservationId == reservationId);

            var confirmationViewModel = new ReservationConfirmationViewModel
            {
                OwnerName = owner.OwnerName,
                DogName = dog.DogName,
                CheckInDate = reservation.CheckInDate,
                CheckOutDate = reservation.CheckOutDate
            };                 

            return View(confirmationViewModel);
        }

    }
}