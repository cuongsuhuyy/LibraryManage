using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManage.DatabaseAccess;

namespace LibraryManage.Controllers
{
    public class SearchBookController : Controller
    {
        // GET: SearchBook
        public ActionResult Index(string booktitle, string action)
        {
            var testa = booktitle;
            var testb = action;
            return View();
        }

        public ActionResult SearchBook(string booktitle)
        {
            var testa = booktitle;
            return View();
        }

        [HttpPost]
        public ActionResult getSelectedValue(string BookName)
        {
            var selectedValue = Request.Form["TitleBook"].ToString();
            LibraryDBEntities db = new LibraryDBEntities();
            List<Book> listBook = new List<Book>();

            var bookSearch = db.Books.Where(x => x.Name.StartsWith(BookName));
            var results = bookSearch.Where(x => x.Type == selectedValue).ToList();

            foreach(var result in results)
            {
                listBook.Add(result);
            }

            //var test = bookSearch.Count();

            this.Session.Add("Search", listBook);

            return RedirectToAction("Search", "Books");
        }
    }
}