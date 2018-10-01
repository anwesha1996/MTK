using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using WebApidemo.Models;

namespace WebApidemo.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			IEnumerable<Products> ObjCustomer = null;
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("http://localhost:52109/");
			// Add an Accept header for JSON format.
			client.DefaultRequestHeaders.Accept.Add(
			new MediaTypeWithQualityHeaderValue("application/json"));

			HttpResponseMessage response = client.GetAsync("api/Products/GetAllProducts").Result;
			if (response.IsSuccessStatusCode)
			{
				var EmpResponse = response.Content.ReadAsStringAsync().Result;

				//Deserializing the response recieved from web api and storing into the Employee list  
				ObjCustomer = JsonConvert.DeserializeObject<List<Products>>(EmpResponse);

				
			}
			return View(ObjCustomer);
		}
	}
}

