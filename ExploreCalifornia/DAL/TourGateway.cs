using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

using ExploreCalifornia.Models;

namespace ExploreCalifornia.DAL
{
    public class TourGateway:DataGateway<Tour>
    {
        //Overloading the SelectAll() Instance Method
        public IEnumerable<Tour> SelectAll(bool orderAsc)
        {
            if(orderAsc)
            {
                return this.data.OrderBy(tour => tour.Price);
            }
            return this.data;
        }
        //All TourGateway Instance method will be invoked using the DataGateway<Tour> SuperClass
        //inherited default instance method

    }
}