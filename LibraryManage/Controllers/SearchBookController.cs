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
        public ActionResult getSelectedValue(string booktitle)
        {
            var testa = booktitle;
            var selectedValue = Request.Form["LogOffTime"].ToString(); //this will get selected value
            return Content(selectedValue);
        }
    }
}