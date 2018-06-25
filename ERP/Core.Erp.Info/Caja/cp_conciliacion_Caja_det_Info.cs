﻿using System;

namespace Core.Erp.Info.Caja
{
    public class cp_conciliacion_Caja_det_Info
    {
        public int IdEmpresa { get; set; }
        public decimal IdConciliacion_Caja { get; set; }
        public int Secuencia { get; set; }
        public int IdEmpresa_OGiro { get; set; }
        public decimal IdCbteCble_Ogiro { get; set; }
        public int IdTipoCbte_Ogiro { get; set; }
        public Nullable<int> IdTipoMovi { get; set; }
        public string IdUsuario { get; set; }
        public System.DateTime Fecha_Transac { get; set; }
        public string nom_pc { get; set; }
        public string ip { get; set; }
        public string IdCentroCosto { get; set; }
        public string IdCentroCosto_sub_centro_costo { get; set; }
        public decimal Valor_a_aplicar { get; set; }
        public string Tipo_documento { get; set; }
        public Nullable<int> IdEmpresa_OP { get; set; }
        public Nullable<decimal> IdOrdenPago_OP { get; set; }

        #region Campos que no existen en la tabla
        public decimal IdPersona { get; set; }
        public decimal idEntidad { get; set; }
        public int idSucursal { get; set; }
        public double por_iva { get; set; }
        #endregion

    }
}
