using System.Collections.Generic;
using WebApIEscuela.Models;

namespace WebApIEscuela.Data.Contracts
{
    public interface IRepositoryDocente
    {
        /// <summary>
        /// Retorna Listado de Docentes
        /// </summary>
        /// <returns></returns>
        List<Docente> GetAllDocentes();

        /// <summary>
        /// Retorna Listado de Materias con Docentes
        /// </summary>
        /// <returns></returns>
        List<MateriasDocente> GetAllDocenteMateria(string strMateria);
    }
}
