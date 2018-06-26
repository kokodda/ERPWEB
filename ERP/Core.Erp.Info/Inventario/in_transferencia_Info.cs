﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Info.Inventario
{
  public  class in_transferencia_Info
    {
        public int IdEmpresa { get; set; }
        public int IdSucursalOrigen { get; set; }
        public int IdBodegaOrigen { get; set; }
        public decimal IdTransferencia { get; set; }
        public string Codigo { get; set; }
        public int IdSucursalDest { get; set; }
        public int IdBodegaDest { get; set; }
        public string tr_Observacion { get; set; }
        public System.DateTime tr_fecha { get; set; }
        public Nullable<int> IdEmpresa_Ing_Egr_Inven_Origen { get; set; }
        public Nullable<int> IdSucursal_Ing_Egr_Inven_Origen { get; set; }
        public Nullable<int> IdMovi_inven_tipo_SucuOrig { get; set; }
        public Nullable<decimal> IdNumMovi_Ing_Egr_Inven_Origen { get; set; }
        public Nullable<int> IdEmpresa_Ing_Egr_Inven_Destino { get; set; }
        public Nullable<int> IdSucursal_Ing_Egr_Inven_Destino { get; set; }
        public Nullable<int> IdMovi_inven_tipo_SucuDest { get; set; }
        public Nullable<decimal> IdNumMovi_Ing_Egr_Inven_Destino { get; set; }
        public string IdUsuario { get; set; }
        public string Estado { get; set; }
        public string tr_userAnulo { get; set; }
        public Nullable<System.DateTime> tr_fechaAnulacion { get; set; }
        public Nullable<System.DateTime> tr_fecha_transaccion { get; set; }
        public string IdUsuarioUltMod { get; set; }
        public Nullable<System.DateTime> Fecha_UltMod { get; set; }
        public string nom_pc { get; set; }
        public string ip { get; set; }
        public string motivo_anula { get; set; }
        public string IdEstadoAprobacion_cat { get; set; }




        public string SucuOrigen { get; set; }
        public string BodegaORIG { get; set; }
        public string SucuDEST { get; set; }
        public string BodegDest { get; set; }

        public List<in_transferencia_det_Info> list_detalle { get; set; }
    }
}
