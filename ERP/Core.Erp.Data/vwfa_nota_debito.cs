//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Erp.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class vwfa_nota_debito
    {
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public int IdBodega { get; set; }
        public decimal IdNota { get; set; }
        public Nullable<int> dev_IdEmpresa { get; set; }
        public Nullable<decimal> dev_IdDev_Inven { get; set; }
        public string CodNota { get; set; }
        public string CreDeb { get; set; }
        public string CodDocumentoTipo { get; set; }
        public string Serie1 { get; set; }
        public string Serie2 { get; set; }
        public string NumNota_Impresa { get; set; }
        public string NumAutorizacion { get; set; }
        public Nullable<System.DateTime> Fecha_Autorizacion { get; set; }
        public string Nombres { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
        public string pe_Naturaleza { get; set; }
        public string pe_cedulaRuc { get; set; }
        public string IdTipoDocumento { get; set; }
        public string pe_nombreCompleto { get; set; }
        public string pe_razonSocial { get; set; }
        public System.DateTime no_fecha { get; set; }
        public string sc_observacion { get; set; }
        public string em_direccion { get; set; }
        public string em_ruc { get; set; }
        public string RazonSocial { get; set; }
        public string NombreComercial { get; set; }
        public string Expr1 { get; set; }
        public string ContribuyenteEspecial { get; set; }
        public string ObligadoAllevarConta { get; set; }
        public string vt_serie1 { get; set; }
        public string vt_serie2 { get; set; }
        public string vt_NumFactura { get; set; }
        public System.DateTime vt_fecha { get; set; }
        public Nullable<decimal> importeTotal { get; set; }
        public Nullable<decimal> impuesto { get; set; }
        public string em_telefonos { get; set; }
        public Nullable<decimal> total_sin_impuesto { get; set; }
        public Nullable<decimal> totalDescuento { get; set; }
    }
}
