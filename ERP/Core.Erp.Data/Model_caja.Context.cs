﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities_caja : DbContext
    {
        public Entities_caja()
            : base("name=Entities_caja")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<caj_parametro> caj_parametro { get; set; }
        public virtual DbSet<caj_Caja> caj_Caja { get; set; }
        public virtual DbSet<caj_Caja_Movimiento_Tipo> caj_Caja_Movimiento_Tipo { get; set; }
        public virtual DbSet<caj_Caja_Movimiento> caj_Caja_Movimiento { get; set; }
        public virtual DbSet<caj_Caja_Movimiento_det> caj_Caja_Movimiento_det { get; set; }
        public virtual DbSet<cp_conciliacion_Caja_det_Ing_Caja> cp_conciliacion_Caja_det_Ing_Caja { get; set; }
        public virtual DbSet<cp_conciliacion_Caja_det_x_ValeCaja> cp_conciliacion_Caja_det_x_ValeCaja { get; set; }
        public virtual DbSet<cp_conciliacion_Caja_det> cp_conciliacion_Caja_det { get; set; }
        public virtual DbSet<cp_conciliacion_Caja> cp_conciliacion_Caja { get; set; }
        public virtual DbSet<vwcaj_Caja_Movimiento_x_Conciliar> vwcaj_Caja_Movimiento_x_Conciliar { get; set; }
        public virtual DbSet<vwcp_conciliacion_Caja_det> vwcp_conciliacion_Caja_det { get; set; }
        public virtual DbSet<vwcp_conciliacion_Caja_det_x_ValeCaja> vwcp_conciliacion_Caja_det_x_ValeCaja { get; set; }
    }
}
