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
    public class TourController : Controller
    {
        /*private ExploreCaliforniaContext db = new ExploreCaliforniaContext();*/
        private TourGateway tourGateway = new TourGateway();

        // GET: Tour
        public ActionResult Index(string sortItem="NO")
        {
            if(sortItem.Equals("YES"))
            {
                //Populate and return the Ascending order of the Tour dataset
                return View(tourGateway.SelectAll(true));
            }
            return View(tourGateway.SelectAll());
            
        }

        // GET: Tour/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = tourGateway.SelectById(id);
            //Tour tour = db.Tours.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }

        // GET: Tour/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tour/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Length,Price,Rating,IncludesMeals")] Tour tour)
        {
            if (ModelState.IsValid)
            {
                tourGateway.Insert(tour);
                /*db.Tours.Add(tour);
                db.SaveChanges();*/
                return RedirectToAction("Index");
            }

            return View(tour);
        }

        // GET: Tour/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = tourGateway.SelectById(id);
            //Tour tour = db.Tours.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }

        // POST: Tour/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Length,Price,Rating,IncludesMeals")] Tour tour)
        {
            if (ModelState.IsValid)
            {
                tourGateway.Update(tour);
                /*db.Entry(tour).State = EntityState.Modified;
                db.SaveChanges();*/
                return RedirectToAction("Index");
            }
            return View(tour);
        }

        // GET: Tour/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = tourGateway.SelectById(id);
            //Tour tour = db.Tours.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }

        // POST: Tour/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tourGateway.Delete(id);
            /*Tour tour = db.Tours.Find(id);
            db.Tours.Remove(tour);
            db.SaveChanges();*/
            return RedirectToAction("Index");
        }
    }
}
