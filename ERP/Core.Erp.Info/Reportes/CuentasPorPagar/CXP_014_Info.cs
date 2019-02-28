﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Info.Reportes.CuentasPorPagar
{
    public class CXP_014_Info
    {
        public int IdEmpresa { get; set; }
        public decimal IdCbteCble_Ogiro { get; set; }
        public int IdTipoCbte_Ogiro { get; set; }
        public string IdOrden_giro_Tipo { get; set; }
        public decimal IdProveedor { get; set; }
        public System.DateTime co_fechaOg { get; set; }
        public string co_serie { get; set; }
        public string co_factura { get; set; }
        public System.DateTime co_FechaFactura { get; set; }
        public Nullable<System.DateTime> co_FechaContabilizacion { get; set; }
        public System.DateTime co_FechaFactura_vct { get; set; }
        public int co_plazo { get; set; }
        public string co_observacion { get; set; }
        public double co_subtotal_iva { get; set; }
        public double co_subtotal_siniva { get; set; }
        public double co_baseImponible { get; set; }
        public double co_Por_iva { get; set; }
        public double co_valoriva { get; set; }
        public Nullable<int> IdCod_ICE { get; set; }
        public double co_total { get; set; }
        public string co_vaCoa { get; set; }
        public Nullable<int> IdIden_credito { get; set; }
        public Nullable<int> IdCod_101 { get; set; }
        public double co_valorpagar { get; set; }
        public Nullable<decimal> IdTipoFlujo { get; set; }
        public string IdTipoServicio { get; set; }
        public string Estado { get; set; }
        public int IdSucursal { get; set; }
        public string PagoLocExt { get; set; }
        public string PaisPago { get; set; }
        public string ConvenioTributacion { get; set; }
        public string PagoSujetoRetencion { get; set; }
        public Nullable<double> BseImpNoObjDeIva { get; set; }
        public Nullable<System.DateTime> fecha_autorizacion { get; set; }
        public string Num_Autorizacion { get; set; }
        public string Num_Autorizacion_Imprenta { get; set; }
        public Nullable<bool> cp_es_comprobante_electronico { get; set; }
        public string Tipodoc_a_Modificar { get; set; }
        public string estable_a_Modificar { get; set; }
        public string ptoEmi_a_Modificar { get; set; }
        public string num_docu_Modificar { get; set; }
        public string aut_doc_Modificar { get; set; }
        public Nullable<int> IdTipoMovi { get; set; }
        public string pe_apellido { get; set; }
        public string pe_nombre { get; set; }
        public string pe_razonSocial { get; set; }
        public string pe_nombreCompleto { get; set; }
        public string pe_cedulaRuc { get; set; }
        public string Descripcion { get; set; }
    }
}