using Dominio.Utilidades;
using Logica.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Dominio.Dto;
using Logica.Implementacion;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ILibroLog _libroLog;

        public LibroController(ILibroLog libroLog)
        {
            _libroLog = libroLog;
        }

        [HttpGet]
        [Route("Obtener-Libros")]
        public async Task<IActionResult> ConsultarLibro([FromQuery] ParametrosPag parametros)
        {
            return Ok(await _libroLog.GetLibro(parametros));
        }

        [HttpGet]
        [Route("Obtener-Libro/{id}")]
        public async Task<IActionResult> ConsultarLibroById(int id)
        {
            return Ok(await _libroLog.GetLibroById(id));
        }

        [HttpPost]
        [Route("Crear-Libro")]
        public async Task<IActionResult> CrearLibro(LibroDto libro)
        {
            var respuesta = await _libroLog.InsLibroLog(libro);
            return StatusCode((int)respuesta.CodigoEstado, respuesta);
        }

        [HttpPut]
        [Route("Modificar-Libro")]
        public async Task<IActionResult> ModificarLibro(LibroDto libro)
        {
            var respuesta = await _libroLog.SetLibroLog(libro);
            return StatusCode((int)respuesta.CodigoEstado, respuesta);
        }

        [HttpDelete]
        [Route("Eliminar-Libro/{id}")]
        public async Task<IActionResult> EliminarLibro(int id)
        {
            var respuesta = await _libroLog.DelLibro(id);
            return StatusCode((int)respuesta.CodigoEstado, respuesta);
        }
    }
}
