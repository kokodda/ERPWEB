//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Erp.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class vwcxc_liquidacion_comisiones_det
    {
        public int IdEmpresa { get; set; }
        public decimal IdLiquidacion { get; set; }
        public Nullable<int> IdSucursal { get; set; }
        public Nullable<int> IdBodega { get; set; }
        public Nullable<decimal> IdCbteVta { get; set; }
        public string vt_tipoDoc { get; set; }
        public string vt_serie1 { get; set; }
        public string vt_serie2 { get; set; }
        public string vt_NumFactura { get; set; }
        public string Nombres { get; set; }
        public string Ve_Vendedor { get; set; }
        public string NomInterno { get; set; }
        public string nom_TerminoPago { get; set; }
        public Nullable<System.DateTime> vt_fecha { get; set; }
        public Nullable<System.DateTime> vt_fech_venc { get; set; }
        public double vt_Subtotal { get; set; }
        public double vt_iva { get; set; }
        public double vt_total { get; set; }
        public int IdVendedor { get; set; }
        public double PorComision { get; set; }
        public double SubtotalFactura { get; set; }
        public double IvaFactura { get; set; }
        public double TotalFactura { get; set; }
        public double TotalCobrado { get; set; }
        public double BaseComision { get; set; }
        public double PorcentajeComision { get; set; }
        public double TotalAComisionar { get; set; }
        public double TotalComisionado { get; set; }
        public double TotalLiquidacion { get; set; }
        public bool NoComisiona { get; set; }
    }
}