//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Erp.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class imp_orden_compra_ext
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public imp_orden_compra_ext()
        {
            this.imp_orden_compra_ext_ct_cbteble_det_gastos = new HashSet<imp_orden_compra_ext_ct_cbteble_det_gastos>();
            this.imp_orden_compra_ext_det = new HashSet<imp_orden_compra_ext_det>();
            this.imp_orden_compra_ext_recepcion = new HashSet<imp_orden_compra_ext_recepcion>();
            this.imp_liquidacion = new HashSet<imp_liquidacion>();
        }
    
        public int IdEmpresa { get; set; }
        public decimal IdOrdenCompra_ext { get; set; }
        public decimal IdProveedor { get; set; }
        public string IdPais_origen { get; set; }
        public string IdPais_embarque { get; set; }
        public string IdCiudad_destino { get; set; }
        public int IdCatalogo_via { get; set; }
        public int IdCatalogo_forma_pago { get; set; }
        public System.DateTime oe_fecha { get; set; }
        public Nullable<System.DateTime> oe_fecha_llegada_est { get; set; }
        public Nullable<System.DateTime> oe_fecha_embarque_est { get; set; }
        public Nullable<System.DateTime> oe_fecha_desaduanizacion_est { get; set; }
        public string IdCtaCble_importacion { get; set; }
        public string oe_observacion { get; set; }
        public string oe_codigo { get; set; }
        public bool estado { get; set; }
        public string IdUsuario_creacion { get; set; }
        public Nullable<System.DateTime> fecha_creacion { get; set; }
        public string IdUsuario_modificacion { get; set; }
        public Nullable<System.DateTime> fecha_modificacion { get; set; }
        public string IdUsuario_anulacion { get; set; }
        public Nullable<System.DateTime> fecha_anulacion { get; set; }
        public Nullable<System.DateTime> oe_fecha_llegada { get; set; }
        public Nullable<System.DateTime> oe_fecha_embarque { get; set; }
        public Nullable<System.DateTime> oe_fecha_desaduanizacion { get; set; }
        public Nullable<int> IdMoneda_origen { get; set; }
        public Nullable<int> IdMoneda_destino { get; set; }
        public bool Estado_cierre { get; set; }
    
        public virtual imp_catalogo imp_catalogo { get; set; }
        public virtual imp_catalogo imp_catalogo1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<imp_orden_compra_ext_ct_cbteble_det_gastos> imp_orden_compra_ext_ct_cbteble_det_gastos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<imp_orden_compra_ext_det> imp_orden_compra_ext_det { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<imp_orden_compra_ext_recepcion> imp_orden_compra_ext_recepcion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<imp_liquidacion> imp_liquidacion { get; set; }
    }
}
