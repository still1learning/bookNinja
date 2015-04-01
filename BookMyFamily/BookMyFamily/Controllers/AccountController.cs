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

        public static Account Current { get; set; }
        //
        // GET: /Account/

     
        public ActionResult LogIn()
        {            
            return View();
        }
        
        [HttpPost]
        public ActionResult Authenticate(string username, string password)
        {
            if (AuthenticationModule.CheckAccount(username, password))
            {
                Current = AuthenticationModule.GetAccount(username);
                FormsAuthentication.SetAuthCookie(username, true);
                return View();
            }
            return Redirect("~/");
        }


        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Current = new Account();
            return View();
        }

        [Authorize]
        public ActionResult Preview()
        {
            return View(Current);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MakeAcount(string email, string password, string passwordC, string twitter, string facebook, string google, string img, HttpPostedFileBase theImg, string name, string lastname, string phone, string address)
        {
            Account tmp = new Account(email, password, new User(name, lastname, DateTime.Now, address));
            AuthenticationModule.AddAccount(tmp);
            return Redirect("~/Account/Preview");
        }
	}
}