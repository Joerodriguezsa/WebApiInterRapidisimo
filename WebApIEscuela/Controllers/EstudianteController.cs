using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using WebApIEscuela.Data.Contracts;
using WebApIEscuela.Models;

namespace WebApIEscuela.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly IRepositoryEstudiante data;

        public EstudianteController(IRepositoryEstudiante data)
        {
            this.data = data;
        }

        /// <summary>
        /// GET: api/<EstudianteController>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Estudiante> Get()
        {
            return data.GetAllEstudiantes();
        }

        /// <summary>
        /// GET: Obtiene listado de Materias por Estudiante
        /// </summary>
        /// <param name="intIdEstudiante"></param>
        /// <returns></returns>
        [HttpGet("GetAllEstudiantesMateria")]
        public List<EstudianteMateria> GetAllEstudiantesMateria(int intIdEstudiante)
        {
            var datos = data.GetAllEstudiantesMateria(intIdEstudiante);
            if (datos == null)
            {
                return new List<EstudianteMateria>(); // Devuelve una lista vacía si no hay datos
            }
            return datos;
        }

        /// <summary>
        /// POST: Registro de Materia
        /// </summary>
        /// <param name="intEstudiante"></param>
        /// <param name="intMateriaDocente"></param>
        /// <returns></returns>
        [HttpPost("RegisterMateria")]
        public IActionResult PostRegMateria(int intEstudiante, int intMateriaDocente)
        {
            var result = data.PostRegMateria(intEstudiante, intMateriaDocente);
            return Ok(new { message = result });
        }

        /// <summary>
        /// DELETE: Borrar Registro de Materia
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var deleted = data.EliminarMateria(id);
                if (deleted)
                {
                    return Ok(new { message = "Estudiante eliminado correctamente." });
                }
                else
                {
                    return NotFound(new { message = "No se encontró el estudiante con el ID proporcionado." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error al eliminar el estudiante: " + ex.Message });
            }
        }

        /// <summary>
        /// retorna lista de estudiantes asociados 
        /// </summary>
        /// <param name="intIdEstudiante"></param>
        /// <returns></returns>
        [HttpGet("GetEstudiantes/{intIdEstudiante}")]
        public ActionResult<List<EstudianteMateria>> GetEstudiantes(int intIdEstudiante)
        {
            var estudiantes = data.GetEstudiantes(intIdEstudiante);
            if (estudiantes == null || estudiantes.Count == 0)
            {
                return Ok(new List<EstudianteMateria>());
            }

            return Ok(estudiantes);
        }
    }
}
