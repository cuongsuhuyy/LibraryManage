using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManage.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        public BaseController()
        {
            if (Session["User"].Equals(""))
            {
                Redirect("~RegisterLogin/Login");
            }
        }
    }
}