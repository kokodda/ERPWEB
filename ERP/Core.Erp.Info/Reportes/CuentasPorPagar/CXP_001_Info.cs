﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Info.Reportes.CuentasPorPagar
{
    public class CXP_001_Info
    {

        public int IdEmpresa { get; set; }
        public decimal IdCbteCble_Ogiro { get; set; }
        public int IdTipoCbte_Ogiro { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string codigoSRI { get; set; }
        public string co_descripcion { get; set; }
        public string em_nombre { get; set; }
        public string Su_Descripcion { get; set; }
        public string pr_nombre { get; set; }
        public Nullable<int> IdIden_credito { get; set; }
        public string IdOrden_giro_Tipo { get; set; }
        public decimal IdProveedor { get; set; }
        public System.DateTime co_fechaOg { get; set; }
        public string co_serie { get; set; }
        public string co_factura { get; set; }
        public System.DateTime co_FechaFactura { get; set; }
        public System.DateTime co_FechaFactura_vct { get; set; }
        public string co_observacion { get; set; }
        public double co_subtotal_iva { get; set; }
        public double co_subtotal_siniva { get; set; }
        public double co_baseImponible { get; set; }
        public double co_total { get; set; }
        public double co_valorpagar { get; set; }
        public int secuencia { get; set; }
        public string IdCtaCble { get; set; }
        public string pc_Cuenta { get; set; }
        public double dc_Valor { get; set; }
        public double dc_Valor_Debe { get; set; }
        public Nullable<double> dc_Valor_Haber { get; set; }
        public string dc_Observacion { get; set; }
        public string NombreUsuario { get; set; }
        public Nullable<int> IdPunto_cargo_grupo { get; set; }
        public Nullable<int> IdPunto_cargo { get; set; }
        public string IdCentroCosto { get; set; }
        public string cc_Descripcion { get; set; }
        public string nom_punto_cargo { get; set; }
        public string nom_punto_cargo_grupo { get; set; }
        public Nullable<System.DateTime> co_FechaContabilizacion { get; set; }
        public int co_plazo { get; set; }
        public string pr_correo { get; set; }
    }
}
