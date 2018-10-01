using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace q3
{

	class payee
	{
		public string address { get; set; }
		public string city { get; set; }
		public string state { get; set; }
		public string country { get; set; }
		public string mobno { get; set; }
		public string emailid { get; set; }



		public void setaddress(string address)
		{
			this.address = address;
		}
		public string getaddress()
		{
			return address;
		}
		public void setcity(string city)
		{
			this.city = city;
		}
		public string getcity()
		{
			return city;
		}
		public void setstate(string state)
		{
			this.state= state;
		}
		public string getstate()
		{
			return state;
		}

		public void setcountry(string country)
		{
			this.country = country;
		}
		public string getcountry()
		{
			return country;
		}
		public void setmobno(string mobno)
		{
			this.mobno = mobno;
		}
		public string getmobno()
		{
			return mobno;
		}
		public void setemail(string emailid)
		{
			this.emailid = emailid;
		}
		public string getemail()
		{
			return emailid;
		}



	}


	class PayeeMgr
	{
		public payee storeData(payee p)
		{
			p.setaddress("sahid nagar");
			p.setcity("bbsr");
			p.setstate("odusha");
			p.setcountry("india");
			p.setmobno("998907654");
			p.setemail("mohanty@gmail.com");

			return p;
		}
		public void showData(payee p)
		{
			Console.WriteLine(p.getaddress());
			Console.WriteLine(p.getcity());
			Console.WriteLine(p.getstate());
			Console.WriteLine(p.getcountry());
			Console.WriteLine(p.getmobno());
			Console.WriteLine(p.getemail());
		}
	}
	public class Test
	{
		public static void Main()
		{
			payee p1 = new payee();
			PayeeMgr p2 = new PayeeMgr();
			p1 = p2.storeData(p1);
			p2.showData(p1);
			Console.ReadKey();
		}
	}
}


