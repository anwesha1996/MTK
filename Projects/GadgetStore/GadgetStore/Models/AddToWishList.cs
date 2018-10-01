using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GadgetStore.Models
{
    public class AddToWishList
    {
        [Key]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int WishListID { get; set; }

        [ForeignKey("Gadget")]
        public int GadgeID { get; set; }
        
        public virtual Gadget Gadget { get; set; }

    }
}