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
    
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            this.Borrows = new HashSet<Borrow>();
        }
    
        public string ID_Employee { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Sex { get; set; }
        public Nullable<System.DateTime> Date_of_Birth { get; set; }
        public string Type { get; set; }
        public Nullable<System.DateTime> Working_day { get; set; }
        public Nullable<System.DateTime> Last_Working_Day { get; set; }
        public Nullable<int> Salary { get; set; }
        public string Notes { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Borrow> Borrows { get; set; }
    }
}