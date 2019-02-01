﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Core.Erp.Bus.Reportes.Inventario;
using Core.Erp.Info.Reportes.Inventario;
using System.Collections.Generic;

namespace Core.Erp.Web.Reportes.Inventario
{
    public partial class INV_015_Rpt : DevExpress.XtraReports.UI.XtraReport
    {
        public string usuario { get; set; }
        public string empresa { get; set; }
        public INV_015_Rpt()
        {
            InitializeComponent();
        }

        private void INV_015_Rpt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lbl_fecha.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            lbl_empresa.Text = empresa;
            lbl_usuario.Text = usuario;
            int IdEmpresa = string.IsNullOrEmpty(p_IdEmpresa.Value.ToString()) ? 0 : Convert.ToInt32(p_IdEmpresa.Value);
            int IdSucursal = string.IsNullOrEmpty(p_IdSucursal.Value.ToString()) ? 0 : Convert.ToInt32(p_IdSucursal.Value);
            int IdBodega = string.IsNullOrEmpty(p_IdBodega.Value.ToString()) ? 0 : Convert.ToInt32(p_IdBodega.Value);
            decimal IdProducto = string.IsNullOrEmpty(p_IdProducto.Value.ToString()) ? 0 : Convert.ToDecimal(p_IdProducto.Value);
            int IdCategoria = string.IsNullOrEmpty(p_IdCategoria.Value.ToString()) ? 0 : Convert.ToInt32(p_IdCategoria.Value);
            int IdLinea = string.IsNullOrEmpty(p_IdLinea.Value.ToString()) ? 0 : Convert.ToInt32(p_IdLinea.Value);
            int IdGrupo = string.IsNullOrEmpty(p_IdGrupo.Value.ToString()) ? 0 : Convert.ToInt32(p_IdGrupo.Value);
            int IdSubgrupo = string.IsNullOrEmpty(p_IdSubgrupo.Value.ToString()) ? 0 : Convert.ToInt32(p_IdSubgrupo.Value);

            INV_015_Bus bus_rpt = new INV_015_Bus();
            List<INV_015_Info> lst_rpt = bus_rpt.get_list(IdEmpresa, IdSucursal, IdBodega, IdProducto, IdCategoria, IdLinea, IdGrupo, IdSubgrupo);
            this.DataSource = lst_rpt;
        }
    }
}