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
    
    public partial class ro_HorasProfesores
    {
        public int IdEmpresa { get; set; }
        public decimal IdCarga { get; set; }
        public int IdNomina { get; set; }
        public int IdNominaTipo { get; set; }
        public int IdPeriodo { get; set; }
        public int IdSucursal { get; set; }
        public System.DateTime FechaCarga { get; set; }
        public string Observacion { get; set; }
        public string IdUsuario { get; set; }
        public bool Estado { get; set; }
        public System.DateTime Fecha_Transac { get; set; }
        public string IdUsuarioUltAnu { get; set; }
        public Nullable<System.DateTime> Fecha_UltAnu { get; set; }
        public string MotiAnula { get; set; }
    }
}
