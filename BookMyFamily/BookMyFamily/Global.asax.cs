using BookMyFamily.Controllers;
using BookMyFamily.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BookMyFamily
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            //test cases for deletition later
            AccountController.Current = new Account("darko", "ninja", new User("darko", "Kotoski", DateTime.Now, "skopje"));
            AuthenticationModule.AddAccount(AccountController.Current);

            AccountController.Current = new Account("kristijan", "ninja", new User("kristijan", "arsovski", DateTime.Now, "skopje"));
            AuthenticationModule.AddAccount(AccountController.Current);
        }
    }
}
