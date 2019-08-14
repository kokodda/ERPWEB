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
    
    public partial class fa_notaCreDeb
    {
        public fa_notaCreDeb()
        {
            this.fa_notaCreDeb_det = new HashSet<fa_notaCreDeb_det>();
            this.fa_notaCreDeb_x_ct_cbtecble = new HashSet<fa_notaCreDeb_x_ct_cbtecble>();
            this.fa_notaCreDeb_x_cxc_cobro = new HashSet<fa_notaCreDeb_x_cxc_cobro>();
            this.fa_notaCreDeb_x_fa_factura_NotaDeb = new HashSet<fa_notaCreDeb_x_fa_factura_NotaDeb>();
        }
    
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public int IdBodega { get; set; }
        public decimal IdNota { get; set; }
        public Nullable<int> dev_IdEmpresa { get; set; }
        public Nullable<decimal> dev_IdDev_Inven { get; set; }
        public string CodNota { get; set; }
        public string CreDeb { get; set; }
        public string CodDocumentoTipo { get; set; }
        public string Serie1 { get; set; }
        public string Serie2 { get; set; }
        public string NumNota_Impresa { get; set; }
        public string NumAutorizacion { get; set; }
        public Nullable<System.DateTime> Fecha_Autorizacion { get; set; }
        public decimal IdCliente { get; set; }
        public System.DateTime no_fecha { get; set; }
        public System.DateTime no_fecha_venc { get; set; }
        public int IdTipoNota { get; set; }
        public string sc_observacion { get; set; }
        public string IdUsuario { get; set; }
        public string IdUsuarioUltMod { get; set; }
        public Nullable<System.DateTime> Fecha_UltMod { get; set; }
        public string IdUsuarioUltAnu { get; set; }
        public Nullable<System.DateTime> Fecha_UltAnu { get; set; }
        public string MotiAnula { get; set; }
        public string Estado { get; set; }
        public string NaturalezaNota { get; set; }
        public string IdCtaCble_TipoNota { get; set; }
        public int IdPuntoVta { get; set; }
        public bool aprobada_enviar_sri { get; set; }
        public Nullable<bool> Generado { get; set; }
        public Nullable<int> IdVendedor { get; set; }
    
        public virtual ICollection<fa_notaCreDeb_det> fa_notaCreDeb_det { get; set; }
        public virtual fa_PuntoVta fa_PuntoVta { get; set; }
        public virtual fa_TipoNota fa_TipoNota { get; set; }
        public virtual fa_Vendedor fa_Vendedor { get; set; }
        public virtual ICollection<fa_notaCreDeb_x_ct_cbtecble> fa_notaCreDeb_x_ct_cbtecble { get; set; }
        public virtual ICollection<fa_notaCreDeb_x_cxc_cobro> fa_notaCreDeb_x_cxc_cobro { get; set; }
        public virtual ICollection<fa_notaCreDeb_x_fa_factura_NotaDeb> fa_notaCreDeb_x_fa_factura_NotaDeb { get; set; }
        public virtual fa_cliente fa_cliente { get; set; }
    }
}
