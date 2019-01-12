﻿using Core.Erp.Bus.Banco;
using Core.Erp.Bus.Contabilidad;
using Core.Erp.Bus.General;
using Core.Erp.Info.Banco;
using Core.Erp.Info.Contabilidad;
using Core.Erp.Info.General;
using Core.Erp.Info.Helps;
using Core.Erp.Web.Areas.Contabilidad.Controllers;
using Core.Erp.Web.Helps;
using DevExpress.Web;
using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Core.Erp.Web.Areas.Banco.Controllers
{
    [SessionTimeout]
    public class NotaDeCreditoBancoController : Controller
    {
        #region Variables
        ba_Cbte_Ban_Bus bus_cbteban = new ba_Cbte_Ban_Bus();
        tb_sucursal_Bus bus_sucursal = new tb_sucursal_Bus();
        ba_tipo_nota_Bus bus_tipo_nota = new ba_tipo_nota_Bus();
        tb_persona_Bus bus_persona = new tb_persona_Bus();
        ba_Banco_Cuenta_Bus bus_banco_cuenta = new ba_Banco_Cuenta_Bus();
        ct_cbtecble_det_List List_ct = new ct_cbtecble_det_List();
        ct_cbtecble_det_Bus bus_det_ct = new ct_cbtecble_det_Bus();
        string mensaje = string.Empty;
        ct_periodo_Bus bus_periodo = new ct_periodo_Bus();
        #endregion
        #region Metodos ComboBox bajo demanda flujo
        ba_TipoFlujo_Bus bus_tipo = new ba_TipoFlujo_Bus();
        public ActionResult CmbFlujo_ND_C()
        {
            decimal model = new decimal();
            return PartialView("_CmbFlujo_ND_C", model);
        }
        public List<ba_TipoFlujo_Info> get_list_bajo_demandaFlujo(ListEditItemsRequestedByFilterConditionEventArgs args)
        {
            return bus_tipo.get_list_bajo_demanda(args, Convert.ToInt32(SessionFixed.IdEmpresa), cl_enumeradores.eTipoIngEgr.ING.ToString());
        }
        public ba_TipoFlujo_Info get_info_bajo_demandaFlujo(ListEditItemRequestedByValueEventArgs args)
        {
            return bus_tipo.get_info_bajo_demanda(args, Convert.ToInt32(SessionFixed.IdEmpresa));
        }
        #endregion

        #region Index
        public ActionResult Index()
        {
            cl_filtros_Info model = new cl_filtros_Info
            {
                IdSucursal = Convert.ToInt32(SessionFixed.IdSucursal)
            };
            cargar_combos_consulta();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(cl_filtros_Info model)
        {
            cargar_combos_consulta();
            return View(model);
        }
        private void cargar_combos_consulta()
        {
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            var lst_sucursal = bus_sucursal.get_list(IdEmpresa, false);
            lst_sucursal.Add(new tb_sucursal_Info
            {
                IdEmpresa = IdEmpresa,
                IdSucursal = 0,
                Su_Descripcion = "Todos"
            });
            ViewBag.lst_sucursal = lst_sucursal;
        }
        public ActionResult GridViewPartial_CreditoBanco(DateTime? Fecha_ini, DateTime? Fecha_fin, int IdSucursal = 0)
        {
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            ViewBag.Fecha_ini = Fecha_ini == null ? DateTime.Now.Date.AddMonths(-1) : Convert.ToDateTime(Fecha_ini);
            ViewBag.Fecha_fin = Fecha_fin == null ? DateTime.Now.Date : Convert.ToDateTime(Fecha_fin);
            ViewBag.IdSucursal = IdSucursal;
            var model = bus_cbteban.get_list(IdEmpresa, ViewBag.Fecha_ini, ViewBag.Fecha_fin, IdSucursal, cl_enumeradores.eTipoCbteBancario.NCBA.ToString(), true);
            return PartialView("_GridViewPartial_CreditoBanco", model);
        }
        #endregion

        #region Metodos
        private void cargar_combos(int IdEmpresa, int IdSucursal)
        {
            var lst_sucursal = bus_sucursal.get_list(IdEmpresa, false);
            ViewBag.lst_sucursal = lst_sucursal;

            var lst_tipo_nota = bus_tipo_nota.get_list(IdEmpresa, cl_enumeradores.eTipoCbteBancario.NCBA.ToString(), false);
            ViewBag.lst_tipo_nota = lst_tipo_nota;

            var lst_banco_cuenta = bus_banco_cuenta.get_list(IdEmpresa, IdSucursal, false);
            ViewBag.lst_banco_cuenta = lst_banco_cuenta;
        }
        private bool validar(ba_Cbte_Ban_Info i_validar, ref string msg)
        {
            if (!bus_periodo.ValidarFechaTransaccion(i_validar.IdEmpresa, i_validar.cb_Fecha, cl_enumeradores.eModulo.BANCO, ref msg))
            {
                return false;
            }
            if (!bus_periodo.ValidarFechaTransaccion(i_validar.IdEmpresa, i_validar.cb_Fecha, cl_enumeradores.eModulo.CONTA, ref msg))
            {
                return false;
            }
            i_validar.lst_det_ct = List_ct.get_list(i_validar.IdTransaccionSession);

            if (i_validar.lst_det_ct.Count == 0)
            {
                msg = "El detalle del diario se encuentra vacío";
                return false;
            }

            foreach (var item in i_validar.lst_det_ct)
            {
                if (string.IsNullOrEmpty(item.IdCtaCble))
                {
                    mensaje = "Faltan cuentas contables, por favor verifique";
                    return false;
                }
            }

            if (Math.Round(i_validar.lst_det_ct.Sum(q => q.dc_Valor), 2, MidpointRounding.AwayFromZero) != 0)
            {
                mensaje = "La suma de los detalles debe ser 0, por favor verifique";
                return false;
            }
            if (i_validar.lst_det_ct.Where(q => q.dc_Valor == 0).Count() > 0)
            {
                mensaje = "Existen detalles con valor 0 en el debe o haber, por favor verifique";
                return false;
            }

            i_validar.IdPeriodo = Convert.ToInt32(i_validar.cb_Fecha.ToString("yyyyMM"));
            i_validar.IdUsuario = SessionFixed.IdUsuario;
            i_validar.IdUsuarioUltMod = SessionFixed.IdUsuario;
            i_validar.IdUsuario_Anu = SessionFixed.IdUsuario;
            i_validar.IdUsuarioUltMod = SessionFixed.IdUsuario;
            i_validar.cb_Valor = Math.Round(i_validar.lst_det_ct.Sum(q => q.dc_Valor_debe), 2, MidpointRounding.AwayFromZero);
            return true;
        }
        #endregion

        #region Acciones

        public ActionResult Nuevo(int IdEmpresa = 0)
        {
            #region Validar Session
            if (string.IsNullOrEmpty(SessionFixed.IdTransaccionSession))
                return RedirectToAction("Login", new { Area = "", Controller = "Account" });
            SessionFixed.IdTransaccionSession = (Convert.ToDecimal(SessionFixed.IdTransaccionSession) + 1).ToString();
            SessionFixed.IdTransaccionSessionActual = SessionFixed.IdTransaccionSession;
            #endregion

            ba_Cbte_Ban_Info model = new ba_Cbte_Ban_Info
            {
                IdEmpresa = IdEmpresa,
                IdSucursal = Convert.ToInt32(SessionFixed.IdSucursal),
                CodTipoCbteBan = cl_enumeradores.eTipoCbteBancario.NCBA.ToString(),
                cb_Fecha = DateTime.Now.Date,
                lst_det_ct = new List<ct_cbtecble_det_Info>(),
                IdBanco = 1,
                IdTipoNota = 2,
                IdTransaccionSession = Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual)
            };
            SessionFixed.TipoPersona = model.IdTipo_Persona;
            List_ct.set_list(model.lst_det_ct, model.IdTransaccionSession);
            cargar_combos(IdEmpresa, model.IdSucursal);
            return View(model);
        }

        [HttpPost]
        public ActionResult Nuevo(ba_Cbte_Ban_Info model)
        {
            if (!validar(model, ref mensaje))
            {
                ViewBag.mensaje = mensaje;
                cargar_combos(model.IdEmpresa, model.IdSucursal);
                return View(model);
            }
            if (!bus_cbteban.guardarDB(model, cl_enumeradores.eTipoCbteBancario.NCBA))
            {
                ViewBag.mensaje = "No se pudo guardar el registro";
                cargar_combos(model.IdEmpresa, model.IdSucursal);
                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Modificar(ba_Cbte_Ban_Info model)
        {
            if (!validar(model, ref mensaje))
            {
                ViewBag.mensaje = mensaje;
                cargar_combos(model.IdEmpresa, model.IdSucursal);
                return View(model);
            }
            if (!bus_cbteban.modificarDB(model, cl_enumeradores.eTipoCbteBancario.NCBA))
            {
                ViewBag.mensaje = "No se pudo modificar el registro";
                cargar_combos(model.IdEmpresa, model.IdSucursal);
                return View(model);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Modificar(int IdEmpresa = 0, int IdTipocbte = 0, decimal IdCbteCble = 0)
        {
            #region Validar Session
            if (string.IsNullOrEmpty(SessionFixed.IdTransaccionSession))
                return RedirectToAction("Login", new { Area = "", Controller = "Account" });
            SessionFixed.IdTransaccionSession = (Convert.ToDecimal(SessionFixed.IdTransaccionSession) + 1).ToString();
            SessionFixed.IdTransaccionSessionActual = SessionFixed.IdTransaccionSession;
            #endregion
            ba_Cbte_Ban_Info model = bus_cbteban.get_info(IdEmpresa, IdTipocbte, IdCbteCble);
            if (model == null)
                return RedirectToAction("Index");
            model.IdTransaccionSession = Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual);
            model.lst_det_ct = bus_det_ct.get_list(model.IdEmpresa, model.IdTipocbte, model.IdCbteCble);
            List_ct.set_list(model.lst_det_ct,model.IdTransaccionSession);
            cargar_combos(IdEmpresa, model.IdSucursal);
            SessionFixed.TipoPersona = model.IdTipo_Persona;
            return View(model);
        }

        public ActionResult Anular(int IdEmpresa = 0 , int IdTipocbte = 0, decimal IdCbteCble = 0)
        {
            #region Validar Session
            if (string.IsNullOrEmpty(SessionFixed.IdTransaccionSession))
                return RedirectToAction("Login", new { Area = "", Controller = "Account" });
            SessionFixed.IdTransaccionSession = (Convert.ToDecimal(SessionFixed.IdTransaccionSession) + 1).ToString();
            SessionFixed.IdTransaccionSessionActual = SessionFixed.IdTransaccionSession;
            #endregion
            ba_Cbte_Ban_Info model = bus_cbteban.get_info(IdEmpresa, IdTipocbte, IdCbteCble);
            if (model == null)
                return RedirectToAction("Index");
            model.IdTransaccionSession = Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual);
            model.lst_det_ct = bus_det_ct.get_list(model.IdEmpresa, model.IdTipocbte, model.IdCbteCble);
            List_ct.set_list(model.lst_det_ct,model.IdTransaccionSession);
            cargar_combos(IdEmpresa, model.IdSucursal);
            return View(model);
        }

        [HttpPost]
        public ActionResult Anular(ba_Cbte_Ban_Info model)
        {
            model.IdUsuario_Anu = SessionFixed.IdUsuario;
            if (!bus_cbteban.anularDB(model))
            {
                ViewBag.mensaje = "No se pudo anular el registro";
                cargar_combos(model.IdEmpresa, model.IdSucursal);
                return View(model);
            }

            return RedirectToAction("Index");
        }
        #endregion

        #region Json
        public JsonResult k(decimal IdTransaccionSession = 0)
        {
            var lst_ct = List_ct.get_list(IdTransaccionSession);
            return Json(Math.Round(lst_ct.Sum(q => q.dc_Valor_debe), 2, MidpointRounding.AwayFromZero), JsonRequestBehavior.AllowGet);
        }
        public JsonResult SetValorDiario(float cb_Valor = 0, decimal IdTransaccionSession = 0)
        {
            var lst_ct = List_ct.get_list(IdTransaccionSession);
            foreach (var item in lst_ct)
            {
                if (item.secuencia == 1)
                {
                    item.dc_Valor_debe = Math.Round(cb_Valor, 2, MidpointRounding.AwayFromZero);
                    item.dc_Valor_haber = 0;
                }
                else
                {
                    item.dc_Valor_debe = 0;
                    item.dc_Valor_haber = Math.Round(cb_Valor, 2, MidpointRounding.AwayFromZero);
                }

                item.dc_Valor = item.dc_Valor_debe > 0 ? item.dc_Valor_debe : item.dc_Valor_haber * -1;
            }
            
            return Json(lst_ct, JsonRequestBehavior.AllowGet);
        }
        public JsonResult armar_diario(int IdEmpresa = 0, int IdBanco = 0, int IdTipoNota = 0, decimal IdTransaccionSession = 0)
        {
            List_ct.set_list(new List<ct_cbtecble_det_Info>(), IdTransaccionSession);

            var bco = bus_banco_cuenta.get_info(IdEmpresa, IdBanco);
            var tipo_nota = bus_tipo_nota.get_info(IdEmpresa, IdTipoNota);

            //Debe
            if (bco != null)
            {
                List_ct.AddRow(new ct_cbtecble_det_Info
                {
                    IdCtaCble = bco.IdCtaCble,
                    dc_para_conciliar = true
                },IdTransaccionSession);
            }            

            //Haber
            if (tipo_nota != null && !string.IsNullOrEmpty(tipo_nota.IdCtaCble))
            {
                List_ct.AddRow(new ct_cbtecble_det_Info
                {
                    IdCtaCble = tipo_nota.IdCtaCble,
                    dc_para_conciliar = false
                }, IdTransaccionSession);
            }
            else
            {
                List_ct.AddRow(new ct_cbtecble_det_Info
                {
                    IdCtaCble = null,
                }, IdTransaccionSession);
            }
            return Json(0, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Detalle del diario
        [ValidateInput(false)]
        public ActionResult GridViewPartial_comprobante_detalle_Credito()
        {
            SessionFixed.IdTransaccionSessionActual = Request.Params["TransaccionFixed"] != null ? Request.Params["TransaccionFixed"].ToString() : SessionFixed.IdTransaccionSessionActual;
            ct_cbtecble_Info model = new ct_cbtecble_Info();
            model.lst_ct_cbtecble_det = List_ct.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            cargar_combos_detalle();
            return PartialView("_GridViewPartial_comprobante_detalle_Credito", model);
        }

        private void cargar_combos_detalle()
        {
            int IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            ct_plancta_Bus bus_cuenta = new ct_plancta_Bus();
            var lst_cuentas = bus_cuenta.get_list(IdEmpresa, false, true);
            ViewBag.lst_cuentas = lst_cuentas;
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EditingAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] ct_cbtecble_det_Info info_det)
        {
            if (ModelState.IsValid)
                List_ct.AddRow(info_det,Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            ct_cbtecble_Info model = new ct_cbtecble_Info();
            model.lst_ct_cbtecble_det = List_ct.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            cargar_combos_detalle();
            return PartialView("_GridViewPartial_comprobante_detalle_Credito", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EditingUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] ct_cbtecble_det_Info info_det)
        {
            if (ModelState.IsValid)
                List_ct.UpdateRow(info_det, Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            ct_cbtecble_Info model = new ct_cbtecble_Info();
            model.lst_ct_cbtecble_det = List_ct.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            cargar_combos_detalle();
            return PartialView("_GridViewPartial_comprobante_detalle_Credito", model);
        }

        public ActionResult EditingDelete(int secuencia)
        {
            List_ct.DeleteRow(secuencia, Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            ct_cbtecble_Info model = new ct_cbtecble_Info();
            model.lst_ct_cbtecble_det = List_ct.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            cargar_combos_detalle();
            return PartialView("_GridViewPartial_comprobante_detalle_Credito", model);
        }
    }
    #endregion
}