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
    
    public partial class SPCONTA_002_Result
    {
        public int IdEmpresa { get; set; }
        public int IdTipoCbte { get; set; }
        public decimal IdCbteCble { get; set; }
        public int secuencia { get; set; }
        public string IdCtaCble { get; set; }
        public string pc_Cuenta { get; set; }
        public double dc_Valor { get; set; }
        public double SaldoInicial { get; set; }
        public double dc_Valor_Debe { get; set; }
        public Nullable<double> dc_Valor_Haber { get; set; }
        public Nullable<double> Saldo { get; set; }
        public Nullable<System.DateTime> cb_Fecha { get; set; }
        public string cb_Observacion { get; set; }
        public string cb_Estado { get; set; }
        public string tc_TipoCbte { get; set; }
        public Nullable<int> IdMes { get; set; }
        public string smes { get; set; }
        public Nullable<int> IdSucursal { get; set; }
        public string Su_Descripcion { get; set; }
        public string nom_punto_cargo { get; set; }
        public string nom_punto_cargo_grupo { get; set; }
    }
}
