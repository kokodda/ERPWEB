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
    
    public partial class SPCONTA_CierreAnual_Result
    {
        public int IdEmpresa { get; set; }
        public string IdCtaCble { get; set; }
        public long Secuencia { get; set; }
        public string Column1 { get; set; }
        public Nullable<double> dc_Valor { get; set; }
        public Nullable<double> dc_Valor_Debe { get; set; }
        public Nullable<double> dc_Valor_Haber { get; set; }
        public string IdCentroCosto { get; set; }
        public string cc_Descripcion { get; set; }
        public Nullable<int> IdPunto_cargo_grupo { get; set; }
        public string nom_punto_cargo_grupo { get; set; }
        public Nullable<int> IdPunto_cargo { get; set; }
        public string nom_punto_cargo { get; set; }
    }
}
