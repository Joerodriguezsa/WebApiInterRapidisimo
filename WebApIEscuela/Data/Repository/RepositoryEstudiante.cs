using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApIEscuela.Context;
using WebApIEscuela.Data.Contracts;
using WebApIEscuela.Models;

namespace WebApIEscuela.Data.Repository
{
    public class RepositoryEstudiante: IRepositoryEstudiante
    {
        private readonly ConexionSQLServer conexionSQLServer;
        public RepositoryEstudiante(ConexionSQLServer context)
        {
            this.conexionSQLServer = context;
        }

        /// <summary>
        /// Retorna Listado de Materias
        /// </summary>
        /// <returns></returns>
        public List<Estudiante> GetAllEstudiantes()
        {
            try
            {
                return conexionSQLServer.Estudiante.ToList();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Todas Las materias registradas para el estudiante
        /// </summary>
        /// <returns></returns>
        public List<EstudianteMateria> GetAllEstudiantesMateria(int intIdEstudiante)
        {
            try
            {
                var datos = (from a in conexionSQLServer.MateriasEstudiante
                             join b in conexionSQLServer.MateriasDocente on a.IdMateriaDocente equals b.Id
                             join c in conexionSQLServer.Materias on b.IdMateria equals c.Id
                             join d in conexionSQLServer.Docente on b.IdDocente equals d.Id
                             where a.IdEstudiante == intIdEstudiante
                             select new EstudianteMateria
                             {
                                 Id = a.Id,
                                 IdEstudiante = a.IdEstudiante,
                                 NombreMateria = c.NombreMateria,
                                 Creditos = c.Creditos,
                                 NombreDocente = d.Nombre,
                                 ApellidoDocente = d.Apellido
                             }).ToList();
                return datos;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Valida y Registra Materia para el estudiante
        /// </summary>
        /// <param name="intEstudiante"></param>
        /// <param name="intMateriaDocente"></param>
        /// <returns></returns>
        public string PostRegMateria(int intEstudiante, int intMateriaDocente)
        {
            string respuesta = string.Empty;
            try
            {
                var cantRegistros = (from a in conexionSQLServer.MateriasEstudiante where a.IdEstudiante == intEstudiante select new MateriasEstudiante { Id = a.Id}).ToList();
                if(cantRegistros.Count < 3)
                {
                    var registroMateria = (from a in conexionSQLServer.MateriasEstudiante 
                                           where a.IdEstudiante == intEstudiante && a.IdMateriaDocente == intMateriaDocente
                                           select new MateriasEstudiante { Id = a.Id }).ToList();
                    if(registroMateria.Count <= 0)
                    {
                        var materiaDocente = (from a in conexionSQLServer.MateriasDocente where a.Id == intMateriaDocente select new MateriasDocente { Id = a.Id, IdDocente = a.IdDocente, IdMateria = a.IdMateria}).ToList();

                        var query = (from me in conexionSQLServer.MateriasEstudiante
                                    join md in conexionSQLServer.MateriasDocente on me.IdMateriaDocente equals md.Id
                                    where me.IdEstudiante == intEstudiante && (md.IdDocente == materiaDocente.First().IdDocente || md.IdMateria == materiaDocente.First().IdMateria)
                                    select new MateriasEstudiante { 
                                    
                                        Id = me.Id
                                    }).ToList();
                        if (query.Count <= 0) 
                        {
                            MateriasEstudiante nuevaMateriaEstudiante = new MateriasEstudiante
                            {
                                IdEstudiante = intEstudiante,
                                IdMateriaDocente = intMateriaDocente
                            };

                            conexionSQLServer.MateriasEstudiante.Add(nuevaMateriaEstudiante);
                            conexionSQLServer.SaveChanges();

                            respuesta = "Registro exitoso";
                        }
                        else
                        {
                            respuesta = "Ya tiene registrado una Materia Igual con otro Profesor o Ya tiene registrado con ese Profesor otra Materia";
                        }
                    }
                    else
                    {
                        respuesta = "Ya tiene registrado esa materia con el mismo profesor";
                    }

                }
                else
                {
                    respuesta = "No puede ser registrado ya que tiene el cupo completo de creditos";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                respuesta = "Falla Registro";
            }
            return respuesta;

        }

        /// <summary>
        /// Eliminar registro de Materia
        /// </summary>
        /// <param name="idRegistro"></param>
        /// <returns></returns>
        public bool EliminarMateria(int idRegistro)
        {
            try
            {
                var estudiante = conexionSQLServer.MateriasEstudiante.FirstOrDefault(e => e.Id == idRegistro);
                if (estudiante != null)
                {
                    conexionSQLServer.MateriasEstudiante.Remove(estudiante);
                    conexionSQLServer.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el estudiante: {ex.Message}");
                return false;
            }
        }

        public List<EstudianteMateria> GetEstudiantes(int intIdEstudiante)
        {
            try
            {
                var query = (from me in conexionSQLServer.MateriasEstudiante
                             join md in conexionSQLServer.MateriasDocente on me.IdMateriaDocente equals md.Id
                             join m in conexionSQLServer.Materias on md.IdMateria equals m.Id
                             join e in conexionSQLServer.Estudiante on me.IdEstudiante equals e.Id
                             where me.IdEstudiante != intIdEstudiante &&
                                   conexionSQLServer.MateriasEstudiante
                                       .Where(g => g.IdEstudiante == intIdEstudiante)
                                       .Select(g => g.IdMateriaDocente)
                                       .Contains(me.IdMateriaDocente)
                             orderby m.NombreMateria
                             select new EstudianteMateria
                             {
                                 Id = me.Id,
                                 NombreEstudiante = e.Nombre+ " "+ e.Apellido,
                                 NombreMateria = m.NombreMateria
                             }).ToList();
                return query;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
