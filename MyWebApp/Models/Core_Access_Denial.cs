//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyWebApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Core_Access_Denial
    {
        public int IdAccessDenial { get; set; }
        public int IdUser { get; set; }
        public int IdCore { get; set; }
    
        public virtual TB_Core TB_Core { get; set; }
        public virtual TB_User TB_User { get; set; }
    }
}
