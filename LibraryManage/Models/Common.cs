using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LibraryManage.Models
{
    public class Common
    {
        public object objAccount { get; set; }
        public object objEmployee { get; set; }
        public object objUsers { get; set; }
        private int _type;
        [DefaultValue(0)]
        public int Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }

        private int _waitVerify;
        public int WaitVerify
        {
            get
            {
                return _waitVerify;
            }
            set
            {
                _waitVerify = value;
            }
        }

        private int _retu;
        public int Retu
        {
            get
            {
                return _retu;
            }
            set
            {
                _retu = value;
            }
        }
    }
}