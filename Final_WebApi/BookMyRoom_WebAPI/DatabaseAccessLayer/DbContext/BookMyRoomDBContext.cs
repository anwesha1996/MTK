using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.DbContext
{
    public class BookMyRoomDBContext : System.Data.Entity.DbContext
    {
        public BookMyRoomDBContext() : base("name=BookMyRoom")
        {

        }
        public DbSet<HotelDetails> hotelDetails { get; set; }
        public DbSet<RoomDetails> roomHotel { get; set; }
        public DbSet<CityDetails> cityDetails { get; set; }
        public DbSet<HotelCityMapping> hotelCityMap { get; set; }
        public DbSet<RoomBookingDetails> roomBookingDetails { get; set; }
        public DbSet<ConfirmBooking> booking { get; set; }
        public DbSet<UserDetails> userDetails { get; set; }
        public DbSet<FavouriteDetails> favouriteDetails { get; set; }

        public DbSet<Review> reviews { get; set; }
    }
}
