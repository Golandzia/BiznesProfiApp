//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BiznesProfiApp.dbEntities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Task
    {
        public int ID { get; set; }
        public int Type_of_task { get; set; }
        public string Short_description { get; set; }
        public string Full_task { get; set; }
        public Nullable<int> Files { get; set; }
        public int Responsible { get; set; }
        public int Customer { get; set; }
    
        public virtual Customer Customer1 { get; set; }
        public virtual File File { get; set; }
        public virtual Type_of_task Type_of_task1 { get; set; }
        public virtual User User { get; set; }
    }
}