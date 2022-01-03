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

            if(this.Session["UserProfile"] != "")
            {
                return View("HireBook", bookInfor);
                
            }
            else
            {
                return RedirectToAction("Login", "RegisterLogin");
            }            
        }

        public ActionResult UpdateToDB (string ID_Book, string Iduser, string Type, string Idemployee, string Notes, 
            DateTime Borrowdate, DateTime Payday)
        {
            LibraryDBEntities db = new LibraryDBEntities();
            if(Notes != "Wait verify")
            {
                var borrowInfo = db.Borrows.ToList();
                if(borrowInfo.Count == 0)
                {
                    var temp = borrowInfo.Max(x => x.ID_Borrow);
                    var AddtoDB = new Borrow();

                    AddtoDB.ID_User = Iduser;
                    AddtoDB.ID_Book = ID_Book;
                    AddtoDB.ID_Employee = Idemployee;
                    AddtoDB.ID_Borrow = 1.ToString();
                    AddtoDB.Borrow_Date = Borrowdate;
                    AddtoDB.Pay_Day = Payday;
                    AddtoDB.Notes = "Hired";

                    db.Borrows.Add(AddtoDB);
                    db.SaveChanges();                    
                }
                else
                {
                    var AddtoDB = new Borrow();
                    var tempp = borrowInfo.Count;

                    AddtoDB.ID_User = Iduser;
                    AddtoDB.ID_Book = ID_Book;
                    AddtoDB.ID_Employee = Idemployee;
                    AddtoDB.ID_Borrow = (tempp + 1).ToString();
                    AddtoDB.Borrow_Date = Borrowdate;
                    AddtoDB.Pay_Day = Payday;
                    AddtoDB.Notes = "Hired";

                    db.Borrows.Add(AddtoDB);
                    db.SaveChanges();
                }

                var bookInfo = db.Books.Single(x => x.ID_Book == ID_Book);

                var presentQuantily = bookInfo.Quantily;
                var check = presentQuantily - 1;
                bookInfo.Quantily = check;
                db.Entry(bookInfo);
                db.SaveChanges();

            }

            return View();
        }
    }
}