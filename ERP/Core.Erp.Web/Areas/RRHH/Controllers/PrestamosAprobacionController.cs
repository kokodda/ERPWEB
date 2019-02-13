﻿using Core.Erp.Bus.CuentasPorPagar;
using Core.Erp.Bus.RRHH;
using Core.Erp.Info.Helps;
using Core.Erp.Info.RRHH;
using Core.Erp.Web.Helps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Core.Erp.Web.Areas.RRHH.Controllers
{
    public class PrestamosAprobacionController : Controller
    {
        ro_prestamo_Bus bus_prestamos = new ro_prestamo_Bus();
        ro_prestamo_List list_prestamos_aprobar = new ro_prestamo_List();
        ro_Parametros_Bus bus_parametros = new ro_Parametros_Bus();
        cp_orden_pago_tipo_x_empresa_Bus bus_orden_pago_tipo_x_empresa = new cp_orden_pago_tipo_x_empresa_Bus();
        // GET: RRHH/PrestamosAprobacion
        public ActionResult Index()
        {
            cl_filtros_Info model = new cl_filtros_Info
            {
                IdEmpresa = string.IsNullOrEmpty(SessionFixed.IdEmpresa) ? 0 : Convert.ToInt32(SessionFixed.IdEmpresa),
                IdTransaccionSession = Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual)
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(cl_filtros_Info model)
        {
            model.IdEmpresa = string.IsNullOrEmpty(SessionFixed.IdEmpresa) ? 0 : Convert.ToInt32(SessionFixed.IdEmpresa);
            list_prestamos_aprobar.get_list(model.IdTransaccionSession);

            return View(model);
        }


        [ValidateInput(false)]
        public ActionResult GridViewPartial_prestamos_aprobacion(DateTime? Fecha_ini, DateTime? Fecha_fin)
        {
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            ViewBag.Fecha_ini = Fecha_ini == null ? DateTime.Now.Date.AddMonths(-1) : Convert.ToDateTime(Fecha_ini);
            ViewBag.Fecha_fin = Fecha_fin == null ? DateTime.Now.Date : Convert.ToDateTime(Fecha_fin);
            List<ro_prestamo_Info> model = bus_prestamos.get_list_aprobacion(IdEmpresa, Convert.ToDateTime(Fecha_ini), Convert.ToDateTime(Fecha_fin));
            return PartialView("_GridViewPartial_prestamos_aprobacion", model);
        }

        public JsonResult aprobar(int IdEmpresa = 0, string Ids = "")
        {
            var info_parametros = bus_parametros.get_info(IdEmpresa);
            var info_op_tipo = bus_orden_pago_tipo_x_empresa.get_info(IdEmpresa, info_parametros.IdTipo_op_prestamos);
          

            string[] array = Ids.Split(',');
            string IdUsuarioAprueba = SessionFixed.IdUsuario;

            if (string.IsNullOrEmpty(Ids))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (string.IsNullOrEmpty(info_op_tipo.IdCtaCble) || string.IsNullOrEmpty(info_op_tipo.IdCtaCble_Credito))
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var resultado_orden = bus_prestamos.aprobar_prestamo(IdEmpresa, array, IdUsuarioAprueba);
                    return Json(resultado_orden, JsonRequestBehavior.AllowGet);
                }                
            }         
        }
    }

    public class ro_prestamo_List
    {
        string variable = "ro_prestamo_Info";
        public List<ro_prestamo_Info> get_list(decimal IdTransaccionSession)
        {
            if (HttpContext.Current.Session[variable + IdTransaccionSession.ToString()] == null)
            {
                List<ro_prestamo_Info> list = new List<ro_prestamo_Info>();

                HttpContext.Current.Session[variable + IdTransaccionSession.ToString()] = list;
            }
            return (List<ro_prestamo_Info>)HttpContext.Current.Session[variable + IdTransaccionSession.ToString()];
        }
        public void set_list(List<ro_prestamo_Info> list, decimal IdTransaccionSession)
        {
            HttpContext.Current.Session[variable + IdTransaccionSession.ToString()] = list;
        }
    }
}