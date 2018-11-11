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

        // GET: RRHH/Division
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_tipo_gastos_personal_anual(string IdTipoGasto)
        {
            try
            {
                int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
                List<ro_tipo_gastos_personales_maxim_x_anio_Info> model = bus_gastos.get_list(IdTipoGasto);
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
                        return RedirectToAction("Index");
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
                ro_tipo_gastos_personales_maxim_x_anio_Info info = new ro_tipo_gastos_personales_maxim_x_anio_Info();
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
                if (ModelState.IsValid)
                {
                    if (!bus_gastos.modificarDB(info))
                        return View(info);
                    else
                        return RedirectToAction("Index");
                }
                else
                    return View(info);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult Modificar(string IdTipoGasto)
        {
            try
            {

                return View(bus_gastos.get_info(IdTipoGasto));

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

                if (!bus_gastos.anularDB(info))
                    return View(info);
                else
                    return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult Anular(string IdTipoGasto)
        {
            try
            {

                return View(bus_gastos.get_info(IdTipoGasto));

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}