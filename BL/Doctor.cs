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
    public class Doctor
    {
        public static ML.Result Add(ML.Doctor doctor)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FlunaScisaContext context = new DL.FlunaScisaContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"DoctorAdd '{doctor.Nombre}' , '{doctor.Especialidad}'");

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
        public static ML.Result Update(ML.Doctor doctor)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FlunaScisaContext context = new DL.FlunaScisaContext())
                {
                    var query = context.Database.ExecuteSqlRaw(
                        $"EXEC DoctorUpdate @IdDoctor = {doctor.IdDoctor} , '{doctor.Nombre}' , '{doctor.Especialidad}'");

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
                    var query = context.Doctors.FromSqlRaw("DoctorGetAll").ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Doctor doctor = new ML.Doctor()
                            {
                                IdDoctor = obj.IdDoctor,
                                Nombre = obj.Nombre,
                                Especialidad = obj.Especialidad
                            };
                            result.Correct = true;
                        }
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
        public static ML.Result GetById(int IdDoctor)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.FlunaScisaContext context = new DL.FlunaScisaContext())
                {
                    var objquery = context.Doctors.FromSqlRaw($"DoctorGetById {IdDoctor}").AsEnumerable().FirstOrDefault();
                    if (objquery != null)
                    {
                        ML.Doctor doctor = new ML.Doctor();
                        doctor.IdDoctor = objquery.IdDoctor;
                        doctor.Nombre = objquery.Nombre;
                        doctor.Especialidad = objquery.Especialidad;

                        result.Object = doctor;
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
        public static ML.Result Delete(int? IdDoctor)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.FlunaScisaContext context = new DL.FlunaScisaContext())
                {
                    var doctor = context.Doctors.FirstOrDefault(e => e.IdDoctor == IdDoctor);

                    if (doctor != null)
                    {
                        context.Doctors.Remove(doctor);
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
