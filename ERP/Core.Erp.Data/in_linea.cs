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
    
    public partial class in_linea
    {
        public in_linea()
        {
            this.in_grupo = new HashSet<in_grupo>();
        }
    
        public int IdEmpresa { get; set; }
        public string IdCategoria { get; set; }
        public int IdLinea { get; set; }
        public string cod_linea { get; set; }
        public string nom_linea { get; set; }
        public string observacion { get; set; }
        public string Estado { get; set; }
        public string IdUsuario { get; set; }
        public Nullable<System.DateTime> Fecha_Transac { get; set; }
        public string nom_pc { get; set; }
        public string ip { get; set; }
        public string MotiAnula { get; set; }
        public string IdUsuarioUltMod { get; set; }
        public Nullable<System.DateTime> Fecha_UltMod { get; set; }
        public string IdUsuarioUltAnu { get; set; }
        public Nullable<System.DateTime> Fecha_UltAnu { get; set; }
    
        public virtual in_categorias in_categorias { get; set; }
        public virtual ICollection<in_grupo> in_grupo { get; set; }
    }
}
