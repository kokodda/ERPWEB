﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Erp.Info.RRHH;
using Core.Erp.Data.RRHH;
namespace Core.Erp.Bus.RRHH
{
  public  class ro_rol_detalle_Bus
    {
        ro_rol_detalle_Data odata = new ro_rol_detalle_Data();
        public List<ro_rol_detalle_Info> Get_lst_detalle_contabilizar(int idEmpresa, int idNominaTipo, int idNominaTipoLiqui, int idPeriodo, bool es_provision)
        {
            try
            {
                return odata.Get_lst_detalle_contabilizar(idEmpresa,idNominaTipo,idNominaTipoLiqui,idPeriodo, es_provision);
            }
            catch (Exception)
            {

                throw;
            }
        }
   }
}
