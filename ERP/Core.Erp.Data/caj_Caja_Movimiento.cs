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
    
    public partial class caj_Caja_Movimiento
    {
        public caj_Caja_Movimiento()
        {
            this.caj_Caja_Movimiento_det = new HashSet<caj_Caja_Movimiento_det>();
            this.cp_conciliacion_Caja_det_Ing_Caja = new HashSet<cp_conciliacion_Caja_det_Ing_Caja>();
            this.cp_conciliacion_Caja_det_x_ValeCaja = new HashSet<cp_conciliacion_Caja_det_x_ValeCaja>();
            this.cp_conciliacion_Caja = new HashSet<cp_conciliacion_Caja>();
        }
    
        public int IdEmpresa { get; set; }
        public decimal IdCbteCble { get; set; }
        public int IdTipocbte { get; set; }
        public string CodMoviCaja { get; set; }
        public string cm_Signo { get; set; }
        public double cm_valor { get; set; }
        public int IdTipoMovi { get; set; }
        public string cm_observacion { get; set; }
        public int IdCaja { get; set; }
        public int IdPeriodo { get; set; }
        public System.DateTime cm_fecha { get; set; }
        public string IdUsuario { get; set; }
        public string IdUsuario_Anu { get; set; }
        public Nullable<System.DateTime> FechaAnulacion { get; set; }
        public System.DateTime Fecha_Transac { get; set; }
        public Nullable<System.DateTime> Fecha_UltMod { get; set; }
        public string IdUsuarioUltMod { get; set; }
        public string Estado { get; set; }
        public string MotivoAnulacion { get; set; }
        public Nullable<decimal> IdTipoFlujo { get; set; }
        public string IdTipo_Persona { get; set; }
        public decimal IdEntidad { get; set; }
        public decimal IdPersona { get; set; }
    
        public virtual ICollection<caj_Caja_Movimiento_det> caj_Caja_Movimiento_det { get; set; }
        public virtual ICollection<cp_conciliacion_Caja_det_Ing_Caja> cp_conciliacion_Caja_det_Ing_Caja { get; set; }
        public virtual ICollection<cp_conciliacion_Caja_det_x_ValeCaja> cp_conciliacion_Caja_det_x_ValeCaja { get; set; }
        public virtual caj_Caja caj_Caja { get; set; }
        public virtual caj_Caja_Movimiento_Tipo caj_Caja_Movimiento_Tipo { get; set; }
        public virtual ICollection<cp_conciliacion_Caja> cp_conciliacion_Caja { get; set; }
    }
}
