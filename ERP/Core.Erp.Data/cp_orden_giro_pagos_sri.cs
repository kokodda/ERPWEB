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
    
    public partial class cp_orden_giro_pagos_sri
    {
        public int IdEmpresa { get; set; }
        public decimal IdCbteCble_Ogiro { get; set; }
        public int IdTipoCbte_Ogiro { get; set; }
        public string codigo_pago_sri { get; set; }
        public string formas_pago_sri { get; set; }
    
        public virtual cp_pagos_sri cp_pagos_sri { get; set; }
        public virtual cp_orden_giro cp_orden_giro { get; set; }
    }
}
