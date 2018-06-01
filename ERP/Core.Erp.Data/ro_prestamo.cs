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
    
    public partial class ro_prestamo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ro_prestamo()
        {
            this.ro_prestamo_detalle = new HashSet<ro_prestamo_detalle>();
        }
    
        public int IdEmpresa { get; set; }
        public decimal IdPrestamo { get; set; }
        public decimal IdEmpleado { get; set; }
        public string IdRubro { get; set; }
        public decimal IdEmpleado_Aprueba { get; set; }
        public bool descuento_mensual { get; set; }
        public bool descuento_quincena { get; set; }
        public bool descuento_men_quin { get; set; }
        public string Estado { get; set; }
        public System.DateTime Fecha { get; set; }
        public double MontoSol { get; set; }
        public double TasaInteres { get; set; }
        public double TotalPrestamo { get; set; }
        public int NumCuotas { get; set; }
        public System.DateTime Fecha_PriPago { get; set; }
        public string Observacion { get; set; }
        public string Tipo_Calculo { get; set; }
        public string IdUsuario { get; set; }
        public System.DateTime Fecha_Transac { get; set; }
        public string IdUsuarioUltMod { get; set; }
        public Nullable<System.DateTime> Fecha_UltMod { get; set; }
        public string IdUsuarioUltAnu { get; set; }
        public Nullable<System.DateTime> Fecha_UltAnu { get; set; }
        public string nom_pc { get; set; }
        public string ip { get; set; }
        public string MotiAnula { get; set; }
        public Nullable<int> IdTipoCbte { get; set; }
        public Nullable<decimal> IdCbteCble { get; set; }
        public Nullable<decimal> IdOrdenPago { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ro_prestamo_detalle> ro_prestamo_detalle { get; set; }
        public virtual ro_empleado ro_empleado { get; set; }
    }
}
