﻿using Core.Erp.Data.RRHH;
using Core.Erp.Info.RRHH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Bus.RRHH
{
   public class ro_tipo_gastos_personales_maxim_x_anio_Bus
    {
        ro_tipo_gastos_personales_maxim_x_anio_Data odata = new ro_tipo_gastos_personales_maxim_x_anio_Data();
        public List<ro_tipo_gastos_personales_maxim_x_anio_Info> get_list()
        {
            try
            {
                return odata.get_list();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ro_tipo_gastos_personales_maxim_x_anio_Info get_info(string IdTipoGasto)
        {
            try
            {
                return odata.get_info(IdTipoGasto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool guardarDB(ro_tipo_gastos_personales_maxim_x_anio_Info info)
        {
            try
            {
                return odata.guardarDB(info);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool modificarDB(ro_tipo_gastos_personales_maxim_x_anio_Info info)
        {
            try
            {

                return odata.modificarDB(info);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool anularDB(ro_tipo_gastos_personales_maxim_x_anio_Info info)
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
    }
}
