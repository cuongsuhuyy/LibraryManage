using LibraryManage.DatabaseAccess;
using LibraryManage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManage.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            LibraryDBEntities db = new LibraryDBEntities();

            Account account = db.Accounts.SingleOrDefault(x => x.Username == "TKSUC1HC");
            AccountModel accountModel = new AccountModel();

            accountModel.Username = account.Username;
            accountModel.Password = account.Password;
            accountModel.ID_Users = account.ID_Users;
            accountModel.First_Name = account.First_Name;
            accountModel.Last_Name = account.Last_Name;
            accountModel.Date_of_Birth = account.Date_of_Birth;
            accountModel.Type = account.Type;
            accountModel.Notes = account.Notes;

            return View(accountModel);
        }
    }
}