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
    
    public partial class vwfa_nota_debito_detalle
    {
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public int IdBodega { get; set; }
        public decimal IdNota { get; set; }
        public int Secuencia { get; set; }
        public decimal IdProducto { get; set; }
        public double sc_cantidad { get; set; }
        public double sc_Precio { get; set; }
        public double sc_descUni { get; set; }
        public double sc_PordescUni { get; set; }
        public double sc_precioFinal { get; set; }
        public double sc_subtotal { get; set; }
        public double sc_iva { get; set; }
        public double sc_total { get; set; }
        public double sc_costo { get; set; }
        public string sc_observacion { get; set; }
        public double vt_por_iva { get; set; }
        public string pr_codigo { get; set; }
        public string pr_codigo2 { get; set; }
        public string pr_descripcion { get; set; }
        public string pr_descripcion_2 { get; set; }
    }
}
