using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreMVC.Models
{
    public class Mind
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string MID { get; set; }
        public string Name { get; set; }
        public string Track { get; set; }
    }
}