using LibraryManage.DatabaseAccess;
using LibraryManage.Models;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace LibraryManage.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            LibraryDBEntities db = new LibraryDBEntities();
            var account = db.Accounts.ToList();

            return View(account);
        }
    }
}