using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExploreCalifornia.DAL;
using ExploreCalifornia.Models;

namespace ExploreCalifornia.Controllers
{
    public class BookingController : Controller
    {
        //private ExploreCaliforniaContext db = new ExploreCaliforniaContext();
        private BookingGateway bookingGateway = new BookingGateway();

        // GET: Booking
        public ActionResult Index()
        {
            return View(bookingGateway.SelectAll());
        }

        // GET: Booking/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = bookingGateway.SelectById(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Booking/Create/5
        public ActionResult Create(int id, string tourName)
        {
            Booking myBooking = new Booking();
            myBooking.TourID = id;
            myBooking.TourName = tourName;

            return View(myBooking);
        }

        // POST: Booking/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookingID,TourID,TourName,ClientID,DepartureDate,NumberofPeople,FullName,Email,ContactNo,SpecialRequest")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                bookingGateway.Insert(booking);
                return RedirectToAction("Index");
            }

            return View(booking);
        }

        // GET: Booking/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = bookingGateway.SelectById(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Booking/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingID,TourID,TourName,ClientID,DepartureDate,NumberofPeople,FullName,Email,ContactNo,SpecialRequest")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                bookingGateway.Update(booking);
                return RedirectToAction("Index");
            }
            return View(booking);
        }

        // GET: Booking/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = bookingGateway.SelectById(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Booking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bookingGateway.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
