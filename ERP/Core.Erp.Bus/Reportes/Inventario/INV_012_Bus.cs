﻿using Core.Erp.Data.Reportes.Inventario;
using Core.Erp.Info.Reportes.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Bus.Reportes.Inventario
{
   public class INV_012_Bus
    {
        INV_012_Data odata = new INV_012_Data();
        public List<INV_012_Info> GetList(int IdEmpresa, int IdSucursal, int IdBodega, string tipo_movi, int IdMovi_inven_tipo, decimal IdNumMovi, DateTime fechaIni, DateTime fechaFin)
        {
            try
            {
                return odata.GetList(IdEmpresa, IdSucursal, IdBodega, tipo_movi, IdMovi_inven_tipo, IdNumMovi, fechaIni, fechaFin);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
