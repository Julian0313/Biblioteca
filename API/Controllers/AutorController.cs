using Dominio.Modelo;
using Dominio.Utilidades;
using Logica.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorLog _autorLog;

        public AutorController(IAutorLog autorLog)
        {
            _autorLog = autorLog;
        }

        [HttpGet]
        [Route("Obtener-Autores")]
        public async Task<IActionResult> ConsultarAutor([FromQuery] ParametrosPag parametros)
        {
            return Ok(await _autorLog.GetAutorLog(parametros));
        }

        [HttpPost]
        [Route("Crear-Autor")]
        public async Task<IActionResult> CrearAutor(Autor autor)
        {
            var respuesta = await _autorLog.InsAutorLog(autor);
            return StatusCode((int)respuesta.CodigoEstado, respuesta);
        }

        [HttpPost]
        [Route("Modificar-Autor")]
        public async Task<IActionResult> ModificarAutor(Autor autor)
        {
            var respuesta = await _autorLog.SetAutorLog(autor);
            return StatusCode((int)respuesta.CodigoEstado, respuesta);
        }

        [HttpDelete]
        [Route("Eliminar-Autor/{id}")]
        public async Task<IActionResult> EliminarAutor(int id)
        {
            var respuesta = await _autorLog.DelAutor(id);
            return StatusCode((int)respuesta.CodigoEstado, respuesta);
        }
    }
}
