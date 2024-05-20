using System.Collections.Generic;
using WebApIEscuela.Models;

namespace WebApIEscuela.Data.Contracts
{
    public interface IRepositoryMateria
    {
        /// <summary>
        /// Retrona Materias
        /// </summary>
        /// <returns></returns>
        List<Materias> GetAllMaterias();
    }
}
