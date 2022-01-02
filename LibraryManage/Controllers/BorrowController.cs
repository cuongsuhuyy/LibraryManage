using LibraryManage.DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManage.Controllers
{
    public class BorrowController : Controller
    {
        // GET: Borrow
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Hire(string IdBook)
        {
            LibraryDBEntities db = new LibraryDBEntities();
            var bookInfor = db.Books.Single(x => x.ID_Book == IdBook);

            if(this.Session["UserProfile"].Equals("User") || this.Session["UserProfile"].Equals("Employee") || this.Session["UserProfile"].Equals("Manager"))
            {
                return View("HireBook", bookInfor);
                
            }
            else
            {
                return RedirectToAction("Login", "RegisterLogin");
            }            
        }
    }
}