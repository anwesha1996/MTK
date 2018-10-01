using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UserDetailsForAdmin
    {
        public int userID { get; set; }
        public string userFullName { get; set; }
        public string userEmail { get; set; }
        public string  userPhone { get; set; }
        public int rewardPoints { get; set; }
    }
}
