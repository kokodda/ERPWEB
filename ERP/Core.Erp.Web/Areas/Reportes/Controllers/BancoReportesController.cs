﻿using Core.Erp.Web.Reportes.Banco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Core.Erp.Web.Areas.Reportes.Controllers
{
    public class BancoReportesController : Controller
    {
        public ActionResult BAN_001(int IdEmpresa = 0, int IdTipoCbte = 0, decimal IdCbteCble = 0)
        {
            BAN_001_Rpt model = new BAN_001_Rpt();
            model.p_IdEmpresa.Value = Convert.ToInt32(Session["IdEmpresa"]);
            model.p_IdTipoCbte.Value = IdTipoCbte;
            model.p_IdCbteCble.Value = IdCbteCble;
            model.usuario = Session["IdUsuario"].ToString();
            model.empresa = Session["nom_empresa"].ToString();
            if (IdTipoCbte == 0)
                model.RequestParameters = false;
            return View(model);
        }
        public ActionResult BAN_002(int IdEmpresa = 0, int IdTipocbte = 0, decimal IdCbteCble = 0)
        {
            BAN_002_Rpt model = new BAN_002_Rpt();
            model.p_IdEmpresa.Value = Convert.ToInt32(Session["IdEmpresa"]);
            model.p_IdTipocbte.Value = IdTipocbte;
            model.p_IdCbteCble.Value = IdCbteCble;
            model.usuario = Session["IdUsuario"].ToString();
            model.empresa = Session["nom_empresa"].ToString();
            if (IdTipocbte == 0)
                model.RequestParameters = false;
            return View(model);
        }
        public ActionResult BAN_003(int IdEmpresa = 0, int IdTipocbte = 0, decimal IdCbteCble = 0)
        {
            BAN_003_Rpt model = new BAN_003_Rpt();
            model.p_IdEmpresa.Value = Convert.ToInt32(Session["IdEmpresa"]);
            model.p_IdTipocbte.Value = IdTipocbte;
            model.p_IdCbteCble.Value = IdCbteCble;
            model.usuario = Session["IdUsuario"].ToString();
            model.empresa = Session["nom_empresa"].ToString();
            if (IdTipocbte == 0)
                model.RequestParameters = false;
            return View(model);
        }
    }
}