//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Erp.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class vwcxc_LiquidacionRetProvDet_PorCruzar
    {
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public decimal IdCobro { get; set; }
        public int secuencial { get; set; }
        public string IdCobro_tipo { get; set; }
        public double dc_ValorPago { get; set; }
        public string tc_descripcion { get; set; }
        public System.DateTime cr_fecha { get; set; }
        public string cr_observacion { get; set; }
        public Nullable<bool> cr_EsProvision { get; set; }
        public string cr_estado { get; set; }
        public string IdCtaCble { get; set; }
        public string pc_Cuenta { get; set; }
        public string ESRetenIVA { get; set; }
        public string ESRetenFTE { get; set; }
        public string cr_NumDocumento { get; set; }
        public Nullable<decimal> IdLiquidacion { get; set; }
        public string vt_NumFactura { get; set; }
        public string pe_nombreCompleto { get; set; }
    }
}
