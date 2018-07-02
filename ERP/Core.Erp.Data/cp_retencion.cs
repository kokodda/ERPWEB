//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Erp.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class cp_retencion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cp_retencion()
        {
            this.cp_retencion_det = new HashSet<cp_retencion_det>();
            this.cp_retencion_x_ct_cbtecble = new HashSet<cp_retencion_x_ct_cbtecble>();
        }
    
        public int IdEmpresa { get; set; }
        public decimal IdRetencion { get; set; }
        public string CodDocumentoTipo { get; set; }
        public string serie1 { get; set; }
        public string serie2 { get; set; }
        public string NumRetencion { get; set; }
        public string NAutorizacion { get; set; }
        public Nullable<System.DateTime> Fecha_Autorizacion { get; set; }
        public System.DateTime fecha { get; set; }
        public string observacion { get; set; }
        public string re_Tiene_RTiva { get; set; }
        public string re_Tiene_RFuente { get; set; }
        public Nullable<int> IdEmpresa_Ogiro { get; set; }
        public Nullable<decimal> IdCbteCble_Ogiro { get; set; }
        public Nullable<int> IdTipoCbte_Ogiro { get; set; }
        public Nullable<int> ct_IdEmpresa_Anu { get; set; }
        public Nullable<int> ct_IdTipoCbte_Anu { get; set; }
        public Nullable<decimal> ct_IdCbteCble_Anu { get; set; }
        public string re_EstaImpresa { get; set; }
        public string Estado { get; set; }
        public string IdUsuario { get; set; }
        public System.DateTime Fecha_Transac { get; set; }
        public string IdUsuarioUltMod { get; set; }
        public Nullable<System.DateTime> Fecha_UltMod { get; set; }
        public string IdUsuarioUltAnu { get; set; }
        public string nom_pc { get; set; }
        public string ip { get; set; }
        public Nullable<System.DateTime> Fecha_UltAnu { get; set; }
        public string MotivoAnulacion { get; set; }
    
        public virtual cp_orden_giro cp_orden_giro { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cp_retencion_det> cp_retencion_det { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cp_retencion_x_ct_cbtecble> cp_retencion_x_ct_cbtecble { get; set; }
    }
}
