﻿using Core.Erp.Info.Contabilidad;
using Core.Erp.Info.CuentasPorPagar;
using System;
using System.Collections.Generic;

namespace Core.Erp.Info.Banco
{
    public class ba_Cbte_Ban_Info
    {
        public int IdEmpresa { get; set; }
        public decimal IdCbteCble { get; set; }
        public int IdTipocbte { get; set; }
        public string Cod_Cbtecble { get; set; }
        public int IdPeriodo { get; set; }
        public int IdBanco { get; set; }
        public System.DateTime cb_Fecha { get; set; }
        public string cb_Observacion { get; set; }
        public double cb_Valor { get; set; }
        public string cb_Cheque { get; set; }
        public string Estado { get; set; }        
        public Nullable<decimal> IdPersona_Girado_a { get; set; }
        public string cb_giradoA { get; set; }
        public string cb_ciudadChq { get; set; }
        public Nullable<decimal> IdTipoFlujo { get; set; }
        public Nullable<int> IdTipoNota { get; set; }
        public string ValorEnLetras { get; set; }
        public Nullable<int> IdSucursal { get; set; }
        public string IdEstado_Cbte_Ban_cat { get; set; }
        public string IdEstado_Preaviso_ch_cat { get; set; }
        public string IdEstado_cheque_cat { get; set; }
        public decimal IdPersona { get; set; }
        public decimal IdEntidad { get; set; }
        public string IdTipo_Persona { get; set; }

        #region Campos auditoria
        public string IdUsuario { get; set; }
        public string IdUsuario_Anu { get; set; }
        public Nullable<System.DateTime> FechaAnulacion { get; set; }
        public Nullable<System.DateTime> Fecha_Transac { get; set; }
        public Nullable<System.DateTime> Fecha_UltMod { get; set; }
        public string IdUsuarioUltMod { get; set; }
        public string MotivoAnulacion { get; set; }
        #endregion

        #region Campos que no existen en la tabla
        public List<ct_cbtecble_det_Info> lst_det_ct { get; set; }
        public List<cp_orden_pago_cancelaciones_Info> lst_det_canc_op { get; set; }
        public List<ba_Caja_Movimiento_x_Cbte_Ban_x_Deposito_Info> lst_det_ing { get; set; }
        public string ba_descripcion { get; set; }
        public string CodTipoCbteBan { get; set; }
        public string pe_nombreCompleto { get; set; }
        public string Su_Descripcion { get; set; }
        #endregion
    }
}
