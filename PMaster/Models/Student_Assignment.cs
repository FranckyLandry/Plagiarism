//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PMaster.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student_Assignment
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        public string AssignmentName { get; set; }
        public Nullable<int> GroupNumber { get; set; }
    
        public virtual Assignment Assignment { get; set; }
        public virtual Student Student { get; set; }
    }
}
