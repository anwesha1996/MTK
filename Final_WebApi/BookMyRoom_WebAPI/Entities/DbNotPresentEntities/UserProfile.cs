using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UserProfileName
    {
        public int userId { get; set; }
        public string fName { get; set; }
        public string profilepic { get; set; }
    }

    public class UserProfilePhone
    {
        public int userId { get; set; }
        public string mobileNo { get; set; }
    }


    public class UserProfilePasssword
    {
        public int userId { get; set; }
        public string oldPass { get; set; }
        public string newPass { get; set; }
    }

}
