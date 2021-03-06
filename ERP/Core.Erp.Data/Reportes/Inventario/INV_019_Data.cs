﻿using Core.Erp.Info.Reportes.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Erp.Data.Reportes.Base;
namespace Core.Erp.Data.Reportes.Inventario
{
    public class INV_019_Data
    {
        public List<INV_019_Info> GetList(int IdEmpresa, int IdSucursal, int IdBodega, int IdProducto, string Tipo, string IdEstadoAproba, DateTime fecha_ini, DateTime fecha_fin )
        {
            try
            {
                int IdSucursalIni = IdSucursal;
                int IdSucursalFin = IdSucursal == 0 ? 9999 : IdSucursal;

                int IdBodegaIni = IdBodega;
                int IdBodegaFin = IdBodega == 0 ? 9999 : IdBodega;

                int IdProductoIni = IdProducto;
                int IdProductoFin = IdProducto == 0 ? 999999999 : IdProducto;

                List<INV_019_Info> Lista;
                using (Entities_reportes Context = new Entities_reportes())
                {
                    Lista = Context.VWINV_019.Where(q=>q.IdEmpresa == IdEmpresa
                    && IdSucursalIni <= q.IdSucursal
                    && q.IdSucursal <= IdSucursalFin
                    && IdBodegaIni <= q.IdBodega
                    && q.IdBodega <= IdBodegaFin
                    && IdProductoIni <= q.IdProducto
                    && q.IdProducto <= IdProductoFin
                    && fecha_ini <= q.cm_fecha
                    && q.cm_fecha <= fecha_fin
                    && q.IdEstadoAproba == (IdEstadoAproba =="" ? q.IdEstadoAproba : IdEstadoAproba)
                    ).Select(q => new INV_019_Info
                    {
                        IdEmpresa = q.IdEmpresa,
                        bo_Descripcion = q.bo_Descripcion,
                        cm_fecha = q.cm_fecha,
                        cm_observacion = q.cm_observacion,
                        cm_tipo_movi = q.cm_tipo_movi,
                        CodMoviInven = q.CodMoviInven,
                        CostoTotal = q.CostoTotal,
                        dm_cantidad_sinConversion = q.dm_cantidad_sinConversion,
                        IdBodega = q.IdBodega,
                        IdEstadoAproba = q.IdEstadoAproba,
                        IdMovi_inven_tipo = q.IdMovi_inven_tipo,
                        IdNumMovi = q.IdNumMovi,
                        IdProducto = q.IdProducto,
                        IdSucursal = q.IdSucursal,
                        mv_costo_sinConversion = q.mv_costo_sinConversion,
                        pr_codigo = q.pr_codigo,
                        pr_descripcion = q.pr_descripcion,
                        Secuencia = q.Secuencia,
                        Su_Descripcion = q.Su_Descripcion,
                        tm_descripcion = q.tm_descripcion
                    }).ToList();
                }
                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
