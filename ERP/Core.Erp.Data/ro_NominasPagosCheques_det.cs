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
    
    public partial class ro_NominasPagosCheques_det
    {
        public int IdEmpresa { get; set; }
        public int IdTransaccion { get; set; }
        public int Secuencia { get; set; }
        public int IdSucursal { get; set; }
        public Nullable<decimal> IdEmpleado { get; set; }
        public string Observacion { get; set; }
        public double Valor { get; set; }
        public int IdEmpresa_op { get; set; }
        public int Secuancia_op { get; set; }
        public decimal IdOrdenPago { get; set; }
        public int IdEmpresa_dc { get; set; }
        public int IdTipoCbte { get; set; }
        public decimal IdCbteCble { get; set; }
        public bool Estado { get; set; }
    
        public virtual ro_empleado ro_empleado { get; set; }
        public virtual ro_NominasPagosCheques ro_NominasPagosCheques { get; set; }
    }
}
