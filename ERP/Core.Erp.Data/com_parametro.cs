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
    
    public partial class com_parametro
    {
        public int IdEmpresa { get; set; }
        public string IdEstadoAprobacion_OC { get; set; }
        public int IdMovi_inven_tipo_OC { get; set; }
        public string IdEstadoAnulacion_OC { get; set; }
        public string IdEstado_cierre { get; set; }
        public int DiasTransaccionesAFuturo { get; set; }
    
        public virtual com_catalogo com_catalogo { get; set; }
        public virtual com_catalogo com_catalogo1 { get; set; }
        public virtual com_estado_cierre com_estado_cierre { get; set; }
    }
}
