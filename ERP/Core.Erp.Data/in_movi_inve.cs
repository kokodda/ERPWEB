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
    
    public partial class in_movi_inve
    {
        public in_movi_inve()
        {
            this.in_movi_inve_detalle = new HashSet<in_movi_inve_detalle>();
            this.in_movi_inve_x_ct_cbteCble = new HashSet<in_movi_inve_x_ct_cbteCble>();
        }
    
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public int IdBodega { get; set; }
        public int IdMovi_inven_tipo { get; set; }
        public decimal IdNumMovi { get; set; }
        public string CodMoviInven { get; set; }
        public string cm_tipo { get; set; }
        public string cm_observacion { get; set; }
        public System.DateTime cm_fecha { get; set; }
        public string Estado { get; set; }
        public Nullable<int> IdMotivo_Inv { get; set; }
    
        public virtual in_Motivo_Inven in_Motivo_Inven { get; set; }
        public virtual ICollection<in_movi_inve_detalle> in_movi_inve_detalle { get; set; }
        public virtual in_movi_inven_tipo in_movi_inven_tipo { get; set; }
        public virtual ICollection<in_movi_inve_x_ct_cbteCble> in_movi_inve_x_ct_cbteCble { get; set; }
    }
}
