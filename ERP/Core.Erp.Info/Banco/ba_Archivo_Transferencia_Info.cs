﻿using Core.Erp.Info.Helps;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Info.Banco
{
    public class ba_Archivo_Transferencia_Info
    {
        public decimal IdTransaccionSession { get; set; }
        public int IdEmpresa { get; set; }
        public decimal IdArchivo { get; set; }
        public string cod_archivo { get; set; }
        [Required(ErrorMessage = "El campo banco es obligatorio")]
        public int IdBanco { get; set; }
        [Required(ErrorMessage = "El campo proceso bancario es obligatorio")]
        public int IdProceso_bancario { get; set; }
        public string Cod_Empresa { get; set; }
        [Required(ErrorMessage = "El campo descripción es obligatorio")]
        public string Nom_Archivo { get; set; }
        [Required(ErrorMessage = "El campo fecha es obligatorio")]
        public System.DateTime Fecha { get; set; }
        public bool Estado { get; set; }
        [Required(ErrorMessage = "El campo observación es obligatorio")]
        public string Observacion { get; set; }
        public string IdUsuario { get; set; }
        public Nullable<System.DateTime> Fecha_Transac { get; set; }
        public string IdUsuarioUltMod { get; set; }
        public Nullable<System.DateTime> Fecha_UltMod { get; set; }
        public string IdUsuarioUltAnu { get; set; }
        public Nullable<System.DateTime> Fecha_UltAnu { get; set; }
        public string Motivo_anulacion { get; set; }
        public Nullable<System.DateTime> Fecha_Proceso { get; set; }
        public Nullable<bool> Contabilizado { get; set; }
        public int IdSucursal { get; set; }

        public List<ba_Archivo_Transferencia_Det_Info> Lst_det { get; set; }
    }
}
