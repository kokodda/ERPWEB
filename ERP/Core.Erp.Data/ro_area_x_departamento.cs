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
    
    public partial class ro_area_x_departamento
    {
        public int IdEmpresa { get; set; }
        public int Secuencia { get; set; }
        public int IdDivision { get; set; }
        public int IdArea { get; set; }
        public int IdDepartamento { get; set; }
    
        public virtual ro_area ro_area { get; set; }
        public virtual ro_Departamento ro_Departamento { get; set; }
    }
}
