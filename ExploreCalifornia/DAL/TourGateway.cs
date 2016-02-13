using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

using ExploreCalifornia.Models;

namespace ExploreCalifornia.DAL
{
    public class TourGateway:ITourGateway
    {
        internal ExploreCaliforniaContext db = new ExploreCaliforniaContext();

        public IEnumerable<Tour> SelectAll()
        {
            return db.Tours;
        }

        public Tour SelectById(int? id)
        {
            return db.Tours.Find(id);
        }

        public void Insert(Tour tour)
        {
            db.Tours.Add(tour);
            this.Save();
        }

        public void Update(Tour tour)
        {
            db.Entry(tour).State = EntityState.Modified;
            //Save Changes to commit to the Database
            this.Save();
        }

        public Tour Delete(int? id)
        {
            Tour tour = this.SelectById(id);
            db.Tours.Remove(tour);
            this.Save();
            return tour;
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}