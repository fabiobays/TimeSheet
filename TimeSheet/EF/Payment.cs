//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TimeSheet.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Payment
    {
        public int Id { get; set; }
        public int employeeId { get; set; }
        public int timesheetMonthId { get; set; }
        public decimal hourlyRate { get; set; }
        public decimal gross { get; set; }
        public decimal cpp { get; set; }
        public decimal ei { get; set; }
        public decimal net { get; set; }
        public decimal tax { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual TimeSheetMonth TimeSheetMonth { get; set; }
    }
}
