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
    
    public partial class com_solicitud_compra
    {
        public com_solicitud_compra()
        {
            this.com_solicitud_compra_det = new HashSet<com_solicitud_compra_det>();
        }
    
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public decimal IdSolicitudCompra { get; set; }
        public string NumDocumento { get; set; }
        public decimal IdSolicitante { get; set; }
        public decimal IdComprador { get; set; }
        public decimal IdDepartamento { get; set; }
        public System.DateTime fecha { get; set; }
        public int plazo { get; set; }
        public System.DateTime fecha_vtc { get; set; }
        public string observacion { get; set; }
        public string Estado { get; set; }
        public Nullable<System.DateTime> Fecha_Transac { get; set; }
        public Nullable<System.DateTime> Fecha_UltMod { get; set; }
        public string IdUsuarioUltMod { get; set; }
        public Nullable<System.DateTime> FechaHoraAnul { get; set; }
        public string IdUsuarioUltAnu { get; set; }
        public string MotivoAnulacion { get; set; }
        public string IdEstadoAprobacion { get; set; }
        public string IdUsuarioAprobo { get; set; }
        public string MotivoAprobacion { get; set; }
        public Nullable<System.DateTime> FechaHoraAprobacion { get; set; }
    
        public virtual com_catalogo com_catalogo { get; set; }
        public virtual com_comprador com_comprador { get; set; }
        public virtual com_departamento com_departamento { get; set; }
        public virtual ICollection<com_solicitud_compra_det> com_solicitud_compra_det { get; set; }
    }
}