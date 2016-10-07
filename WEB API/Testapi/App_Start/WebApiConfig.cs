using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Testapi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

           

            config.Routes.MapHttpRoute(
               name: "loginApi",
               routeTemplate: "api/{controller}/{action}/{id}/{pass}/{g}"
            );


            config.Routes.MapHttpRoute(
               name: "activateApi",
               routeTemplate: "api/{controller}/{action}/{em}"
            );

           

            config.Routes.MapHttpRoute(
               name: "RegisterApi",
               routeTemplate: "api/{controller}/{action}/{UName}/{Name}/{Email}/{R_Pass}"
            );

             config.Routes.MapHttpRoute(
               name: "LogoutApi",
               routeTemplate: "api/{controller}/{action}/{id}/{g}"
            );


             config.Routes.MapHttpRoute(
               name: "updatePassApi",
               routeTemplate: "api/{controller}/{action}/{ID}/{newPass}"
            );



            // config.Routes.MapHttpRoute(
            //   name: "updateInfoApi",
            //   routeTemplate: "api/{controller}/{action}/{ID}/{newName}/{newEmail}"
            //);

             config.Routes.MapHttpRoute(
               name: "querryApi",
               routeTemplate: "api/{controller}/{action}"
            );


             


        }
    }
}
