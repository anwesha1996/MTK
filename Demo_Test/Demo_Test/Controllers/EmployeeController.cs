using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EntityLayer;
using BuisnessLayer;

namespace Demo_Test.Controllers
{
    public class EmployeeController : ApiController
    {
		private readonly EmployeeManager empc = new EmployeeManager();


	}
}
