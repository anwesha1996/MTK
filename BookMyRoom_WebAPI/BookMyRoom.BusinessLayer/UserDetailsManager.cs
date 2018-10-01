using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMyRoom.DataAccessLayer;
using BookMyRoom.Entitites;


namespace BookMyRoom.BusinessLayer
{
    public class UserDetailsManager
    {
		private readonly UserDetailsSave saveUserDetails = new UserDetailsSave();
		public int SaveUserDetail(UserDetails userDetails)
		{

			int result=saveUserDetails.SaveUserDetails(userDetails);
			return result;
		}

	
	}
}
