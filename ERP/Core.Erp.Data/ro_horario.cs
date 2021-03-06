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
    
    public partial class ro_horario
    {
        public ro_horario()
        {
            this.ro_empleado_x_horario = new HashSet<ro_empleado_x_horario>();
            this.ro_horario_planificacion_det = new HashSet<ro_horario_planificacion_det>();
            this.ro_nomina_x_horas_extras_det = new HashSet<ro_nomina_x_horas_extras_det>();
        }
    
        public int IdEmpresa { get; set; }
        public decimal IdHorario { get; set; }
        public System.TimeSpan HoraIni { get; set; }
        public System.TimeSpan HoraFin { get; set; }
        public int ToleranciaEnt { get; set; }
        public int ToleranciaReg_lunh { get; set; }
        public System.TimeSpan SalLunch { get; set; }
        public System.TimeSpan RegLunch { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public string IdUsuario { get; set; }
        public Nullable<System.DateTime> Fecha_Transac { get; set; }
        public string IdUsuarioUltMod { get; set; }
        public Nullable<System.DateTime> Fecha_UltMod { get; set; }
        public string IdUsuarioUltAnu { get; set; }
        public Nullable<System.DateTime> Fecha_UltAnu { get; set; }
        public string nom_pc { get; set; }
        public string ip { get; set; }
        public string MotiAnula { get; set; }
    
        public virtual ICollection<ro_empleado_x_horario> ro_empleado_x_horario { get; set; }
        public virtual ICollection<ro_horario_planificacion_det> ro_horario_planificacion_det { get; set; }
        public virtual ICollection<ro_nomina_x_horas_extras_det> ro_nomina_x_horas_extras_det { get; set; }
    }
}
