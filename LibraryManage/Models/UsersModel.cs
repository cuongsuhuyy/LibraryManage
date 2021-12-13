using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManage.Models
{
    public class UsersModel
    {
        public string ID_User { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Sex { get; set; }
        public Nullable<System.DateTime> Date_of_Birth { get; set; }
        public string Type { get; set; }
        public string Faculty { get; set; }
        public Nullable<System.DateTime> Production_Date { get; set; }
        public Nullable<System.DateTime> Expiration_Date { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Nullable<int> Phone_Number { get; set; }
        public string Notes { get; set; }
    }
}