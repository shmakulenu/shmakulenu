using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BLL;

namespace WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
   
           // ReadAsapimExcel.readExcel();
        }
        protected void Application_BeginRequest()
        {
            Response.AddHeader("Access-Control-Allow-Origin", "*");
            Response.AddHeader("Access-Control-Allow-Methods", "GET,PUT,POST,DELETE");
            Response.AddHeader("Access-Control-Allow-Headers", "Content-Type,Accept,Pragma,Cache-Control,Authorization");

            if (Request.Headers.AllKeys.Contains("Origin", StringComparer.CurrentCultureIgnoreCase) && Request.HttpMethod == "OPTIONS")
            {
                Response.End();
            }


        }
    }
}
