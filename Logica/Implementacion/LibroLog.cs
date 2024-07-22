using Dominio.Utilidades;
using Dominio.Modelo;
using Logica.Interfaces;
using Logica.Utilidades;
using Repositorio.Interfaces;
using UnidadDeTrabajo.Interfaces;
using Dominio.Dto;
using AutoMapper;

namespace Logica.Implementacion
{
    public class LibroLog : ILibroLog
    {
        private readonly IGetEntidadPag<LibroRtn> _consultarEntidad;
        private readonly IValidarDatosEntidad<Libro> _validarLibro;
        private readonly IInsEntidad<Libro> _insLibro;
        private readonly ISetEntidad<Libro> _setLibro;
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;
        private readonly IMapper _mapper;
        private readonly IGetEntidadById<Libro> _consutarById;
        private readonly IDelEntidad _delLibro;

        public LibroLog(IGetEntidadPag<LibroRtn> consultarEntidad, IValidarDatosEntidad<Libro> validarLibro,
             IInsEntidad<Libro> insLibro, ISetEntidad<Libro> setLibro,IUnidadDeTrabajo unidadDeTrabajo,
             IMapper mapper, IGetEntidadById<Libro> consutarById, IDelEntidad delLibro)
        {
            _consultarEntidad = consultarEntidad;
            _validarLibro = validarLibro;
            _insLibro = insLibro;
            _setLibro = setLibro;
            _unidadDeTrabajo = unidadDeTrabajo;
            _mapper = mapper;
            _consutarById = consutarById;
            _delLibro = delLibro;
        }

        public async Task<Respuesta<string>> DelLibro(int id)
        {
            string mensaje;
            try
            {
                if (id <= 0)
                {
                    mensaje = "Ingrese un libro valido";
                    return RespuestaError.ErrorRespuesta(mensaje);
                }              

                var validarAutor = await _consutarById.GetEntidadByIdAsync(id);              

                if (validarAutor != null)
                {                   
                    await _delLibro.DelEntidadAsync(id);
                    await _unidadDeTrabajo.GuardarCambiosAsync();
                    mensaje = "Libro fue eliminado exitosamente";
                    return RespuestaError.RespuestaOkay(mensaje);
                }
                else
                {
                    mensaje = "Libro no se encuentra registrado en el sistema";
                    return RespuestaError.ErrorRespuesta(mensaje);
                }

            }
            catch (Exception ex)
            {
                return RespuestaError.ErrorRespuesta(ex.Message + ex.InnerException);
            }
        }

        public async Task<Respuesta<Paginacion<LibroRtn>>> GetLibro(ParametrosPag parametros)
        {
            try
            {
                Paginacion<LibroRtn> consultarLibro = await _consultarEntidad.IGetEntidadPagAsync(parametros);
                return consultarLibro.Contador > 0 ?
                RespuestaError.RespuestaOkay(consultarLibro) :
                RespuestaError.RespuestaSinRegistros<Paginacion<LibroRtn>>("No hay registros de Libros");
            }
            catch (Exception ex)
            {
                return RespuestaError.ErrorIntRespuesta<Paginacion<LibroRtn>>(ex.Message);
            }
        }

        public async Task<Respuesta<LibroRtn>> GetLibroById(int id)
        {
            try
            {
                var consultarLibro = await _consutarById.GetEntidadByIdAsync(id);
                var libroMap = _mapper.Map<LibroRtn>(consultarLibro);
                return libroMap != null ?
                RespuestaError.RespuestaOkay(libroMap) :
                RespuestaError.RespuestaSinRegistros<LibroRtn>("No hay registros de Libros");
            }
            catch (Exception ex)
            {
                return RespuestaError.ErrorIntRespuesta<LibroRtn>(ex.Message);
            }
        }

        public async Task<Respuesta<string>> InsLibroLog(LibroDto libro)
        {
            string mensaje;
            try
            {
                var libroMap = _mapper.Map<Libro>(libro);

                if (libro.FkIdAutor < 1)
                {
                    mensaje = "Ingrese un autor valido";
                    return RespuestaError.ErrorRespuesta(mensaje);
                }
                libroMap.Titulo = libro.Titulo.ToUpper();
                var validarAutor = await _validarLibro.ValidarEntidadAsync(libroMap);                

                if (validarAutor == null)
                {
                    libroMap.FkIdEstado = 1;
                    libroMap.Titulo = libro.Titulo.ToUpper();
                    await _insLibro.InsEntidadAsync(libroMap);
                    await _unidadDeTrabajo.GuardarCambiosAsync();
                    mensaje = "Libro " + libro.Titulo + " fue creado exitosamente";
                    return RespuestaError.RespuestaOkay(mensaje);
                }
                else
                {
                    mensaje = "Libro " + libro.Titulo + " no se encuentra registrado en el sistema";
                    return RespuestaError.ErrorRespuesta(mensaje);
                }

            }
            catch (Exception ex)
            {
                return RespuestaError.ErrorRespuesta(ex.Message+ex.InnerException);
            }
        }

        public async Task<Respuesta<string>> SetLibroLog(LibroDto libro)
        {
            string mensaje;
            try
            {
                if (libro.IdLibro <=0)
                {
                    mensaje = "Ingrese un libro valido";
                    return RespuestaError.ErrorRespuesta(mensaje);
                }
                if (libro.FkIdAutor <= 0)
                {
                    mensaje = "Ingrese un autor valido";
                    return RespuestaError.ErrorRespuesta(mensaje);
                }

                var validarAutor = await _consutarById.GetEntidadByIdAsync(libro.IdLibro);
                var libroMap = _mapper.Map<Libro>(libro);

                if (libro.FkIdAutor < 1)
                {
                    mensaje = "Ingrese un autor valido";
                    return RespuestaError.ErrorRespuesta(mensaje);
                }
                libroMap.Titulo = libro.Titulo.ToUpper();                

                if (validarAutor != null)
                {
                    libroMap.Titulo = libro.Titulo.ToUpper();
                    await _setLibro.SetEntidadAsync(libroMap);
                    await _unidadDeTrabajo.GuardarCambiosAsync();
                    mensaje = "Libro " + libro.Titulo + " fue modificado exitosamente";
                    return RespuestaError.RespuestaOkay(mensaje);
                }
                else
                {
                    mensaje = "Libro " + libro.Titulo + " no se encuentra registrado en el sistema";
                    return RespuestaError.ErrorRespuesta(mensaje);
                }

            }
            catch (Exception ex)
            {
                return RespuestaError.ErrorRespuesta(ex.Message + ex.InnerException);
            }
        }
    }
}
