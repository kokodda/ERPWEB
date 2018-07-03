﻿using Core.Erp.Data.RRHH;
using Core.Erp.Info.RRHH;
using System;
using System.Collections.Generic;
namespace Core.Erp.Bus.RRHH
{
    public class ro_nomina_x_horas_extras_Bus
    {
        #region variables
        ro_nomina_x_horas_extras_Data odata = new ro_nomina_x_horas_extras_Data();
        ro_nomina_x_horas_extras_det_Data odata_det = new ro_nomina_x_horas_extras_det_Data();

        ro_nomina_x_horas_extras_Info info = new ro_nomina_x_horas_extras_Info();
        ro_nomina_x_horas_extras_det_Bus bus_detalle = new ro_nomina_x_horas_extras_det_Bus();
        #endregion
        public List<ro_nomina_x_horas_extras_Info> get_list(int IdEmpresa)
        {
            try
            {
                return odata.get_list(IdEmpresa);
            }
            catch (Exception)
            {

                throw;
            }
        }   
        public ro_nomina_x_horas_extras_Info get_info(int IdEmpresa, int IdCargo)
        {
            try
            {
                return odata.get_info(IdEmpresa, IdCargo);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool guardarDB(ro_nomina_x_horas_extras_Info info)
        {
            try
            {
                if (odata.Procesar(info))
                    return bus_detalle.calcular_horas_extras(info.IdEmpresa, info.IdNomina_Tipo, info.IdNomina_TipoLiqui, info.IdPeriodo);
                else
                    return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool modificarDB(ro_nomina_x_horas_extras_Info info)
        {
            try
            {
                if (odata.Procesar(info))
                    return bus_detalle.calcular_horas_extras(info.IdEmpresa, info.IdNomina_Tipo, info.IdNomina_TipoLiqui, info.IdPeriodo);
                else
                    return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool anularDB(ro_nomina_x_horas_extras_Info info)
        {
            try
            {
                return odata.anularDB(info);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool aprobacionHE(ro_nomina_x_horas_extras_Info info)
        {
            try
            {
                return bus_detalle.aprobarHE(info);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
