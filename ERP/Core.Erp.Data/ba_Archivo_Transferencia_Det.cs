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
    
    public partial class ba_Archivo_Transferencia_Det
    {
        public int IdEmpresa { get; set; }
        public decimal IdArchivo { get; set; }
        public int Secuencia { get; set; }
        public string Id_Item { get; set; }
        public Nullable<int> IdEmpresa_OP { get; set; }
        public Nullable<decimal> IdOrdenPago { get; set; }
        public Nullable<int> Secuencia_OP { get; set; }
        public bool Estado { get; set; }
        public decimal Valor { get; set; }
        public decimal Secuencial_reg_x_proceso { get; set; }
        public Nullable<bool> Contabilizado { get; set; }
        public Nullable<System.DateTime> Fecha_proceso { get; set; }
    
        public virtual ba_Archivo_Transferencia ba_Archivo_Transferencia { get; set; }
    }
}
