using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManage.DatabaseAccess;
using LibraryManage.Models;

namespace LibraryManage.Controllers
{
    public class RegisterLoginController : Controller
    {
        // GET: RegisterLogin
        public ActionResult Register()
        {

            return View("Register");
        }

        public ActionResult RegisterToDB(string Iduser, string Sex, string Firstname, string Lastname, string Password, string Confirmpassword,
            DateTime Dateofbirth, string Type, string Faculty, string Email, string Productiondate,
            string Address, int Phonenumber, string Notes, string Pathimage)
        {
            if(Password != Confirmpassword)
            {
                return Content("Password not match");
            }

            LibraryDBEntities db = new LibraryDBEntities();

            DateTime productionDate = DateTime.Parse(Productiondate);
            DateTime Expirationdate = productionDate.AddDays(365);

            User user = new User();
            user.ID_User = Iduser;
            user.First_Name = Firstname;
            user.Last_Name = Lastname;
            user.Sex = Sex;
            user.Date_of_Birth = Dateofbirth;
            user.Type = Type;
            user.Faculty = Faculty;
            user.Production_Date = productionDate;
            user.Expiration_Date = Expirationdate;
            user.Email = Email;
            user.Address = Address;
            user.Phone_Number = Phonenumber;
            user.Notes = Notes;

            Account account = new Account();
            account.Username = Iduser;
            account.Password = Password;
            account.ID_Users = Iduser;
            account.First_Name = Firstname;
            account.Last_Name = Lastname;
            account.Date_of_Birth = Dateofbirth.ToString();
            account.Type = Type;
            account.Notes = Notes;
            account.PathImage = Pathimage;

            db.Users.Add(user);
            db.Accounts.Add(account);
            db.SaveChanges();

            return Content("Register Successful");
        }

        public ActionResult AddExpirationDate(DateTime Productiondate, DateTime Expirationdate)
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
                this.Session.Add("UserProfile", accountUser.First_Name);
                this.Session.Add("ID", accountUser.ID_Users);
                this.Session.Add("Type", accountUser.Type);
                return View("Logged");
            }
            else
            {
                username = "Cannot find that username";
            }               
                
            return View(username);
        }

        public ActionResult Logout()
        {
            this.Session.Add("UserProfile", "");
            this.Session.Add("Type", "");
            this.Session.Add("ID", "");
            return View("Login");
        }
    }
}