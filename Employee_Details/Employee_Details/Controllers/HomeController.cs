﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Employee_Details.Models;
using Newtonsoft.Json;

namespace Employee_Details.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			IEnumerable<Department> ObjEmp = null;
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("http://localhost:59246/");
			// Add an Accept header for JSON format.
			client.DefaultRequestHeaders.Accept.Add(
			new MediaTypeWithQualityHeaderValue("application/json"));

			HttpResponseMessage response = client.GetAsync("api/EmployeeDetails/GetAllDepartments").Result;
			if (response.IsSuccessStatusCode)
			{
				var EmpResponse = response.Content.ReadAsStringAsync().Result;

				//Deserializing the response recieved from web api and storing into the Employee list  
				ObjEmp = JsonConvert.DeserializeObject<List<Department>>(EmpResponse);


			}
			return View(ObjEmp);
		}
	}
}