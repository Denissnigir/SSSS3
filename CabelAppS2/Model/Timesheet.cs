//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CabelAppS2.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Timesheet
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public System.DateTime StartDate { get; set; }
        public int ActiveTypeId { get; set; }
    
        public virtual ActiveType ActiveType { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
