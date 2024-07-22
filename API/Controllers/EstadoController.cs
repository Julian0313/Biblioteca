using Logica.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private readonly IEstadoLog _consultarEstadoLog;

        public EstadoController(IEstadoLog consultarEstadoLog)
        {
            _consultarEstadoLog = consultarEstadoLog;
        }

        [HttpGet]
        [Route("Obtener-Estados")]
        public async Task<IActionResult> ConsultarEstado()
        {
            return Ok(await _consultarEstadoLog.GetEstado());
        }
    }
}
