﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Erp.Data.Facturacion.Base
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Entities_facturacion : DbContext
    {
        public Entities_facturacion()
            : base("name=Entities_facturacion")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<fa_CambioProducto> fa_CambioProducto { get; set; }
        public virtual DbSet<fa_CambioProductoDet> fa_CambioProductoDet { get; set; }
        public virtual DbSet<fa_CambioProductoDet_x_in_devolucion_inven> fa_CambioProductoDet_x_in_devolucion_inven { get; set; }
        public virtual DbSet<fa_catalogo> fa_catalogo { get; set; }
        public virtual DbSet<fa_catalogo_tipo> fa_catalogo_tipo { get; set; }
        public virtual DbSet<fa_cliente> fa_cliente { get; set; }
        public virtual DbSet<fa_cliente_contactos> fa_cliente_contactos { get; set; }
        public virtual DbSet<fa_cliente_tipo> fa_cliente_tipo { get; set; }
        public virtual DbSet<fa_cliente_x_fa_Vendedor_x_sucursal> fa_cliente_x_fa_Vendedor_x_sucursal { get; set; }
        public virtual DbSet<fa_cuotas_x_doc> fa_cuotas_x_doc { get; set; }
        public virtual DbSet<fa_factura_det> fa_factura_det { get; set; }
        public virtual DbSet<fa_factura_det_x_in_Ing_Egr_Inven_det> fa_factura_det_x_in_Ing_Egr_Inven_det { get; set; }
        public virtual DbSet<fa_factura_resumen> fa_factura_resumen { get; set; }
        public virtual DbSet<fa_factura_x_ct_cbtecble> fa_factura_x_ct_cbtecble { get; set; }
        public virtual DbSet<fa_factura_x_cxc_cobro> fa_factura_x_cxc_cobro { get; set; }
        public virtual DbSet<fa_factura_x_fa_guia_remision> fa_factura_x_fa_guia_remision { get; set; }
        public virtual DbSet<fa_factura_x_in_Ing_Egr_Inven> fa_factura_x_in_Ing_Egr_Inven { get; set; }
        public virtual DbSet<fa_formaPago> fa_formaPago { get; set; }
        public virtual DbSet<fa_guia_remision_det> fa_guia_remision_det { get; set; }
        public virtual DbSet<fa_guia_remision_det_x_factura> fa_guia_remision_det_x_factura { get; set; }
        public virtual DbSet<fa_MotivoTraslado> fa_MotivoTraslado { get; set; }
        public virtual DbSet<fa_NivelDescuento> fa_NivelDescuento { get; set; }
        public virtual DbSet<fa_notaCreDeb_det> fa_notaCreDeb_det { get; set; }
        public virtual DbSet<fa_notaCreDeb_resumen> fa_notaCreDeb_resumen { get; set; }
        public virtual DbSet<fa_notaCreDeb_x_ct_cbtecble> fa_notaCreDeb_x_ct_cbtecble { get; set; }
        public virtual DbSet<fa_notaCreDeb_x_cxc_cobro> fa_notaCreDeb_x_cxc_cobro { get; set; }
        public virtual DbSet<fa_notaCreDeb_x_fa_factura_NotaDeb> fa_notaCreDeb_x_fa_factura_NotaDeb { get; set; }
        public virtual DbSet<fa_parametro> fa_parametro { get; set; }
        public virtual DbSet<fa_proforma_det> fa_proforma_det { get; set; }
        public virtual DbSet<fa_PuntoVta> fa_PuntoVta { get; set; }
        public virtual DbSet<fa_TerminoPago> fa_TerminoPago { get; set; }
        public virtual DbSet<fa_TerminoPago_Distribucion> fa_TerminoPago_Distribucion { get; set; }
        public virtual DbSet<fa_TipoNota> fa_TipoNota { get; set; }
        public virtual DbSet<fa_Vendedor> fa_Vendedor { get; set; }
        public virtual DbSet<vwfa_CambioProducto> vwfa_CambioProducto { get; set; }
        public virtual DbSet<vwfa_CambioProductoDet> vwfa_CambioProductoDet { get; set; }
        public virtual DbSet<vwfa_CambioProductoDet_facturas> vwfa_CambioProductoDet_facturas { get; set; }
        public virtual DbSet<vwfa_CambioProductoDet_FacturasConMovimiento> vwfa_CambioProductoDet_FacturasConMovimiento { get; set; }
        public virtual DbSet<vwfa_cliente_contactos> vwfa_cliente_contactos { get; set; }
        public virtual DbSet<vwfa_factura_ParaContabilizar> vwfa_factura_ParaContabilizar { get; set; }
        public virtual DbSet<vwfa_factura_sin_automatico> vwfa_factura_sin_automatico { get; set; }
        public virtual DbSet<vwfa_proforma> vwfa_proforma { get; set; }
        public virtual DbSet<vwfa_proforma_det> vwfa_proforma_det { get; set; }
        public virtual DbSet<vwfa_proforma_det_por_facturar> vwfa_proforma_det_por_facturar { get; set; }
        public virtual DbSet<vwfa_proforma_det_por_guia> vwfa_proforma_det_por_guia { get; set; }
        public virtual DbSet<vwfa_PuntoVta> vwfa_PuntoVta { get; set; }
        public virtual DbSet<vwfa_cliente_consulta> vwfa_cliente_consulta { get; set; }
        public virtual DbSet<vwfa_factura> vwfa_factura { get; set; }
        public virtual DbSet<vwfa_factura_det> vwfa_factura_det { get; set; }
        public virtual DbSet<vwfa_factura_x_fa_guia_remision> vwfa_factura_x_fa_guia_remision { get; set; }
        public virtual DbSet<vwfa_guia_remision> vwfa_guia_remision { get; set; }
        public virtual DbSet<vwfa_notaCreDeb> vwfa_notaCreDeb { get; set; }
        public virtual DbSet<vwfa_notaCreDeb_det> vwfa_notaCreDeb_det { get; set; }
        public virtual DbSet<vwfa_notaCreDeb_x_fa_factura_NotaDeb> vwfa_notaCreDeb_x_fa_factura_NotaDeb { get; set; }
        public virtual DbSet<vwfa_factura_sin_guia> vwfa_factura_sin_guia { get; set; }
        public virtual DbSet<vwfa_guia_remision_det> vwfa_guia_remision_det { get; set; }
        public virtual DbSet<fa_factura> fa_factura { get; set; }
        public virtual DbSet<fa_guia_remision> fa_guia_remision { get; set; }
        public virtual DbSet<fa_notaCreDeb> fa_notaCreDeb { get; set; }
        public virtual DbSet<fa_proforma> fa_proforma { get; set; }
        public virtual DbSet<fa_ProbabilidadCobro> fa_ProbabilidadCobro { get; set; }
        public virtual DbSet<fa_ProbabilidadCobroDet> fa_ProbabilidadCobroDet { get; set; }
        public virtual DbSet<vwfa_ProbabilidadCobroDet> vwfa_ProbabilidadCobroDet { get; set; }
    
        public virtual int SPFAC_EliminarCobroEfectivo(Nullable<int> idEmpresa, Nullable<int> idSucursal, Nullable<int> idBodega, Nullable<decimal> idCbteVta)
        {
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            var idSucursalParameter = idSucursal.HasValue ?
                new ObjectParameter("IdSucursal", idSucursal) :
                new ObjectParameter("IdSucursal", typeof(int));
    
            var idBodegaParameter = idBodega.HasValue ?
                new ObjectParameter("IdBodega", idBodega) :
                new ObjectParameter("IdBodega", typeof(int));
    
            var idCbteVtaParameter = idCbteVta.HasValue ?
                new ObjectParameter("IdCbteVta", idCbteVta) :
                new ObjectParameter("IdCbteVta", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SPFAC_EliminarCobroEfectivo", idEmpresaParameter, idSucursalParameter, idBodegaParameter, idCbteVtaParameter);
        }
    }
}
