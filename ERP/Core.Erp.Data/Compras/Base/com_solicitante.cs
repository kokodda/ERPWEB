//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Erp.Data.Compras.Base
{
    using System;
    using System.Collections.Generic;
    
    public partial class com_solicitante
    {
        public int IdEmpresa { get; set; }
        public decimal IdSolicitante { get; set; }
        public string nom_solicitante { get; set; }
        public string estado { get; set; }
        public string cedula { get; set; }
        public Nullable<decimal> IdPersona { get; set; }
        public string IdUsuario { get; set; }
        public Nullable<System.DateTime> Fecha_Transac { get; set; }
        public string IdUsuarioUltMod { get; set; }
        public Nullable<System.DateTime> Fecha_UltMod { get; set; }
        public string IdUsuarioUltAnu { get; set; }
        public Nullable<System.DateTime> Fecha_UltAnu { get; set; }
        public string MotiAnula { get; set; }
    }
}
