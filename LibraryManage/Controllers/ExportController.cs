using Jitbit.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManage.DatabaseAccess;

namespace LibraryManage.Controllers
{
    public class ExportController : Controller
    {
        // GET: Export
        public ActionResult Index()
        {


            return View();
        }

        public ActionResult Export()
        {
            var selectedValue = Request.Form["Status"].ToString();

            LibraryDBEntities db = new LibraryDBEntities();
            var exportdb = db.Borrows.Where(x => x.Notes == selectedValue).ToList();
            var myExport = new CsvExport();

            foreach (var ex in exportdb)
            {
                myExport.AddRow();
                myExport["ID Borrow"] = ex.ID_Borrow;
                myExport["ID Book"] = ex.ID_Book;
                myExport["ID User"] = ex.ID_User;
                myExport["ID Employee"] = ex.ID_Employee;
                myExport["Borrow Date"] = ex.Borrow_Date;
                myExport["Pay Day"] = ex.Pay_Day;
                myExport["Notes"] = ex.Notes;
            }

            ///ASP.NET MVC action example
            return File(myExport.ExportToBytes(), "text/csv", "StatusBookList.csv");
        }
    }
}