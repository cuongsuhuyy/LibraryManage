using LibraryManage.DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManage.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        public ActionResult Index()
        {
            LibraryDBEntities db = new LibraryDBEntities();
            var book = db.Books.ToList();

            return View(book);
        }
    }
}