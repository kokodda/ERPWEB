﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Erp.Info.RRHH;
using Core.Erp.Bus.RRHH;
using Core.Erp.Web.Helps;

namespace Core.Erp.Web.Areas.RRHH.Controllers
{
    public class TipoGastosPersonalesAnualController : Controller
    {
        ro_tipo_gastos_personales_maxim_x_anio_Bus bus_gastos = new ro_tipo_gastos_personales_maxim_x_anio_Bus();
        ro_tipo_gastos_personales_maxim_x_anio_List Lista_GastosPersonalesAnual = new ro_tipo_gastos_personales_maxim_x_anio_List();

        #region Variables
        ro_tipo_gastos_personales_Bus bus_tipo_gasto = new ro_tipo_gastos_personales_Bus();
        #endregion
        public ActionResult Index(string IdTipoGasto)
        {
            #region Validar Session
            if (string.IsNullOrEmpty(SessionFixed.IdTransaccionSession))
                return RedirectToAction("Login", new { Area = "", Controller = "Account" });
            SessionFixed.IdTransaccionSession = (Convert.ToDecimal(SessionFixed.IdTransaccionSession) + 1).ToString();
            SessionFixed.IdTransaccionSessionActual = SessionFixed.IdTransaccionSession;
            #endregion

            ro_tipo_gastos_personales_maxim_x_anio_Info model = new ro_tipo_gastos_personales_maxim_x_anio_Info
            {
                IdTransaccionSession = Convert.ToDecimal(SessionFixed.IdTransaccionSession)
            };

            List<ro_tipo_gastos_personales_maxim_x_anio_Info> lista = bus_gastos.get_list(IdTipoGasto);
            Lista_GastosPersonalesAnual.set_list(lista, Convert.ToDecimal(SessionFixed.IdTransaccionSession));

            ViewBag.IdTipoGasto = IdTipoGasto;
            return View(model);
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_tipo_gastos_personal_anual(string IdTipoGasto)
        {
            try
            {
                cargar_combo();
                SessionFixed.IdTransaccionSessionActual = Request.Params["TransaccionFixed"] != null ? Request.Params["TransaccionFixed"].ToString() : SessionFixed.IdTransaccionSessionActual;

                List<ro_tipo_gastos_personales_maxim_x_anio_Info> model = Lista_GastosPersonalesAnual.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
                ViewBag.IdTipoGasto = IdTipoGasto;
                return PartialView("_GridViewPartial_tipo_gastos_personal_anual", model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult Nuevo(ro_tipo_gastos_personales_maxim_x_anio_Info info)
        {
            try
            {
                ViewBag.IdTipoGasto = info.IdTipoGasto;
                info.IdUsuario = SessionFixed.IdUsuario;
                if (ModelState.IsValid)
                {
                    var model = bus_gastos.si_existe(info.IdTipoGasto, info.AnioFiscal);
                    if (model != null)
                    {
                        ViewBag.mensaje = "El codigo ya se encuentra registrado para este año fiscal";
                        return View(model);
                    }
                    if (!bus_gastos.guardarDB(info))
                        return View(info);
                    else
                        return RedirectToAction("Index", new { IdTipoGasto = info.IdTipoGasto });
                }
                else
                    return View(info);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult Nuevo(string IdTipoGasto)
        {
            try
            {
                cargar_combo();
                   ro_tipo_gastos_personales_maxim_x_anio_Info info = new ro_tipo_gastos_personales_maxim_x_anio_Info();
                info.AnioFiscal = DateTime.Now.Year;
                ViewBag.IdTipoGasto = IdTipoGasto;
                return View(info);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult Modificar(ro_tipo_gastos_personales_maxim_x_anio_Info info)
        {
            try
            {
                info.IdUsuarioUltMod = SessionFixed.IdUsuario;
                ViewBag.IdTipoGasto = info.IdTipoGasto;

                if (ModelState.IsValid)
                {
                    if (!bus_gastos.modificarDB(info))
                    {
                        cargar_combo();
                        return View(info);
                    }
                    else
                        return RedirectToAction("Index", new { IdTipoGasto =info.IdTipoGasto});
                }
                else
                {
                    cargar_combo();

                    return View(info);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult Modificar(int IdGasto)
        {
            try
            {
                cargar_combo();


                return View(bus_gastos.get_info(IdGasto));

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult Anular(ro_tipo_gastos_personales_maxim_x_anio_Info info)
        {
            try
            {
                info.IdUsuarioUltAnu = SessionFixed.IdUsuario;
                ViewBag.IdTipoGasto = info.IdTipoGasto;

                if (!bus_gastos.anularDB(info))
                {
                    cargar_combo();

                    return View(info);
                }
                else
                    return RedirectToAction("Index", new { IdTipoGasto = info.IdTipoGasto });
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult Anular(int IdGasto)
        {
            try
            {
                cargar_combo();

                return View(bus_gastos.get_info(IdGasto));

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void cargar_combo()
        {
            try
            {
                var list_tipo_gasto = bus_tipo_gasto.get_list(false);
                ViewBag.list_tipo_gasto = list_tipo_gasto;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

    public class ro_tipo_gastos_personales_maxim_x_anio_List
    {
        string Variable = "ro_tipo_gastos_personales_maxim_x_anio_Info";
        public List<ro_tipo_gastos_personales_maxim_x_anio_Info> get_list(decimal IdTransaccionSession)
        {
            if (HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] == null)
            {
                List<ro_tipo_gastos_personales_maxim_x_anio_Info> list = new List<ro_tipo_gastos_personales_maxim_x_anio_Info>();

                HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] = list;
            }
            return (List<ro_tipo_gastos_personales_maxim_x_anio_Info>)HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()];
        }

        public void set_list(List<ro_tipo_gastos_personales_maxim_x_anio_Info> list, decimal IdTransaccionSession)
        {
            HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] = list;
        }
    }
}