using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApIEscuela.Data.Contracts;
using WebApIEscuela.Models;

namespace WebApIEscuela.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaController : ControllerBase
    {
        private readonly IRepositoryMateria data;

        public MateriaController(IRepositoryMateria data)
        {
            this.data = data;
        }

        /// <summary>
        /// GET: api/<MateriaController>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Materias> Get()
        {
            return data.GetAllMaterias();
        }
    }
}
