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
    
    public partial class vwro_Historico_Liquidacion_Vacaciones
    {
        public int IdEmpresa { get; set; }
        public decimal IdEmpleado { get; set; }
        public int IdLiquidacion { get; set; }
        public string pe_apellido { get; set; }
        public string pe_nombre { get; set; }
        public double ValorCancelado { get; set; }
        public System.DateTime FechaPago { get; set; }
        public string Observaciones { get; set; }
        public int Dias_q_Corresponde { get; set; }
        public int Dias_a_disfrutar { get; set; }
        public int Dias_pendiente { get; set; }
        public string Periodo { get; set; }
        public string Estado { get; set; }
        public System.DateTime Anio_Desde { get; set; }
        public System.DateTime Anio_Hasta { get; set; }
        public System.DateTime Fecha_Desde { get; set; }
        public System.DateTime Fecha_Hasta { get; set; }
        public System.DateTime Fecha_Retorno { get; set; }
    }
}
