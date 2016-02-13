using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

using ExploreCalifornia.Models;

namespace ExploreCalifornia.DAL
{
    public class TourGateway:DataGateway<Tour>
    {
        //All TourGateway Instance method will be invoked using the DataGateway<Tour> SuperClass
        //inherited default instance method
    }
}