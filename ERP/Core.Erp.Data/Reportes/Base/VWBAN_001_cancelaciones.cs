//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Erp.Data.Reportes.Base
{
    using System;
    using System.Collections.Generic;
    
    public partial class VWBAN_001_cancelaciones
    {
        public int IdEmpresa { get; set; }
        public decimal Idcancelacion { get; set; }
        public int Secuencia { get; set; }
        public Nullable<int> IdEmpresa_cxp { get; set; }
        public Nullable<int> IdTipoCbte_cxp { get; set; }
        public Nullable<decimal> IdCbteCble_cxp { get; set; }
        public string Referencia { get; set; }
        public string Observacion { get; set; }
        public double MontoAplicado { get; set; }
        public int IdEmpresa_pago { get; set; }
        public int IdTipoCbte_pago { get; set; }
        public decimal IdCbteCble_pago { get; set; }
        public string pe_nombreCompleto { get; set; }
        public Nullable<System.DateTime> co_FechaFactura { get; set; }
        public Nullable<System.DateTime> FechaCruce { get; set; }
        public string pe_nombreCompleto1 { get; set; }
        public Nullable<System.DateTime> co_FechaFactura1 { get; set; }
    }
}
