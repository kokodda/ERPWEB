﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Info.Reportes.Facturacion
{
    public class FAC_003_Info
    {
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public int IdBodega { get; set; }
        public decimal IdCbteVta { get; set; }
        public int Secuencia { get; set; }
        public decimal IdProducto { get; set; }
        public string pr_descripcion { get; set; }
        public double vt_cantidad { get; set; }
        public double vt_Precio { get; set; }
        public double SubtotalSinDscto { get; set; }
        public double SubtotalConDscto { get; set; }
        public double vt_iva { get; set; }
        public double vt_Total { get; set; }
        public System.DateTime vt_fecha { get; set; }
        public string vt_NumFactura { get; set; }
        public string cli_Nombre { get; set; }
        public string cli_cedulaRuc { get; set; }
        public string cli_direccion { get; set; }
        public string cli_Telefonos { get; set; }
        public string cli_correo { get; set; }
        public string Su_Descripcion { get; set; }
        public string Su_Telefonos { get; set; }
        public string Su_Direccion { get; set; }
        public string FormaDePago { get; set; }
        public string IdCatalogo_FormaPago { get; set; }
        public string vt_autorizacion { get; set; }
        public Nullable<System.DateTime> Fecha_Autorizacion { get; set; }
        public string vt_Observacion { get; set; }
        public Nullable<decimal> SubtotalIVASinDscto { get; set; }
        public Nullable<decimal> SubtotalSinIVASinDscto { get; set; }
        public Nullable<decimal> T_SubtotalSinDscto { get; set; }
        public Nullable<decimal> Descuento { get; set; }
        public Nullable<decimal> SubtotalIVAConDscto { get; set; }
        public Nullable<decimal> SubtotalSinIVAConDscto { get; set; }
        public Nullable<decimal> T_SubtotalConDscto { get; set; }
        public Nullable<decimal> ValorIVA { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<decimal> ValorEfectivo { get; set; }
        public Nullable<decimal> Cambio { get; set; }
        public string vt_detallexItems { get; set; }

        public string ValorEnLetras { get; set; }
    }
}
