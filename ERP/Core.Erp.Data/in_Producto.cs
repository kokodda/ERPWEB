//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Erp.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class in_Producto
    {
        public in_Producto()
        {
            this.in_ConsignacionDet = new HashSet<in_ConsignacionDet>();
            this.in_Ing_Egr_Inven_det = new HashSet<in_Ing_Egr_Inven_det>();
            this.in_Producto_Composicion = new HashSet<in_Producto_Composicion>();
            this.in_Producto_Composicion1 = new HashSet<in_Producto_Composicion>();
            this.in_Producto1 = new HashSet<in_Producto>();
            this.in_Producto_x_fa_NivelDescuento = new HashSet<in_Producto_x_fa_NivelDescuento>();
            this.in_producto_x_tb_bodega = new HashSet<in_producto_x_tb_bodega>();
            this.in_transferencia_det = new HashSet<in_transferencia_det>();
        }
    
        public int IdEmpresa { get; set; }
        public decimal IdProducto { get; set; }
        public string pr_codigo { get; set; }
        public string pr_codigo2 { get; set; }
        public string pr_descripcion { get; set; }
        public string pr_descripcion_2 { get; set; }
        public int IdProductoTipo { get; set; }
        public int IdMarca { get; set; }
        public string IdPresentacion { get; set; }
        public string IdCategoria { get; set; }
        public int IdLinea { get; set; }
        public int IdGrupo { get; set; }
        public int IdSubGrupo { get; set; }
        public string IdUnidadMedida { get; set; }
        public string IdUnidadMedida_Consumo { get; set; }
        public string pr_codigo_barra { get; set; }
        public string pr_observacion { get; set; }
        public string IdUsuario { get; set; }
        public Nullable<System.DateTime> Fecha_Transac { get; set; }
        public string IdUsuarioUltMod { get; set; }
        public Nullable<System.DateTime> Fecha_UltMod { get; set; }
        public string IdUsuarioUltAnu { get; set; }
        public Nullable<System.DateTime> Fecha_UltAnu { get; set; }
        public string pr_motivoAnulacion { get; set; }
        public string nom_pc { get; set; }
        public string ip { get; set; }
        public string Estado { get; set; }
        public string IdCod_Impuesto_Iva { get; set; }
        public bool Aparece_modu_Ventas { get; set; }
        public bool Aparece_modu_Compras { get; set; }
        public bool Aparece_modu_Inventario { get; set; }
        public bool Aparece_modu_Activo_F { get; set; }
        public Nullable<decimal> IdProducto_padre { get; set; }
        public Nullable<System.DateTime> lote_fecha_fab { get; set; }
        public Nullable<System.DateTime> lote_fecha_vcto { get; set; }
        public string lote_num_lote { get; set; }
        public Nullable<double> precio_1 { get; set; }
        public Nullable<bool> se_distribuye { get; set; }
        public byte[] pr_imagen { get; set; }
    
        public virtual in_categorias in_categorias { get; set; }
        public virtual ICollection<in_ConsignacionDet> in_ConsignacionDet { get; set; }
        public virtual ICollection<in_Ing_Egr_Inven_det> in_Ing_Egr_Inven_det { get; set; }
        public virtual in_Marca in_Marca { get; set; }
        public virtual in_presentacion in_presentacion { get; set; }
        public virtual ICollection<in_Producto_Composicion> in_Producto_Composicion { get; set; }
        public virtual ICollection<in_Producto_Composicion> in_Producto_Composicion1 { get; set; }
        public virtual ICollection<in_Producto> in_Producto1 { get; set; }
        public virtual in_Producto in_Producto2 { get; set; }
        public virtual in_ProductoTipo in_ProductoTipo { get; set; }
        public virtual in_subgrupo in_subgrupo { get; set; }
        public virtual in_UnidadMedida in_UnidadMedida { get; set; }
        public virtual in_UnidadMedida in_UnidadMedida1 { get; set; }
        public virtual ICollection<in_Producto_x_fa_NivelDescuento> in_Producto_x_fa_NivelDescuento { get; set; }
        public virtual ICollection<in_producto_x_tb_bodega> in_producto_x_tb_bodega { get; set; }
        public virtual ICollection<in_transferencia_det> in_transferencia_det { get; set; }
    }
}
