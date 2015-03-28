using BookMyFamily.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BookMyFamily.Controllers
{
    public class AccountController : Controller
    {

        public Account Current { get; set; }
        //
        // GET: /Account/

        [HttpPost]
        public ActionResult LogIn(string username,string password)
        {
            if (AuthenticationModule.CheckAccount(username, password))
            {
                Current=AuthenticationModule.GetAccount(username);
                FormsAuthentication.SetAuthCookie(username, true);
            }
            return View();
        }


        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return View();
        }

        public ActionResult Preview()
        {
            return View(Current);
        }

        public ActionResult Register()
        {
            return View();
        }
	}
}