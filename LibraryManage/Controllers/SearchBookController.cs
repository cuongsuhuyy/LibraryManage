using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManage.Controllers
{
    public class SearchBookController : Controller
    {
        // GET: SearchBook
        public ActionResult Index(string titlebook, string action)
        {
            var testa = titlebook;
            var testb = action;
            return View();
        }
    }
}