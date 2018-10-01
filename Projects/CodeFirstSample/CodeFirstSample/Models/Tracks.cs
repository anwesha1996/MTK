using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstSample.Models
{
    [Table("tbTrackDetails")]
    public class Tracks
    {
        [Key]
        public int Track_ID { get; set; }
        public string Track_Name { get; set; }

        public string RoomAllocated { get; set; }

        public string LeadName { get; set; }
    }
}