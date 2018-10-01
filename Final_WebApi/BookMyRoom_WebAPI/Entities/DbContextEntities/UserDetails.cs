using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UserDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userId { get; set; }
        public string name { get; set; }
        [Index(IsUnique = true)]
        [MaxLength(40)]
        public string email { get; set; }
        public string password { get; set; }

        [Index(IsUnique = true)]
        [MaxLength(450)]
        public string userName { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        public string mobileNo { get; set; }
        public int rewardPoints { get; set; }
        public string profilepic { get; set; }
    }
}
