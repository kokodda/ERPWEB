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
    
    public partial class SPCXC_005_Result
    {
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public int IdBodega { get; set; }
        public decimal IdCbteVta { get; set; }
        public string vt_tipoDoc { get; set; }
        public string vt_NumFactura { get; set; }
        public decimal IdCliente { get; set; }
        public string NomCliente { get; set; }
        public System.DateTime vt_fecha { get; set; }
        public System.DateTime vt_fech_venc { get; set; }
        public Nullable<double> Subtotal { get; set; }
        public Nullable<double> IVA { get; set; }
        public Nullable<double> Total { get; set; }
        public double Cobrado { get; set; }
        public double NotaCredito { get; set; }
        public Nullable<double> Saldo { get; set; }
        public string Su_Descripcion { get; set; }
        public int Idtipo_cliente { get; set; }
        public string Descripcion_tip_cliente { get; set; }
    }
}