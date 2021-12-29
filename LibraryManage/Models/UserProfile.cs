using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManage.Models
{
    [Serializable]
    public class UserProfile
    {        
        public string Username { get; set; }
        public string Type { get; set; }
    }
}