//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryManage.DatabaseAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Book
    {
        public string ID_Book { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> Publishing_Year { get; set; }
        public string Publishing_Location { get; set; }
        public string Type { get; set; }
        public string Date_add_to_library { get; set; }
        public string Location_in_library { get; set; }
        public string Notes { get; set; }
        public string PathImage { get; set; }
        public Nullable<int> Quantily { get; set; }
    }
}
