//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Erp.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class cxc_Catalogo
    {
        public string IdCatalogo { get; set; }
        public string IdCatalogo_tipo { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
        public Nullable<int> Orden { get; set; }
        public string IdUsuario { get; set; }
        public string IdUsuarioUltMod { get; set; }
        public Nullable<System.DateTime> FechaUltMod { get; set; }
        public string nom_pc { get; set; }
        public string ip { get; set; }
    
        public virtual cxc_CatalogoTipo cxc_CatalogoTipo { get; set; }
    }
}
