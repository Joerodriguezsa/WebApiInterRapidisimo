using System.Collections.Generic;
using System.Linq;
using WebApIEscuela.Context;
using WebApIEscuela.Data.Contracts;
using WebApIEscuela.Models;

namespace WebApIEscuela.Data.Repository
{
    public class RepositoryMateria: IRepositoryMateria
    {
        private readonly ConexionSQLServer conexionSQLServer;
        public RepositoryMateria(ConexionSQLServer context)
        {
            this.conexionSQLServer = context;
        }

        /// <summary>
        /// Retorna Listado de Materias
        /// </summary>
        /// <returns></returns>
        public List<Materias> GetAllMaterias()
        {
            try
            {
                return conexionSQLServer.Materias.ToList();
            }
            catch
            {
                return null;
            }

        }
    }
}
