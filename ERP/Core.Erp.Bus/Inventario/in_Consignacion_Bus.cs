﻿using Core.Erp.Data.Inventario;
using Core.Erp.Info.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Bus.Inventario
{
    public class in_Consignacion_Bus
    {
        in_Consignacion_Data odata = new in_Consignacion_Data();

        public List<in_Consignacion_Info> GetList(int IdEmpresa, string signo, bool mostrar_anulados, DateTime fecha_ini, DateTime fecha_fin)
        {
            try
            {
                return odata.GetList(IdEmpresa, signo, mostrar_anulados, fecha_ini, fecha_fin);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public in_Consignacion_Info GetInfo(int IdEmpresa, int IdConsignacion)
        {
            try

            {
                return odata.GetInfo(IdEmpresa, IdConsignacion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool GuardarBD(in_Consignacion_Info info)
        {
            try
            {
                return odata.GuardarBD(info);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ModificarBD(in_Consignacion_Info info)
        {
            try
            {
                return odata.ModificarDB(info);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AnularBD(in_Consignacion_Info info)
        {
            try
            {
                return odata.AnularBD(info);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
