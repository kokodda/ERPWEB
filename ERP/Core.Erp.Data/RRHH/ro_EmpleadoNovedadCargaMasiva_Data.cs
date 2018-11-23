﻿using Core.Erp.Info.RRHH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Data.RRHH
{
   public class ro_EmpleadoNovedadCargaMasiva_Data
    {

        ro_empleado_novedad_Data odata_novedad = new ro_empleado_novedad_Data();
        public List<ro_EmpleadoNovedadCargaMasiva_Info> get_list(int IdEmpresa, DateTime FechaInicio, DateTime FechaFin)
        {
            try
            {
                FechaFin = Convert.ToDateTime(FechaFin.Date.ToShortDateString());
                FechaInicio = Convert.ToDateTime(FechaInicio.Date.ToShortDateString());
                List<ro_EmpleadoNovedadCargaMasiva_Info> lista;
                using (Entities_rrhh Context = new Entities_rrhh())
                {
                        lista = (from q in Context.ro_EmpleadoNovedadCargaMasiva
                                 where q.IdEmpresa == IdEmpresa
                                 && q.FechaCarga >= FechaInicio
                                 && q.FechaCarga <= FechaFin
                                 select new ro_EmpleadoNovedadCargaMasiva_Info
                                 {
                                     IdEmpresa=q.IdEmpresa,
                                     IdCarga=q.IdCarga,
                                     FechaCarga = q.FechaCarga,
                                     Observacion = q.Observacion,
                                     IdRubro = q.IdRubro,
                                     Estado = q.Estado
                                 }
                               ).ToList();
                   

                }

                return lista;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public bool GuardarDB(ro_EmpleadoNovedadCargaMasiva_Info info)
        {
            try
            {
                decimal IdNovedad = odata_novedad.get_id(info.IdEmpresa);


                using (Entities_rrhh Contex=new Entities_rrhh())
                {

                    ro_EmpleadoNovedadCargaMasiva entity = new ro_EmpleadoNovedadCargaMasiva
                    {
                        IdEmpresa = info.IdEmpresa,
                        IdCarga = info.IdCarga = Get_id(info.IdEmpresa),
                        FechaCarga = info.FechaCarga.Date,
                        Observacion = info.Observacion,
                        IdNomina = info.IdNomina,
                        IdNominaTipo = info.IdNominaTipo,
                        IdSucursal = info.IdSucursal,
                        IdRubro = info.IdRubro,
                        IdUsuario = info.IdUsuario,
                        Fecha_Transac = DateTime.Now,
                    };
                    Contex.ro_EmpleadoNovedadCargaMasiva.Add(entity);

                    foreach (var item in info.detalle)
                    {
                        

                        ro_empleado_Novedad Entity = new ro_empleado_Novedad
                        {
                            IdEmpresa = info.IdEmpresa,
                            IdNovedad = item.IdNovedad = IdNovedad,
                            IdNomina_Tipo = info.IdNomina,
                            IdNomina_TipoLiqui = info.IdNominaTipo,
                            IdEmpleado = item.IdEmpleado,
                            Fecha = info.FechaCarga,

                            Observacion = info.Observacion==null?"":info.Observacion,
                            Estado  = "A",
                            IdUsuario = info.IdUsuario,
                            Fecha_Transac = info.Fecha_Transac = DateTime.Now
                        };
                        Contex.ro_empleado_Novedad.Add(Entity);

                        ro_empleado_novedad_det Entity_det = new ro_empleado_novedad_det
                        {
                            IdEmpresa = info.IdEmpresa,
                            IdNovedad = item.IdNovedad,
                            FechaPago = info.FechaCarga,
                            IdRubro = info.IdRubro,
                            Valor = item.Valor,
                            Observacion = item.Observacion,
                            EstadoCobro  = "PEN",
                            Secuencia=1
                        };
                        Contex.ro_empleado_novedad_det.Add(Entity_det);

                        ro_EmpleadoNovedadCargaMasiva_det Entity_det_ = new ro_EmpleadoNovedadCargaMasiva_det
                        {
                            IdEmpresa = info.IdEmpresa,
                            IdCarga = info.IdCarga,
                            IdNovedad = item.IdNovedad,
                            IdEmpleado = item.IdEmpleado,
                            Observacion = item.Observacion,
                            Secuencia = item.Secuancia,
                            IdEmpresa_nov = info.IdEmpresa
                        };
                        Contex.ro_EmpleadoNovedadCargaMasiva_det.Add(Entity_det_);
                        IdNovedad++;
                    }
                    Contex.SaveChanges();

                }
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public bool AnularDB (ro_EmpleadoNovedadCargaMasiva_Info info)
        {
            try
            {
                using (Entities_rrhh contex=new Entities_rrhh())
                {

                    ro_EmpleadoNovedadCargaMasiva entity = contex.ro_EmpleadoNovedadCargaMasiva.FirstOrDefault(q => q.IdEmpresa == info.IdEmpresa && q.IdCarga == info.IdCarga);

                    if (entity == null)
                        return false;
                    entity.IdUsuarioUltAnu = info.IdUsuarioUltAnu;
                    entity.IdUsuarioUltAnu = info.IdUsuarioUltAnu;
                    entity.Estado = false;
                    var lista = contex.ro_EmpleadoNovedadCargaMasiva_det.Where(q => q.IdEmpresa == info.IdEmpresa && q.IdCarga == info.IdCarga);
                    foreach (var item in lista)
                    {
                        ro_empleado_Novedad entity_det = contex.ro_empleado_Novedad.FirstOrDefault(q => q.IdEmpresa == info.IdEmpresa && q.IdEmpleado == info.IdEmpresa&& q.IdNovedad==item.IdNovedad);
                        entity_det.Estado = "I";
                        entity.IdUsuarioUltAnu = info.IdUsuarioUltAnu;
                        entity_det.Fecha_UltAnu = DateTime.Now;
                        contex.SaveChanges();

                    }
                    contex.SaveChanges  ();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ro_EmpleadoNovedadCargaMasiva_Info get_info(int IdEmpresa, decimal IdCarga)
        {
            try
            {
                ro_EmpleadoNovedadCargaMasiva_Info info = new ro_EmpleadoNovedadCargaMasiva_Info();

                using (Entities_rrhh Context = new Entities_rrhh())
                {
                    ro_EmpleadoNovedadCargaMasiva Entity = Context.ro_EmpleadoNovedadCargaMasiva.FirstOrDefault(q => q.IdEmpresa == IdEmpresa && q.IdCarga == IdCarga);
                    if (Entity == null) return null;

                    info = new ro_EmpleadoNovedadCargaMasiva_Info
                    {
                        IdEmpresa = Entity.IdEmpresa,
                        IdCarga = Entity.IdCarga,
                        IdRubro = Entity.IdRubro,
                        FechaCarga = Entity.FechaCarga,
                        Estado = Entity.Estado,
                        Observacion = Entity.Observacion
                    };
                }

                return info;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private decimal Get_id(int IdEmpresa)
        {
            try
            {
                decimal Id = 1;
                using (Entities_rrhh Contex=new Entities_rrhh())
                {
                    var list = from q in Contex.ro_EmpleadoNovedadCargaMasiva
                               select q;
                    if (list.Count() > 0)
                       Id=list.Max(v =>v.IdCarga)+1;

                    return Id;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        
    }
}