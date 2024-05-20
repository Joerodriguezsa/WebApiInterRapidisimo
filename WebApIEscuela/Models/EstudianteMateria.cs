namespace WebApIEscuela.Models
{
    /// <summary>
    /// Clase Modelo Estudiante Materia
    /// </summary>
    public class EstudianteMateria
    {
        /// <summary>
        /// Id REgistro
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id Estudiante
        /// </summary>
        public int IdEstudiante { get; set; }

        /// <summary>
        /// Nombre de la Materia
        /// </summary>
        public string NombreMateria { get; set; }

        /// <summary>
        /// Creditos de la Materia
        /// </summary>
        public int Creditos { get; set; }

        /// <summary>
        /// Nombre Docente
        /// </summary>
        public string NombreDocente { get; set; }

        /// <summary>
        /// Apellido Docente
        /// </summary>
        public string ApellidoDocente { get; set; }

        /// <summary>
        /// Nombre Completo Estudiante
        /// </summary>
        public string NombreEstudiante { get; set; }
    }
}
