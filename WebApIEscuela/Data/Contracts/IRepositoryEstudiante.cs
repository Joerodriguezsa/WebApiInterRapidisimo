using System.Collections.Generic;
using WebApIEscuela.Models;

namespace WebApIEscuela.Data.Contracts
{
    public interface IRepositoryEstudiante
    {
        /// <summary>
        /// Retorna Lista de Estudiantes
        /// </summary>
        /// <returns></returns>
        List<Estudiante> GetAllEstudiantes();

        /// <summary>
        /// Guarda Registro de Materia
        /// </summary>
        /// <param name="intEstudiante"></param>
        /// <param name="intMateriaDocente"></param>
        /// <returns></returns>
        string PostRegMateria(int intEstudiante, int intMateriaDocente);

        /// <summary>
        /// Retorna Lista de Estudiantes Filtraod por Id Estudiante
        /// </summary>
        /// <param name="intIdEstudiante"></param>
        /// <returns></returns>
        List<EstudianteMateria> GetAllEstudiantesMateria(int intIdEstudiante);

        /// <summary>
        /// Elimina Registro de Materia
        /// </summary>
        /// <param name="idRegistro"></param>
        /// <returns></returns>
        bool EliminarMateria(int idRegistro);

        /// <summary>
        /// Retorna lista de Compañeros de clase
        /// </summary>
        /// <param name="intIdEstudiante"></param>
        /// <returns></returns>
        List<EstudianteMateria> GetEstudiantes(int intIdEstudiante);
    }
}
