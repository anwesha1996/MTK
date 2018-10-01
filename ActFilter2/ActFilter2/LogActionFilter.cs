using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Routing;

namespace ActFilter2
{
		public class LogActionFilter : System.Web.Mvc.ActionFilterAttribute

		{
			public override void OnActionExecuting(ActionExecutingContext filterContext)
			{
				Trace("OnActionExecuting", filterContext.RouteData);
			
			}

			public override void OnActionExecuted(ActionExecutedContext filterContext1)
			{
				Trace("OnActionExecuted", filterContext1.RouteData);
			}

			public override void OnResultExecuting(ResultExecutingContext filterContext3)
			{
				Trace("OnResultExecuting", filterContext3.RouteData);
			}

			public override void OnResultExecuted(ResultExecutedContext filterContext4)
			{
				Trace("OnResultExecuted", filterContext4.RouteData);
			}


			private void Trace(string methodName, RouteData routeData)
			{
			//var controllerName = routeData.Values["controller"];
			//var actionName = routeData.Values["action"];
			//var message = String.Format("{0} controller:{1} action:{2}", methodName, controllerName, actionName);
			//Debug.WriteLine(message, "Action Filter Log");
			string controllerName = routeData.Values["controller"].ToString();
			string actionName = routeData.Values["action"].ToString();
			HttpContext.Current.Response.Write($"MethodName ={methodName},Controller={controllerName},Action={ actionName} <br><br>");
		}

		}
	}
