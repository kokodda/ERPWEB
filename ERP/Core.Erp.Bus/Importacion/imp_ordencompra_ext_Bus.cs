﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Erp.Info.Importacion;
using Core.Erp.Data.Importacion;
using Core.Erp.Data.Contabilidad;
namespace Core.Erp.Bus.Importacion
{
  public  class imp_ordencompra_ext_Bus
    {
        imp_ordencompra_ext_Data odata = new imp_ordencompra_ext_Data();
        imp_ordencompra_ext_det_Data odata_det = new imp_ordencompra_ext_det_Data();
        imp_ordencompra_ext_Info info_oc = new imp_ordencompra_ext_Info();
        ct_cbtecble_det_Data comprobante_data = new ct_cbtecble_det_Data();
        List<imp_orden_compra_ext_ct_cbteble_det_gastos_Info> lst_gastos_nos_asignados = new List<imp_orden_compra_ext_ct_cbteble_det_gastos_Info>();
        List<imp_orden_compra_ext_ct_cbteble_det_gastos_Info> lst_gastos_asignados = new List<imp_orden_compra_ext_ct_cbteble_det_gastos_Info>();
        imp_orden_compra_ext_ct_cbteble_det_gastos_Data data_gastos = new imp_orden_compra_ext_ct_cbteble_det_gastos_Data();
        public List<imp_ordencompra_ext_Info> get_list(int IdEmpresa)
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
        public List<imp_ordencompra_ext_Info> get_list(int IdEmpresa, DateTime fecha_inicio, DateTime Fecha_fin)
        {
            try
            {
                return odata.get_list(IdEmpresa, fecha_inicio, Fecha_fin);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<imp_ordencompra_ext_Info> get_list_oc_con_recepcion_mercaderia(int IdEmpresa, DateTime fecha_inicio, DateTime Fecha_fin)
        {
            try
            {
                return odata.get_list_oc_con_recepcion_mercaderia(IdEmpresa, fecha_inicio, Fecha_fin);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public imp_ordencompra_ext_Info get_asignar_gastos(int IdEmpresa, decimal IdOrdenCompra_ext)
        {
            try
            {
                info_oc = odata.get_info_recepcion_merca(IdEmpresa, IdOrdenCompra_ext);
                info_oc.lst_gastos_por_asignar = new List<imp_orden_compra_ext_ct_cbteble_det_gastos_Info>();
                info_oc.lst_gastos_asignados = new List<imp_orden_compra_ext_ct_cbteble_det_gastos_Info>();
                info_oc.lst_gastos_asignados = data_gastos.get_list_gastos_asignados(IdEmpresa, IdOrdenCompra_ext);
                info_oc.lst_gastos_por_asignar = data_gastos.get_list_gastos_no_asignados(IdEmpresa,  info_oc.IdCtaCble_importacion);
                return info_oc;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public imp_ordencompra_ext_Info get_info(int IdEmpresa, decimal IdOrdenCompra_ext)
        {
            try
            {
                return odata.get_info(IdEmpresa, IdOrdenCompra_ext);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool guardarDB(imp_ordencompra_ext_Info info)
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
        public bool modificarDB(imp_ordencompra_ext_Info info)
        {
            try
            {
                odata_det.eliminar(info.IdEmpresa, info.IdOrdenCompra_ext);
                return odata.modificarDB(info);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool anularDB(imp_ordencompra_ext_Info info)
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
        public string validar(imp_ordencompra_ext_Info info)
        {
            try
            {
                string mensaje = "";
                if (info.IdProveedor == 0)
                    mensaje = "Seleccione proveedor";
                if (info.IdCtaCble_importacion == ""|info.IdCtaCble_importacion==null)
                    mensaje = "Seleccione cuenta contable";
                if (info.lst_detalle == null)
                    mensaje = "No existe detalle para la orden de compra";
                if(info.lst_detalle!=null)
                if (info.lst_detalle.Count() == 0)
                        mensaje = "No existe detalle para la orden de compra";
                if (info.IdPais_embarque == "" | info.IdPais_embarque==null)
                    mensaje = "Seleccione país embarque";
                return mensaje;

            }
            catch (Exception)
            {
                throw;
            }
        }



    }
}
