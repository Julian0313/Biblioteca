using Dominio.Utilidades;
using Dominio.Modelo;
using Logica.Interfaces;
using Logica.Utilidades;
using Repositorio.Interfaces;

namespace Logica.Implementacion
{
    public class EstadoLog : IEstadoLog
    {
        private readonly IGetEntidad<Estado> _consultarEntidad;

        public EstadoLog(IGetEntidad<Estado> consultarEntidad)
        {
            _consultarEntidad = consultarEntidad;
        }

        public async Task<Respuesta<IReadOnlyList<Estado>>> GetEstado()
        {
            try
            {
                var _consultarEstado = await _consultarEntidad.IGetEntidadAsync();
                return _consultarEstado.Count > 0 ?
                RespuestaError.RespuestaOkay(_consultarEstado) :
                RespuestaError.RespuestaSinRegistros<IReadOnlyList<Estado>>("No hay registros de Estados");
            }
            catch (Exception ex)
            {
                return RespuestaError.ErrorIntRespuesta<IReadOnlyList<Estado>>(ex.Message);
            }
        }
    }
}
