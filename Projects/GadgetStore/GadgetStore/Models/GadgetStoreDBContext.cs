using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GadgetStore.Models
{
    public class GadgetStoreDBContext : DbContext
    {
        public GadgetStoreDBContext() : base("name = GadgetStore")
        {
                
        }

        public DbSet<Gadget> Gadgets { get; set; }
        public DbSet<AddToWishList> AddToWishlists { get; set; }
    }
}