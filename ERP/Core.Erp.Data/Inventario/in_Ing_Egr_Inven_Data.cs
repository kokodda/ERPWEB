﻿using Core.Erp.Data.Contabilidad;
using Core.Erp.Info.Contabilidad;
using Core.Erp.Info.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Data.Inventario
{
    public class in_Ing_Egr_Inven_Data
    {
        ct_cbtecble_Data odata_ct = new ct_cbtecble_Data();
        in_producto_x_tb_bodega_Costo_Historico_Data data_costo = new in_producto_x_tb_bodega_Costo_Historico_Data();
        public List<in_Ing_Egr_Inven_Info> get_list (int IdEmpresa, string signo,int IdSucursal, bool mostrar_anulados, DateTime fecha_ini, DateTime fecha_fin)
        {
            try
            {
                fecha_ini = fecha_ini.Date;
                fecha_fin = fecha_fin.Date;
                int IdSucursalIni = IdSucursal;
                int IdSucursalFin = IdSucursal == 0 ? 9999 : IdSucursal;
                List<in_Ing_Egr_Inven_Info> Lista;
                using (Entities_inventario Context = new Entities_inventario())
                {
                    if (mostrar_anulados)
                        Lista = (from q in Context.in_Ing_Egr_Inven
                                 join t in Context.in_movi_inven_tipo
                                 on new { q.IdEmpresa, q.IdMovi_inven_tipo} equals new { t.IdEmpresa, t.IdMovi_inven_tipo}
                                 where q.IdEmpresa == IdEmpresa
                                 && q.signo == signo 
                                 && IdSucursalIni <= q.IdSucursal
                                 && q.IdSucursal <= IdSucursalFin
                                 && fecha_ini <= q.cm_fecha && q.cm_fecha <= fecha_fin
                                 orderby new { q.cm_fecha } descending
                                 select new in_Ing_Egr_Inven_Info
                                 {
                                     IdEmpresa = q.IdEmpresa,
                                     IdSucursal = q.IdSucursal,
                                     IdMovi_inven_tipo = q.IdMovi_inven_tipo,
                                     IdBodega = q.IdBodega,
                                     IdNumMovi = q.IdNumMovi,
                                     IdMotivo_Inv = q.IdMotivo_Inv,
                                     Estado = q.Estado,
                                     signo = q.signo,
                                     cm_observacion = q.cm_observacion,
                                     CodMoviInven = q.CodMoviInven,
                                     cm_fecha = q.cm_fecha,
                                     tm_descripcion = t.tm_descripcion,

                                     EstadoBool = q.Estado == "A" ? true : false

                                 }).ToList();

                    else
                        Lista = (from q in Context.in_Ing_Egr_Inven
                                 join t in Context.in_movi_inven_tipo
                                 on new { q.IdEmpresa, q.IdMovi_inven_tipo } equals new { t.IdEmpresa, t.IdMovi_inven_tipo }
                                 where q.IdEmpresa == IdEmpresa
                                 && q.signo == signo
                                 && IdSucursalIni <= q.IdSucursal
                                 && q.IdSucursal <= IdSucursalFin
                                 && fecha_ini <= q.cm_fecha && q.cm_fecha <= fecha_fin
                                 && q.Estado == "A"
                                 orderby new { q.cm_fecha } descending
                                 select new in_Ing_Egr_Inven_Info
                                 {
                                     IdEmpresa = q.IdEmpresa,
                                     IdSucursal = q.IdSucursal,
                                     IdMovi_inven_tipo = q.IdMovi_inven_tipo,
                                     IdBodega = q.IdBodega,
                                     IdNumMovi = q.IdNumMovi,
                                     IdMotivo_Inv = q.IdMotivo_Inv,
                                     Estado = q.Estado,
                                     signo = q.signo,
                                     cm_observacion = q.cm_observacion,
                                     CodMoviInven = q.CodMoviInven,
                                     cm_fecha = q.cm_fecha,
                                     tm_descripcion = t.tm_descripcion,

                                     EstadoBool = q.Estado == "A" ? true : false
                                 }).ToList();
                }
                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public in_Ing_Egr_Inven_Info get_info(int IdEmpresa, int IdSucursal, int IdMovi_inven_tipo, decimal IdNumMovi)
        {
            try
            {
                in_Ing_Egr_Inven_Info info = new in_Ing_Egr_Inven_Info();
                using (Entities_inventario Context = new Entities_inventario())
                {
                    in_Ing_Egr_Inven Entity = Context.in_Ing_Egr_Inven.FirstOrDefault(q => q.IdEmpresa == IdEmpresa && q.IdSucursal == IdSucursal && q.IdMovi_inven_tipo == IdMovi_inven_tipo && q.IdNumMovi == IdNumMovi);
                    if (Entity == null) return null;
                    info = new in_Ing_Egr_Inven_Info
                    {
                        IdEmpresa = Entity.IdEmpresa,
                        IdSucursal = Entity.IdSucursal,
                        IdMovi_inven_tipo = Entity.IdMovi_inven_tipo,
                        IdBodega = Entity.IdBodega,
                        IdNumMovi = Entity.IdNumMovi,
                        IdMotivo_Inv = Entity.IdMotivo_Inv,
                        cm_fecha = Entity.cm_fecha,
                        cm_observacion = Entity.cm_observacion,
                        CodMoviInven = Entity.CodMoviInven,
                        Estado = Entity.Estado,
                        IdResponsable = Entity.IdResponsable,
                        signo = Entity.signo
                    };
                }
                return info;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private decimal get_id(int IdEmpresa, int IdSucursal, int IdMovi_inven_tipo)
        {
            try
            {
                decimal ID = 1;
                using (Entities_inventario Context = new Entities_inventario())
                {
                    var lst = from q in Context.in_Ing_Egr_Inven
                              where q.IdEmpresa == IdEmpresa
                              && q.IdSucursal == IdSucursal
                              && q.IdMovi_inven_tipo == IdMovi_inven_tipo
                              select q;
                    if (lst.Count() > 0)
                        ID = lst.Max(q => q.IdNumMovi) + 1;
                }
                return ID;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool guardarDB(in_Ing_Egr_Inven_Info info, string signo)
        {
            try
            {
                int sec = 1;
                using (Entities_inventario Context = new Entities_inventario())
                {
                    in_Ing_Egr_Inven Entity = new in_Ing_Egr_Inven
                    {
                        IdEmpresa = info.IdEmpresa,
                        IdSucursal = info.IdSucursal,
                        IdMovi_inven_tipo = info.IdMovi_inven_tipo,
                        IdNumMovi = info.IdNumMovi = get_id(info.IdEmpresa, info.IdSucursal, info.IdMovi_inven_tipo),
                        IdBodega = info.IdBodega,
                        IdMotivo_Inv = info.IdMotivo_Inv,
                        cm_fecha = info.cm_fecha.Date,
                        cm_observacion = info.cm_observacion,
                        CodMoviInven = info.CodMoviInven,
                        Estado = info.Estado = "A",
                        IdResponsable = info.IdResponsable,
                        signo = info.signo,

                        IdUsuario = info.IdUsuario,
                        Fecha_Transac = DateTime.Now
                    };
                    Context.in_Ing_Egr_Inven.Add(Entity);

                    foreach (var item in info.lst_in_Ing_Egr_Inven_det)
                    {
                        if (signo == "-")
                            item.mv_costo_sinConversion = data_costo.get_ultimo_costo(info.IdEmpresa, info.IdSucursal, Convert.ToInt32(info.IdBodega), item.IdProducto, info.cm_fecha);
                        in_Ing_Egr_Inven_det entity_det = new in_Ing_Egr_Inven_det
                        {
                            
                            IdEmpresa = info.IdEmpresa,
                            IdSucursal = info.IdSucursal,
                            IdMovi_inven_tipo = info.IdMovi_inven_tipo,
                            IdNumMovi = info.IdNumMovi,
                            Secuencia = item.Secuencia = sec,
                            IdBodega =(int) info.IdBodega,
                            IdProducto = item.IdProducto,

                            IdCentroCosto = item.IdCentroCosto,
                            IdCentroCosto_sub_centro_costo = item.IdCentroCosto_sub_centro_costo,
                            IdPunto_cargo = item.IdPunto_cargo,
                            IdPunto_cargo_grupo = item.IdPunto_cargo_grupo,

                            dm_observacion = item.dm_observacion,
                            IdMotivo_Inv = info.IdMotivo_Inv,
                            IdEstadoAproba = "APRO",
                            Motivo_Aprobacion = item.Motivo_Aprobacion,

                            IdEmpresa_oc = item.IdEmpresa_oc,
                            IdSucursal_oc = item.IdSucursal_oc,
                            IdOrdenCompra = item.IdOrdenCompra,
                            Secuencia_oc = item.Secuencia_oc,

                            IdEmpresa_inv = item.IdEmpresa_inv,
                            IdSucursal_inv = item.IdSucursal_inv,
                            IdBodega_inv = item.IdBodega_inv,
                            IdMovi_inven_tipo_inv = item.IdMovi_inven_tipo_inv,
                            IdNumMovi_inv = item.IdNumMovi_inv,
                            secuencia_inv = item.secuencia_inv,

                            dm_cantidad_sinConversion = Math.Abs(item.dm_cantidad_sinConversion) * (info.signo == "-" ? -1 : 1),
                            dm_cantidad = Math.Abs(item.dm_cantidad_sinConversion) * (info.signo == "-" ? -1 : 1),

                            IdUnidadMedida  = (item.IdUnidadMedida_sinConversion) ==null? "UNID":item.IdUnidadMedida_sinConversion,
                            IdUnidadMedida_sinConversion = (item.IdUnidadMedida_sinConversion) == null ? "UNID" : item.IdUnidadMedida_sinConversion,

                            mv_costo_sinConversion = (item.mv_costo_sinConversion) == null ? 0 : item.mv_costo_sinConversion,
                            mv_costo = (item.mv_costo_sinConversion) == null ? 0 : Convert.ToDouble(item.mv_costo_sinConversion),

                        };
                        Context.in_Ing_Egr_Inven_det.Add(entity_det);
                        sec++;
                    }
                    Context.SaveChanges();

                    // ejecutando el sp para in_movi_det
                    Context.spINV_aprobacion_ing_egr(info.IdEmpresa, info.IdSucursal, info.IdBodega, info.IdMovi_inven_tipo, info.IdNumMovi);
                }
                Contabilizar(info.IdEmpresa, info.IdSucursal, info.IdMovi_inven_tipo, info.IdNumMovi, info.cm_observacion, info.cm_fecha);
                return true;
            }
            catch (Exception )
            {

                throw;
            }
        }
        public bool modificarDB(in_Ing_Egr_Inven_Info info)
        {
            try
            {
                int sec = 1;
                //Reversar_Aprobacion(info.IdEmpresa, info.IdSucursal, info.IdMovi_inven_tipo, info.IdNumMovi, "");
                ReversarAprobacion(info.IdEmpresa, info.IdSucursal, info.IdMovi_inven_tipo, info.IdNumMovi);

                using (Entities_inventario Context = new Entities_inventario())
                {
                    in_Ing_Egr_Inven Entity = Context.in_Ing_Egr_Inven.FirstOrDefault(q => q.IdEmpresa == info.IdEmpresa && q.IdSucursal == info.IdSucursal && q.IdMovi_inven_tipo == info.IdMovi_inven_tipo && q.IdNumMovi == info.IdNumMovi);
                    if (Entity == null) return false;

                    Entity.cm_observacion = info.cm_observacion;
                    Entity.CodMoviInven = info.CodMoviInven;
                    Entity.cm_fecha = info.cm_fecha.Date;
                    Entity.IdResponsable = info.IdResponsable;
                    Entity.IdMotivo_Inv = info.IdMotivo_Inv;
                    Entity.IdBodega = info.IdBodega;
                    Entity.IdUsuarioUltModi = info.IdUsuarioUltModi;
                    Entity.Fecha_UltMod = DateTime.Now;

                    var lst = Context.in_Ing_Egr_Inven_det.Where(q => q.IdEmpresa == info.IdEmpresa && q.IdSucursal == info.IdSucursal && q.IdMovi_inven_tipo == info.IdMovi_inven_tipo && q.IdNumMovi == info.IdNumMovi);
                    Context.in_Ing_Egr_Inven_det.RemoveRange(lst);

                    foreach (var item in info.lst_in_Ing_Egr_Inven_det)
                    {
                        if (info.signo == "-")
                            item.mv_costo_sinConversion = data_costo.get_ultimo_costo(info.IdEmpresa, info.IdSucursal, Convert.ToInt32(info.IdBodega), item.IdProducto, info.cm_fecha);
                        Context.in_Ing_Egr_Inven_det.Add(new in_Ing_Egr_Inven_det
                        {
                            IdEmpresa = info.IdEmpresa,
                            IdSucursal = info.IdSucursal,
                            IdMovi_inven_tipo = info.IdMovi_inven_tipo,
                            IdNumMovi = info.IdNumMovi,
                            Secuencia = sec,
                            IdBodega = (int)info.IdBodega,
                            IdProducto = item.IdProducto,

                            IdCentroCosto = item.IdCentroCosto,
                            IdCentroCosto_sub_centro_costo = item.IdCentroCosto_sub_centro_costo,
                            IdPunto_cargo = item.IdPunto_cargo,
                            IdPunto_cargo_grupo = item.IdPunto_cargo_grupo,

                            dm_observacion = item.dm_observacion,
                            IdMotivo_Inv = item.IdMotivo_Inv,
                            IdEstadoAproba = item.IdEstadoAproba,
                            Motivo_Aprobacion = item.Motivo_Aprobacion,

                            IdEmpresa_oc = item.IdEmpresa_oc,
                            IdSucursal_oc = item.IdSucursal_oc,
                            IdOrdenCompra = item.IdOrdenCompra,
                            Secuencia_oc = item.Secuencia_oc,

                            //Deben ir null para que al aprobarse se liguen con el nuevo
                            IdEmpresa_inv = null,
                            IdSucursal_inv = null,
                            IdBodega_inv = null,
                            IdMovi_inven_tipo_inv = null,
                            IdNumMovi_inv = null,
                            secuencia_inv = null,

                            dm_cantidad_sinConversion = Math.Abs(item.dm_cantidad_sinConversion) * (info.signo == "-" ? -1 : 1),
                            dm_cantidad = Math.Abs(item.dm_cantidad_sinConversion) * (info.signo == "-" ? -1 : 1),

                            IdUnidadMedida = (item.IdUnidadMedida_sinConversion) == null ? "UNID" : item.IdUnidadMedida_sinConversion,
                            IdUnidadMedida_sinConversion = (item.IdUnidadMedida_sinConversion) == null ? "UNID" : item.IdUnidadMedida_sinConversion,

                            mv_costo_sinConversion = (item.mv_costo_sinConversion) == null ? 0 : item.mv_costo_sinConversion,
                            mv_costo = (item.mv_costo_sinConversion) == null ? 0 : Convert.ToDouble(item.mv_costo_sinConversion),
                        });                        
                        sec++;
                    }
                    Context.SaveChanges();

                    Context.spINV_aprobacion_ing_egr(info.IdEmpresa, info.IdSucursal, info.IdBodega, info.IdMovi_inven_tipo, info.IdNumMovi);
                    Contabilizar(info.IdEmpresa, info.IdSucursal, info.IdMovi_inven_tipo, info.IdNumMovi, info.cm_observacion, info.cm_fecha);
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool anularDB(in_Ing_Egr_Inven_Info info)
        {
            try
            {
                using (Entities_inventario Context = new Entities_inventario())
                {
                    in_Ing_Egr_Inven Entity = Context.in_Ing_Egr_Inven.FirstOrDefault(q => q.IdEmpresa == info.IdEmpresa && q.IdSucursal == info.IdSucursal && q.IdMovi_inven_tipo == info.IdMovi_inven_tipo && q.IdNumMovi == info.IdNumMovi);
                    if (Entity == null) return false;

                    if (Entity.Estado == "I")
                        return true;

                    Entity.Estado = info.Estado="I";
                    Entity.MotivoAnulacion = info.MotivoAnulacion;
                    Entity.IdusuarioUltAnu = info.IdusuarioUltAnu;
                    Entity.Fecha_UltAnu = DateTime.Now;
                    Context.SaveChanges();

                    ReversarAprobacion(info.IdEmpresa, info.IdSucursal, info.IdMovi_inven_tipo, info.IdNumMovi);
                }

                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }        
        public List<in_Ing_Egr_Inven_Info> get_list_por_devolver(int IdEmpresa, string signo, DateTime Fecha_ini, DateTime Fecha_fin)
        {
            try
            {
                List<in_Ing_Egr_Inven_Info> Lista;
                Fecha_ini = Fecha_ini.Date;
                Fecha_fin = Fecha_fin.Date;
                using (Entities_inventario Context = new Entities_inventario())
                {
                    Lista = (from q in Context.vwin_Ing_Egr_Inven_por_devolver
                             where q.IdEmpresa == IdEmpresa
                             && q.signo == signo
                             && Fecha_ini <= q.cm_fecha 
                             && q.cm_fecha <= Fecha_fin
                             select new in_Ing_Egr_Inven_Info
                             {
                                 IdEmpresa = q.IdEmpresa,
                                 IdSucursal = q.IdSucursal,
                                 IdMovi_inven_tipo = q.IdMovi_inven_tipo,
                                 IdNumMovi = q.IdNumMovi,
                                 signo = q.signo,
                                 tm_descripcion = q.tm_descripcion,
                                 cm_observacion = q.cm_observacion,
                                 cm_fecha = q.cm_fecha,
                                 Su_Descripcion = q.Su_Descripcion
                             }).ToList();
                }

                Lista.ForEach(q => q.SecuencialID = q.IdEmpresa.ToString("00") + q.IdSucursal.ToString("00") + q.IdMovi_inven_tipo.ToString("00") + q.IdNumMovi.ToString("00000000"));

                return Lista;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool ReversarAprobacion(int IdEmpresa, int IdSucursal, int IdMovi_inve_tipo, decimal IdNumMovi)
        {
            Entities_inventario db_i = new Entities_inventario();
            Entities_contabilidad db_ct = new Entities_contabilidad();
            try
            {
                var lst_det = db_i.in_Ing_Egr_Inven_det.Where(q => q.IdEmpresa == IdEmpresa && q.IdSucursal == IdSucursal && q.IdMovi_inven_tipo == IdMovi_inve_tipo && q.IdNumMovi == IdNumMovi).ToList();
                if (lst_det.Where(q => q.IdNumMovi_inv == null).Count() == 0)
                {
                    var PK_movi = new {
                        lst_det.First().IdEmpresa_inv,
                        lst_det.First().IdSucursal_inv,
                        lst_det.First().IdBodega_inv,
                        lst_det.First().IdMovi_inven_tipo_inv,
                        lst_det.First().IdNumMovi_inv
                    };

                    #region Elimino detalle de movi inve
                    var lst_movi_d = db_i.in_movi_inve_detalle.Where(q => q.IdEmpresa == PK_movi.IdEmpresa_inv
                                    && q.IdSucursal == PK_movi.IdSucursal_inv
                                    && q.IdBodega == PK_movi.IdBodega_inv
                                    && q.IdMovi_inven_tipo == PK_movi.IdMovi_inven_tipo_inv
                                    && q.IdNumMovi == PK_movi.IdNumMovi_inv
                                    ).ToList();

                    db_i.in_movi_inve_detalle.RemoveRange(lst_movi_d);
                    #endregion

                    #region Elimino cabecera
                    var movi = db_i.in_movi_inve.Where(q => q.IdEmpresa == PK_movi.IdEmpresa_inv
                               && q.IdSucursal == PK_movi.IdSucursal_inv
                               && q.IdBodega == PK_movi.IdBodega_inv
                               && q.IdMovi_inven_tipo == PK_movi.IdMovi_inven_tipo_inv
                               && q.IdNumMovi == PK_movi.IdNumMovi_inv).FirstOrDefault();

                    db_i.in_movi_inve.Remove(movi);
                    #endregion

                    #region Obtengo relacion contable y la elimino
                    var PK_conta = db_i.in_movi_inve_x_ct_cbteCble.Where(q => q.IdEmpresa == PK_movi.IdEmpresa_inv
                                    && q.IdSucursal == PK_movi.IdSucursal_inv
                                    && q.IdBodega == PK_movi.IdBodega_inv
                                    && q.IdMovi_inven_tipo == PK_movi.IdMovi_inven_tipo_inv
                                    && q.IdNumMovi == PK_movi.IdNumMovi_inv
                                    ).FirstOrDefault();
                    
                    #endregion
                    if (PK_conta != null)
                    {
                        #region Elimino diario contable
                        var lst_conta = db_ct.ct_cbtecble_det.Where(q => q.IdEmpresa == PK_conta.IdEmpresa_ct 
                                        && q.IdTipoCbte == PK_conta.IdTipoCbte 
                                        && q.IdCbteCble == PK_conta.IdCbteCble
                                        ).ToList();
                        db_ct.ct_cbtecble_det.RemoveRange(lst_conta);

                        var Conta = db_ct.ct_cbtecble.Where(q => q.IdEmpresa == PK_conta.IdEmpresa
                                    && q.IdTipoCbte == PK_conta.IdTipoCbte
                                    && q.IdCbteCble == PK_conta.IdCbteCble
                                    ).FirstOrDefault();
                        db_ct.ct_cbtecble.Remove(Conta);
                        #endregion
                        db_i.in_movi_inve_x_ct_cbteCble.Remove(PK_conta);
                    }
                }
                #region Seteo campos de aprobacion en null
                lst_det.ForEach(q =>
                {
                    q.IdEmpresa_inv = null;
                    q.IdSucursal_inv = null;
                    q.IdBodega_inv = null;
                    q.IdMovi_inven_tipo_inv = null;
                    q.IdNumMovi_inv = null;
                    q.IdEstadoAproba = "PEND";
                });
                #endregion

                db_i.SaveChanges();
                db_ct.SaveChanges();

                db_ct.Dispose();
                db_i.Dispose();
                return true;
            }
            catch (Exception)
            {
                db_ct.Dispose();
                db_i.Dispose();
                throw;
            }
        }
        public bool Contabilizar(int IdEmpresa, int IdSucursal, int IdMovi_inven_tipo, decimal IdNumMovi, string Observacion, DateTime Fecha)
        {
            Entities_inventario db_i = new Entities_inventario();
            Entities_contabilidad db_c = new Entities_contabilidad();
            try
            {
                var tipo_movi = db_i.in_movi_inven_tipo.Where(q => q.IdEmpresa == IdEmpresa && q.IdMovi_inven_tipo == IdMovi_inven_tipo).FirstOrDefault();
                if (tipo_movi == null)
                    return false;

                if (!(tipo_movi.Genera_Diario_Contable ?? false))
                    return false;

                if (tipo_movi.IdTipoCbte == null)
                    return false;

                var lst = db_i.vwin_Ing_Egr_Inven_PorContabilizar.Where(q => q.IdEmpresa == IdEmpresa && q.IdSucursal == IdSucursal && q.IdMovi_inven_tipo == IdMovi_inven_tipo && q.IdNumMovi == IdNumMovi).ToList();
                if (lst.Count == 0)
                    return false;


                List<in_movi_inve_detalle_x_ct_cbtecble_det> lst_rel = new List<in_movi_inve_detalle_x_ct_cbtecble_det>();
                List<ct_cbtecble_det_Info> lst_ct = new List<ct_cbtecble_det_Info>();
                int Secuencia = 1;
                foreach (var item in lst)
                {
                    lst_rel.Add(new in_movi_inve_detalle_x_ct_cbtecble_det
                    {
                        IdEmpresa_inv = (int)item.IdEmpresa_inv,
                        IdSucursal_inv = (int)item.IdSucursal_inv,
                        IdBodega_inv = (int)item.IdBodega_inv,
                        IdMovi_inven_tipo_inv = (int)item.IdMovi_inven_tipo_inv,
                        IdNumMovi_inv = (decimal)item.IdNumMovi_inv,
                        Secuencia_inv = (int)item.secuencia_inv,

                        secuencia_ct = Secuencia,
                        Secuencial_reg = Secuencia,
                        observacion = ""
                    });
                    //Debe
                    lst_ct.Add(new ct_cbtecble_det_Info
                    {
                        secuencia = Secuencia++,
                        IdCtaCble = tipo_movi.cm_tipo_movi == "+" ? item.IdCtaCtble_Inve : ( (bool)item.EsTransferencia ? item.P_IdCtaCble_transitoria_transf_inven : (string.IsNullOrEmpty(item.IdCtaCble_Motivo) ? item.IdCtaCtble_Costo : item.IdCtaCble_Motivo)),
                        dc_Valor = Math.Abs(Math.Round(item.Valor, 2, MidpointRounding.AwayFromZero))
                    });
                    lst_rel.Add(new in_movi_inve_detalle_x_ct_cbtecble_det
                    {
                        IdEmpresa_inv = (int)item.IdEmpresa_inv,
                        IdSucursal_inv = (int)item.IdSucursal_inv,
                        IdBodega_inv = (int)item.IdBodega_inv,
                        IdMovi_inven_tipo_inv = (int)item.IdMovi_inven_tipo_inv,
                        IdNumMovi_inv = (decimal)item.IdNumMovi_inv,
                        Secuencia_inv = (int)item.secuencia_inv,
                        
                        secuencia_ct = Secuencia,
                        Secuencial_reg = Secuencia,
                        observacion = ""
                    });
                    //Haber
                    lst_ct.Add(new ct_cbtecble_det_Info
                    {
                        secuencia = Secuencia++,
                        IdCtaCble = tipo_movi.cm_tipo_movi == "-" ? item.IdCtaCtble_Inve : ((bool)item.EsTransferencia ? item.P_IdCtaCble_transitoria_transf_inven : (string.IsNullOrEmpty(item.IdCtaCble_Motivo) ? item.IdCtaCtble_Costo : item.IdCtaCble_Motivo)),
                        dc_Valor = Math.Abs(Math.Round(item.Valor, 2, MidpointRounding.AwayFromZero)) * -1
                    });
                }

                var diario = odata_ct.armar_info(lst_ct, IdEmpresa, IdSucursal, (int)tipo_movi.IdTipoCbte, 0, tipo_movi.tm_descripcion + " #" + IdNumMovi + " " + Observacion, Fecha);

                diario.lst_ct_cbtecble_det.RemoveAll(q => q.dc_Valor == 0);

                if (diario.lst_ct_cbtecble_det.Count == 0)
                    return false;

                if (diario.lst_ct_cbtecble_det.Where(q => q.dc_Valor == 0).Count() > 0)
                    return false;

                double descuadre = Math.Round(diario.lst_ct_cbtecble_det.Sum(q => q.dc_Valor), 2, MidpointRounding.AwayFromZero);
                if (descuadre < -0.01 || 0.01 <= descuadre)
                    return false;

                if (descuadre <= 0.01 || -0.01 <= descuadre && descuadre != 0)
                {
                    if (descuadre > 0)
                        diario.lst_ct_cbtecble_det.Where(q => q.dc_Valor < 0).FirstOrDefault().dc_Valor -= descuadre;
                    else
                        diario.lst_ct_cbtecble_det.Where(q => q.dc_Valor > 0).FirstOrDefault().dc_Valor += (descuadre * -1);
                }

                descuadre = Math.Round(diario.lst_ct_cbtecble_det.Sum(q => q.dc_Valor), 2, MidpointRounding.AwayFromZero);
                if (descuadre != 0)
                    return false;

                if (odata_ct.guardarDB(diario))
                {
                    lst_rel.ForEach(q =>
                    {
                        q.IdEmpresa_ct = diario.IdEmpresa;
                        q.IdTipoCbte_ct = diario.IdTipoCbte;
                        q.IdCbteCble_ct = diario.IdCbteCble;
                    });
                    var First = lst_rel.First();
                    db_i.in_movi_inve_x_ct_cbteCble.Add(new in_movi_inve_x_ct_cbteCble
                    {
                        IdEmpresa = First.IdEmpresa_inv,
                        IdSucursal = First.IdSucursal_inv,
                        IdBodega = First.IdBodega_inv,
                        IdMovi_inven_tipo = First.IdMovi_inven_tipo_inv,
                        IdNumMovi = First.IdNumMovi_inv,

                        IdEmpresa_ct = First.IdEmpresa_ct,
                        IdTipoCbte = First.IdTipoCbte_ct,
                        IdCbteCble = First.IdCbteCble_ct,

                        Observacion = ""
                    });
                    db_i.in_movi_inve_detalle_x_ct_cbtecble_det.AddRange(lst_rel);
                    db_i.SaveChanges();
                }

                db_c.Dispose();
                db_i.Dispose();
                return true;
            }
            catch (Exception)
            {
                db_c.Dispose();
                db_i.Dispose();
                throw;
            }
        }
    }
}
