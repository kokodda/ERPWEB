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
    
    public partial class SPFAC_002_Result
    {
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public int IdBodega { get; set; }
        public decimal IdCliente { get; set; }
        public string Codigo { get; set; }
        public decimal IdCbteVta { get; set; }
        public string CodCbteVta { get; set; }
        public string vt_tipoDoc { get; set; }
        public string vt_serie1 { get; set; }
        public string vt_serie2 { get; set; }
        public string vt_NumFactura { get; set; }
        public string Su_Descripcion { get; set; }
        public string pe_nombreCompleto { get; set; }
        public string pe_cedulaRuc { get; set; }
        public double Valor_Original { get; set; }
        public double Total_Pagado { get; set; }
        public double Valor_x_Vencer { get; set; }
        public double Valor_vencido { get; set; }
        public double Vencer_30_Dias { get; set; }
        public double Vencer_60_Dias { get; set; }
        public double Vencer_90_Dias { get; set; }
        public double Mayor_a_90Dias { get; set; }
        public System.DateTime vt_fech_venc { get; set; }
        public System.DateTime vt_fecha { get; set; }
        public int Idtipo_cliente { get; set; }
        public Nullable<int> Dias_Vencidos { get; set; }
        public decimal Saldo { get; set; }
        public string pe_telefonoOfic { get; set; }
        public string vt_Observacion { get; set; }
        public Nullable<decimal> vt_plazo { get; set; }
        public Nullable<int> IdContacto { get; set; }
        public string NomContacto { get; set; }
        public string TelefonoContacto { get; set; }
        public string Descripcion_tip_cliente { get; set; }
        public int Idtipo_cliente1 { get; set; }
    }
}
