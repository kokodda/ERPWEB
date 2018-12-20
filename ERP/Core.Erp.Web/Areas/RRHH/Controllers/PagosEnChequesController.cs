﻿using Core.Erp.Bus.RRHH;
using Core.Erp.Info.Helps;
using Core.Erp.Info.RRHH;
using Core.Erp.Web.Helps;
using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Erp.Bus.Banco;
using Core.Erp.Bus.General;

namespace Core.Erp.Web.Areas.RRHH.Controllers
{
    public class PagosEnChequesController : Controller
    {
        #region Variables
        ro_archivos_bancos_generacion_Bus bus_archivo = new ro_archivos_bancos_generacion_Bus();
        ro_nomina_tipo_Bus bus_nomina = new ro_nomina_tipo_Bus();
        ro_Nomina_Tipoliquiliqui_Bus bus_nomina_tipo = new ro_Nomina_Tipoliquiliqui_Bus();
        ro_archivos_bancos_generacion_x_empleado_Bus bus_archivo_detalle = new ro_archivos_bancos_generacion_x_empleado_Bus();
        ro_NominasPagosCheques_det_Info_list ro_NominasPagosCheques_det_Info_list = new ro_NominasPagosCheques_det_Info_list();
        ro_rubro_tipo_Bus bus_rubro = new ro_rubro_tipo_Bus();
        ro_empleado_Bus bus_empleado = new ro_empleado_Bus();
        ba_Banco_Cuenta_Bus bus_cuentas_bancarias = new ba_Banco_Cuenta_Bus();
        tb_banco_procesos_bancarios_x_empresa_Bus bus_procesos_bancarios = new tb_banco_procesos_bancarios_x_empresa_Bus();
        tb_sucursal_Bus bus_sucursal = new tb_sucursal_Bus();

        #endregion

        #region Vistas
        public ActionResult Index()
        {
            cl_filtros_Info model = new cl_filtros_Info();
            cargar_combos_consulta();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(cl_filtros_Info model)
        {
            cargar_combos_consulta();
            return View(model);

        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_archivo_transferencia(DateTime? Fecha_ini, DateTime? Fecha_fin, decimal? IdSucursal = 0)
        {
            ViewBag.Fecha_ini = Fecha_ini == null ? DateTime.Now.Date.AddMonths(-1) : Convert.ToDateTime(Fecha_ini);
            ViewBag.Fecha_fin = Fecha_fin == null ? DateTime.Now.Date : Convert.ToDateTime(Fecha_fin);
            ViewBag.IdSucursal = IdSucursal;
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            var model = bus_archivo.get_list(IdEmpresa, ViewBag.Fecha_ini, ViewBag.Fecha_fin, true);
            return PartialView("_GridViewPartial_archivo_transferencia", model);
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_archivo_transferencia_det()
        {
            SessionFixed.IdTransaccionSessionActual = Request.Params["TransaccionFixed"] != null ? Request.Params["TransaccionFixed"].ToString() : SessionFixed.IdTransaccionSessionActual;
            ro_archivos_bancos_generacion_Info model = new ro_archivos_bancos_generacion_Info();
            model.detalle = ro_NominasPagosCheques_det_Info_list.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            return PartialView("_GridViewPartial_archivo_transferencia_det", model);


        }
        #endregion

        #region acciones
        public ActionResult Nuevo(int IdEmpresa = 0, int IdNomina_Tipo = 0, int IdNomina_TipoLiqui = 0, int IdPeriodo = 0)
        {
            #region Validar Session
            if (string.IsNullOrEmpty(SessionFixed.IdTransaccionSession))
                return RedirectToAction("Login", new { Area = "", Controller = "Account" });
            SessionFixed.IdTransaccionSession = (Convert.ToDecimal(SessionFixed.IdTransaccionSession) + 1).ToString();
            SessionFixed.IdTransaccionSessionActual = SessionFixed.IdTransaccionSession;
            #endregion
            ro_archivos_bancos_generacion_Info model = new ro_archivos_bancos_generacion_Info
            {
                IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa),
                IdNomina = IdNomina_Tipo,
                IdNominaTipo = IdNomina_TipoLiqui,
                IdTransaccionSession = Convert.ToDecimal(SessionFixed.IdTransaccionSession),



            };

            model.detalle = bus_archivo_detalle.get_list(IdEmpresa, IdNomina_Tipo, IdNomina_TipoLiqui, IdPeriodo, "");
            ro_NominasPagosCheques_det_Info_list.set_list(model.detalle, Convert.ToDecimal(SessionFixed.IdTransaccionSession));
            cargar_combos(0);
            return View(model);
        }

        [HttpPost]
        public ActionResult Nuevo(ro_archivos_bancos_generacion_Info model)
        {



            model.detalle = ro_NominasPagosCheques_det_Info_list.get_list(model.IdTransaccionSession);
            model.IdRol = 1;
            if (model.detalle == null || model.detalle.Count() == 0)
            {
                ViewBag.mensaje = "No existe detalle para el archivo";
                cargar_combos(model.IdNomina);
                return View(model);
            }



            model.IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            model.IdUsuario = SessionFixed.IdUsuario;
            if (!bus_archivo.guardarDB(model))
            {
                cargar_combos(model.IdNomina);
                return View(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Modificar(int IdEmpresa = 0, decimal IdArchivo = 0)
        {
            #region Validar Session
            if (string.IsNullOrEmpty(SessionFixed.IdTransaccionSession))
                return RedirectToAction("Login", new { Area = "", Controller = "Account" });
            SessionFixed.IdTransaccionSession = (Convert.ToDecimal(SessionFixed.IdTransaccionSession) + 1).ToString();
            SessionFixed.IdTransaccionSessionActual = SessionFixed.IdTransaccionSession;
            #endregion
            ro_archivos_bancos_generacion_Info model = bus_archivo.get_info(IdEmpresa, IdArchivo);
            model.IdTransaccionSession = Convert.ToDecimal(SessionFixed.IdTransaccionSession);
            if (model == null)
                return RedirectToAction("Index");
            model.detalle = bus_archivo_detalle.get_list(IdEmpresa, IdArchivo);
            ro_NominasPagosCheques_det_Info_list.set_list(model.detalle, Convert.ToDecimal(SessionFixed.IdTransaccionSession));
            cargar_combos(model.IdNomina);
            return View(model);
        }

        [HttpPost]
        public ActionResult Modificar(ro_archivos_bancos_generacion_Info model)
        {
            model.detalle = ro_NominasPagosCheques_det_Info_list.get_list(model.IdTransaccionSession);
            if (model.detalle == null || model.detalle.Count() == 0)
            {
                ViewBag.mensaje = "No existe detalle para el arhivo";
                cargar_combos(model.IdNomina);
                return View(model);
            }
            model.IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            model.IdUsuarioUltMod = Session["IdUsuario"].ToString();
            if (!bus_archivo.modificarDB(model))
            {
                cargar_combos(model.IdNomina);
                return View(model);
            }
            return RedirectToAction("Index");

        }

        public ActionResult Anular(int IdEmpresa = 0, decimal IdArchivo = 0)
        {
            #region Validar Session
            if (string.IsNullOrEmpty(SessionFixed.IdTransaccionSession))
                return RedirectToAction("Login", new { Area = "", Controller = "Account" });
            SessionFixed.IdTransaccionSession = (Convert.ToDecimal(SessionFixed.IdTransaccionSession) + 1).ToString();
            SessionFixed.IdTransaccionSessionActual = SessionFixed.IdTransaccionSession;
            #endregion
            ro_archivos_bancos_generacion_Info model = bus_archivo.get_info(IdEmpresa, IdArchivo);
            if (model == null)
                return RedirectToAction("Index");
            model.detalle = bus_archivo_detalle.get_list(IdEmpresa, IdArchivo);
            ro_NominasPagosCheques_det_Info_list.set_list(model.detalle, Convert.ToDecimal(SessionFixed.IdTransaccionSession));
            cargar_combos(model.IdNomina);
            return View(model);
        }
        [HttpPost]
        public ActionResult Anular(ro_archivos_bancos_generacion_Info model)
        {
            model.detalle = ro_NominasPagosCheques_det_Info_list.get_list(model.IdTransaccionSession);

            model.IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            model.IdUsuarioUltAnu = Session["IdUsuario"].ToString();
            model.Fecha_UltAnu = DateTime.Now;
            if (!bus_archivo.anularDB(model))
            {
                cargar_combos(model.IdNomina);
                return View(model);
            }
            return RedirectToAction("Index");
        }


   
        public JsonResult CargarEmpleados(int IdProceso = 0, int IdNomina_Tipo = 0, int IdNomina_TipoLiqui = 0, int IdPeriodo = 0, decimal IdTransaccionSession = 0)
        {
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            string TipoCuenta = "";

            var infoProceso = bus_procesos_bancarios.get_info(IdEmpresa, IdProceso);
            if (infoProceso == null)
            {
                infoProceso = new Info.General.tb_banco_procesos_bancarios_x_empresa_Info();
                ro_NominasPagosCheques_det_Info_list.set_list(new List<ro_archivos_bancos_generacion_x_empleado_Info>(), Convert.ToDecimal(IdTransaccionSession));

            }
            else
            {
                if (infoProceso.IdProceso_bancario_tipo == cl_enumeradores.eTipoProcesoBancario.NCR.ToString())
                    TipoCuenta = cl_enumeradores.eTipoCuentaRRHH.AHO.ToString() + "," + cl_enumeradores.eTipoCuentaRRHH.COR.ToString();
                else
                    TipoCuenta = cl_enumeradores.eTipoCuentaRRHH.VRT.ToString();

                var detalle = bus_archivo_detalle.get_list(IdEmpresa, IdNomina_Tipo, IdNomina_TipoLiqui, IdPeriodo, TipoCuenta);
                ro_NominasPagosCheques_det_Info_list.set_list(detalle, Convert.ToDecimal(IdTransaccionSession));
            }
            return Json("", JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region cargar combos

        private void cargar_combos(int IdNomina)
        {
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);

            IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            ViewBag.lst_nomina = bus_nomina.get_list(IdEmpresa, false);
            ViewBag.lst_nomina_tipo = bus_nomina_tipo.get_list(IdEmpresa, IdNomina);

            var lst_cuenta_bancarias = bus_cuentas_bancarias.get_list(IdEmpresa, false);
            ViewBag.lst_cuenta_bancarias = lst_cuenta_bancarias;

            var lst_proceso = bus_procesos_bancarios.get_list(IdEmpresa, false);
            ViewBag.lst_proceso = lst_proceso;

            List<ro_periodo_x_ro_Nomina_TipoLiqui_Info> lst_periodos = new List<ro_periodo_x_ro_Nomina_TipoLiqui_Info>();
            ViewBag.lst_periodos = lst_periodos;
        }

        private void cargar_combos_consulta()
        {
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            var lst_sucursal = bus_sucursal.get_list(IdEmpresa, false);
            ViewBag.lst_sucursal = lst_sucursal;
        }
        #endregion

        #region funciones del detalle

        [HttpPost, ValidateInput(false)]
        public ActionResult EditingUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] ro_archivos_bancos_generacion_x_empleado_Info info_det)
        {
            if (ModelState.IsValid)
                ro_NominasPagosCheques_det_Info_list.UpdateRow(info_det, Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            ro_archivos_bancos_generacion_Info model = new ro_archivos_bancos_generacion_Info();
            model.detalle = ro_NominasPagosCheques_det_Info_list.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            return PartialView("_GridViewPartial_archivo_transferencia_det", model);
        }

        public ActionResult EditingDelete([ModelBinder(typeof(DevExpressEditorsBinder))] ro_archivos_bancos_generacion_x_empleado_Info info_det)
        {
            ro_NominasPagosCheques_det_Info_list.DeleteRow(info_det.IdEmpleado, Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            ro_archivos_bancos_generacion_Info model = new ro_archivos_bancos_generacion_Info();
            model.detalle = ro_NominasPagosCheques_det_Info_list.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            return PartialView("_GridViewPartial_archivo_transferencia_det", model);
        }
        #endregion



    }


    public class ro_NominasPagosCheques_det_Info_list
    {
        string variable = "ro_archivos_bancos_generacion_x_empleado_Info";
        public List<ro_archivos_bancos_generacion_x_empleado_Info> get_list(decimal IdTransaccionSession)
        {
            if (HttpContext.Current.Session[variable + IdTransaccionSession.ToString()] == null)
            {
                List<ro_archivos_bancos_generacion_x_empleado_Info> list = new List<ro_archivos_bancos_generacion_x_empleado_Info>();

                HttpContext.Current.Session[variable + IdTransaccionSession.ToString()] = list;
            }
            return (List<ro_archivos_bancos_generacion_x_empleado_Info>)HttpContext.Current.Session[variable + IdTransaccionSession.ToString()];
        }

        public void set_list(List<ro_archivos_bancos_generacion_x_empleado_Info> list, decimal IdTransaccionSession)
        {
            HttpContext.Current.Session[variable + IdTransaccionSession.ToString()] = list;
        }

        public void UpdateRow(ro_archivos_bancos_generacion_x_empleado_Info info_det, decimal IdTransaccionSession)
        {
            ro_archivos_bancos_generacion_x_empleado_Info edited_info = get_list(IdTransaccionSession).Where(m => m.IdEmpleado == info_det.IdEmpleado).First();
            edited_info.Valor = info_det.Valor;


        }


        public void DeleteRow(decimal IdEmpleado, decimal IdTransaccionSession)
        {
            List<ro_archivos_bancos_generacion_x_empleado_Info> list = get_list(IdTransaccionSession);
            list.Remove(list.Where(m => m.IdEmpleado == IdEmpleado).First());
        }
    }
}