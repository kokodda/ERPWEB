﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Erp.Info.RRHH;
using Core.Erp.Bus.RRHH;
using DevExpress.Web.Mvc;
using Core.Erp.Web.Helps;
using DevExpress.Web;

namespace Core.Erp.Web.Areas.RRHH.Controllers
{
    public class DepartamentoPorAreaController : Controller
    {
        #region variables
        ro_area_x_departamento_Bus bus_area_x_departamento = new ro_area_x_departamento_Bus();
        List<ro_area_x_departamento_Info> lst_departamento_area = new List<ro_area_x_departamento_Info>();
        ro_division_Bus bus_divisiaon = new ro_division_Bus();
        ro_area_Bus bus_area = new ro_area_Bus();
        ro_departamento_Bus bus_departamento = new ro_departamento_Bus();
        ro_division_Bus bus_division = new ro_division_Bus();
        ro_departamento_Info info = new ro_departamento_Info();
        ro_area_x_departamento_List Lista_AreaDep = new ro_area_x_departamento_List();
        #endregion

        #region Index
        public ActionResult Index()
        {
            #region Validar Session
            if (string.IsNullOrEmpty(SessionFixed.IdTransaccionSession))
                return RedirectToAction("Login", new { Area = "", Controller = "Account" });
            SessionFixed.IdTransaccionSession = (Convert.ToDecimal(SessionFixed.IdTransaccionSession) + 1).ToString();
            SessionFixed.IdTransaccionSessionActual = SessionFixed.IdTransaccionSession;
            #endregion

            ro_area_x_departamento_Info model = new ro_area_x_departamento_Info
            {
                IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa),
                IdTransaccionSession = Convert.ToDecimal(SessionFixed.IdTransaccionSession)
            };

            List<ro_area_x_departamento_Info> lista = bus_area_x_departamento.get_list(model.IdEmpresa);
            Lista_AreaDep.set_list(lista, Convert.ToDecimal(SessionFixed.IdTransaccionSession));

            return View(model);
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_departamento_area()
        {
            SessionFixed.IdTransaccionSessionActual = Request.Params["TransaccionFixed"] != null ? Request.Params["TransaccionFixed"].ToString() : SessionFixed.IdTransaccionSessionActual;

            lst_departamento_area = Lista_AreaDep.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            return PartialView("_GridViewPartial_departamento_area", lst_departamento_area);
        }
        #endregion

        #region Combos bajo demanda
        #region Division
        public ActionResult CmbDivision()
        {
            ro_empleado_Info model = new ro_empleado_Info();
            return PartialView("_CmbDivision", model);
        }
        public List<ro_division_Info> get_list_bajo_demanda_division(ListEditItemsRequestedByFilterConditionEventArgs args)
        {
            return bus_division.get_list_bajo_demanda_division(args, Convert.ToInt32(SessionFixed.IdEmpresa), false);
        }
        public ro_division_Info get_info_bajo_demanda_division(ListEditItemRequestedByValueEventArgs args)
        {
            return bus_division.get_info_bajo_demanda_division(args, Convert.ToInt32(SessionFixed.IdEmpresa));
        }
        #endregion

        #region Area
        public ActionResult CmbArea()
        {
            SessionFixed.IdDivision = Request.Params["IdDivision"] != null ? Request.Params["IdDivision"].ToString() : SessionFixed.IdDivision;
            ro_empleado_Info model = new ro_empleado_Info();
            return PartialView("_CmbArea", model);
        }
        public List<ro_area_Info> get_list_bajo_demanda_area(ListEditItemsRequestedByFilterConditionEventArgs args)
        {
            return bus_area.get_list_bajo_demanda_area(args, Convert.ToInt32(SessionFixed.IdEmpresa), false, Convert.ToInt32(SessionFixed.IdDivision));
        }
        public ro_area_Info get_info_bajo_demanda_area(ListEditItemRequestedByValueEventArgs args)
        {
            return bus_area.get_info_bajo_demanda_area(args, Convert.ToInt32(SessionFixed.IdEmpresa), Convert.ToInt32(SessionFixed.IdDivision));
        }
        #endregion

        #endregion

        #region Acciones
        [ValidateInput(false)]
        public ActionResult Nuevo(int IdEmpresa = 0)
        {
            cargar_combos();
            ro_area_x_departamento_Info info = new ro_area_x_departamento_Info();
            info.IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            return View(info);
        }
        [HttpPost]
        public ActionResult Nuevo(ro_area_x_departamento_Info model)
        {
            if (model == null)
                return View(model);

            if (bus_area_x_departamento.guardarDB(model))
                return RedirectToAction("Index");
            else
            {
                cargar_combos();
                return View(model);
            }
        }
        public ActionResult Modificar(int IdEmpresa = 0, int Secuencia = 0)
        {
            cargar_combos();
            return View(bus_area_x_departamento.get_info(IdEmpresa, Secuencia));
        }
        [HttpPost]
        public ActionResult Modificar(ro_area_x_departamento_Info model)
        {
            if (!bus_area_x_departamento.modificarDB(model))
            {
                cargar_combos();
                return View(model);
            }
            return RedirectToAction("Index");

        }
        public ActionResult Anular(int IdEmpresa = 0, int Secuencia = 0)
        {
            cargar_combos();
            return View(bus_area_x_departamento.get_info(IdEmpresa, Secuencia));
        }
        [HttpPost]
        public ActionResult Anular(ro_area_x_departamento_Info model)
        {
            if (!bus_area_x_departamento.anularDB(model))
            {
                cargar_combos();
                return View(model);
            }
            return RedirectToAction("Index");

        }
        #endregion

        private void cargar_combos()
        {
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            ViewBag.lst_division = bus_divisiaon.get_list(IdEmpresa, false);
            ViewBag.lst_area = bus_area.get_list(IdEmpresa, false);
            ViewBag.lst_departamento = bus_departamento.get_list(IdEmpresa, false);
        }
    }

    public class ro_area_x_departamento_List
    {
        string Variable = "ro_area_x_departamento_Info";
        public List<ro_area_x_departamento_Info> get_list(decimal IdTransaccionSession)
        {
            if (HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] == null)
            {
                List<ro_area_x_departamento_Info> list = new List<ro_area_x_departamento_Info>();

                HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] = list;
            }
            return (List<ro_area_x_departamento_Info>)HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()];
        }

        public void set_list(List<ro_area_x_departamento_Info> list, decimal IdTransaccionSession)
        {
            HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] = list;
        }
    }
}