using System;
using System.Collections.Generic;
using System.Data.Entity;
using ExploreCalifornia.Models;

namespace ExploreCalifornia.DAL
{
    public class ExploreCaliforniaContext : DbContext
    {
        public ExploreCaliforniaContext() : base("ExploreCaliforniaDB")
        {

        }
        public DbSet<Tour> Tours { get; set; }
    }
}