//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Erp.Data.Reportes.Base
{
    using System;
    using System.Collections.Generic;
    
    public partial class VWCXP_009
    {
        public int IdEmpresa { get; set; }
        public int IdTipoCbte_Ogiro { get; set; }
        public decimal IdCbteCble_Ogiro { get; set; }
        public decimal IdRetencion { get; set; }
        public int Idsecuencia { get; set; }
        public string IdOrden_giro_Tipo { get; set; }
        public decimal IdProveedor { get; set; }
        public string nom_proveedor { get; set; }
        public string ced_proveedor { get; set; }
        public string dir_proveedor { get; set; }
        public System.DateTime co_fechaOg { get; set; }
        public string co_serie { get; set; }
        public string num_factura { get; set; }
        public System.DateTime co_FechaFactura { get; set; }
        public string Estado { get; set; }
        public string TipoDocumento { get; set; }
        public System.DateTime fecha_retencion { get; set; }
        public Nullable<int> ejercicio_fiscal { get; set; }
        public string Impuesto { get; set; }
        public double base_retencion { get; set; }
        public int IdCodigo_SRI { get; set; }
        public string cod_Impuesto_SRI { get; set; }
        public double por_Retencion_SRI { get; set; }
        public double valor_Retenido { get; set; }
        public int IdEmpresa_Ogiro { get; set; }
        public string serie { get; set; }
        public string NumRetencion { get; set; }
        public string co_descripcion { get; set; }
        public string IdCtaCble { get; set; }
        public Nullable<decimal> IdCbteCbleRet { get; set; }
        public string co_observacion { get; set; }
        public int IdSucursal { get; set; }
        public string Su_Descripcion { get; set; }
        public Nullable<bool> es_Documento_Electronico { get; set; }
    }
}
