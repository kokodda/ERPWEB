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
    
    public partial class tb_sis_Impuesto
    {
        public tb_sis_Impuesto()
        {
            this.tb_sis_Impuesto_x_ctacble = new HashSet<tb_sis_Impuesto_x_ctacble>();
            this.tb_parametro = new HashSet<tb_parametro>();
        }
    
        public string IdCod_Impuesto { get; set; }
        public string nom_impuesto { get; set; }
        public bool Usado_en_Ventas { get; set; }
        public bool Usado_en_Compras { get; set; }
        public double porcentaje { get; set; }
        public Nullable<int> IdCodigo_SRI { get; set; }
        public bool estado { get; set; }
        public string IdTipoImpuesto { get; set; }
    
        public virtual tb_sis_Impuesto_Tipo tb_sis_Impuesto_Tipo { get; set; }
        public virtual ICollection<tb_sis_Impuesto_x_ctacble> tb_sis_Impuesto_x_ctacble { get; set; }
        public virtual ICollection<tb_parametro> tb_parametro { get; set; }
    }
}
