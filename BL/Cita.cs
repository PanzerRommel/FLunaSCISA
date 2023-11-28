using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BL
{
    public class Cita
    {
        public static ML.Result Add(ML.Cita cita)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FlunaScisaContext context = new DL.FlunaScisaContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"CitaAdd '{cita.FechaCita}' , {cita.doctor.IdDoctor} , '{cita.doctor.Nombre}', '{cita.doctor.Especialidad}' , {cita.Paciente.IdPaciente} , '{cita.Paciente.Nombre}' , {cita.Paciente.Edad}");
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se inserto el registro";

                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Update(ML.Cita cita)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.FlunaScisaContext context = new DL.FlunaScisaContext())
                {
                    var query = context.Database.ExecuteSqlRaw(
                        $"EXEC CitaUpdate @IdCita = {cita.IdCita}, @FechaCita = {cita.FechaCita}, @IdDoctor = {cita.doctor.IdDoctor}, @Nombre = '{cita.doctor.Nombre}' , @Especialidad = '{cita.doctor.Especialidad} , @Nombre = '{cita.Paciente.Nombre}' , @Edad = {cita.Paciente.Edad}");

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se insertó el registro";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.FlunaScisaContext context = new DL.FlunaScisaContext())
                {
                    var query = context.Cita.FromSqlRaw("CitaGetAll").ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Cita cita = new ML.Cita()
                            {
                                IdCita = obj.IdCita,
                                FechaCita = obj.FechaCita.Value,

                                doctor = new ML.Doctor()
                                {
                                    IdDoctor = obj.IdCita,
                                    Nombre = obj.NombreDoctor,
                                    Especialidad = obj.Especialidad,
                                },

                                Paciente = new ML.Paciente
                                {
                                    IdPaciente = obj.IdPaciente.Value,
                                    Nombre = obj.NombrePaciente,
                                    Edad = obj.EdadPaciente.Length
                                }
                            };
                            result.Objects.Add(cita);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido realizar la consulta";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetById(int IdCita)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FlunaScisaContext context = new DL.FlunaScisaContext())
                {
                    var query = context.Cita.FromSqlRaw("CitaGetById @IdCita", new SqlParameter("@IdCita", IdCita)).SingleOrDefault();

                    if (query != null)
                    {
                        ML.Cita cita = new ML.Cita()
                        {
                            IdCita = query.IdCita,
                            FechaCita = query.FechaCita.Value,

                            doctor = new ML.Doctor()
                            {
                                IdDoctor = query.IdDoctor.Value,
                                Nombre = query.NombreDoctor,
                                Especialidad = query.Especialidad,
                            },

                            Paciente = new ML.Paciente
                            {
                                IdPaciente = query.IdPaciente.Value,
                                Nombre = query.NombrePaciente,
                                Edad = query.EdadPaciente.Length
                            }
                        };
                        result.Object = cita;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha encontrado la cita";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Delete(int IdCita)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FlunaScisaContext context = new DL.FlunaScisaContext())
                {
                    var citaToDelete = context.Cita.Find(IdCita);

                    if (citaToDelete != null)
                    {
                        context.Cita.Remove(citaToDelete);
                        context.SaveChanges();
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha encontrado la cita para eliminar";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

    }
}
