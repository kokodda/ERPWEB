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
    
    public partial class vwin_Ing_Egr_Inven_det
    {
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public int IdMovi_inven_tipo { get; set; }
        public decimal IdNumMovi { get; set; }
        public int Secuencia { get; set; }
        public int IdBodega { get; set; }
        public decimal IdProducto { get; set; }
        public double dm_cantidad { get; set; }
        public string dm_observacion { get; set; }
        public double mv_costo { get; set; }
        public string IdCentroCosto { get; set; }
        public string IdCentroCosto_sub_centro_costo { get; set; }
        public string IdEstadoAproba { get; set; }
        public string IdUnidadMedida { get; set; }
        public Nullable<int> IdEmpresa_oc { get; set; }
        public Nullable<int> IdSucursal_oc { get; set; }
        public Nullable<decimal> IdOrdenCompra { get; set; }
        public Nullable<int> Secuencia_oc { get; set; }
        public Nullable<int> IdPunto_cargo_grupo { get; set; }
        public Nullable<int> IdPunto_cargo { get; set; }
        public Nullable<int> IdEmpresa_inv { get; set; }
        public Nullable<int> IdSucursal_inv { get; set; }
        public Nullable<int> IdBodega_inv { get; set; }
        public Nullable<int> IdMovi_inven_tipo_inv { get; set; }
        public Nullable<decimal> IdNumMovi_inv { get; set; }
        public Nullable<int> secuencia_inv { get; set; }
        public string Motivo_Aprobacion { get; set; }
        public double dm_cantidad_sinConversion { get; set; }
        public string IdUnidadMedida_sinConversion { get; set; }
        public Nullable<double> mv_costo_sinConversion { get; set; }
        public Nullable<int> IdMotivo_Inv { get; set; }
        public string pr_descripcion { get; set; }
        public string nom_presentacion { get; set; }
        public Nullable<System.DateTime> lote_fecha_vcto { get; set; }
        public string lote_num_lote { get; set; }
    }
}
