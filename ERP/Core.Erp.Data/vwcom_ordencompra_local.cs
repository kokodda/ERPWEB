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
    
    public partial class vwcom_ordencompra_local
    {
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public decimal IdOrdenCompra { get; set; }
        public string Codigo { get; set; }
        public string Su_Descripcion { get; set; }
        public System.DateTime oc_fecha { get; set; }
        public string pe_nombreCompleto { get; set; }
        public Nullable<double> Total { get; set; }
        public string IdEstadoAprobacion_cat { get; set; }
        public string EstadoAprobacion { get; set; }
        public string oc_observacion { get; set; }
        public string Descripcion { get; set; }
        public string IdEstado_cierre { get; set; }
        public string EstadoCierre { get; set; }
        public string Estado { get; set; }
        public string TerminoPago { get; set; }
        public int oc_plazo { get; set; }
    }
}
