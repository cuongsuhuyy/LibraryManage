using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManage.Models
{
    public class AccountModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ID_Users { get; set; }
        public string Last_Name { get; set; }
        public string First_Name { get; set; }
        public Nullable<System.DateTime> Date_of_Birth { get; set; }
        public string Type { get; set; }
        public string Notes { get; set; }
    }
}