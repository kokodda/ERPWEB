//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Erp.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class cp_orden_pago_tipo_x_empresa
    {
        public int IdEmpresa { get; set; }
        public string IdTipo_op { get; set; }
        public string IdCtaCble { get; set; }
        public string IdCentroCosto { get; set; }
        public Nullable<int> IdTipoCbte_OP { get; set; }
        public Nullable<int> IdTipoCbte_OP_anulacion { get; set; }
        public string IdEstadoAprobacion { get; set; }
        public string Buscar_FactxPagar { get; set; }
        public string IdCtaCble_Credito { get; set; }
        public Nullable<bool> Dispara_Alerta { get; set; }
    
        public virtual cp_orden_pago_tipo cp_orden_pago_tipo { get; set; }
    }
}
