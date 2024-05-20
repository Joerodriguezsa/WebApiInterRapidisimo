using System.Collections.Generic;
using System.Linq;
using WebApIEscuela.Context;
using WebApIEscuela.Data.Contracts;
using WebApIEscuela.Models;

namespace WebApIEscuela.Data.Repository
{
    public class RepositoryDocente: IRepositoryDocente
    {
        private readonly ConexionSQLServer conexionSQLServer;
        public RepositoryDocente(ConexionSQLServer context)
        {
            this.conexionSQLServer = context;
        }

        /// <summary>
        /// Retorna Listado de Docentes
        /// </summary>
        /// <returns></returns>
        public List<Docente> GetAllDocentes()
        {
            try
            {
                return conexionSQLServer.Docente.ToList();
            }
            catch
            {
                return null;
            }

        }

        /// <summary>
        /// Retorna Listado de Docentes con Materias
        /// </summary>
        /// <returns></returns>
        public List<MateriasDocente> GetAllDocenteMateria(string strMateria)
        {
            try
            {
                var datos = (from md in conexionSQLServer.MateriasDocente
                             join d in conexionSQLServer.Docente on md.IdDocente equals d.Id
                             join m in conexionSQLServer.Materias on md.IdMateria equals m.Id
                             where string.IsNullOrEmpty(strMateria) || m.NombreMateria.ToLower().Contains(strMateria.ToLower())
                             orderby md.IdMateria
                             select new MateriasDocente
                             {
                                 Id = md.Id,
                                 IdDocente = md.IdDocente,
                                 DocenteCedula = d.Cedula,
                                 DocenteNombre = d.Nombre + " "+ d.Apellido,
                                 IdMateria = md.IdMateria,
                                 MateriaNombre = m.NombreMateria
                             }).ToList();
                return datos;
            }
            catch
            {
                return null;
            }
        }
    }
}
