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

        public ActionResult Update(string IdBook, string Name, string Description, int PublishingYear, string PublishingLocation, 
            string Type, string DateAddToLibrary, string Location, string Notes, string PathImage, int Quantily)
        {
            LibraryDBEntities db = new LibraryDBEntities();
            var bookUpdate = db.Books.Single(x => x.ID_Book == IdBook);

            bookUpdate.Name = Name;
            bookUpdate.Description = Description;
            bookUpdate.Publishing_Year = PublishingYear;
            bookUpdate.Publishing_Location = PublishingLocation;
            bookUpdate.Type = Type;
            bookUpdate.Date_add_to_library = DateAddToLibrary;
            bookUpdate.Location_in_library = Location;
            bookUpdate.Notes = Notes;
            bookUpdate.PathImage = PathImage;
            bookUpdate.Quantily = Quantily;

            db.Entry(bookUpdate);
            db.SaveChanges();

            return RedirectToAction("Index", "Books");
        }

        public ActionResult Detail(string IdBook)
        {
            LibraryDBEntities db = new LibraryDBEntities();
            var bookInfor = db.Books.Single(x => x.ID_Book == IdBook);

            return View("BookDetail", bookInfor);
        }

        public ActionResult Delete(string IdBook)
        {
            LibraryDBEntities db = new LibraryDBEntities();
            var bookInfor = db.Books.Single(x => x.ID_Book == IdBook);

            db.Books.Remove(bookInfor);
            db.SaveChanges();

            return RedirectToAction("Index", "Books");
        }
                
        public ActionResult Create()
        {            
            return View("BookCreate");
        }

        [HttpPost]
        public ActionResult AddNewToDB(string IdBook, string Name, string Description, int PublishingYear, string PublishingLocation,
            string Type, string DateAddToLibrary, string Location, string Notes, string PathImage, int Quantily)
        {
            LibraryDBEntities db = new LibraryDBEntities();

            var checkIfExist = db.Books.SingleOrDefault(x => x.ID_Book == IdBook);
            if(checkIfExist != null)
            {
                return Content("This ID Book have been created");
            }

            Book bookInfo = new Book();

            bookInfo.ID_Book = IdBook;
            bookInfo.Name = Name;
            bookInfo.Description = Description;
            bookInfo.Publishing_Year = PublishingYear;
            bookInfo.Publishing_Location = PublishingLocation;
            bookInfo.Type = Type;
            bookInfo.Date_add_to_library = DateAddToLibrary;
            bookInfo.Location_in_library = Location;
            bookInfo.Notes = Notes;
            bookInfo.PathImage = PathImage;
            bookInfo.Quantily = Quantily;

            db.Books.Add(bookInfo);
            db.SaveChanges();

            return RedirectToAction("Index", "Books");
        }
    }
}