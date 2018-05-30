﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Erp.Info.RRHH;
using Core.Erp.Bus.RRHH;
using DevExpress.Web.Mvc;
using Core.Erp.Bus.Contabilidad;
namespace Core.Erp.Web.Areas.RRHH.Controllers
{
    public class ParametrosContableController : Controller
    {

        #region
        ro_Parametros_Bus bus_parametros = new ro_Parametros_Bus();
        ro_nomina_tipo_Bus bus_nomina = new ro_nomina_tipo_Bus();
        ro_Nomina_Tipoliquiliqui_Bus bus_nomina_tipo = new ro_Nomina_Tipoliquiliqui_Bus();
        ro_Config_Param_contable_lst lst_cta_rubro = new ro_Config_Param_contable_lst();
        ro_rubro_tipo_Bus bus_rubro = new ro_rubro_tipo_Bus();
        ro_Config_Param_contable_Bus bus_configuracion_ctas = new ro_Config_Param_contable_Bus();
        ct_plancta_Bus bus_cuenta = new ct_plancta_Bus();
        ro_catalogo_Bus bus_catalogo = new ro_catalogo_Bus();
        ro_parametro_contable_x_Nomina_Tipoliqui_Sueldo_x_Pagar_Bus bus_configuracion_cta_x_sueldo = new ro_parametro_contable_x_Nomina_Tipoliqui_Sueldo_x_Pagar_Bus();
        ct_cbtecble_tipo_Bus bus_comprobante_tipo = new ct_cbtecble_tipo_Bus();

        int IdEmpresa = 0;
        #endregion
        public ActionResult Index()
        {
            return View();
        }
        [ValidateInput(false)]
        public ActionResult GridViewPartial_parametros()
        {
            int IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            List<ro_Parametros_Info> model = bus_parametros.get_list(IdEmpresa);
            return PartialView("_GridViewPartial_parametros", model);
        }
        private void cargar_combos()
        {
            IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            ViewBag.lst_nomina = bus_nomina.get_list(IdEmpresa, false);
            ViewBag.lst_nomina_tipo = bus_nomina_tipo.get_list(IdEmpresa,false);
            ViewBag.lst_rubro = bus_rubro.get_list(IdEmpresa, false);
            ViewBag.lst_comprobante_tipo = bus_comprobante_tipo.get_list(IdEmpresa, false);
            ViewBag.lst_rubro = bus_rubro.get_list_rub_concepto(IdEmpresa);
        }
        public ActionResult Nuevo()
        {
            ro_Parametros_Info model = new ro_Parametros_Info
            {
                IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]),
                IdTipoCbte_AsientoSueldoXPagar = 1,
            };
            model.lst_cta_x_rubros = new List<ro_Config_Param_contable_Info>();
            lst_cta_rubro.set_list_cta_rubros(model.lst_cta_x_rubros);
            cargar_combos();
            cargar_combos_detalle();
            return View(model);
        }
        [HttpPost]
        public ActionResult Nuevo(ro_Parametros_Info model)
        {
            
            model.IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            model.lst_cta_x_rubros = lst_cta_rubro.get_list_cta_rubros();
            model.lst_cta_x_sueldo_pagar=lst_cta_rubro.get_list_sueldo_x_pagar();
            if (!bus_parametros.guardarDB(model))
            {
                cargar_combos();
                return View(model);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Modificar()
        {
            cargar_combos();
            int IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            ro_Parametros_Info model = bus_parametros.get_info(IdEmpresa);
            lst_cta_rubro.set_list_cta_rubros(model.lst_cta_x_rubros);
            lst_cta_rubro.set_list_sueldo_x_pagar(model.lst_cta_x_sueldo_pagar);
            if (model == null)
                return RedirectToAction("Index");
            return View(model);
        }
        [HttpPost]
        public ActionResult Modificar(ro_Parametros_Info model)
        {

            model.IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            model.lst_cta_x_rubros = lst_cta_rubro.get_list_cta_rubros();
            model.lst_cta_x_sueldo_pagar = lst_cta_rubro.get_list_sueldo_x_pagar();
            if (!bus_parametros.modificarDB(model))
            {
                cargar_combos();
                return View(model);
            }
            return RedirectToAction("Index");

        }     
        [ValidateInput(false)]
        public ActionResult GridViewPartial_cta_ctble_rubros()
        {
            int IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            ro_Parametros_Info model = new ro_Parametros_Info();
            model.lst_cta_x_rubros = lst_cta_rubro.get_list_cta_rubros();
            if (model.lst_cta_x_rubros.Count() == 0)
            {
                model.lst_cta_x_rubros = bus_configuracion_ctas.get_list(IdEmpresa);
                lst_cta_rubro.set_list_cta_rubros(model.lst_cta_x_rubros);
            }
            model.lst_cta_x_rubros = lst_cta_rubro.get_list_cta_rubros().Where(v => v.rub_provision == false).ToList();
            cargar_combos_detalle();
            return PartialView("_GridViewPartial_cta_ctble_rubros", model);
        }
        [ValidateInput(false)]
        public ActionResult GridViewPartial_cta_ctble_provisiones()
        {
            int IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            ro_Parametros_Info model = new ro_Parametros_Info();
            model.lst_cta_x_rubros = lst_cta_rubro.get_list_cta_rubros();
            if (model.lst_cta_x_rubros.Count() == 0)
            {
                model.lst_cta_x_rubros = bus_configuracion_ctas.get_list(IdEmpresa);
                lst_cta_rubro.set_list_cta_rubros(model.lst_cta_x_rubros);
            }
            model.lst_cta_x_provisiones = lst_cta_rubro.get_list_cta_rubros().Where(v => v.rub_provision == true).ToList();
            cargar_combos_detalle();
            return PartialView("_GridViewPartial_cta_ctble_provisiones", model);
        }

        public ActionResult GridViewPartial_cta_contable_sueldo_pagar()
        {
            int IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            ro_Parametros_Info model = new ro_Parametros_Info();
            model.lst_cta_x_sueldo_pagar = lst_cta_rubro.get_list_sueldo_x_pagar();
            if (model.lst_cta_x_sueldo_pagar.Count() == 0)
            {
                model.lst_cta_x_sueldo_pagar = bus_configuracion_cta_x_sueldo.get_list(IdEmpresa);
                lst_cta_rubro.set_list_sueldo_x_pagar(model.lst_cta_x_sueldo_pagar);
            }
            model.lst_cta_x_sueldo_pagar = lst_cta_rubro.get_list_sueldo_x_pagar();
            cargar_combos_detalle();
            return PartialView("_GridViewPartial_cta_contable_sueldo_pagar", model);
        }

        
        private void cargar_combos_detalle()
        {
            int IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            ViewBag.lst_catalogo = bus_catalogo.get_list_x_tipo(34);
            ViewBag.lst_cta_contable = bus_cuenta.get_list(IdEmpresa, false,true);
            ViewBag.lst_nomina = bus_nomina.get_list(IdEmpresa, false);
            ViewBag.lst_nomina_tipo = bus_nomina_tipo.get_list(IdEmpresa, false);      
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult EditingUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] ro_Config_Param_contable_Info info_det)
        {
            if (ModelState.IsValid)
                lst_cta_rubro.UpdateRow_cta_rubros(info_det);
            ro_Parametros_Info model = new ro_Parametros_Info();
            model.lst_cta_x_rubros = lst_cta_rubro.get_list_cta_rubros().Where(v => v.rub_provision == false).ToList();
            cargar_combos_detalle();
            return PartialView("_GridViewPartial_cta_ctble_rubros", model);
        }
        public ActionResult EditingUpdate_provisiones([ModelBinder(typeof(DevExpressEditorsBinder))] ro_Config_Param_contable_Info info_det)
        {
            if (ModelState.IsValid)
                lst_cta_rubro.UpdateRow_cta_rubros(info_det);
            ro_Parametros_Info model = new ro_Parametros_Info();
            model.lst_cta_x_provisiones = lst_cta_rubro.get_list_cta_rubros().Where(v => v.rub_provision == true).ToList();
            cargar_combos_detalle();
            return PartialView("_GridViewPartial_cta_ctble_provisiones", model);
        }

        public ActionResult EditingUpdate_cta_sueldo([ModelBinder(typeof(DevExpressEditorsBinder))] ro_parametro_contable_x_Nomina_Tipoliqui_Sueldo_x_Pagar_Info info_det)
        {
            if (ModelState.IsValid)
                lst_cta_rubro.UpdateRow_cta_sueldo_x_pagar(info_det);
            ro_Parametros_Info model = new ro_Parametros_Info();
            model.lst_cta_x_sueldo_pagar = lst_cta_rubro.get_list_sueldo_x_pagar();
            cargar_combos_detalle();
            return PartialView("_GridViewPartial_cta_contable_sueldo_pagar", model);
        }
        public ActionResult EditingNew_cta_sueldo([ModelBinder(typeof(DevExpressEditorsBinder))] ro_parametro_contable_x_Nomina_Tipoliqui_Sueldo_x_Pagar_Info info_det)
        {
            if (ModelState.IsValid)
                lst_cta_rubro.NewRow_cta_sueldo_x_pagar(info_det);
            ro_Parametros_Info model = new ro_Parametros_Info();
            model.lst_cta_x_sueldo_pagar = lst_cta_rubro.get_list_sueldo_x_pagar();
            cargar_combos_detalle();
            return PartialView("_GridViewPartial_cta_contable_sueldo_pagar", model);
        }
        public ActionResult EditingDelete_cta_sueldo([ModelBinder(typeof(DevExpressEditorsBinder))] ro_parametro_contable_x_Nomina_Tipoliqui_Sueldo_x_Pagar_Info info_det)
        {
            if (ModelState.IsValid)
                lst_cta_rubro.DeleteRow_cta_sueldo_x_pagar(info_det);
            ro_Parametros_Info model = new ro_Parametros_Info();
            model.lst_cta_x_sueldo_pagar = lst_cta_rubro.get_list_sueldo_x_pagar();
            cargar_combos_detalle();
            return PartialView("_GridViewPartial_cta_contable_sueldo_pagar", model);
        }

    }


    public class ro_Config_Param_contable_lst
    {
        public List<ro_Config_Param_contable_Info> get_list_cta_rubros()
        {
            if (HttpContext.Current.Session["lst_cta_rubro"] == null)
            {
                List<ro_Config_Param_contable_Info> list = new List<ro_Config_Param_contable_Info>();

                HttpContext.Current.Session["lst_cta_rubro"] = list;
            }
            return (List<ro_Config_Param_contable_Info>)HttpContext.Current.Session["lst_cta_rubro"];
        }
        public void set_list_cta_rubros(List<ro_Config_Param_contable_Info> list)
        {
            HttpContext.Current.Session["lst_cta_rubro"] = list;
        }      
        public void UpdateRow_cta_rubros(ro_Config_Param_contable_Info info_det)
        {
            ro_Config_Param_contable_Info edited_info = get_list_cta_rubros().Where(m => m.Secuencia == info_det.Secuencia).First();
            edited_info.IdCtaCble = info_det.IdCtaCble;
            edited_info.IdCtaCble_Haber = info_det.IdCtaCble_Haber;
            edited_info.DebCre = info_det.DebCre;
        }



        public List<ro_parametro_contable_x_Nomina_Tipoliqui_Sueldo_x_Pagar_Info> get_list_sueldo_x_pagar()
        {
            if (HttpContext.Current.Session["lst_cta_sueldo"] == null)
            {
                List<ro_parametro_contable_x_Nomina_Tipoliqui_Sueldo_x_Pagar_Info> list = new List<ro_parametro_contable_x_Nomina_Tipoliqui_Sueldo_x_Pagar_Info>();

                HttpContext.Current.Session["lst_cta_sueldo"] = list;
            }
            return (List<ro_parametro_contable_x_Nomina_Tipoliqui_Sueldo_x_Pagar_Info>)HttpContext.Current.Session["lst_cta_sueldo"];
        }
        public void set_list_sueldo_x_pagar(List<ro_parametro_contable_x_Nomina_Tipoliqui_Sueldo_x_Pagar_Info> list)
        {
            HttpContext.Current.Session["lst_cta_sueldo"] = list;
        }
        public void UpdateRow_cta_sueldo_x_pagar(ro_parametro_contable_x_Nomina_Tipoliqui_Sueldo_x_Pagar_Info info_det)
        {
            ro_parametro_contable_x_Nomina_Tipoliqui_Sueldo_x_Pagar_Info edited_info = get_list_sueldo_x_pagar().Where(m => m.Secuencia == info_det.Secuencia).First();
            edited_info.IdCtaCble = info_det.IdCtaCble;
            edited_info.IdNomina = info_det.IdNomina;
            edited_info.IdNominaTipo = info_det.IdNominaTipo;
        }
        public void NewRow_cta_sueldo_x_pagar(ro_parametro_contable_x_Nomina_Tipoliqui_Sueldo_x_Pagar_Info info_det)
        {
            List<ro_parametro_contable_x_Nomina_Tipoliqui_Sueldo_x_Pagar_Info> list = get_list_sueldo_x_pagar();
            info_det.Secuencia = list.Count == 0 ? 1 : list.Max(q => q.Secuencia) + 1;
            list.Add(info_det);
        }
        public void DeleteRow_cta_sueldo_x_pagar(ro_parametro_contable_x_Nomina_Tipoliqui_Sueldo_x_Pagar_Info info_det)
        {
            List<ro_parametro_contable_x_Nomina_Tipoliqui_Sueldo_x_Pagar_Info> list = get_list_sueldo_x_pagar();
            list.Remove(list.Where(m => m.Secuencia == info_det.Secuencia).First());
        }


    }

}
