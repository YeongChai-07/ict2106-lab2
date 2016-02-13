using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ExploreCalifornia.DAL
{
    public class DataGateway<T>:IDataGateway<T> where T:class
    {
        internal ExploreCaliforniaContext db = new ExploreCaliforniaContext();
        internal DbSet<T> data = null;

        public DataGateway()
        {
            this.data = db.Set<T>();
        }
        public IEnumerable<T> SelectAll()
        {
            return data;
        }
        public T SelectById(int? id)
        {
            return data.Find(id);
        }
        public void Insert(T obj)
        {
            data.Add(obj);
            this.Save();
        }
        public void Update(T obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            //Save Changes to commit to the Database
            this.Save();
        }
        public T Delete(int? id)
        {
            T obj = this.SelectById(id);
            data.Remove(obj);
            this.Save();
            return obj;
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}