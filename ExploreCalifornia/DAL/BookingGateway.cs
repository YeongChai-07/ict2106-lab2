using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

using ExploreCalifornia.Models;

namespace ExploreCalifornia.DAL
{
    public class BookingGateway:DataGateway<Booking>
    {
        //All BookingGateway Instance method will be invoked using the DataGateway<Booking> SuperClass
        //inherited default instance method
    }
}