namespace Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;

    namespace MVC.Models
    {
        public class SearchCriteria
        {
            public int hotelId { get; set; }
            public string hotelName { get; set; }
            public string hotelRoomType { get; set; }
            public DateTime hotelFromDate { get; set; }
            public DateTime hotelToDate { get; set; }
            public decimal hotelPrice { get; set; }
            public string hotelCity { get; set; }
            public int hotelRating { get; set; }
            public string hotelUrl { get; set; }


        }
    }
}
