﻿using Core.Erp.Info.Reportes.CuentasPorPagar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Erp.Data.Reportes.Base;
namespace Core.Erp.Data.Reportes.CuentasPorPagar
{
  public class CXP_015_Data
    {
        public List<CXP_015_Info> GetList(int IdEmpresa, int IdSucursal, decimal IdProveedor, DateTime fecha_corte, bool mostrarSaldo0, int IdClaseProveedor, bool FiltrarFechaContable)
        {
            try
            {
                int IdSucursalIni = IdSucursal;
                int IdSucursalFin = IdSucursal == 0 ? 99999 : IdSucursal;

                decimal IdProveedorIni = IdProveedor;
                decimal IdProveedorFin = IdProveedor == 0 ? 99999 : IdProveedor;


                int IdClaseProveedorIni = IdClaseProveedor;
                int IdClaseProveedorFin = IdClaseProveedor == 0 ? 99999999 : IdClaseProveedor;
                List<CXP_015_Info> Lista;
                using (Entities_reportes Context = new Entities_reportes())
                {
                    Lista = Context.SPCXP_015(IdEmpresa, IdSucursalIni, IdSucursalFin, IdProveedorIni, IdProveedorFin, fecha_corte, mostrarSaldo0, IdClaseProveedorIni, IdClaseProveedorFin, FiltrarFechaContable).Select(q => new CXP_015_Info
                    {
                        IdEmpresa = q.IdEmpresa,
                        IdSucursal = q.IdSucursal,
                        Codigo = q.Codigo,
                        co_factura = q.co_factura,
                        co_FechaFactura = q.co_FechaFactura,
                        co_FechaFactura_vct = q.co_FechaFactura_vct,
                        co_observacion = q.co_observacion,
                        co_subtotal_iva = q.co_subtotal_iva,
                        co_subtotal_siniva = q.co_subtotal_siniva,
                        co_total = q.co_total,
                        co_valoriva = q.co_valoriva,
                        IdCbteCble_Ogiro = q.IdCbteCble_Ogiro,
                        IdProveedor = q.IdProveedor,
                        IdTipoCbte_Ogiro = q.IdTipoCbte_Ogiro,
                        pe_nombreCompleto = q.pe_nombreCompleto,
                        Saldo = q.Saldo,
                        Su_Descripcion = q.Su_Descripcion,
                        ValorAbono = q.ValorAbono,
                        ValorNC = q.ValorNC,
                        ValorRetencion = q.ValorRetencion,
                        descripcion_clas_prove = q.descripcion_clas_prove,
                        IdClaseProveedor = q.IdClaseProveedor,
                        DiasVcto = q.DiasVcto,
                        co_FechaContabilizacion = q.co_FechaContabilizacion
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
