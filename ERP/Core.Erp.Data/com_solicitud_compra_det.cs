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
    
    public partial class com_solicitud_compra_det
    {
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public decimal IdSolicitudCompra { get; set; }
        public int Secuencia { get; set; }
        public Nullable<decimal> IdProducto { get; set; }
        public double do_Cantidad { get; set; }
        public string NomProducto { get; set; }
        public string IdCentroCosto { get; set; }
        public string IdCentroCosto_sub_centro_costo { get; set; }
        public Nullable<int> IdPunto_cargo_grupo { get; set; }
        public Nullable<int> IdPunto_cargo { get; set; }
        public string IdUnidadMedida { get; set; }
        public string do_observacion { get; set; }
    
        public virtual com_solicitud_compra com_solicitud_compra { get; set; }
    }
}
