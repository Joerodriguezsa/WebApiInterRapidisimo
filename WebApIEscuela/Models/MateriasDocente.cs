namespace WebApIEscuela.Models
{
    /// <summary>
    /// Clase Modelo Materias Asociadas a el Docente
    /// </summary>
    public class MateriasDocente
    {
        /// <summary>
        /// Id Materias Docente
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id Docente
        /// </summary>
        public int IdDocente { get; set; }

        /// <summary>
        /// Cedula Docente
        /// </summary>
        public string DocenteCedula { get; set; }

        /// <summary>
        /// Nombre Docente
        /// </summary>
        public string DocenteNombre { get; set; }

        /// <summary>
        /// Id Materia
        /// </summary>
        public int IdMateria { get; set; }

        /// <summary>
        /// Nombre Materia
        /// </summary>
        public string MateriaNombre { get; set;}

    }
}
