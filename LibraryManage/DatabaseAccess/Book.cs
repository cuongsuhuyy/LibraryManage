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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            this.Borrows = new HashSet<Borrow>();
        }
    
        public string ID_Book { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> Publishing_Year { get; set; }
        public string Publishing_Location { get; set; }
        public string Type { get; set; }
        public Nullable<System.DateTime> Date_add_to_library { get; set; }
        public string Location_in_library { get; set; }
        public string Notes { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Borrow> Borrows { get; set; }
    }
}