using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApidemo.Models;

namespace WebApidemo.Controllers
{
    public class ProductsController : ApiController
    {
		public static List<Products> Products;
		public ProductsController()
		{
			Products = new List<Products>() {
				new Products{ ID = 1,
								ProductName = "Mobile",
								Customers = new List<Customer>{
												new Customer{ Customer_ID = 1, CustomerName = "John"},
												new Customer{ Customer_ID = 2, CustomerName = "Martin"}
															}
				},
				new Products{ ID = 2,
								ProductName = "Ipad",
								Customers = new List<Customer>{
												new Customer{ Customer_ID = 3, CustomerName = "Mathew"},
												new Customer{ Customer_ID = 4, CustomerName = "albert"}
															}
				}
			};
		}

		[HttpGet]
		public List<Products> GetAllProducts()
		{
			return Products;
		}

	}
}
