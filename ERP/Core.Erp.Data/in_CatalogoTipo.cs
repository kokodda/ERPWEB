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
    
    public partial class in_CatalogoTipo
    {
        public in_CatalogoTipo()
        {
            this.in_Catalogo = new HashSet<in_Catalogo>();
        }
    
        public int IdCatalogo_tipo { get; set; }
        public string cod_Catalogo_tipo { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
    
        public virtual ICollection<in_Catalogo> in_Catalogo { get; set; }
    }
}
