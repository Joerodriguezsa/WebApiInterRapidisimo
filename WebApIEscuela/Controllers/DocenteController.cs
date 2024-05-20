using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApIEscuela.Data.Contracts;
using WebApIEscuela.Models;

namespace WebApIEscuela.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocenteController : Controller
    {
        private readonly IRepositoryDocente data;

        public DocenteController(IRepositoryDocente data)
        {
            this.data = data;
        }

        /// <summary>
        /// GET: api/<DocenteController>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Docente> Get()
        {
            return data.GetAllDocentes();
        }

        /// <summary>
        /// GET: api/Docente/Materias
        /// </summary>
        /// <returns>List of MateriasDocente</returns>
        [HttpGet("Materias")]
        public List<MateriasDocente> GetMateriasDocente([FromQuery] string strMateria = "")
        {
            return data.GetAllDocenteMateria(strMateria);
        }
    }
}
