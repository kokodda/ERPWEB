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
    
    public partial class SPCXC_009_Result
    {
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public int IdBodega { get; set; }
        public decimal IdCbteVta { get; set; }
        public string vt_tipoDoc { get; set; }
        public string NumDocumento { get; set; }
        public System.DateTime vt_fecha { get; set; }
        public System.DateTime vt_fech_venc { get; set; }
        public string Su_Descripcion { get; set; }
        public decimal IdCliente { get; set; }
        public string pe_nombreCompleto { get; set; }
        public string pe_cedulaRuc { get; set; }
        public int IdVendedor { get; set; }
        public string Ve_Vendedor { get; set; }
        public Nullable<double> Total { get; set; }
        public Nullable<int> DiasVencido { get; set; }
        public double TotalCobrado { get; set; }
        public Nullable<double> Saldo { get; set; }
        public string vt_Observacion { get; set; }
        public Nullable<double> X_VENCER { get; set; }
        public Nullable<double> VENCIDO30 { get; set; }
        public Nullable<double> VENCIDO60 { get; set; }
        public Nullable<double> VENCIDO90 { get; set; }
        public Nullable<double> VENCIDO90MAS { get; set; }
    }
}
