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
    
    public partial class ct_cbtecble_det
    {
        public int IdEmpresa { get; set; }
        public int IdTipoCbte { get; set; }
        public decimal IdCbteCble { get; set; }
        public int secuencia { get; set; }
        public string IdCtaCble { get; set; }
        public double dc_Valor { get; set; }
        public string dc_Observacion { get; set; }
        public Nullable<bool> dc_para_conciliar { get; set; }
        public Nullable<int> IdPunto_cargo_grupo { get; set; }
        public Nullable<int> IdPunto_cargo { get; set; }
        public string IdCentroCosto { get; set; }
    
        public virtual ct_cbtecble ct_cbtecble { get; set; }
        public virtual ct_CentroCosto ct_CentroCosto { get; set; }
        public virtual ct_plancta ct_plancta { get; set; }
        public virtual ct_punto_cargo ct_punto_cargo { get; set; }
        public virtual ct_punto_cargo_grupo ct_punto_cargo_grupo { get; set; }
    }
}
