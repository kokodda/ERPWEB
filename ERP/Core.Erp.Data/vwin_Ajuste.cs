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
    
    public partial class vwin_Ajuste
    {
        public int IdEmpresa { get; set; }
        public decimal IdAjuste { get; set; }
        public int IdSucursal { get; set; }
        public int IdBodega { get; set; }
        public Nullable<int> IdMovi_inven_tipo_ing { get; set; }
        public Nullable<int> IdMovi_inven_tipo_egr { get; set; }
        public Nullable<decimal> IdNumMovi_ing { get; set; }
        public Nullable<decimal> IdNumMovi_egr { get; set; }
        public string IdCatalogo_Estado { get; set; }
        public bool Estado { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Observacion { get; set; }
        public string NombreEstado { get; set; }
        public string Su_Descripcion { get; set; }
        public string bo_Descripcion { get; set; }
    }
}