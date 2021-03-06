﻿using Core.Erp.Bus.General;
using Core.Erp.Bus.RRHH;
using Core.Erp.Info.Helps;
using Core.Erp.Info.RRHH;
using Core.Erp.Web.Helps;
using DevExpress.DataAccess.Excel;
using DevExpress.Web.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExcelDataReader;
using Core.Erp.Info.General;
using DevExpress.Web;
using Core.Erp.Bus.Contabilidad;

namespace Core.Erp.Web.Areas.RRHH.Controllers
{
    public class ImportacionNovedadesController : Controller
    {
        #region Variables
        ro_EmpleadoNovedadCargaMasiva_Bus bus_novedad = new ro_EmpleadoNovedadCargaMasiva_Bus();
        ro_nomina_tipo_Bus bus_nomina = new ro_nomina_tipo_Bus();
        ro_Nomina_Tipoliquiliqui_Bus bus_nomina_tipo = new ro_Nomina_Tipoliquiliqui_Bus();
        ro_EmpleadoNovedadCargaMasiva_det_Bus bus_novedad_detalle_bus = new ro_EmpleadoNovedadCargaMasiva_det_Bus();
        ro_EmpleadoNovedadCargaMasiva_detLis_Info detalle = new ro_EmpleadoNovedadCargaMasiva_detLis_Info();
        ro_rubro_tipo_Bus bus_rubro = new ro_rubro_tipo_Bus();
        ro_empleado_Bus bus_empleado = new ro_empleado_Bus();
        ro_contrato_Bus bus_contrato = new ro_contrato_Bus();
        List<ro_rubro_tipo_Info> lst_rubros = new List<ro_rubro_tipo_Info>();
        tb_sucursal_Bus bus_sucursal = new tb_sucursal_Bus();
        ro_empleado_info_list empleado_info_list = new ro_empleado_info_list();
        string mensaje = string.Empty;
        ct_periodo_Bus bus_periodo = new ct_periodo_Bus();
        int IdEmpresa = 0;
        ro_EmpleadoNovedadCargaMasiva_List Lista_NovedadMasiva = new ro_EmpleadoNovedadCargaMasiva_List();
        #endregion

        #region Vistas
        public ActionResult Index()
        {
            #region Validar Session
            if (string.IsNullOrEmpty(SessionFixed.IdTransaccionSession))
                return RedirectToAction("Login", new { Area = "", Controller = "Account" });
            SessionFixed.IdTransaccionSession = (Convert.ToDecimal(SessionFixed.IdTransaccionSession) + 1).ToString();
            SessionFixed.IdTransaccionSessionActual = SessionFixed.IdTransaccionSession;
            #endregion

            cl_filtros_Info model = new cl_filtros_Info
            {
                IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa),
                IdSucursal = Convert.ToInt32(SessionFixed.IdSucursal),
                fecha_ini = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1),
                fecha_fin = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1),
                IdTransaccionSession = Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual)
            };

            List<ro_EmpleadoNovedadCargaMasiva_Info> lista = bus_novedad.get_list(model.IdEmpresa, model.fecha_ini, model.fecha_fin, model.IdSucursal, false);
            Lista_NovedadMasiva.set_list(lista, Convert.ToDecimal(model.IdTransaccionSession));

            return View(model);
        }
        [HttpPost]
        public ActionResult Index(cl_filtros_Info model)
        {
            SessionFixed.IdTransaccionSessionActual = model.IdTransaccionSession.ToString();
            List<ro_EmpleadoNovedadCargaMasiva_Info> lista = bus_novedad.get_list(model.IdEmpresa, model.fecha_ini, model.fecha_fin, model.IdSucursal, false);
            Lista_NovedadMasiva.set_list(lista, Convert.ToDecimal(model.IdTransaccionSession));

            return View(model);

        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_importacion_novedades(DateTime? Fecha_ini, DateTime? Fecha_fin, int IdSucursal=0)
        {
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            ViewBag.Fecha_ini = Fecha_ini == null ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1) : Convert.ToDateTime(Fecha_ini);
            ViewBag.Fecha_fin = Fecha_fin == null ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1) : Convert.ToDateTime(Fecha_fin);
            ViewBag.IdSucursal = IdSucursal;

            SessionFixed.IdTransaccionSessionActual = Request.Params["TransaccionFixed"] != null ? Request.Params["TransaccionFixed"].ToString() : SessionFixed.IdTransaccionSessionActual;

            List<ro_EmpleadoNovedadCargaMasiva_Info> model = Lista_NovedadMasiva.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            return PartialView("_GridViewPartial_importacion_novedades", model);
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_importacion_novedades_det()
        {
            ro_EmpleadoNovedadCargaMasiva_Info modelReturn = new ro_EmpleadoNovedadCargaMasiva_Info();
            SessionFixed.IdTransaccionSessionActual = Request.Params["TransaccionFixed"] != null ? Request.Params["TransaccionFixed"].ToString() : SessionFixed.IdTransaccionSessionActual;

            modelReturn.detalle = detalle.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            return PartialView("_GridViewPartial_importacion_novedades_det", modelReturn);
        }
        #endregion

        #region acciones
        public ActionResult Nuevo()
        {
            #region Validar Session
            if (string.IsNullOrEmpty(SessionFixed.IdTransaccionSession))
                return RedirectToAction("Login", new { Area = "", Controller = "Account" });
            SessionFixed.IdTransaccionSession = (Convert.ToDecimal(SessionFixed.IdTransaccionSession) + 1).ToString();
            SessionFixed.IdTransaccionSessionActual = SessionFixed.IdTransaccionSession;
            #endregion

            empleado_info_list.set_list(bus_empleado.get_list_combo(Convert.ToInt32(SessionFixed.IdEmpresa)), Convert.ToDecimal(SessionFixed.IdTransaccionSession));

            ro_EmpleadoNovedadCargaMasiva_Info model = new ro_EmpleadoNovedadCargaMasiva_Info
            {
                IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa),                
                FechaCarga = DateTime.Now,
                IdNomina=1,
                IdNominaTipo=2,
                IdSucursal = Convert.ToInt32(SessionFixed.IdSucursal),
                IdTransaccionSession = Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual)
            };
            model.detalle = new List<ro_EmpleadoNovedadCargaMasiva_det_Info>();
            detalle.set_list(model.detalle, model.IdTransaccionSession);
            cargar_combos();
            return View(model);
        }

        [HttpPost]
        public ActionResult Nuevo(ro_EmpleadoNovedadCargaMasiva_Info model)
        {
            model.detalle = detalle.get_list(model.IdTransaccionSession);
            if (model.detalle == null || model.detalle.Count() == 0)
            {
                ViewBag.mensaje = "No existe detalle para la novedad";
                cargar_combos();
                return View(model);
            }

          

            model.IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            model.IdUsuario = SessionFixed.IdUsuario;
            if (!bus_novedad.GuardarDB(model))
            {
                SessionFixed.IdTransaccionSessionActual = model.IdTransaccionSession.ToString();
                cargar_combos();
                return View(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Anular(int IdEmpresa = 0, decimal IdCarga=0)
        {
            #region Validar Session
            if (string.IsNullOrEmpty(SessionFixed.IdTransaccionSession))
                return RedirectToAction("Login", new { Area = "", Controller = "Account" });
            SessionFixed.IdTransaccionSession = (Convert.ToDecimal(SessionFixed.IdTransaccionSession) + 1).ToString();
            SessionFixed.IdTransaccionSessionActual = SessionFixed.IdTransaccionSession;
            #endregion

            ro_EmpleadoNovedadCargaMasiva_Info model = bus_novedad.get_info(IdEmpresa,  IdCarga);
            if (model == null)
                return RedirectToAction("Index");
            model.IdTransaccionSession = Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual);
            model.detalle = bus_novedad_detalle_bus.get_list(IdEmpresa,  IdCarga);
            detalle.set_list(model.detalle, model.IdTransaccionSession);

            #region Validacion Periodo
            ViewBag.MostrarBoton = true;
            if (!bus_periodo.ValidarFechaTransaccion(IdEmpresa, model.FechaCarga, cl_enumeradores.eModulo.RRHH, 0, ref mensaje))
            {
                ViewBag.mensaje = mensaje;
                ViewBag.MostrarBoton = false;
            }
            #endregion

            cargar_combos();
            return View(model);
        }
        [HttpPost]
        public ActionResult Anular(ro_EmpleadoNovedadCargaMasiva_Info model)
        {
            model.detalle = detalle.get_list(model.IdTransaccionSession);
            model.IdUsuarioUltAnu = SessionFixed.IdUsuario;
            model.Fecha_UltAnu = DateTime.Now;
            if (!bus_novedad.AnularDB(model))
            {
                SessionFixed.IdTransaccionSessionActual = model.IdTransaccionSession.ToString();
                cargar_combos();
                return View(model);
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region cargar combos

        private void cargar_combos()
        {
            tb_sucursal_Bus bus_sucursal = new tb_sucursal_Bus();
            IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            ViewBag.lst_nomina = bus_nomina.get_list(IdEmpresa, false);
            ViewBag.lst_nomina_tipo = bus_nomina_tipo.get_list(IdEmpresa, 1);
            ViewBag.lst_sucursal = bus_sucursal.GetList(IdEmpresa, SessionFixed.IdUsuario, false);

            ViewBag.lst_rubro = bus_rubro.get_list(Convert.ToInt32(SessionFixed.IdEmpresa), false);
        }
        #endregion

        #region metodo bajo demanda sucursal
        public ActionResult CmbSucursal()
        {
            int model = new int();
            return PartialView("_CmbSucursal", model);
        }
        public List<tb_sucursal_Info> get_list_bajo_demanda_sucursal(ListEditItemsRequestedByFilterConditionEventArgs args)
        {
            return bus_sucursal.get_list_bajo_demanda(args, Convert.ToInt32(SessionFixed.IdEmpresa));
        }
        public tb_sucursal_Info get_info_bajo_demanda_sucursal(ListEditItemRequestedByValueEventArgs args)
        {
            return bus_sucursal.get_info_bajo_demanda(Convert.ToInt32(SessionFixed.IdEmpresa), args);
        }
        #endregion

        #region funciones del detalle

        [HttpPost, ValidateInput(false)]
        public ActionResult EditingUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] ro_EmpleadoNovedadCargaMasiva_det_Info info_det)
        {
            if (ModelState.IsValid)
                detalle.UpdateRow(info_det, Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            ro_EmpleadoNovedadCargaMasiva_Info model = new ro_EmpleadoNovedadCargaMasiva_Info();
            model.detalle = detalle.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            return PartialView("_GridViewPartial_importacion_novedades_det", model);
        }

        public ActionResult EditingDelete([ModelBinder(typeof(DevExpressEditorsBinder))] ro_EmpleadoNovedadCargaMasiva_det_Info info_det)
        {
            detalle.DeleteRow(info_det.Secuancia, Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            ro_EmpleadoNovedadCargaMasiva_Info model = new ro_EmpleadoNovedadCargaMasiva_Info();
            model.detalle = detalle.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            return PartialView("_GridViewPartial_importacion_novedades_det", model);
        }
        #endregion
       
      
        public ActionResult UploadControlUpload()
        {
            UploadControlExtension.GetUploadedFiles("UploadControlFile", UploadControlSettings.UploadValidationSettings, UploadControlSettings.FileUploadComplete);
            return null;
        }

    }
    public class UploadControlSettings
    {
        public static DevExpress.Web.UploadControlValidationSettings UploadValidationSettings = new DevExpress.Web.UploadControlValidationSettings()
        {
            AllowedFileExtensions = new string[] { ".xlsx" },
            MaxFileSize = 40000000
        };
        public static void FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
            int cont = 0;
            ro_empleado_info_list empleado_info_list = new ro_empleado_info_list();
            ro_EmpleadoNovedadCargaMasiva_detLis_Info EmpleadoNovedadCargaMasiva_detLis_Info = new ro_EmpleadoNovedadCargaMasiva_detLis_Info();
            List<ro_EmpleadoNovedadCargaMasiva_det_Info> lista_novedades = new List<ro_EmpleadoNovedadCargaMasiva_det_Info>();
            decimal IdTransaccionSession = Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual);

            Stream stream = new MemoryStream(e.UploadedFile.FileBytes);
            if (stream.Length > 0)
            {
                IExcelDataReader reader = null;
                reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        if (cont != 0)
                        {
                            string cedua = reader.GetString(0);
                            var empleado = empleado_info_list.get_list(IdTransaccionSession).Where(v => v.pe_cedulaRuc == cedua).FirstOrDefault();
                            if (empleado != null)
                            {
                                ro_EmpleadoNovedadCargaMasiva_det_Info info = new ro_EmpleadoNovedadCargaMasiva_det_Info
                                {
                                    Valor = Convert.ToDouble(reader.GetValue(3)),
                                    CantidadHoras = Convert.ToDouble(reader.GetValue(4)),

                                    pe_cedulaRuc = cedua,
                                    pe_apellido = empleado.Empleado,
                                    em_codigo = empleado.em_codigo,
                                    Secuancia = cont,
                                    IdEmpleado=empleado.IdEmpleado
                                };
                                lista_novedades.Add(info);
                            }
                        }
                        cont++;

                    }

                }
                EmpleadoNovedadCargaMasiva_detLis_Info.set_list(lista_novedades, IdTransaccionSession);
            }
        }


      
    }

    public class ro_EmpleadoNovedadCargaMasiva_List
    {
        string Variable = "ro_EmpleadoNovedadCargaMasiva_Info";
        public List<ro_EmpleadoNovedadCargaMasiva_Info> get_list(decimal IdTransaccionSession)
        {
            if (HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] == null)
            {
                List<ro_EmpleadoNovedadCargaMasiva_Info> list = new List<ro_EmpleadoNovedadCargaMasiva_Info>();

                HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] = list;
            }
            return (List<ro_EmpleadoNovedadCargaMasiva_Info>)HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()];
        }

        public void set_list(List<ro_EmpleadoNovedadCargaMasiva_Info> list, decimal IdTransaccionSession)
        {
            HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] = list;
        }
    }

    public class ro_EmpleadoNovedadCargaMasiva_detLis_Info
    {
        string Variable = "ro_EmpleadoNovedadCargaMasiva_det_Info";
        public List<ro_EmpleadoNovedadCargaMasiva_det_Info> get_list(decimal IdTransaccionSession)
        {
            if (HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] == null)
            {
                List<ro_EmpleadoNovedadCargaMasiva_det_Info> list = new List<ro_EmpleadoNovedadCargaMasiva_det_Info>();

                HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] = list;
            }
            return (List<ro_EmpleadoNovedadCargaMasiva_det_Info>)HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()];
        }

        public void set_list(List<ro_EmpleadoNovedadCargaMasiva_det_Info> list, decimal IdTransaccionSession)
        {
            HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] = list;
        }


        public void UpdateRow(ro_EmpleadoNovedadCargaMasiva_det_Info info_det, decimal IdTransaccionSession)
        {
            ro_EmpleadoNovedadCargaMasiva_det_Info edited_info = get_list(IdTransaccionSession).Where(m => m.Secuancia == info_det.Secuancia).First();
            edited_info.Valor = info_det.Valor;
            edited_info.Valor = info_det.Valor;
        }

        public void DeleteRow(int Secuencia, decimal IdTransaccionSession)
        {
            List<ro_EmpleadoNovedadCargaMasiva_det_Info> list = get_list(IdTransaccionSession);
            list.Remove(list.Where(m => m.Secuancia == Secuencia).First());
        }
    }


}