﻿using Core.Erp.Data.Reportes.Inventario;
using Core.Erp.Info.Reportes.Inventario;
using System;
using System.Collections.Generic;

namespace Core.Erp.Bus.Reportes.Inventario
{
    public class INV_022_Bus
    {
        INV_022_Data odata = new INV_022_Data();
    
        public List<INV_022_Info> get_list(int IdEmpresa, int IdSucursal, int IdBodega, decimal IdProducto, string IdCategoria, int IdLinea, int IdGrupo, int IdSubgrupo, DateTime fecha_corte, bool mostrar_stock_0, int IdMarca, bool ConsiderarNoAprobados)
        {
            try
            {
                return odata.get_list(IdEmpresa, IdSucursal, IdBodega, IdProducto, IdCategoria, IdLinea, IdGrupo, IdSubgrupo, fecha_corte, mostrar_stock_0, IdMarca, ConsiderarNoAprobados);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
