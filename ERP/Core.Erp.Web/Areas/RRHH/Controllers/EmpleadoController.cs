﻿using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Erp.Bus.RRHH;
using Core.Erp.Info.RRHH;
using Core.Erp.Info.General;
using Core.Erp.Bus.General;
using Core.Erp.Bus.Contabilidad;
using DevExpress.Web;
using System.IO;
using Microsoft.SqlServer.Server;
using Core.Erp.Web.Helps;
using static Core.Erp.Info.General.tb_sis_log_error_InfoList;
using ExcelDataReader;
using System.Globalization;
using Core.Erp.Info.Helps;
using Core.Erp.Web.Areas.General.Controllers;
using static Core.Erp.Web.Areas.RRHH.Controllers.UploadControlSettings_Importacion;

namespace Core.Erp.Web.Areas.RRHH.Controllers
{
    public class EmpleadoController : Controller
    {
        #region variables

        int IdEmpresa = 0;
        Bus.RRHH.ro_empleado_Bus bus_empleado = new Bus.RRHH.ro_empleado_Bus();
        tb_Catalogo_Bus bus_catalogo_general = new tb_Catalogo_Bus();
        ro_catalogo_Bus bus_catalogorrhh = new ro_catalogo_Bus();
        tb_banco_Bus bus_banco = new tb_banco_Bus();
        ro_cargo_Bus bus_cargo = new ro_cargo_Bus();
        ro_departamento_Bus bus_departamento = new ro_departamento_Bus();
        ro_division_Bus bus_division = new ro_division_Bus();
        ro_area_Bus bus_area = new ro_area_Bus();
        tb_pais_Bus bus_pais = new tb_pais_Bus();
        tb_provincia_Bus bus_provincia = new tb_provincia_Bus();
        tb_ciudad_Bus bus_ciudad = new tb_ciudad_Bus();
        ct_punto_cargo_Bus bus_puntocargo = new ct_punto_cargo_Bus();
        ro_horario_Bus bus_horario = new ro_horario_Bus();
        tb_sucursal_Bus bus_sucursal = new tb_sucursal_Bus();

        tb_sis_log_error_List SisLogError = new tb_sis_log_error_List();
        ro_rubro_tipo_Info_list ListaRubro = new ro_rubro_tipo_Info_list();
        ro_horario_List ListaHorario = new ro_horario_List();
        ro_turno_List ListaTurno = new ro_turno_List();
        ro_empleado_info_list ListaEmpleado = new ro_empleado_info_list();
        ro_contrato_List ListaContrato = new ro_contrato_List();
        ro_cargaFamiliar_List ListaCargasFamiliares = new ro_cargaFamiliar_List();
        ro_rol_detalle_x_rubro_acumulado_List ListaProvisionesAcumuladas = new ro_rol_detalle_x_rubro_acumulado_List();
        ro_historico_vacaciones_x_empleado_Info_list ListaVacaciones = new ro_historico_vacaciones_x_empleado_Info_list();

        List<ro_division_Info> lista_division = new List<ro_division_Info>();
        ro_division_List ListaDivision = new ro_division_List();
        List<ro_area_Info> Lista_Area = new List<ro_area_Info>();
        ro_area_List ListaArea = new ro_area_List();
        List<ro_departamento_Info> Lista_Departamento = new List<ro_departamento_Info>();
        ro_departamento_List ListaDepartamento = new ro_departamento_List();
        List<ro_cargo_Info> Lista_Cargo = new List<ro_cargo_Info>();
        ro_cargo_List ListaCargo = new ro_cargo_List();
        List<ro_nomina_tipo_Info> Lista_TipoNomina = new List<ro_nomina_tipo_Info>();
        ro_nomina_tipo_List ListaTipoNomina = new ro_nomina_tipo_List();
        List<ro_empleado_x_rubro_acumulado_Info> Lista_RubrosAcumulados = new List<ro_empleado_x_rubro_acumulado_Info>();
        ro_empleado_x_rubro_acumulado_List ListaRubrosAcumulados = new ro_empleado_x_rubro_acumulado_List();
        List<ro_cargaFamiliar_Info> Lista_CargasFamiliares = new List<ro_cargaFamiliar_Info>();

        public static byte[] imagen { get; set; }
        public decimal IdEmpleado { get; set; }
        public static UploadedFile file { get; set; }
        public string UploadDirectory = "~/Content/imagenes/empleados";

        #endregion
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_empleados()
        {
            try
            {
                IdEmpresa = GetIdEmpresa();
                List<ro_empleado_Info> model = bus_empleado.get_list(IdEmpresa, true);
                return PartialView("_GridViewPartial_empleados", model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult Nuevo(ro_empleado_Info info)
        {
            try
            {
                string mensaje = "";
                mensaje = Validar(info);
                if (mensaje != "")
                {
                    if (info.em_foto == null)
                        info.em_foto = new byte[0];
                    ViewBag.mensaje = mensaje;
                    cargar_combos();
                    return View(info);
                }
                info.IdEmpresa = GetIdEmpresa();
                info.IdUsuario = SessionFixed.IdUsuario;
                var return_naturaleza = "";

                if (cl_funciones.ValidaIdentificacion(info.IdTipoDocumento, "", info.pe_cedulaRuc, ref return_naturaleza))
                {
                    if (!bus_empleado.guardarDB(info))
                    {
                        if (info.em_foto == null)
                            info.em_foto = new byte[0];
                        cargar_combos();
                        return View(info);
                    }
                }
                else
                {
                    ViewBag.mensaje = "Número de identificación inválida";
                    if (info.em_foto == null)
                        info.em_foto = new byte[0];
                    cargar_combos();
                    return View(info);
                }
                                      
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                if (info.em_foto == null)
                    info.em_foto = new byte[0];
                throw;
            }
        }
        public ActionResult Nuevo()
        {
            try
            {

                cargar_combos();
                ro_empleado_Info info = new ro_empleado_Info
                {
                    em_fechaIngaRol = DateTime.Now,
                    em_fechaSalida = DateTime.Now,
                    IdSucursal = Convert.ToInt32(SessionFixed.IdSucursal),
                    Pago_por_horas = true,
                    GozaMasDeQuinceDiasVaciones = false
                };
                info.em_foto = new byte[0];

                return View(info);

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult Modificar(ro_empleado_Info info)
        {
            try
            {
                string mensaje = "";
                mensaje = Validar(info);
                if (mensaje != "")
                {
                    if (info.em_foto == null)
                        info.em_foto = new byte[0];
                    ViewBag.mensaje = mensaje;
                    cargar_combos();
                    return View(info);
                }
                info.IdEmpresa = GetIdEmpresa();
                var return_naturaleza = "";

                if (cl_funciones.ValidaIdentificacion(info.IdTipoDocumento, "", info.pe_cedulaRuc, ref return_naturaleza))
                {
                    if (!bus_empleado.modificarDB(info))
                    {
                        if (info.em_foto == null)
                            info.em_foto = new byte[0];
                        cargar_combos();
                        return View(info);
                    }
                }
                else
                {
                    ViewBag.mensaje = "Número de identificación inválida";
                    if (info.em_foto == null)
                        info.em_foto = new byte[0];
                    cargar_combos();
                    return View(info);
                }
                                
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                if (info.em_foto == null)
                    info.em_foto = new byte[0];

                throw;
            }
        }

        public ActionResult Modificar(int IdEmpleado = 0)
        {
            try
            {
                cargar_combos();
                ro_empleado_Info info = new ro_empleado_Info();
                info = bus_empleado.get_info(GetIdEmpresa(), IdEmpleado);
                if (info.em_foto == null)
                    info.em_foto = new byte[0];

                try
                {
                    ViewBag.foto = info.IdEmpresa.ToString() + info.IdEmpleado.ToString() + ".jpg";

                    info.em_foto = System.IO.File.ReadAllBytes(Server.MapPath(UploadDirectory) + info.IdEmpresa.ToString() + info.IdEmpleado.ToString() + ".jpg");
                }
                catch (Exception)
                {

                    info.em_foto = new byte[0];
                }

                return View(info);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost]

        public ActionResult Anular(ro_empleado_Info info)
        {
            try
            {
                string mensaje = "";
                mensaje = Validar(info);
                if (mensaje != "")
                {
                    if (info.em_foto == null)
                        info.em_foto = new byte[0];
                    ViewBag.mensaje = mensaje;
                    cargar_combos();
                    return View(info);
                }
                info.IdEmpresa = GetIdEmpresa();
                if (!bus_empleado.anularDB(info))
                {
                    if (info.em_foto == null)
                        info.em_foto = new byte[0];
                    cargar_combos();
                    return View(info);
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                if (info.em_foto == null)
                    info.em_foto = new byte[0];

                throw;
            }
        }
        public ActionResult Anular(int Idempleado = 0)
        {
            try
            {
                IdEmpresa = GetIdEmpresa();
                cargar_combos();
                ro_empleado_Info info = new ro_empleado_Info();
                info = bus_empleado.get_info(GetIdEmpresa(), Idempleado);
                if (info.em_foto == null)
                    info.em_foto = new byte[0];

                try
                {

                    info.em_foto = System.IO.File.ReadAllBytes(Server.MapPath(UploadDirectory) + info.IdEmpresa.ToString() + info.IdEmpleado.ToString() + ".jpg");
                }
                catch (Exception)
                {

                    info.em_foto = new byte[0];
                }

                return View(info);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult Consulta(int Idempleado = 0)
        {
            try
            {
                cargar_combos();
                IdEmpresa = GetIdEmpresa();
                return View(bus_empleado.get_info(IdEmpresa, Idempleado));

            }
            catch (Exception)
            {

                throw;
            }
        }

        private int GetIdEmpresa()
        {
            try
            {
                if (Session["IdEmpresa"] != null)
                    return Convert.ToInt32(Session["IdEmpresa"]);
                else
                    return 0;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void cargar_combos()
        {
            try
            {
                IdEmpresa = GetIdEmpresa();
                ViewBag.lst_area = bus_area.get_list(IdEmpresa, false);
                ViewBag.lst_banco = bus_banco.get_list(false);
                ViewBag.lst_cargo = bus_cargo.get_list(IdEmpresa, false);
                ViewBag.lst_division = bus_division.get_list(IdEmpresa, false);
                ViewBag.lst_departamento = bus_departamento.get_list(IdEmpresa, false);
                ViewBag.lst_documento = bus_catalogo_general.get_list(3, false);
                ViewBag.lst_sexo = bus_catalogo_general.get_list(1, false);
                ViewBag.lst_estado_civil = bus_catalogo_general.get_list(2, false);
                ViewBag.lst_tipo_docu = bus_catalogo_general.get_list(3, false);
                ViewBag.lst_estado_empleado = bus_catalogorrhh.get_list_x_tipo(25);
                ViewBag.lst_pais = bus_pais.get_list(false);
                ViewBag.lst_ciudad = bus_ciudad.get_list("", false);
                ViewBag.lst_empleado = bus_empleado.get_list_combo(IdEmpresa);
                ViewBag.lst_punto_cargo = bus_puntocargo.get_list(IdEmpresa, false);
                ViewBag.lst_horario = bus_horario.get_list(IdEmpresa, false);
                ViewBag.lst_tipo_discapacidad = bus_catalogorrhh.get_list_x_tipo(26);
                ViewBag.lst_tipo_doc_sustutuido = bus_catalogorrhh.get_list_x_tipo(29);
                ViewBag.lst_tipo_sangre = bus_catalogorrhh.get_list_x_tipo(7);
                ViewBag.lst_tipo_licencia = bus_catalogorrhh.get_list_x_tipo(10);
                ViewBag.lst_tipo_cuenta = bus_catalogorrhh.get_list_x_tipo(9);
                ViewBag.lst_tipo_empleado = bus_catalogorrhh.get_list_x_tipo(8);
                ViewBag.lst_sucursal = bus_sucursal.get_list(IdEmpresa, false);


            }
            catch (Exception)
            {
                throw;
            }
        }

        private string Validar(ro_empleado_Info info)
        {
            try
            {
                string mensaje = "";
                if (info.pe_cedulaRuc == "")
                {
                    mensaje = "El campo cédula es obligatoria";
                }
                if (info.pe_nombre == "" | info.pe_nombre == null)
                {
                    mensaje = "El campo nombres es obligatoria";
                }
                if (info.pe_apellido == "" | info.pe_apellido == null)
                {
                    mensaje = "El campo apellidos es obligatoria";
                }
                if (info.pe_correo == "" | info.pe_correo == null)
                {
                    mensaje = "El campo correo es obligatoria";
                }
                if (info.pe_fechaNacimiento == null)
                {
                    mensaje = "El campo fecha nacimiento es obligatoria";
                }
                if (info.pe_celular == "" | info.pe_celular == null)
                {
                    mensaje = "El campo fecha nacimiento es obligatoria";
                }

                return mensaje;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult DragAndDropImageUpload([ModelBinder(typeof(DragAndDropSupportDemoBinder))]IEnumerable<UploadedFile> ucDragAndDrop)
        {

            //Extract Image File Name.
            string fileName = System.IO.Path.GetFileName(ucDragAndDrop.FirstOrDefault().FileName);

            //Set the Image File Path.
            UploadDirectory = UploadDirectory + SessionFixed.IdEmpresa + SessionFixed.NombreImagen + ".jpg";
            imagen = ucDragAndDrop.FirstOrDefault().FileBytes;
            //Save the Image File in Folder.
            ucDragAndDrop.FirstOrDefault().SaveAs(Server.MapPath(UploadDirectory));
            SessionFixed.NombreImagen = UploadDirectory;

            file = ucDragAndDrop.FirstOrDefault();
            return Json(ucDragAndDrop.FirstOrDefault().FileBytes, JsonRequestBehavior.AllowGet);


        }

        public JsonResult nombre_imagen(decimal IdEmpleado = 0)
        {
            try
            {
                if (IdEmpleado == 0)
                    IdEmpleado = bus_empleado.get_id(Convert.ToInt32(SessionFixed.IdEmpresa));
                SessionFixed.NombreImagen = IdEmpleado.ToString();
                return Json("", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult actualizar_div()
        {
            return Json(SessionFixed.NombreImagen, JsonRequestBehavior.AllowGet);
        }

        #region Importacion
        public ActionResult UploadControlUpload()
        {
            UploadControlExtension.GetUploadedFiles("UploadControlFile", UploadControlSettings_Importacion.UploadValidationSettings, UploadControlSettings_Importacion.FileUploadComplete);
            return null;
        }
        public ActionResult Importar(int IdEmpresa = 0)
        {
            #region Validar Session
            if (string.IsNullOrEmpty(SessionFixed.IdTransaccionSession))
                return RedirectToAction("Login", new { Area = "", Controller = "Account" });
            SessionFixed.IdTransaccionSession = (Convert.ToDecimal(SessionFixed.IdTransaccionSession) + 1).ToString();
            SessionFixed.IdTransaccionSessionActual = SessionFixed.IdTransaccionSession;
            #endregion

            ro_empleado_Info model = new ro_empleado_Info
            {
                IdEmpresa = IdEmpresa,
                IdTransaccionSession = Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual)
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Importar(ro_empleado_Info model)
        {
            try
            {
                var Lista_Rubro = ListaRubro.get_list();
                var Lista_Horario = ListaHorario.get_list(model.IdTransaccionSession);
                var Lista_Turno = ListaTurno.get_list(model.IdTransaccionSession);
                var Lista_Empleado = ListaEmpleado.get_list();
                var lista_division = ListaDivision.get_list(model.IdTransaccionSession);
                var Lista_Area = ListaArea.get_list(model.IdTransaccionSession);
                var Lista_Departamento = ListaDepartamento.get_list(model.IdTransaccionSession);
                var Lista_Cargo = ListaCargo.get_list(model.IdTransaccionSession);
                var Lista_Contrato = ListaContrato.get_list(model.IdTransaccionSession);
                var Lista_TipoNomina = ListaTipoNomina.get_list(model.IdTransaccionSession);
                var Lista_RubrosAcumulados = ListaRubrosAcumulados.get_list(model.IdTransaccionSession);
                var Lista_CargasFamiliares = ListaCargasFamiliares.get_list(model.IdTransaccionSession);
                var Lista_ProvisionesAcumuladas = ListaProvisionesAcumuladas.get_list(model.IdTransaccionSession);
                var Lista_Vacaciones = ListaVacaciones.get_list();

                if (!bus_empleado.guardarDB_importacion(Convert.ToInt32(SessionFixed.IdEmpresa), lista_division, Lista_Area, Lista_Departamento, Lista_Cargo,
                                                        Lista_Rubro, Lista_Horario, Lista_Turno, Lista_Empleado, Lista_RubrosAcumulados, Lista_TipoNomina, Lista_Contrato, 
                                                        Lista_CargasFamiliares, Lista_ProvisionesAcumuladas, Lista_Vacaciones))
                {
                    ViewBag.mensaje = "Error al importar el archivo";
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                SisLogError.set_list((ex.InnerException) == null ? ex.Message.ToString() : ex.InnerException.ToString());

                ViewBag.error = ex.Message.ToString();
                return View(model);
            }

            return RedirectToAction("Index");
        }

        public ActionResult GridViewPartial_Rubro_importacion()
        {
            SessionFixed.IdTransaccionSessionActual = Request.Params["TransaccionFixed"] != null ? Request.Params["TransaccionFixed"].ToString() : SessionFixed.IdTransaccionSessionActual;
            var model = ListaRubro.get_list();
            return PartialView("_GridViewPartial_Rubro_importacion", model);
        }

        public ActionResult GridViewPartial_Horario_importacion()
        {
            SessionFixed.IdTransaccionSessionActual = Request.Params["TransaccionFixed"] != null ? Request.Params["TransaccionFixed"].ToString() : SessionFixed.IdTransaccionSessionActual;
            var model = ListaHorario.get_list((Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual)));
            return PartialView("_GridViewPartial_Horario_importacion", model);
        }

        public ActionResult GridViewPartial_Turno_importacion()
        {
            SessionFixed.IdTransaccionSessionActual = Request.Params["TransaccionFixed"] != null ? Request.Params["TransaccionFixed"].ToString() : SessionFixed.IdTransaccionSessionActual;
            var model = ListaTurno.get_list((Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual)));
            return PartialView("_GridViewPartial_Turno_importacion", model);
        }

        public ActionResult GridViewPartial_Empleado_importacion()
        {
            SessionFixed.IdTransaccionSessionActual = Request.Params["TransaccionFixed"] != null ? Request.Params["TransaccionFixed"].ToString() : SessionFixed.IdTransaccionSessionActual;
            var model = ListaEmpleado.get_list();
            return PartialView("_GridViewPartial_Empleado_importacion", model);
        }

        public ActionResult GridViewPartial_Contrato_importacion()
        {
            SessionFixed.IdTransaccionSessionActual = Request.Params["TransaccionFixed"] != null ? Request.Params["TransaccionFixed"].ToString() : SessionFixed.IdTransaccionSessionActual;
            var model = ListaContrato.get_list((Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual)));
            return PartialView("_GridViewPartial_Contrato_importacion", model);
        }

        public ActionResult GridViewPartial_CargaFamiliar_importacion()
        {
            SessionFixed.IdTransaccionSessionActual = Request.Params["TransaccionFixed"] != null ? Request.Params["TransaccionFixed"].ToString() : SessionFixed.IdTransaccionSessionActual;
            var model = ListaCargasFamiliares.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            return PartialView("_GridViewPartial_CargaFamiliar_importacion", model);
        }

        public ActionResult GridViewPartial_ProvisionesAcumuladas_importacion()
        {
            SessionFixed.IdTransaccionSessionActual = Request.Params["TransaccionFixed"] != null ? Request.Params["TransaccionFixed"].ToString() : SessionFixed.IdTransaccionSessionActual;
            var model = ListaProvisionesAcumuladas.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            return PartialView("_GridViewPartial_ProvisionesAcumuladas_importacion", model);
        }

        public ActionResult GridViewPartial_Vacaciones_importacion()
        {
            SessionFixed.IdTransaccionSessionActual = Request.Params["TransaccionFixed"] != null ? Request.Params["TransaccionFixed"].ToString() : SessionFixed.IdTransaccionSessionActual;
            var model = ListaVacaciones.get_list();
            return PartialView("_GridViewPartial_Vacaciones_importacion", model);
        }

        public JsonResult ActualizarVariablesSession(int IdEmpresa = 0, decimal IdTransaccionSession = 0)
        {
            string retorno = string.Empty;
            SessionFixed.IdEmpresa = IdEmpresa.ToString();
            SessionFixed.IdTransaccionSession = IdTransaccionSession.ToString();
            SessionFixed.IdTransaccionSessionActual = IdTransaccionSession.ToString();
            return Json(retorno, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }


    public class DragAndDropSupportDemoBinder : DevExpressEditorsBinder
    {
        public DragAndDropSupportDemoBinder()
        {
            UploadControlBinderSettings.ValidationSettings.Assign(UploadControlDemosHelper.UploadValidationSettings);
            UploadControlBinderSettings.FileUploadCompleteHandler = UploadControlDemosHelper.FileUploadComplete;
        }
    }
    public class UploadControlDemosHelper
    {
        public static byte[] em_foto { get; set; }
        public static DevExpress.Web.UploadControlValidationSettings UploadValidationSettings = new DevExpress.Web.UploadControlValidationSettings()
        {
            AllowedFileExtensions = new string[] { ".jpg", ".jpeg", ".png" },
            MaxFileSize = 4000000
        };
        public static void FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {

            if (e.UploadedFile.IsValid)
            {
                em_foto = e.UploadedFile.FileBytes;
                //var filename = Path.GetFileName(e.UploadedFile.FileName);
                //e.UploadedFile.SaveAs("~/Content/imagenes/"+e.UploadedFile.FileName, true);
            }
        }
    }

    #region Upload Excel
    public class UploadControlSettings_Importacion
    {
        public static DevExpress.Web.UploadControlValidationSettings UploadValidationSettings = new DevExpress.Web.UploadControlValidationSettings()
        {
            AllowedFileExtensions = new string[] { ".xlsx" },
            MaxFileSize = 40000000
        };
        public static void FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
            #region Variables
            ro_empleado_Bus bus_empleado = new ro_empleado_Bus();
            tb_persona_Bus bus_persona = new tb_persona_Bus();
            ro_division_Bus bus_division = new ro_division_Bus();
            ro_area_Bus bus_area = new ro_area_Bus();
            tb_pais_Bus bus_pais = new tb_pais_Bus();
            tb_banco_Bus bus_banco = new tb_banco_Bus();
            tb_provincia_Bus bus_provincia = new tb_provincia_Bus();
            tb_ciudad_Bus bus_ciudad = new tb_ciudad_Bus();
            ro_cargo_Bus bus_cargo = new ro_cargo_Bus();
            ro_departamento_Bus bus_departamento = new ro_departamento_Bus();
            ro_catalogo_Bus bus_catalogorrhh = new ro_catalogo_Bus();
            tb_Catalogo_Bus bus_catalogo = new tb_Catalogo_Bus();

            ro_rubro_tipo_Info_list ListaRubro = new ro_rubro_tipo_Info_list();
            List<ro_rubro_tipo_Info> Lista_Rubro = new List<ro_rubro_tipo_Info>();
            ro_horario_List ListaHorario = new ro_horario_List();
            List<ro_horario_Info> Lista_Horario = new List<ro_horario_Info>();
            ro_turno_List ListaTurno = new ro_turno_List();
            List<ro_turno_Info> Lista_Turno = new List<ro_turno_Info>();
            ro_empleado_info_list ListaEmpleado = new ro_empleado_info_list();
            List<ro_empleado_Info> Lista_Empleado = new List<ro_empleado_Info>();
            ro_contrato_List ListaContrato = new ro_contrato_List();
            List<ro_contrato_Info> Lista_Contrato = new List<ro_contrato_Info>();
            ro_cargaFamiliar_List ListaCargasFamiliares = new ro_cargaFamiliar_List();
            List<ro_cargaFamiliar_Info> Lista_CargasFamiliares = new List<ro_cargaFamiliar_Info>();
            ro_rol_detalle_x_rubro_acumulado_List ListaProvisionesAcumuladas = new ro_rol_detalle_x_rubro_acumulado_List();
            List<ro_rol_detalle_x_rubro_acumulado_Info> Lista_ProvisionesAcumuladas = new List<ro_rol_detalle_x_rubro_acumulado_Info>();
            ro_historico_vacaciones_x_empleado_Info_list ListaVacaciones = new ro_historico_vacaciones_x_empleado_Info_list();
            List<ro_historico_vacaciones_x_empleado_Info> Lista_Vacaciones = new List<ro_historico_vacaciones_x_empleado_Info>();

            int cont = 0;
            decimal IdTransaccionSession = Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual);
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            #endregion


            Stream stream = new MemoryStream(e.UploadedFile.FileBytes);
            if (stream.Length > 0)
            {
                IExcelDataReader reader = null;
                reader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                #region Rubro                
                while (reader.Read())
                {
                    var orden = 1;
                    if (!reader.IsDBNull(0) && cont > 0)
                    {

                        ro_rubro_tipo_Info info = new ro_rubro_tipo_Info
                        {
                            IdEmpresa = IdEmpresa,
                            IdRubro = Convert.ToString(reader.GetValue(0)),
                            rub_codigo = Convert.ToString(reader.GetString(2)),
                            ru_codRolGen = (Convert.ToString(reader.GetString(1))).Trim(),
                            ru_descripcion = Convert.ToString(reader.GetValue(3)),
                            NombreCorto = Convert.ToString(reader.GetValue(4)),
                            ru_tipo = Convert.ToString(reader.GetValue(5)),
                            ru_estado = "A",
                            ru_orden = orden++,
                            rub_concep = false,
                            rub_ctacon = Convert.ToString(reader.GetValue(9)),
                            rub_provision = Convert.ToString(reader.GetValue(7)) == "SI" ? true : false,
                            rub_nocontab = Convert.ToString(reader.GetValue(8)) == "SI" ? true : false,
                            rub_aplica_IESS = Convert.ToString(reader.GetValue(6)) == "SI" ? true : false,
                            rub_acumula = false,
                            rub_acumula_descuento = false,
                            IdUsuario = SessionFixed.IdUsuario                            
                        };
                        Lista_Rubro.Add(info);
                    }
                    else
                    {
                        cont++;
                    }
                }
                ListaRubro.set_list(Lista_Rubro);
                #endregion

                //Para avanzar a la siguiente hoja de excel
                cont = 0;
                reader.NextResult();

                #region Horario                
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0) && cont > 0)
                    {
                        var hora = Convert.ToString(reader.GetValue(1));
                        ro_horario_Info info = new ro_horario_Info
                        {
                            IdEmpresa = IdEmpresa,
                            IdHorario = Convert.ToDecimal(reader.GetValue(0)),
                            HoraIni = new TimeSpan(Convert.ToDateTime(reader.GetValue(1)).Hour, Convert.ToDateTime(reader.GetValue(1)).Minute, Convert.ToDateTime(reader.GetValue(1)).Second),
                            HoraFin = new TimeSpan(Convert.ToDateTime(reader.GetValue(2)).Hour, Convert.ToDateTime(reader.GetValue(2)).Minute, Convert.ToDateTime(reader.GetValue(2)).Second),
                            ToleranciaEnt = Convert.ToInt32(reader.GetValue(3)),
                            ToleranciaReg_lunh = Convert.ToInt32(reader.GetValue(4)),
                            SalLunch = new TimeSpan(Convert.ToDateTime(reader.GetValue(5)).Hour, Convert.ToDateTime(reader.GetValue(5)).Minute, Convert.ToDateTime(reader.GetValue(5)).Second),
                            RegLunch = new TimeSpan(Convert.ToDateTime(reader.GetValue(6)).Hour, Convert.ToDateTime(reader.GetValue(6)).Minute, Convert.ToDateTime(reader.GetValue(6)).Second),
                            Descripcion = Convert.ToString(reader.GetValue(7)),
                            IdUsuario = SessionFixed.IdUsuario,
                            Estado = "A"
                        };
                        Lista_Horario.Add(info);
                    }
                    else
                    {
                        cont++;
                    }
                }
                ListaHorario.set_list(Lista_Horario, IdTransaccionSession);
                #endregion

                //Para avanzar a la siguiente hoja de excel
                cont = 0;
                reader.NextResult();

                #region Turno                
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0) && cont > 0)
                    {

                        ro_turno_Info info = new ro_turno_Info
                        {
                            IdEmpresa = IdEmpresa,
                            IdTurno = Convert.ToDecimal(reader.GetValue(0)),
                            tu_descripcion = Convert.ToString(reader.GetValue(1)),
                            Lunes = Convert.ToString(reader.GetValue(1)) == "SI" ? true : false,
                            Martes = Convert.ToString(reader.GetValue(1)) == "SI" ? true : false,
                            Miercoles = Convert.ToString(reader.GetValue(1)) == "SI" ? true : false,
                            Jueves = Convert.ToString(reader.GetValue(1)) == "SI" ? true : false,
                            Viernes = Convert.ToString(reader.GetValue(1)) == "SI" ? true : false,
                            Sabado = Convert.ToString(reader.GetValue(1)) == "SI" ? true : false,
                            Domingo = Convert.ToString(reader.GetValue(1)) == "SI" ? true : false,
                            IdUsuario = SessionFixed.IdUsuario,
                            Estado = "A"
                        };
                        Lista_Turno.Add(info);
                    }
                    else
                    {
                        cont++;
                    }
                }
                ListaTurno.set_list(Lista_Turno, IdTransaccionSession);
                #endregion

                //Para avanzar a la siguiente hoja de excel
                cont = 0;
                reader.NextResult();

                #region Empleado  
                var lst_persona = bus_persona.get_list(false);
                var lst_banco = bus_banco.get_list(false);
                var lst_catalogo_tipo_empleado = bus_catalogorrhh.get_list_x_tipo(8);
                var lst_catalogo_sexo = bus_catalogo.get_list(1, false);

                List<ro_empleado_x_rubro_acumulado_Info> Lista_RubrosAcumulados = new List<ro_empleado_x_rubro_acumulado_Info>();
                ro_empleado_x_rubro_acumulado_List ListaRubrosAcumulados = new ro_empleado_x_rubro_acumulado_List();
                var IdEmpleado_guardar = 1;

                while (reader.Read())
                {
                    if (!reader.IsDBNull(0) && cont > 0)
                    {
                        var cedula_ruc = (Convert.ToString(reader.GetValue(2)).Trim());

                        tb_persona_Info info_persona = lst_persona.Where(q => q.pe_cedulaRuc.Trim() == cedula_ruc).FirstOrDefault();
                        tb_persona_Info info_persona_empleado = info_persona;
                        var return_naturaleza = "";
                        var Naturaleza = "NATU";                        
                        var tipo_doc = Convert.ToString(reader.GetValue(3));
                        var tipo_empleado = lst_catalogo_tipo_empleado.Where(q => q.CodCatalogo == Convert.ToString(reader.GetValue(14))).FirstOrDefault();
                        var desc_sexo = Convert.ToString(reader.GetValue(10)).Trim();
                        var sexo = lst_catalogo_sexo.Where(q => q.ca_descripcion.ToLower() == desc_sexo.ToLower()).FirstOrDefault();
                        var Horario = ListaHorario.get_list(IdTransaccionSession).Where(v => v.Descripcion == Convert.ToString(reader.GetValue(41))).FirstOrDefault();

                        if (cl_funciones.ValidaIdentificacion(tipo_doc, Naturaleza, cedula_ruc, ref return_naturaleza ))
                        {
                            if (info_persona == null)
                            {
                                tb_persona_Info info_ = new tb_persona_Info
                                {
                                    pe_Naturaleza = Naturaleza,
                                    pe_nombreCompleto = Convert.ToString(reader.GetValue(5)) + ' ' + Convert.ToString(reader.GetValue(4)),
                                    pe_apellido = Convert.ToString(reader.GetValue(5)),
                                    pe_nombre = Convert.ToString(reader.GetValue(4)),
                                    IdTipoDocumento = Convert.ToString(reader.GetValue(3)),
                                    pe_cedulaRuc = cedula_ruc,
                                    pe_direccion = Convert.ToString(reader.GetValue(6)),
                                    pe_telfono_Contacto = Convert.ToString(reader.GetValue(7)),
                                    pe_celular = Convert.ToString(reader.GetValue(8)),
                                    pe_correo = Convert.ToString(reader.GetValue(9)),
                                    pe_sexo = desc_sexo,
                                    IdEstadoCivil = Convert.ToString(reader.GetValue(11)),
                                    pe_fechaNacimiento = Convert.ToDateTime(reader.GetValue(12))
                                };

                                info_persona_empleado = info_;
                            }
                            else
                            {
                                info_persona_empleado = bus_persona.get_info(info_persona.IdPersona);
                                info_persona_empleado.IdPersona = info_persona.IdPersona;
                                info_persona_empleado.pe_Naturaleza = Naturaleza;
                                info_persona_empleado.pe_nombreCompleto = Convert.ToString(reader.GetValue(5)) + ' ' + Convert.ToString(reader.GetValue(4));
                                info_persona_empleado.pe_apellido = Convert.ToString(reader.GetValue(5));
                                info_persona_empleado.pe_nombre = Convert.ToString(reader.GetValue(4));
                                info_persona_empleado.IdTipoDocumento = Convert.ToString(reader.GetValue(3));
                                info_persona_empleado.pe_cedulaRuc = cedula_ruc;
                                info_persona_empleado.pe_direccion = Convert.ToString(reader.GetValue(6));
                                info_persona_empleado.pe_telfono_Contacto = Convert.ToString(reader.GetValue(7));
                                info_persona_empleado.pe_celular = Convert.ToString(reader.GetValue(8));
                                info_persona_empleado.pe_correo = Convert.ToString(reader.GetValue(9));
                                info_persona_empleado.pe_sexo = desc_sexo;
                                info_persona_empleado.IdEstadoCivil = Convert.ToString(reader.GetValue(11));
                                info_persona_empleado.pe_fechaNacimiento = Convert.ToDateTime(reader.GetValue(12));
                            }

                            info_persona_empleado.pe_Naturaleza = return_naturaleza;
                            ro_empleado_Info info = new ro_empleado_Info
                            {
                                IdEmpresa = IdEmpresa,
                                IdEmpleado = IdEmpleado_guardar++,
                                pe_cedulaRuc = cedula_ruc,
                                IdPersona = info_persona_empleado.IdPersona,
                                IdSucursal = Convert.ToInt32(reader.GetValue(36)),
                                IdTipoEmpleado = (tipo_empleado==null) ? "NO": tipo_empleado.CodCatalogo,
                                em_codigo = (Convert.ToString(reader.GetValue(1))!= "") ? Convert.ToString(reader.GetValue(1)) : null,
                                Codigo_Biometrico = (Convert.ToString(reader.GetValue(1))!= "") ? Convert.ToString(reader.GetValue(1)) : null,
                                em_lugarNacimiento = Convert.ToString(reader.GetValue(35)),
                                em_fechaIngaRol = Convert.ToDateTime(reader.GetValue(13)),
                                em_tipoCta = Convert.ToString(reader.GetValue(20)),
                                em_NumCta = Convert.ToString(reader.GetValue(21)),
                                em_estado = "A",
                                CodigoSectorial = (Convert.ToString(reader.GetValue(16))).Trim(),
                                de_descripcion = Convert.ToString(reader.GetValue(39)),
                                IdTipoSangre = Convert.ToString(reader.GetValue(22)),
                                ca_descripcion = Convert.ToString(reader.GetValue(40)).Trim(),
                                IdCtaCble_Emplea = null,
                                IdCiudad = Convert.ToString(reader.GetValue(35)),
                                em_mail = Convert.ToString(reader.GetValue(9)),
                                IdTipoLicencia = null,
                                ba_descripcion = Convert.ToString(reader.GetValue(19)),
                                ar_descripcion = Convert.ToString(reader.GetValue(38)),
                                di_descripcion = Convert.ToString(reader.GetValue(37)),
                                ho_descripcion = Convert.ToString(reader.GetValue(41)),
                                por_discapacidad = 0,
                                carnet_conadis = null,
                                talla_pant = Convert.ToDouble(reader.GetValue(23)),
                                talla_camisa = Convert.ToString(reader.GetValue(24)),
                                talla_zapato = Convert.ToDouble(reader.GetValue(25)),
                                em_status = "EST_ACT",
                                IdCondicionDiscapacidadSRI = null,
                                IdTipoIdentDiscapacitadoSustitutoSRI = null,
                                IdentDiscapacitadoSustitutoSRI = null,
                                IdAplicaConvenioDobleImposicionSRI = null,
                                IdTipoResidenciaSRI = null,
                                IdTipoSistemaSalarioNetoSRI = null,
                                es_AcreditaHorasExtras = Convert.ToString(reader.GetValue(18)) == "SI" ? true : false,
                                IdTipoAnticipo = null,
                                ValorAnticipo = null,
                                em_AnticipoSueldo = null,
                                Marca_Biometrico = Convert.ToString(reader.GetValue(17)) == "SI" ? true : false,
                                IdHorario = (Horario == null) ? 0 : Convert.ToInt32(Horario.IdHorario),
                                Tiene_ingresos_compartidos = false,
                                IdUsuario = SessionFixed.IdUsuario,
                                Fecha_Transaccion = DateTime.Now,
                                Pago_por_horas = Convert.ToString(reader.GetValue(26)) == "SI" ? true : false,
                                Valor_horas_vespertina = Convert.ToDouble(reader.GetValue(28)),
                                Valor_horas_brigada = Convert.ToDouble(reader.GetValue(31)),
                                Valor_horas_matutino = Convert.ToDouble(reader.GetValue(27)),
                                Valor_hora_adicionales = null,
                                DiasVacaciones = 15,
                                GozaMasDeQuinceDiasVaciones = false                                
                            };

                            info.info_persona = info_persona_empleado;

                            if (Lista_Empleado.Where(q => q.info_persona.pe_cedulaRuc == info_persona_empleado.pe_cedulaRuc).Count() == 0)
                                Lista_Empleado.Add(info);

                            #region RubrosAcumulados    
                            ro_rubros_calculados_Bus bus_rubros_acumulados = new ro_rubros_calculados_Bus();
                            var info_rubros = bus_rubros_acumulados.get_info(IdEmpresa);

                            //DIII
                            var xiii = Convert.ToString(reader.GetValue(32));
                            var xiv = Convert.ToString(reader.GetValue(33));
                            var fdr = Convert.ToString(reader.GetValue(34));

                            if (xiii == "SI")
                            {
                                ro_empleado_x_rubro_acumulado_Info info_rubro_acumulado = new ro_empleado_x_rubro_acumulado_Info
                                {
                                    IdEmpresa = IdEmpresa,
                                    pe_cedulaRuc = info_persona_empleado.pe_cedulaRuc,
                                    IdEmpleado = info.IdEmpleado,
                                    IdRubro = info_rubros.IdRubro_DIII,
                                    UsuarioIngresa = SessionFixed.IdUsuario,
                                    FechaIngresa = DateTime.Now
                                };

                                Lista_RubrosAcumulados.Add(info_rubro_acumulado);
                            }

                            //DIV
                            if (xiv == "SI")
                            {
                                ro_empleado_x_rubro_acumulado_Info info_rubro_acumulado = new ro_empleado_x_rubro_acumulado_Info
                                {
                                    IdEmpresa = IdEmpresa,
                                    pe_cedulaRuc = info_persona_empleado.pe_cedulaRuc,
                                    IdEmpleado = info.IdEmpleado,
                                    IdRubro = info_rubros.IdRubro_DIV,
                                    UsuarioIngresa = SessionFixed.IdUsuario,
                                    FechaIngresa = DateTime.Now
                                };

                                Lista_RubrosAcumulados.Add(info_rubro_acumulado);
                            }

                            //FDR
                            if (fdr == "SI")
                            {
                                ro_empleado_x_rubro_acumulado_Info info_rubro_acumulado = new ro_empleado_x_rubro_acumulado_Info
                                {
                                    IdEmpresa = IdEmpresa,
                                    pe_cedulaRuc = info_persona_empleado.pe_cedulaRuc,
                                    IdEmpleado = info.IdEmpleado,
                                    IdRubro = info_rubros.IdRubro_fondo_reserva,
                                    UsuarioIngresa = SessionFixed.IdUsuario,
                                    FechaIngresa = DateTime.Now
                                };

                                Lista_RubrosAcumulados.Add(info_rubro_acumulado);
                            }

                            ListaRubrosAcumulados.set_list(Lista_RubrosAcumulados, IdTransaccionSession);
                            #endregion
                        }
                    }
                    else
                    {
                        cont++;
                    }
                }
                ListaEmpleado.set_list(Lista_Empleado);

                #region division 
                List<ro_division_Info> lista_division;
                ro_division_List ListaDivision = new ro_division_List();

                lista_division = (from q in Lista_Empleado
                                  group q by new
                                  {
                                      q.IdEmpresa,
                                      q.di_descripcion,
                                  } into Grupo
                                  select new ro_division_Info
                                  {
                                      IdEmpresa = Grupo.Key.IdEmpresa,
                                      Descripcion = Grupo.Key.di_descripcion

                                  }).ToList();
                int secuncia = 1;
                lista_division.ForEach(
                     item =>
                     {
                         item.IdDivision = secuncia;
                         item.estado = "A";
                         item.IdUsuario = SessionFixed.IdUsuario;
                         secuncia++;
                     }
                    );

                ListaDivision.set_list(lista_division, IdTransaccionSession);
                #endregion

                #region Area 
                List<ro_area_Info> Lista_Area;
                ro_area_List ListaArea = new ro_area_List();

                Lista_Area = (from q in Lista_Empleado
                              group q by new
                              {
                                  q.IdEmpresa,
                                  q.ar_descripcion,
                              } into Area
                              select new ro_area_Info
                              {
                                  IdEmpresa = Area.Key.IdEmpresa,
                                  Descripcion = Area.Key.ar_descripcion

                              }).ToList();
                int secuencia = 1;
                Lista_Area.ForEach(
                     item =>
                     {
                         item.IdDivision = 1;
                         item.IdArea = secuencia;
                         item.estado = "A";
                         item.IdUsuario = SessionFixed.IdUsuario;
                         secuencia++;
                     }
                    );

                ListaArea.set_list(Lista_Area, IdTransaccionSession);
                #endregion

                #region Departamento 
                List<ro_departamento_Info> Lista_Departamento;
                ro_departamento_List ListaDepartamento = new ro_departamento_List();

                Lista_Departamento = (from q in Lista_Empleado
                                      group q by new
                                      {
                                          q.IdEmpresa,
                                          q.de_descripcion,
                                      } into Departamento
                                      select new ro_departamento_Info
                                      {
                                          IdEmpresa = Departamento.Key.IdEmpresa,
                                          de_descripcion = Departamento.Key.de_descripcion

                                      }).ToList();

                int IdDepartamento = 1;
                Lista_Departamento.ForEach(
                     item =>
                     {
                         item.IdDepartamento = IdDepartamento;
                         item.Estado = "A";
                         item.IdUsuario = SessionFixed.IdUsuario;
                         IdDepartamento++;
                     }
                    );

                ListaDepartamento.set_list(Lista_Departamento, IdTransaccionSession);
                #endregion

                #region Cargo 
                List<ro_cargo_Info> Lista_Cargo;
                ro_cargo_List ListaCargo = new ro_cargo_List();

                Lista_Cargo = (from q in Lista_Empleado
                                      group q by new
                                      {
                                          q.IdEmpresa,
                                          q.ca_descripcion,
                                      } into Departamento
                                      select new ro_cargo_Info
                                      {
                                          IdEmpresa = Departamento.Key.IdEmpresa,
                                          ca_descripcion = Departamento.Key.ca_descripcion

                                      }).ToList();

                int IdCargo = 1;
                Lista_Cargo.ForEach(
                     item =>
                     {
                         item.IdCargo = IdCargo;
                         item.Estado = "A";
                         item.IdUsuario = SessionFixed.IdUsuario;
                         IdCargo++;
                     }
                    );

                ListaCargo.set_list(Lista_Cargo, IdTransaccionSession);
                #endregion
                Lista_Empleado.ForEach(
                    item =>
                    {
                        var infoBanco = lst_banco.Where(v => v.ba_descripcion == item.ba_descripcion).FirstOrDefault();
                        item.IdDivision = ListaDivision.get_list(IdTransaccionSession).Where(v => v.Descripcion == item.di_descripcion).FirstOrDefault().IdDivision;
                        item.IdArea = ListaArea.get_list(IdTransaccionSession).Where(v => v.Descripcion == item.ar_descripcion).FirstOrDefault().IdArea;
                        item.IdDepartamento = ListaDepartamento.get_list(IdTransaccionSession).Where(v => v.de_descripcion == item.de_descripcion).FirstOrDefault().IdDepartamento;
                        item.IdCargo = ListaCargo.get_list(IdTransaccionSession).Where(v => v.ca_descripcion == item.ca_descripcion).FirstOrDefault().IdCargo;
                        item.IdBanco = (infoBanco == null) ? 0 : Convert.ToInt32(infoBanco.IdBanco);
                    }
                );
                #endregion

                //Para avanzar a la siguiente hoja de excel
                cont = 0;
                reader.NextResult();

                #region Contrato                  
                var lst_catalogo_contrato = bus_catalogorrhh.get_list_x_tipo(2);

                while (reader.Read())
                {
                    if (!reader.IsDBNull(0) && cont > 0)
                    {
                        var IdCont = 0;
                        var cedula_contrato = Convert.ToString(reader.GetValue(0)).Trim();
                        var InfoEmpleadoContrato = Lista_Empleado.Where(v => v.pe_cedulaRuc == cedula_contrato).FirstOrDefault();

                        if (InfoEmpleadoContrato != null)
                        {
                            IdCont++;
                            ro_contrato_Info info = new ro_contrato_Info
                            {
                                IdEmpresa = IdEmpresa,
                                IdContrato = IdCont,
                                cedula_ruc = Convert.ToString(reader.GetValue(0)),
                                contrato_tipo_descripcion = Convert.ToString(reader.GetValue(1)),
                                FechaInicio = Convert.ToDateTime(reader.GetValue(2)),
                                FechaFin = (Convert.ToDateTime(reader.GetValue(3)).Year ==1) ? new DateTime(2050,01,01) : Convert.ToDateTime(reader.GetValue(3)),
                                Sueldo = Convert.ToDouble(reader.GetValue(4)),
                                nomina_tipo_descripcion = Convert.ToString(reader.GetValue(5)),
                                NumDocumento = Convert.ToString(reader.GetValue(0)),
                                IdEmpleado = InfoEmpleadoContrato.IdEmpleado,
                                IdNomina = Convert.ToInt32(reader.GetValue(5)),
                                IdUsuario = SessionFixed.IdUsuario,
                                Fecha_Transac = DateTime.Now,
                                Observacion = "Importación de Empleados mediante Plantilla",
                                EstadoContrato = cl_enumeradores.eEstadoContratoRRHH.ECT_ACT.ToString(),
                                Estado = "A"
                            };

                            if (Lista_Contrato.Where(q => q.cedula_ruc == info.cedula_ruc).Count() == 0)
                                Lista_Contrato.Add(info);
                        }
                    }
                    else
                    {
                        cont++;
                    }
                }
                ListaContrato.set_list(Lista_Contrato, IdTransaccionSession);

                //#region TipoNomina 
                //List<ro_nomina_tipo_Info> Lista_TipoNomina;
                //ro_nomina_tipo_List ListaTipoNomina = new ro_nomina_tipo_List();

                //Lista_TipoNomina = (from q in Lista_Contrato
                //                    group q by new
                //                    {
                //                        q.IdEmpresa,
                //                        q.nomina_tipo_descripcion,
                //                    } into TipoNomina
                //                    select new ro_nomina_tipo_Info
                //                    {
                //                        IdEmpresa = TipoNomina.Key.IdEmpresa,
                //                        Descripcion = TipoNomina.Key.nomina_tipo_descripcion,
                //                        IdUsuario = SessionFixed.IdUsuario,
                //                        FechaTransac = DateTime.Now,
                //                        Estado = "A"
                //                    }).ToList();

                //int IdTipoNomina = 1;
                //Lista_TipoNomina.ForEach(
                //     item =>
                //     {
                //         item.IdNomina_Tipo = IdTipoNomina;
                //         IdTipoNomina++;
                //     }
                //    );

                //ListaTipoNomina.set_list(Lista_TipoNomina, IdTransaccionSession);
                //#endregion

                Lista_Contrato.ForEach(
                    item =>
                    {
                        //item.IdNomina = ListaTipoNomina.get_list(IdTransaccionSession).Where(v => v.Descripcion == item.nomina_tipo_descripcion).FirstOrDefault().IdNomina_Tipo;
                        item.IdContrato_Tipo = lst_catalogo_contrato.Where(q => q.ca_descripcion.ToString().ToUpper() == item.contrato_tipo_descripcion.ToString().ToUpper()).FirstOrDefault().CodCatalogo;
                    }
                );
                #endregion                

                //Para avanzar a la siguiente hoja de excel
                cont = 0;
                reader.NextResult();

                #region CargasFamiliares             
                //while (reader.Read())
                //{
                //    var IdCargaFamiliar = 1;
                //    var cedula_carga = Convert.ToString(reader.GetValue(1)).Trim();
                //    var cedula_empleado = Convert.ToString(reader.GetValue(0)).Trim();
                //    var tipo_familiar = Convert.ToString(reader.GetValue(5)).Trim();
                //    var InfoEmpleado = Lista_Empleado.Where(v => v.pe_cedulaRuc == cedula_empleado).FirstOrDefault();
                //    var lst_ro_catalogo = bus_catalogorrhh.get_list_x_tipo(3);

                //    if (!reader.IsDBNull(0) && cont > 0)
                //    {

                //        ro_cargaFamiliar_Info info = new ro_cargaFamiliar_Info
                //        {
                //            IdEmpresa = IdEmpresa,
                //            IdCargaFamiliar = IdCargaFamiliar++,
                //            IdEmpleado = InfoEmpleado.IdEmpleado,
                //            Cedula = cedula_carga,
                //            Sexo = "SEXO_MAS",
                //            TipoFamiliar = lst_ro_catalogo.Where(q=>q.ca_descripcion == tipo_familiar).FirstOrDefault().CodCatalogo,
                //            Nombres = Convert.ToString(reader.GetValue(2))+" "+ Convert.ToString(reader.GetValue(3)),
                //            FechaNacimiento = Convert.ToDateTime(reader.GetValue(4)),
                //            Estado = "A",
                //            FechaDefucion = null,
                //            capacidades_especiales = false                            
                //        };
                //        Lista_CargasFamiliares.Add(info);
                //    }
                //    else
                //    {
                //        cont++;
                //    }
                //}
                //ListaCargasFamiliares.set_list(Lista_CargasFamiliares, IdTransaccionSession);
                #endregion
            };
        }
    }
    #endregion

    public class ro_empleado_info_list
    {
        string variable = "ro_empleado_Info";
        public List<ro_empleado_Info> get_list()
        {
            if (HttpContext.Current.Session[variable] == null)
            {
                List<ro_empleado_Info> list = new List<ro_empleado_Info>();

                HttpContext.Current.Session[variable] = list;
            }
            return (List<ro_empleado_Info>)HttpContext.Current.Session[variable];
        }

        public void set_list(List<ro_empleado_Info> list)
        {
            HttpContext.Current.Session[variable] = list;
        }
    }

    public class ro_rol_detalle_x_rubro_acumulado_List
    {
        string Variable = "ro_rol_detalle_x_rubro_acumulado_Info";
        public List<ro_rol_detalle_x_rubro_acumulado_Info> get_list(decimal IdTransaccionSession)
        {
            if (HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] == null)
            {
                List<ro_rol_detalle_x_rubro_acumulado_Info> list = new List<ro_rol_detalle_x_rubro_acumulado_Info>();

                HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] = list;
            }
            return (List<ro_rol_detalle_x_rubro_acumulado_Info>)HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()];
        }

        public void set_list(List<ro_rol_detalle_x_rubro_acumulado_Info> list, decimal IdTransaccionSession)
        {
            HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] = list;
        }
    }
}