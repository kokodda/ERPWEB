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
    
    public partial class ro_rubro_tipo_x_jornada
    {
        public int IdEmpresa { get; set; }
        public string IdRubro { get; set; }
        public int Secuencia { get; set; }
        public string IdRubroContabilizacion { get; set; }
        public int IdJornada { get; set; }
    
        public virtual ro_jornada ro_jornada { get; set; }
        public virtual ro_rubro_tipo ro_rubro_tipo { get; set; }
        public virtual ro_rubro_tipo ro_rubro_tipo1 { get; set; }
    }
}