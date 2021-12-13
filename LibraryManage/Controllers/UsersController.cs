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
    }
}