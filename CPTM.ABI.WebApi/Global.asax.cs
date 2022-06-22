using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CPTM.ABI.WebApi
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

            // Habilita a minificação dos JS e CSS
            BundleTable.EnableOptimizations = true;
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (Context.Request.HttpMethod != "OPTIONS") return;
            if (Context.Request.Headers["Origin"] != null)
                Context.Response.AddHeader("Access-Control-Allow-Origin", Context.Request.Headers["Origin"]);

            Context.Response.AddHeader("Access-Control-Allow-Headers",
                "Origin,X-Requested-With,Content-Type,Accept,Authorization");
            Context.Response.AddHeader("Access-Control-Allow-Methods", "*");
            Context.Response.AddHeader("Access-Control-Allow-Credentials", "true");

            Response.End();
        }
    }
}