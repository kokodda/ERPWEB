﻿using Core.Erp.Data.RRHH;
using Core.Erp.Info.RRHH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Bus.RRHH
{
    public class ro_empleado_x_CuentaContable_Bus
    {
        ro_empleado_x_CuentaContable_Data odata = new ro_empleado_x_CuentaContable_Data();
        public List<ro_empleado_x_CuentaContable_Info> GetList(int IdEmpresa, decimal IdEmpleado)
        {
            try
            {
                return odata.GetList(IdEmpresa, IdEmpleado);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
