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
    
    public partial class in_Ing_Egr_Inven_distribucion
    {
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public int IdMovi_inven_tipo { get; set; }
        public decimal IdNumMovi { get; set; }
        public int secuencia_distribucion { get; set; }
        public int IdEmpresa_dis { get; set; }
        public int IdSucursal_dis { get; set; }
        public int IdMovi_inven_tipo_dis { get; set; }
        public decimal IdNumMovi_dis { get; set; }
        public bool estado { get; set; }
        public string signo { get; set; }
    
        public virtual in_Ing_Egr_Inven in_Ing_Egr_Inven { get; set; }
        public virtual in_Ing_Egr_Inven in_Ing_Egr_Inven1 { get; set; }
    }
}
