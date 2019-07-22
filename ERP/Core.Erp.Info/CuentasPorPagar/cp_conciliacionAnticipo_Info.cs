﻿using Core.Erp.Info.Contabilidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Info.CuentasPorPagar
{
    public class cp_conciliacionAnticipo_Info
    {
        public int IdEmpresa { get; set; }
        public decimal IdConciliacion { get; set; }
        public int IdSucursal { get; set; }
        public decimal IdProveedor { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Observacion { get; set; }
        public bool Estado { get; set; }
        public Nullable<decimal> Idcancelacion { get; set; }
        public Nullable<int> IdTipoCbte { get; set; }
        public Nullable<decimal> IdCbteCble { get; set; }
        public string IdUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string IdUsuarioModificacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public string IdUsuarioAnulacion { get; set; }
        public Nullable<System.DateTime> FechaAnulacion { get; set; }
        public string MotivoAnulacion { get; set; }

        #region Campos que no existen en la tabla
        public List<cp_ConciliacionAnticipoDetAnt_Info> Lista_det_OP { get; set; }
        public List<cp_ConciliacionAnticipoDetCXP_Info> Lista_det_Fact { get; set; }
        public ct_cbtecble_Info InfoCbte { get; set; }
        public List<ct_cbtecble_det_Info> Lista_det_Cbte { get; set; }
        #endregion
    }
}
