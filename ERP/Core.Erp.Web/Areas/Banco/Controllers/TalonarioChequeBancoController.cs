﻿using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Erp.Bus.Banco;
using Core.Erp.Info.Banco;

namespace Core.Erp.Web.Areas.Banco.Controllers
{
    public class TalonarioChequeBancoController : Controller
    {
        ba_Talonario_cheques_x_banco_Bus bus_talonario = new ba_Talonario_cheques_x_banco_Bus();
        ba_Banco_Cuenta_Bus bus_bco_cuenta = new ba_Banco_Cuenta_Bus();
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_talonario_cheque()
        {
            List<ba_Talonario_cheques_x_banco_Info> model = new List<ba_Talonario_cheques_x_banco_Info>();
            int IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            model = bus_talonario.get_list(IdEmpresa, true);
            return PartialView("_GridViewPartial_talonario_cheque", model);
        }

        private void cargar_combos()
        {
            int IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            ba_Banco_Cuenta_Bus bus_banco = new ba_Banco_Cuenta_Bus();
            var lst_banco = bus_banco.get_list(IdEmpresa, false);
            ViewBag.lst_banco = lst_banco;
        }

        public ActionResult Nuevo()
        {
            ba_Talonario_cheques_x_banco_Info model = new ba_Talonario_cheques_x_banco_Info
            {
               IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]),
               Estado_bool = true
            };
            cargar_combos();
            return View(model);
        }

        [HttpPost]
        public ActionResult Nuevo(ba_Talonario_cheques_x_banco_Info model)
        {
            if (bus_talonario.validar_existe_Numcheque(model.Num_cheque))
            {
                ViewBag.mensaje = "El número ya se encuentra registrado";
                cargar_combos();
                return View(model);
            }

            if (!bus_talonario.guardarDB(model))
            {
                cargar_combos();
                return View(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Modificar(int IdBanco = 0, string Num_cheque = "")
        {
            int IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            ba_Talonario_cheques_x_banco_Info model = bus_talonario.get_info(IdEmpresa, IdBanco, Num_cheque);
                if (model == null) 
            return RedirectToAction("Index");
            cargar_combos();
            return View(model);
        }

        [HttpPost]
        public ActionResult Modificar(ba_Talonario_cheques_x_banco_Info model)
        {
            if(!bus_talonario.modificarDB(model))
            {
                cargar_combos();
                return View(model);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Anular(int IdBanco = 0, string Num_cheque = "")
        {
            int IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            ba_Talonario_cheques_x_banco_Info model = bus_talonario.get_info(IdEmpresa, IdBanco, Num_cheque);
            if (model == null)
                return RedirectToAction("Index");
            cargar_combos();
            return View(model);
        }

        [HttpPost]
        public ActionResult Anular(ba_Talonario_cheques_x_banco_Info model)
        {
            if (!bus_talonario.anularDB(model))
            {
                cargar_combos();
                return View(model);
            }
            return RedirectToAction("Index");
        }

        public JsonResult get_id(int IdBanco = 0)
        {
            int IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            var banco_cuenta = bus_bco_cuenta.get_info(IdEmpresa, IdBanco);
            var Numerocheque = bus_talonario.get_id(IdEmpresa, IdBanco, banco_cuenta.ba_num_digito_cheq);
            return Json(Numerocheque, JsonRequestBehavior.AllowGet);

        }
    }
}