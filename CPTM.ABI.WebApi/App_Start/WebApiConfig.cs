using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Cors;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CPTM.ABI.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Filters.Add(new LocalRequestOnlyAttribute());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(name: "ActionApi", routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional });

            // JSON Formatter
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.Add(new BrowserJsonFormatter());
        }

        /// <inheritdoc />
        public class BrowserJsonFormatter : JsonMediaTypeFormatter
        {
            /// <inheritdoc />
            public BrowserJsonFormatter()
            {
                SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
                SerializerSettings.Formatting = Formatting.Indented;
                SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                UseDataContractJsonSerializer = false;
            }

            /// <inheritdoc />
            public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers,
                MediaTypeHeaderValue mediaType)
            {
                base.SetDefaultContentHeaders(type, headers, mediaType);
                headers.ContentType = new MediaTypeHeaderValue("application/json");
            }
        }

        public class LocalRequestOnlyAttribute : AuthorizeAttribute
        {
            protected override bool IsAuthorized(HttpActionContext context)
            {
                return context.RequestContext.IsLocal;
            }
        }
    }
}