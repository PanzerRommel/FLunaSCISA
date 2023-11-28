using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL
{
    public class Paciente
    {
        public static ML.Result Add(ML.Paciente paciente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FlunaScisaContext context = new DL.FlunaScisaContext())
                {
                    var query = context.Database.ExecuteSql($"PacienteAdd '{paciente.Nombre}' , '{paciente.Edad}' , '{paciente.FechaNacimiento}' , '{paciente.Telefono}'");
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
        public static ML.Result Update(ML.Paciente paciente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FlunaScisaContext context = new DL.FlunaScisaContext())
                {
                    var query = context.Database.ExecuteSqlRaw(
                        $"EXEC PacienteUpdate @IdPaciente = {paciente.IdPaciente}, @Nombre = '{paciente.Nombre}', @Edad = {paciente.Edad}, @FechaNacimiento = '{paciente.FechaNacimiento}', @Telefono = '{paciente.Telefono}'");

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
                    var query = context.Pacientes.FromSqlRaw("PacienteGetAll").ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Paciente paciente = new ML.Paciente()
                            {
                                IdPaciente = obj.IdPaciente,
                                Nombre = obj.Nombre,
                                Edad = obj.Edad.Value,
                                FechaNacimiento = obj.FechaNacimiento.Value,
                                Telefono = obj.Telefono
                            };
                            result.Objects.Add(paciente);
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
        public static ML.Result GetById(int IdPaciente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.FlunaScisaContext context = new DL.FlunaScisaContext())
                {
                    var objquery = context.Pacientes.FromSqlRaw($"PacienteGetById {IdPaciente}").AsEnumerable().FirstOrDefault();
                    if (objquery != null)
                    {
                        ML.Paciente paciente = new ML.Paciente();
                        paciente.IdPaciente = objquery.IdPaciente;
                        paciente.Nombre = objquery.Nombre;
                        paciente.Edad = objquery.Edad.Value;
                        paciente.FechaNacimiento = objquery.FechaNacimiento.Value;
                        paciente.Telefono = objquery.Telefono;

                        result.Object = paciente;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo completar los registros de la tabla";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result Delete(int IdPaciente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FlunaScisaContext context = new DL.FlunaScisaContext())
                {
                    var paciente = context.Pacientes.FirstOrDefault(e => e.IdPaciente == IdPaciente);

                    if ( paciente != null)
                    {
                        context.Pacientes.Remove(paciente);
                        context.SaveChanges();
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontró el empleado para eliminar.";
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
