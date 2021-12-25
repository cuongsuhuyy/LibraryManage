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
                
        public ActionResult EDIT(string IdBook)
        {
            LibraryDBEntities db = new LibraryDBEntities();
            var bookInfor = db.Books.Single(x => x.ID_Book == IdBook);

            return View("BookEdit", bookInfor);
        }
    }
}