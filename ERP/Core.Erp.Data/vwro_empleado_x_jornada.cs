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
    
    public partial class vwro_empleado_x_jornada
    {
        public int IdEmpresa { get; set; }
        public decimal IdEmpleado { get; set; }
        public string Empleado { get; set; }
        public string em_status { get; set; }
        public Nullable<int> IdNomina { get; set; }
        public int IdSucursal { get; set; }
        public bool Pago_por_horas { get; set; }
        public Nullable<double> Valor_horas_matutino { get; set; }
        public Nullable<double> Valor_horas_vespertina { get; set; }
        public Nullable<double> Valor_horas_brigada { get; set; }
        public Nullable<double> Valor_hora_control_salida { get; set; }
        public Nullable<double> Valor_hora_adicionales { get; set; }
        public string pe_cedulaRuc { get; set; }
    }
}
