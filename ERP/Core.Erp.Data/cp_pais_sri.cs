//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Erp.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class cp_pais_sri
    {
        public cp_pais_sri()
        {
            this.cp_orden_giro = new HashSet<cp_orden_giro>();
        }
    
        public string Codigo { get; set; }
        public string Pais { get; set; }
    
        public virtual ICollection<cp_orden_giro> cp_orden_giro { get; set; }
    }
}
