using Dominio.Modelo;
using Dominio.Utilidades;
using Logica.Interfaces;
using Logica.Utilidades;
using Repositorio.Interfaces;
using UnidadDeTrabajo.Interfaces;

namespace Logica.Implementacion
{
    public class AutorLog : IAutorLog
    {
        private readonly IGetEntidadPag<Autor> _getEntidad;
        private readonly IInsEntidad<Autor> _insAutor;
        private readonly IValidarDatosEntidad<Autor> _validarAutor;
        private readonly ISetEntidad<Autor> _setAutor;
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;
        private readonly IGetEntidadById<Autor> _validarAutorId;
        private readonly IDelEntidad _delAutor;

        public AutorLog(IGetEntidadPag<Autor> getEntidad, IInsEntidad<Autor> insAutor,
            IValidarDatosEntidad<Autor> validarAutor, ISetEntidad<Autor> setAutor,
            IUnidadDeTrabajo unidadDeTrabajo, IGetEntidadById<Autor> validarAutorId, IDelEntidad delAutor)
        {
            _getEntidad = getEntidad;
            _insAutor = insAutor;
            _validarAutor = validarAutor;
            _setAutor = setAutor;
            _unidadDeTrabajo = unidadDeTrabajo;
            _validarAutorId = validarAutorId;
            _delAutor = delAutor;
        }

        public async Task<Respuesta<string>> DelAutor(int id)
        {
            string mensaje = "";
            try
            {
                if (id <= 0)
                {
                    mensaje = "Ingrese un autor valido";
                    return RespuestaError.ErrorRespuesta(mensaje);
                }

                var validarAutor = await _validarAutorId.GetEntidadByIdAsync(id);

                if (validarAutor != null)
                {
                    await _delAutor.DelEntidadAsync(id);
                    await _unidadDeTrabajo.GuardarCambiosAsync();
                    mensaje = "Autor fue eliminado exitosamente";
                    return RespuestaError.RespuestaOkay(mensaje);
                }
                else
                {
                    mensaje = "Datos invalidos";
                    return RespuestaError.ErrorRespuesta(mensaje);
                }

            }
            catch (Exception ex)
            {
                return RespuestaError.ErrorRespuesta(ex.Message);
            }
        }

        public async Task<Respuesta<Paginacion<Autor>>> GetAutorLog(ParametrosPag parametros)
        {
            try
            {
                Paginacion<Autor> _consultarAutor = await _getEntidad.IGetEntidadPagAsync(parametros);
                return _consultarAutor.Contador > 0 ?
                RespuestaError.RespuestaOkay(_consultarAutor) :
                RespuestaError.RespuestaSinRegistros<Paginacion<Autor>>("No hay registros de Autores");
            }
            catch (Exception ex) 
            {
                return RespuestaError.ErrorIntRespuesta<Paginacion<Autor>>(ex.Message);
            }
        }

        public async Task<Respuesta<string>> InsAutorLog(Autor autor)
        {
            string mensaje = "";
            try
            {
                autor.Nombre = autor.Nombre.ToUpper();
                var validarAutor = await _validarAutor.ValidarEntidadAsync(autor);

                if (validarAutor == null) 
                {
                    autor.Nombre = autor.Nombre.ToUpper();
                    await _insAutor.InsEntidadAsync(autor);
                    await _unidadDeTrabajo.GuardarCambiosAsync();
                    mensaje = "Autor " + autor.Nombre + " fue creado exitosamente";
                    return RespuestaError.RespuestaOkay(mensaje);
                }
                else
                {
                    mensaje = "Autor " + autor.Nombre + " ya se encuentra registrado en el sistema";
                    return RespuestaError.ErrorRespuesta(mensaje);
                }
             
            }
            catch (Exception ex)
            {
                return RespuestaError.ErrorRespuesta(ex.Message);
            }
        }

        public async Task<Respuesta<string>> SetAutorLog(Autor autor)
        {
            string mensaje = "";
            try
            {
                if (autor.IdAutor <= 0)
                {
                    mensaje = "Ingrese un autor valido";
                    return RespuestaError.ErrorRespuesta(mensaje);
                }

                autor.Nombre = autor.Nombre.ToUpper();
                var validarAutor = await _validarAutorId.GetEntidadByIdAsync(autor.IdAutor);

                if (validarAutor != null)
                {
                    autor.Nombre = autor.Nombre.ToUpper();
                    await _setAutor.SetEntidadAsync(autor);
                    await _unidadDeTrabajo.GuardarCambiosAsync();
                    mensaje = "Autor " + autor.Nombre + " fue modificado exitosamente";
                    return RespuestaError.RespuestaOkay(mensaje);
                }
                else
                {
                    mensaje = "Autor " + autor.Nombre + " no se encuentra registrado en el sistema";
                    return RespuestaError.ErrorRespuesta(mensaje);
                }

            }
            catch (Exception ex)
            {
                return RespuestaError.ErrorRespuesta(ex.Message);
            }
           
        }
    }
}
