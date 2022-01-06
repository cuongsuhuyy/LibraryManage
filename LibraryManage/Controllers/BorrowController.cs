using LibraryManage.DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManage.Models;

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
            if(Payday <= Borrowdate)
            {
                return Content("Pay day can not smaller than borrow date");
            }

            LibraryDBEntities db = new LibraryDBEntities();

            var checkIfOverTurn = db.Borrows.Where(x => x.ID_User == Iduser).Count();
            if(checkIfOverTurn > 5)
            {
                return Content("You have exceeded the allowed number of times");
            }

            var GetExpirationDateofUser = db.Users.Single(x => x.ID_User == Iduser);
            var getDate = GetExpirationDateofUser.Expiration_Date;
            if(getDate < DateTime.Now)
            {
                return Content("Your library card was our of date, Please contact to library for extend");
            }

            var AddtoDB = new Borrow();
            var borrowInfo = db.Borrows.ToList();
            var temp = borrowInfo.Max(x => x.ID_Borrow);
            var tempp = borrowInfo.Count;
            var bookInfo = db.Books.Single(x => x.ID_Book == ID_Book);

            Payday = Borrowdate.AddDays(30);

            AddtoDB.ID_User = Iduser;
            AddtoDB.ID_Book = ID_Book;
            AddtoDB.ID_Employee = Idemployee;
            AddtoDB.Borrow_Date = Borrowdate;
            AddtoDB.Pay_Day = Payday;

            if (Notes != "Wait verify")
            {
                AddtoDB.Notes = "Hired";
                                
                var presentQuantily = bookInfo.Quantily;
                if(presentQuantily > 0)
                {
                    var check = presentQuantily - 1;
                    bookInfo.Quantily = check;
                }
                else
                {
                    return Content ("Quantily of this book is 0");
                }
                       
            }
            else
            {
                AddtoDB.ID_Employee = "null";
                AddtoDB.Notes = Notes;               
            }

            if (borrowInfo.Count == 0)
            {
                AddtoDB.ID_Borrow = 1.ToString();
            }
            else
            {
                AddtoDB.ID_Borrow = (tempp + 1).ToString();
            }           

            db.Entry(bookInfo);
            db.Borrows.Add(AddtoDB);
            db.SaveChanges();

            return RedirectToAction("Index", "Books");
        }

        public ActionResult Verify()
        {
            LibraryDBEntities db = new LibraryDBEntities();
            var verify = db.Borrows.Where(x => x.Notes == "Wait verify");

            return View("VerifyHireBook", verify);
        }

        public ActionResult UpdateVerify(string IdBorrow, string Idbook, string Idemployee)
        {
            LibraryDBEntities db = new LibraryDBEntities();

            var update = db.Borrows.Single(x => x.ID_Borrow == IdBorrow);
            var bookInfo = db.Books.Single(x => x.ID_Book == Idbook);
            update.Notes = "Hired";
            update.ID_Employee = Idemployee;

            var presentQuantily = bookInfo.Quantily;
            if (presentQuantily > 0)
            {
                var check = presentQuantily - 1;
                bookInfo.Quantily = check;
            }
            else
            {
                return Content("Quantily of this book is 0");
            }

            db.Entry(bookInfo);
            db.Entry(update);
            db.SaveChanges();

            return View();
        }

        public ActionResult DeleteVerify(string Idborrow)
        {
            LibraryDBEntities db = new LibraryDBEntities();
            var deleteVerify = db.Borrows.Single(x => x.ID_Borrow == Idborrow);

            db.Borrows.Remove(deleteVerify);
            db.SaveChanges();

            return View();
        }

        public ActionResult ReturnBook()
        {
            LibraryDBEntities db = new LibraryDBEntities();
            var retBook = db.Borrows.Where(x => x.Notes == "Hired");

            return View("ReturnBook", retBook);
        }

        public ActionResult UpdateReturnBook (string Idborrow, DateTime Payday)
        {
            LibraryDBEntities db = new LibraryDBEntities();
            var delete = db.Borrows.Single(x => x.ID_Borrow == Idborrow);
            var retBook = db.Borrows.Where(x => x.Notes == "Hired");

            
            var compare = DateTime.Now.Subtract(Payday);
            
            if(compare.Days > 0)
            {
                var temp = compare.Days;
                var price = temp * 5000;
                return Content("Late: " + temp + " days, Pay " + price + "VND");
            }

            db.Borrows.Remove(delete);
            db.SaveChanges();

            return View("ReturnBook", retBook);
        }
    }
}