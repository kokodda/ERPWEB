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
    
    public partial class vwro_SancionesPorMarcaciones
    {
        public int IdEmpresa { get; set; }
        public int IdAjuste { get; set; }
        public int IdNomina_Tipo { get; set; }
        public int IdNomina_TipoLiqui { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public System.DateTime FecaFin { get; set; }
        public string Observacion { get; set; }
        public bool Estado { get; set; }
        public string DescripcionProcesoNomina { get; set; }
        public string Descripcion { get; set; }
    }
}