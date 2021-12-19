using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManage.DatabaseAccess;

namespace LibraryManage.Controllers
{
    public class RegisterLoginController : Controller
    {
        // GET: RegisterLogin
        public ActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            LibraryDBEntities db = new LibraryDBEntities();
            var test = db.Accounts;

            var accountUser = db.Accounts.Single(x => x.Username == username && x.Password == password);
            if (accountUser != null)
            {
                ViewData["Username"] = accountUser.First_Name;
                ViewBag.US = accountUser.First_Name;
                ViewBag.Role = accountUser.Type;
                return View("Logged");
            }
            else
            {
                username = "Cannot find that username";
            }               
                
            return View(username);
        }
    }
}