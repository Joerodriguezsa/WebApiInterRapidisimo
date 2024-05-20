using Microsoft.EntityFrameworkCore;
using WebApIEscuela.Models;

namespace WebApIEscuela.Context
{
    public class ConexionSQLServer: DbContext
    {
        public ConexionSQLServer(DbContextOptions<ConexionSQLServer> options) : base(options) { }
        public DbSet<Docente> Docente { get; set; }
        public DbSet<Estudiante> Estudiante { get; set; }
        public DbSet<Materias> Materias { get; set; }
        public DbSet<MateriasDocente> MateriasDocente { get; set; }
        public DbSet<MateriasEstudiante> MateriasEstudiante { get; set; }
    }
}
