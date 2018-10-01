using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ex_handling
{

	class user
	{
		public long userid;
		public string password;

	}

	class usermgr
	{
		public user create(user us)
		{
			Console.WriteLine("enter userid");
			us.userid = Convert.ToInt64(Console.ReadLine());
			try
			{
				if (Math.Ceiling(Math.Log10(us.userid)) < 5)
				{
					throw new InvalidIdException();

				}


			}

			catch (InvalidIdException e)
			{
				Console.WriteLine("wrong id");
				Console.ReadKey();
				Environment.Exit(0);
			}


			Console.WriteLine("enter password");
			us.password = Console.ReadLine();


			try
			{

				if (!Regex.IsMatch(us.password, @"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9]).*"))
				{
					throw new InvalidpasswordException();
				}


			}
			catch (InvalidpasswordException e)
			{
				Console.WriteLine("wrong password");
				Console.ReadKey();
				Environment.Exit(0);

			}
			display(us);
			return us;

		}


		public user display(user us)
		{
			Console.WriteLine(us.userid);
			Console.WriteLine(us.password);

			return us;


		}
	}
	class InvalidIdException : Exception

	{
		public InvalidIdException()
		{


		}
	}

	class InvalidpasswordException : Exception
	{
		public InvalidpasswordException()
		{

		}
	}





	public class Program
	{
		static void Main(string[] args)
		{
			user us = new user();
			usermgr mg = new usermgr();
			mg.create(us);

			Console.ReadKey();
		}
	}
}






	


