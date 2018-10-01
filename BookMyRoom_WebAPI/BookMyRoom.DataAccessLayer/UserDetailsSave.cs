using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMyRoom.Entitites;

namespace BookMyRoom.DataAccessLayer
{
    public class UserDetailsSave
    {
		private readonly DbContext.UserDetailsDBContext  dbContext = new DbContext.UserDetailsDBContext();


		public int SaveUserDetails(UserDetails userDetails)
		{
			//try
			//{
			//	dbContext.userDetails.Add(userDetails);

			//	this.dbContext.SaveChanges();
			//}

			//catch (Exception ex)
			//{
			//	Console.WriteLine(ex.Message);
			//}

			try
			{

				dbContext.userDetails.Add(userDetails);
				this.dbContext.SaveChanges();
			}
			catch (Exception e)
			{
				return 0;
			}
			return 1;
		}
	}
}
