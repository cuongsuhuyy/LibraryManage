using LibraryManage.DatabaseAccess;
using LibraryManage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManage.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            LibraryDBEntities db = new LibraryDBEntities();

            User user = db.Users.SingleOrDefault(x => x.ID_User == "SUC1HC");
            UsersModel userModel = new UsersModel();

            userModel.ID_User = user.ID_User;
            userModel.First_Name = user.First_Name;
            userModel.Last_Name = user.Last_Name;
            userModel.Date_of_Birth = user.Date_of_Birth;
            userModel.Type = user.Type;
            userModel.Faculty = user.Faculty;
            userModel.Production_Date = user.Production_Date;
            userModel.Expiration_Date = user.Expiration_Date;
            userModel.Email = user.Email;
            userModel.Address = user.Address;
            userModel.Phone_Number = user.Phone_Number;
            userModel.Notes = user.Notes;

            return View(userModel);
        }

        public ActionResult UserAccount()
        {
            LibraryDBEntities db = new LibraryDBEntities();

            var AllUserAccount = db.Accounts.ToList();

            return View(AllUserAccount);
        }

        public ActionResult Create()
        {
            return View("UserCreate");
        }

        public ActionResult AddNewToDB(string IdUser, string Username, string Password, string Firstname, string Lastname,
            string Type, string Dateofbirth, string Notes, string Pathimage)
        {
            LibraryDBEntities db = new LibraryDBEntities();

            var checkIfExist = db.Accounts.SingleOrDefault(x => x.ID_Users == IdUser);
            if (checkIfExist != null)
            {
                return Content("This ID User have been created");
            }

            if (Notes == "")
                Notes = "/";
            if (Pathimage == "")
                Pathimage = "/";

            Account accountInfo = new Account();

            accountInfo.ID_Users = IdUser;
            accountInfo.Username = Username;
            accountInfo.Password = Password;
            accountInfo.First_Name = Firstname;
            accountInfo.Last_Name = Lastname;
            accountInfo.Type = Type;
            accountInfo.Date_of_Birth = Dateofbirth;
            accountInfo.Notes = Notes;
            accountInfo.PathImage = Pathimage;

            db.Accounts.Add(accountInfo);
            db.SaveChanges();

            return RedirectToAction("UserAccount", "Users");
        }

        public ActionResult EDIT(string Username)
        {
            LibraryDBEntities db = new LibraryDBEntities();
            var userInfor = db.Accounts.Single(x => x.Username == Username);

            return View("UserEdit", userInfor);
        }

        public ActionResult Update(string IdUsers, string Username, string Password, string Firstname, string Lastname,
            string Type, string Dateofbirth, string Notes, string Pathimage)
        {
            LibraryDBEntities db = new LibraryDBEntities();
            var userUpdate = db.Accounts.Single(x => x.Username == Username);

            if (Notes == "")
                Notes = "/";
            if (Pathimage == "")
                Pathimage = "/";

            userUpdate.ID_Users = IdUsers;
            userUpdate.Password = Password;
            userUpdate.First_Name = Firstname;
            userUpdate.Last_Name = Lastname;
            userUpdate.Type = Type;
            userUpdate.Date_of_Birth = Dateofbirth;
            userUpdate.Notes = Notes;
            userUpdate.PathImage = Pathimage;

            db.Entry(userUpdate);
            db.SaveChanges();

            return RedirectToAction("UserAccount", "Users");
        }

        public ActionResult Delete(string Username)
        {
            LibraryDBEntities db = new LibraryDBEntities();
            var userInfor = db.Accounts.Single(x => x.Username == Username);

            db.Accounts.Remove(userInfor);
            db.SaveChanges();

            return RedirectToAction("UserAccount", "Users");
        }
    }
}