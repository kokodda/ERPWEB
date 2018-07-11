﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Erp.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Entities_reportes : DbContext
    {
        public Entities_reportes()
            : base("name=Entities_reportes")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Af_SPACTF_004_detalle> Af_SPACTF_004_detalle { get; set; }
        public virtual DbSet<Af_SPACTF_004_resumen> Af_SPACTF_004_resumen { get; set; }
        public virtual DbSet<VWACTF_001> VWACTF_001 { get; set; }
        public virtual DbSet<VWACTF_002> VWACTF_002 { get; set; }
        public virtual DbSet<VWACTF_003> VWACTF_003 { get; set; }
        public virtual DbSet<VWCONTA_001> VWCONTA_001 { get; set; }
        public virtual DbSet<VWINV_001> VWINV_001 { get; set; }
        public virtual DbSet<VWINV_002> VWINV_002 { get; set; }
        public virtual DbSet<VWINV_004> VWINV_004 { get; set; }
        public virtual DbSet<VWROL_002> VWROL_002 { get; set; }
        public virtual DbSet<ro_SPROL_002> ro_SPROL_002 { get; set; }
        public virtual DbSet<VWCXP_001> VWCXP_001 { get; set; }
        public virtual DbSet<VWCXP_002> VWCXP_002 { get; set; }
        public virtual DbSet<VWCXP_002_diario> VWCXP_002_diario { get; set; }
        public virtual DbSet<VWROL_003> VWROL_003 { get; set; }
        public virtual DbSet<VWROL_004> VWROL_004 { get; set; }
        public virtual DbSet<VWROL_005> VWROL_005 { get; set; }
        public virtual DbSet<VWROL_006> VWROL_006 { get; set; }
        public virtual DbSet<VWROL_007> VWROL_007 { get; set; }
        public virtual DbSet<VWROL_008> VWROL_008 { get; set; }
        public virtual DbSet<VWBAN_001> VWBAN_001 { get; set; }
        public virtual DbSet<VWBAN_001_cancelaciones> VWBAN_001_cancelaciones { get; set; }
        public virtual DbSet<VWBAN_002> VWBAN_002 { get; set; }
        public virtual DbSet<VWBAN_002_cancelaciones> VWBAN_002_cancelaciones { get; set; }
        public virtual DbSet<VWBAN_003> VWBAN_003 { get; set; }
        public virtual DbSet<VWCAJ_002> VWCAJ_002 { get; set; }
        public virtual DbSet<VWCAJ_002_ingresos> VWCAJ_002_ingresos { get; set; }
        public virtual DbSet<VWCXP_003> VWCXP_003 { get; set; }
        public virtual DbSet<VWCXP_003_cancelaciones> VWCXP_003_cancelaciones { get; set; }
        public virtual DbSet<VWCXP_004> VWCXP_004 { get; set; }
        public virtual DbSet<VWCXP_005> VWCXP_005 { get; set; }
        public virtual DbSet<VWCXP_005_cancelaciones> VWCXP_005_cancelaciones { get; set; }
        public virtual DbSet<VWCXP_006> VWCXP_006 { get; set; }
        public virtual DbSet<VWCXP_006_diario> VWCXP_006_diario { get; set; }
        public virtual DbSet<VWINV_007> VWINV_007 { get; set; }
        public virtual DbSet<VWROL_009> VWROL_009 { get; set; }
        public virtual DbSet<VWROL_010> VWROL_010 { get; set; }
        public virtual DbSet<VWCXP_007> VWCXP_007 { get; set; }
        public virtual DbSet<VWROL_011> VWROL_011 { get; set; }
        public virtual DbSet<VWCXC_001> VWCXC_001 { get; set; }
        public virtual DbSet<VWCXC_001_diario> VWCXC_001_diario { get; set; }
        public virtual DbSet<VWFAC_001> VWFAC_001 { get; set; }
        public virtual DbSet<VWCAJ_001> VWCAJ_001 { get; set; }
        public virtual DbSet<VWFAC_003> VWFAC_003 { get; set; }
        public virtual DbSet<VWFAC_003_cuotas> VWFAC_003_cuotas { get; set; }
        public virtual DbSet<VWFAC_004> VWFAC_004 { get; set; }
        public virtual DbSet<VWCXC_002> VWCXC_002 { get; set; }
        public virtual DbSet<VWCXC_002_diario> VWCXC_002_diario { get; set; }
        public virtual DbSet<VWROL_001> VWROL_001 { get; set; }
        public virtual DbSet<VWROL_014> VWROL_014 { get; set; }
    
        public virtual ObjectResult<SPINV_001_Result> SPINV_001(Nullable<int> idEmpresa, Nullable<int> idSucursal_ini, Nullable<int> idSucursal_fin, Nullable<int> idBodega_ini, Nullable<int> idBodega_fin, Nullable<decimal> idProducto_ini, Nullable<decimal> idProducto_fin, string idCategoria, Nullable<int> idLinea, Nullable<int> idGrupo, Nullable<int> idSubGrupo, Nullable<System.DateTime> fecha_corte, Nullable<bool> mostrar_stock_0)
        {
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            var idSucursal_iniParameter = idSucursal_ini.HasValue ?
                new ObjectParameter("IdSucursal_ini", idSucursal_ini) :
                new ObjectParameter("IdSucursal_ini", typeof(int));
    
            var idSucursal_finParameter = idSucursal_fin.HasValue ?
                new ObjectParameter("IdSucursal_fin", idSucursal_fin) :
                new ObjectParameter("IdSucursal_fin", typeof(int));
    
            var idBodega_iniParameter = idBodega_ini.HasValue ?
                new ObjectParameter("IdBodega_ini", idBodega_ini) :
                new ObjectParameter("IdBodega_ini", typeof(int));
    
            var idBodega_finParameter = idBodega_fin.HasValue ?
                new ObjectParameter("IdBodega_fin", idBodega_fin) :
                new ObjectParameter("IdBodega_fin", typeof(int));
    
            var idProducto_iniParameter = idProducto_ini.HasValue ?
                new ObjectParameter("IdProducto_ini", idProducto_ini) :
                new ObjectParameter("IdProducto_ini", typeof(decimal));
    
            var idProducto_finParameter = idProducto_fin.HasValue ?
                new ObjectParameter("IdProducto_fin", idProducto_fin) :
                new ObjectParameter("IdProducto_fin", typeof(decimal));
    
            var idCategoriaParameter = idCategoria != null ?
                new ObjectParameter("IdCategoria", idCategoria) :
                new ObjectParameter("IdCategoria", typeof(string));
    
            var idLineaParameter = idLinea.HasValue ?
                new ObjectParameter("IdLinea", idLinea) :
                new ObjectParameter("IdLinea", typeof(int));
    
            var idGrupoParameter = idGrupo.HasValue ?
                new ObjectParameter("IdGrupo", idGrupo) :
                new ObjectParameter("IdGrupo", typeof(int));
    
            var idSubGrupoParameter = idSubGrupo.HasValue ?
                new ObjectParameter("IdSubGrupo", idSubGrupo) :
                new ObjectParameter("IdSubGrupo", typeof(int));
    
            var fecha_corteParameter = fecha_corte.HasValue ?
                new ObjectParameter("fecha_corte", fecha_corte) :
                new ObjectParameter("fecha_corte", typeof(System.DateTime));
    
            var mostrar_stock_0Parameter = mostrar_stock_0.HasValue ?
                new ObjectParameter("mostrar_stock_0", mostrar_stock_0) :
                new ObjectParameter("mostrar_stock_0", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SPINV_001_Result>("SPINV_001", idEmpresaParameter, idSucursal_iniParameter, idSucursal_finParameter, idBodega_iniParameter, idBodega_finParameter, idProducto_iniParameter, idProducto_finParameter, idCategoriaParameter, idLineaParameter, idGrupoParameter, idSubGrupoParameter, fecha_corteParameter, mostrar_stock_0Parameter);
        }
    
        public virtual int SPROL_002(Nullable<int> idempresa, Nullable<int> idnomina_tipo, Nullable<int> idnomina_Tipo_liq, Nullable<int> idperiodo)
        {
            var idempresaParameter = idempresa.HasValue ?
                new ObjectParameter("idempresa", idempresa) :
                new ObjectParameter("idempresa", typeof(int));
    
            var idnomina_tipoParameter = idnomina_tipo.HasValue ?
                new ObjectParameter("idnomina_tipo", idnomina_tipo) :
                new ObjectParameter("idnomina_tipo", typeof(int));
    
            var idnomina_Tipo_liqParameter = idnomina_Tipo_liq.HasValue ?
                new ObjectParameter("idnomina_Tipo_liq", idnomina_Tipo_liq) :
                new ObjectParameter("idnomina_Tipo_liq", typeof(int));
    
            var idperiodoParameter = idperiodo.HasValue ?
                new ObjectParameter("idperiodo", idperiodo) :
                new ObjectParameter("idperiodo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SPROL_002", idempresaParameter, idnomina_tipoParameter, idnomina_Tipo_liqParameter, idperiodoParameter);
        }
    
        public virtual ObjectResult<SPACTF_004_detalle_Result> SPACTF_004_detalle(Nullable<int> idEmpresa, Nullable<System.DateTime> fecha_corte, string idUsuario, Nullable<int> idActivoFijoTipo_ini, Nullable<int> idActivoFijoTipo_fin, Nullable<int> idCategoria_ini, Nullable<int> idCategoria_fin, string estado_Proceso)
        {
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            var fecha_corteParameter = fecha_corte.HasValue ?
                new ObjectParameter("Fecha_corte", fecha_corte) :
                new ObjectParameter("Fecha_corte", typeof(System.DateTime));
    
            var idUsuarioParameter = idUsuario != null ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(string));
    
            var idActivoFijoTipo_iniParameter = idActivoFijoTipo_ini.HasValue ?
                new ObjectParameter("IdActivoFijoTipo_ini", idActivoFijoTipo_ini) :
                new ObjectParameter("IdActivoFijoTipo_ini", typeof(int));
    
            var idActivoFijoTipo_finParameter = idActivoFijoTipo_fin.HasValue ?
                new ObjectParameter("IdActivoFijoTipo_fin", idActivoFijoTipo_fin) :
                new ObjectParameter("IdActivoFijoTipo_fin", typeof(int));
    
            var idCategoria_iniParameter = idCategoria_ini.HasValue ?
                new ObjectParameter("IdCategoria_ini", idCategoria_ini) :
                new ObjectParameter("IdCategoria_ini", typeof(int));
    
            var idCategoria_finParameter = idCategoria_fin.HasValue ?
                new ObjectParameter("IdCategoria_fin", idCategoria_fin) :
                new ObjectParameter("IdCategoria_fin", typeof(int));
    
            var estado_ProcesoParameter = estado_Proceso != null ?
                new ObjectParameter("Estado_Proceso", estado_Proceso) :
                new ObjectParameter("Estado_Proceso", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SPACTF_004_detalle_Result>("SPACTF_004_detalle", idEmpresaParameter, fecha_corteParameter, idUsuarioParameter, idActivoFijoTipo_iniParameter, idActivoFijoTipo_finParameter, idCategoria_iniParameter, idCategoria_finParameter, estado_ProcesoParameter);
        }
    
        public virtual ObjectResult<SPACTF_004_resumen_Result> SPACTF_004_resumen(Nullable<int> idEmpresa, Nullable<System.DateTime> fecha_corte, string idUsuario, Nullable<int> idActivoFijoTipo_ini, Nullable<int> idActivoFijoTipo_fin, Nullable<int> idCategoria_ini, Nullable<int> idCategoria_fin, string estado_Proceso)
        {
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            var fecha_corteParameter = fecha_corte.HasValue ?
                new ObjectParameter("Fecha_corte", fecha_corte) :
                new ObjectParameter("Fecha_corte", typeof(System.DateTime));
    
            var idUsuarioParameter = idUsuario != null ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(string));
    
            var idActivoFijoTipo_iniParameter = idActivoFijoTipo_ini.HasValue ?
                new ObjectParameter("IdActivoFijoTipo_ini", idActivoFijoTipo_ini) :
                new ObjectParameter("IdActivoFijoTipo_ini", typeof(int));
    
            var idActivoFijoTipo_finParameter = idActivoFijoTipo_fin.HasValue ?
                new ObjectParameter("IdActivoFijoTipo_fin", idActivoFijoTipo_fin) :
                new ObjectParameter("IdActivoFijoTipo_fin", typeof(int));
    
            var idCategoria_iniParameter = idCategoria_ini.HasValue ?
                new ObjectParameter("IdCategoria_ini", idCategoria_ini) :
                new ObjectParameter("IdCategoria_ini", typeof(int));
    
            var idCategoria_finParameter = idCategoria_fin.HasValue ?
                new ObjectParameter("IdCategoria_fin", idCategoria_fin) :
                new ObjectParameter("IdCategoria_fin", typeof(int));
    
            var estado_ProcesoParameter = estado_Proceso != null ?
                new ObjectParameter("Estado_Proceso", estado_Proceso) :
                new ObjectParameter("Estado_Proceso", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SPACTF_004_resumen_Result>("SPACTF_004_resumen", idEmpresaParameter, fecha_corteParameter, idUsuarioParameter, idActivoFijoTipo_iniParameter, idActivoFijoTipo_finParameter, idCategoria_iniParameter, idCategoria_finParameter, estado_ProcesoParameter);
        }
    
        public virtual ObjectResult<SPACTF_005_Result> SPACTF_005(Nullable<int> idEmpresa, Nullable<int> idActivoFijoTipo_ini, Nullable<int> idActivoFijoTipo_fin, Nullable<int> idCategoriaAF_ini, Nullable<int> idCategoriaAF_fin, Nullable<System.DateTime> fecha_corte, string estado_proceso)
        {
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            var idActivoFijoTipo_iniParameter = idActivoFijoTipo_ini.HasValue ?
                new ObjectParameter("IdActivoFijoTipo_ini", idActivoFijoTipo_ini) :
                new ObjectParameter("IdActivoFijoTipo_ini", typeof(int));
    
            var idActivoFijoTipo_finParameter = idActivoFijoTipo_fin.HasValue ?
                new ObjectParameter("IdActivoFijoTipo_fin", idActivoFijoTipo_fin) :
                new ObjectParameter("IdActivoFijoTipo_fin", typeof(int));
    
            var idCategoriaAF_iniParameter = idCategoriaAF_ini.HasValue ?
                new ObjectParameter("IdCategoriaAF_ini", idCategoriaAF_ini) :
                new ObjectParameter("IdCategoriaAF_ini", typeof(int));
    
            var idCategoriaAF_finParameter = idCategoriaAF_fin.HasValue ?
                new ObjectParameter("IdCategoriaAF_fin", idCategoriaAF_fin) :
                new ObjectParameter("IdCategoriaAF_fin", typeof(int));
    
            var fecha_corteParameter = fecha_corte.HasValue ?
                new ObjectParameter("Fecha_corte", fecha_corte) :
                new ObjectParameter("Fecha_corte", typeof(System.DateTime));
    
            var estado_procesoParameter = estado_proceso != null ?
                new ObjectParameter("Estado_proceso", estado_proceso) :
                new ObjectParameter("Estado_proceso", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SPACTF_005_Result>("SPACTF_005", idEmpresaParameter, idActivoFijoTipo_iniParameter, idActivoFijoTipo_finParameter, idCategoriaAF_iniParameter, idCategoriaAF_finParameter, fecha_corteParameter, estado_procesoParameter);
        }
    
        public virtual ObjectResult<SPINV_003_Result> SPINV_003(Nullable<int> idEmpresa, Nullable<int> idSucursal_ini, Nullable<int> idSucursal_fin, Nullable<int> idBodega_ini, Nullable<int> idBodega_fin, Nullable<decimal> idProducto_ini, Nullable<decimal> idProducto_fin, string idCategoria, Nullable<int> idLinea, Nullable<int> idGrupo, Nullable<int> idSubGrupo, Nullable<System.DateTime> fecha_corte, Nullable<bool> mostrar_stock_0)
        {
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            var idSucursal_iniParameter = idSucursal_ini.HasValue ?
                new ObjectParameter("IdSucursal_ini", idSucursal_ini) :
                new ObjectParameter("IdSucursal_ini", typeof(int));
    
            var idSucursal_finParameter = idSucursal_fin.HasValue ?
                new ObjectParameter("IdSucursal_fin", idSucursal_fin) :
                new ObjectParameter("IdSucursal_fin", typeof(int));
    
            var idBodega_iniParameter = idBodega_ini.HasValue ?
                new ObjectParameter("IdBodega_ini", idBodega_ini) :
                new ObjectParameter("IdBodega_ini", typeof(int));
    
            var idBodega_finParameter = idBodega_fin.HasValue ?
                new ObjectParameter("IdBodega_fin", idBodega_fin) :
                new ObjectParameter("IdBodega_fin", typeof(int));
    
            var idProducto_iniParameter = idProducto_ini.HasValue ?
                new ObjectParameter("IdProducto_ini", idProducto_ini) :
                new ObjectParameter("IdProducto_ini", typeof(decimal));
    
            var idProducto_finParameter = idProducto_fin.HasValue ?
                new ObjectParameter("IdProducto_fin", idProducto_fin) :
                new ObjectParameter("IdProducto_fin", typeof(decimal));
    
            var idCategoriaParameter = idCategoria != null ?
                new ObjectParameter("IdCategoria", idCategoria) :
                new ObjectParameter("IdCategoria", typeof(string));
    
            var idLineaParameter = idLinea.HasValue ?
                new ObjectParameter("IdLinea", idLinea) :
                new ObjectParameter("IdLinea", typeof(int));
    
            var idGrupoParameter = idGrupo.HasValue ?
                new ObjectParameter("IdGrupo", idGrupo) :
                new ObjectParameter("IdGrupo", typeof(int));
    
            var idSubGrupoParameter = idSubGrupo.HasValue ?
                new ObjectParameter("IdSubGrupo", idSubGrupo) :
                new ObjectParameter("IdSubGrupo", typeof(int));
    
            var fecha_corteParameter = fecha_corte.HasValue ?
                new ObjectParameter("fecha_corte", fecha_corte) :
                new ObjectParameter("fecha_corte", typeof(System.DateTime));
    
            var mostrar_stock_0Parameter = mostrar_stock_0.HasValue ?
                new ObjectParameter("mostrar_stock_0", mostrar_stock_0) :
                new ObjectParameter("mostrar_stock_0", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SPINV_003_Result>("SPINV_003", idEmpresaParameter, idSucursal_iniParameter, idSucursal_finParameter, idBodega_iniParameter, idBodega_finParameter, idProducto_iniParameter, idProducto_finParameter, idCategoriaParameter, idLineaParameter, idGrupoParameter, idSubGrupoParameter, fecha_corteParameter, mostrar_stock_0Parameter);
        }
    
        public virtual ObjectResult<SPINV_005_Result> SPINV_005(Nullable<int> idEmpresa, Nullable<int> idSucursal_ini, Nullable<int> idSucursal_fin, Nullable<int> idBodega_ini, Nullable<int> idBodega_fin, Nullable<decimal> idProducto_ini, Nullable<decimal> idProducto_fin, Nullable<System.DateTime> fecha_ini, Nullable<System.DateTime> fecha_fin, string idUsuario, Nullable<bool> no_Mostrar_valores_en_0, Nullable<bool> mostrar_detallado)
        {
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            var idSucursal_iniParameter = idSucursal_ini.HasValue ?
                new ObjectParameter("IdSucursal_ini", idSucursal_ini) :
                new ObjectParameter("IdSucursal_ini", typeof(int));
    
            var idSucursal_finParameter = idSucursal_fin.HasValue ?
                new ObjectParameter("IdSucursal_fin", idSucursal_fin) :
                new ObjectParameter("IdSucursal_fin", typeof(int));
    
            var idBodega_iniParameter = idBodega_ini.HasValue ?
                new ObjectParameter("IdBodega_ini", idBodega_ini) :
                new ObjectParameter("IdBodega_ini", typeof(int));
    
            var idBodega_finParameter = idBodega_fin.HasValue ?
                new ObjectParameter("IdBodega_fin", idBodega_fin) :
                new ObjectParameter("IdBodega_fin", typeof(int));
    
            var idProducto_iniParameter = idProducto_ini.HasValue ?
                new ObjectParameter("IdProducto_ini", idProducto_ini) :
                new ObjectParameter("IdProducto_ini", typeof(decimal));
    
            var idProducto_finParameter = idProducto_fin.HasValue ?
                new ObjectParameter("IdProducto_fin", idProducto_fin) :
                new ObjectParameter("IdProducto_fin", typeof(decimal));
    
            var fecha_iniParameter = fecha_ini.HasValue ?
                new ObjectParameter("Fecha_ini", fecha_ini) :
                new ObjectParameter("Fecha_ini", typeof(System.DateTime));
    
            var fecha_finParameter = fecha_fin.HasValue ?
                new ObjectParameter("Fecha_fin", fecha_fin) :
                new ObjectParameter("Fecha_fin", typeof(System.DateTime));
    
            var idUsuarioParameter = idUsuario != null ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(string));
    
            var no_Mostrar_valores_en_0Parameter = no_Mostrar_valores_en_0.HasValue ?
                new ObjectParameter("No_Mostrar_valores_en_0", no_Mostrar_valores_en_0) :
                new ObjectParameter("No_Mostrar_valores_en_0", typeof(bool));
    
            var mostrar_detalladoParameter = mostrar_detallado.HasValue ?
                new ObjectParameter("Mostrar_detallado", mostrar_detallado) :
                new ObjectParameter("Mostrar_detallado", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SPINV_005_Result>("SPINV_005", idEmpresaParameter, idSucursal_iniParameter, idSucursal_finParameter, idBodega_iniParameter, idBodega_finParameter, idProducto_iniParameter, idProducto_finParameter, fecha_iniParameter, fecha_finParameter, idUsuarioParameter, no_Mostrar_valores_en_0Parameter, mostrar_detalladoParameter);
        }
    
        public virtual ObjectResult<SPBAN_004_Result> SPBAN_004(Nullable<int> idEmpresa, Nullable<int> idBanco, Nullable<decimal> idConciliacion)
        {
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            var idBancoParameter = idBanco.HasValue ?
                new ObjectParameter("IdBanco", idBanco) :
                new ObjectParameter("IdBanco", typeof(int));
    
            var idConciliacionParameter = idConciliacion.HasValue ?
                new ObjectParameter("IdConciliacion", idConciliacion) :
                new ObjectParameter("IdConciliacion", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SPBAN_004_Result>("SPBAN_004", idEmpresaParameter, idBancoParameter, idConciliacionParameter);
        }
    
        public virtual ObjectResult<SPCXP_007_Result> SPCXP_007(Nullable<int> idEmpresa, Nullable<System.DateTime> fecha_ini, Nullable<System.DateTime> fecha_fin, Nullable<bool> mostrar_agrupado)
        {
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            var fecha_iniParameter = fecha_ini.HasValue ?
                new ObjectParameter("Fecha_ini", fecha_ini) :
                new ObjectParameter("Fecha_ini", typeof(System.DateTime));
    
            var fecha_finParameter = fecha_fin.HasValue ?
                new ObjectParameter("Fecha_fin", fecha_fin) :
                new ObjectParameter("Fecha_fin", typeof(System.DateTime));
    
            var mostrar_agrupadoParameter = mostrar_agrupado.HasValue ?
                new ObjectParameter("Mostrar_agrupado", mostrar_agrupado) :
                new ObjectParameter("Mostrar_agrupado", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SPCXP_007_Result>("SPCXP_007", idEmpresaParameter, fecha_iniParameter, fecha_finParameter, mostrar_agrupadoParameter);
        }
    
        public virtual ObjectResult<SPCXP_008_Result> SPCXP_008(Nullable<int> idempresa, Nullable<System.DateTime> fecha, Nullable<decimal> idProveedorIni, Nullable<decimal> idProveedorFIn)
        {
            var idempresaParameter = idempresa.HasValue ?
                new ObjectParameter("idempresa", idempresa) :
                new ObjectParameter("idempresa", typeof(int));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("fecha", fecha) :
                new ObjectParameter("fecha", typeof(System.DateTime));
    
            var idProveedorIniParameter = idProveedorIni.HasValue ?
                new ObjectParameter("idProveedorIni", idProveedorIni) :
                new ObjectParameter("idProveedorIni", typeof(decimal));
    
            var idProveedorFInParameter = idProveedorFIn.HasValue ?
                new ObjectParameter("idProveedorFIn", idProveedorFIn) :
                new ObjectParameter("idProveedorFIn", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SPCXP_008_Result>("SPCXP_008", idempresaParameter, fechaParameter, idProveedorIniParameter, idProveedorFInParameter);
        }
    
        public virtual ObjectResult<SPCONTA_002_Result> SPCONTA_002(Nullable<int> idEmpresa, string idCtaCble, Nullable<System.DateTime> fechaIni, Nullable<System.DateTime> fechaFin)
        {
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            var idCtaCbleParameter = idCtaCble != null ?
                new ObjectParameter("IdCtaCble", idCtaCble) :
                new ObjectParameter("IdCtaCble", typeof(string));
    
            var fechaIniParameter = fechaIni.HasValue ?
                new ObjectParameter("FechaIni", fechaIni) :
                new ObjectParameter("FechaIni", typeof(System.DateTime));
    
            var fechaFinParameter = fechaFin.HasValue ?
                new ObjectParameter("FechaFin", fechaFin) :
                new ObjectParameter("FechaFin", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SPCONTA_002_Result>("SPCONTA_002", idEmpresaParameter, idCtaCbleParameter, fechaIniParameter, fechaFinParameter);
        }
    
        public virtual ObjectResult<SPROL_012_Result> SPROL_012(Nullable<int> idEmpresa, Nullable<System.DateTime> fecha_desde, Nullable<System.DateTime> fecha_hasta)
        {
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            var fecha_desdeParameter = fecha_desde.HasValue ?
                new ObjectParameter("Fecha_desde", fecha_desde) :
                new ObjectParameter("Fecha_desde", typeof(System.DateTime));
    
            var fecha_hastaParameter = fecha_hasta.HasValue ?
                new ObjectParameter("Fecha_hasta", fecha_hasta) :
                new ObjectParameter("Fecha_hasta", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SPROL_012_Result>("SPROL_012", idEmpresaParameter, fecha_desdeParameter, fecha_hastaParameter);
        }
    
        public virtual ObjectResult<SPROL_013_Result> SPROL_013(Nullable<int> idempresa, Nullable<int> idnomina, Nullable<System.DateTime> fecha_inicio, Nullable<System.DateTime> fecha_fin)
        {
            var idempresaParameter = idempresa.HasValue ?
                new ObjectParameter("idempresa", idempresa) :
                new ObjectParameter("idempresa", typeof(int));
    
            var idnominaParameter = idnomina.HasValue ?
                new ObjectParameter("idnomina", idnomina) :
                new ObjectParameter("idnomina", typeof(int));
    
            var fecha_inicioParameter = fecha_inicio.HasValue ?
                new ObjectParameter("fecha_inicio", fecha_inicio) :
                new ObjectParameter("fecha_inicio", typeof(System.DateTime));
    
            var fecha_finParameter = fecha_fin.HasValue ?
                new ObjectParameter("fecha_fin", fecha_fin) :
                new ObjectParameter("fecha_fin", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SPROL_013_Result>("SPROL_013", idempresaParameter, idnominaParameter, fecha_inicioParameter, fecha_finParameter);
        }
    
        public virtual ObjectResult<SPFAC_002_Result> SPFAC_002(Nullable<int> idEmpresa, Nullable<int> sucursalIni, Nullable<int> sucursalFin, Nullable<decimal> idClienteIni, Nullable<decimal> idClienteFin, Nullable<int> idClienteContactoIni, Nullable<int> idClienteContactoFin, Nullable<System.DateTime> fechaCorte)
        {
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            var sucursalIniParameter = sucursalIni.HasValue ?
                new ObjectParameter("SucursalIni", sucursalIni) :
                new ObjectParameter("SucursalIni", typeof(int));
    
            var sucursalFinParameter = sucursalFin.HasValue ?
                new ObjectParameter("SucursalFin", sucursalFin) :
                new ObjectParameter("SucursalFin", typeof(int));
    
            var idClienteIniParameter = idClienteIni.HasValue ?
                new ObjectParameter("IdClienteIni", idClienteIni) :
                new ObjectParameter("IdClienteIni", typeof(decimal));
    
            var idClienteFinParameter = idClienteFin.HasValue ?
                new ObjectParameter("IdClienteFin", idClienteFin) :
                new ObjectParameter("IdClienteFin", typeof(decimal));
    
            var idClienteContactoIniParameter = idClienteContactoIni.HasValue ?
                new ObjectParameter("IdClienteContactoIni", idClienteContactoIni) :
                new ObjectParameter("IdClienteContactoIni", typeof(int));
    
            var idClienteContactoFinParameter = idClienteContactoFin.HasValue ?
                new ObjectParameter("IdClienteContactoFin", idClienteContactoFin) :
                new ObjectParameter("IdClienteContactoFin", typeof(int));
    
            var fechaCorteParameter = fechaCorte.HasValue ?
                new ObjectParameter("fechaCorte", fechaCorte) :
                new ObjectParameter("fechaCorte", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SPFAC_002_Result>("SPFAC_002", idEmpresaParameter, sucursalIniParameter, sucursalFinParameter, idClienteIniParameter, idClienteFinParameter, idClienteContactoIniParameter, idClienteContactoFinParameter, fechaCorteParameter);
        }
    }
}
