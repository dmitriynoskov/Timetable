//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccessToDL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Net
    {
        public int ID { get; set; }
        public int PersonID { get; set; }
        public System.DateTime DateWorked { get; set; }
        public string TimeWorked { get; set; }
    
        public virtual Person Person { get; set; }
    }
}
