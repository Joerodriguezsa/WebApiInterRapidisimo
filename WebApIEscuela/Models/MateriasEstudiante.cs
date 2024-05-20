namespace WebApIEscuela.Models
{
    /// <summary>
    /// Clase Modelo Materias Asociadas a el Estudiante
    /// </summary>
    public class MateriasEstudiante
    {
        /// <summary>
        /// Id Materias Estudiante
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id Docente
        /// </summary>
        public int IdEstudiante { get; set; }

        /// <summary>
        /// Id Materia Asociada a el Docente
        /// </summary>
        public int IdMateriaDocente { get; set; }

    }
}
