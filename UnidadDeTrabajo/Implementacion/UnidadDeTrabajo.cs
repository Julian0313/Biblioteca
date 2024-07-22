using AutoMapper;
using Dominio.Modelo;
using Dominio.Utilidades;
using Repositorio.Implementacion;
using Repositorio.Interfaces;
using UnidadDeTrabajo.Interfaces;

namespace UnidadDeTrabajo.Implementacion
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {
        private readonly Dictionary<Type, object> _repositorios = new Dictionary<Type, object>();
        private readonly LibreriaContext _context;
        private readonly IMapper _mapper;  
        
        private IGetEntidadPag<Autor> _getAutorPag;
        private IGetEntidadPag<LibroRtn> _getLibroPag;

        private IInsEntidad<Autor> _insAutor;
        private IInsEntidad<Libro> _insLibro;

        private IValidarDatosEntidad<Autor> _validarAutor;
        private IValidarDatosEntidad<Libro> _validarLibro;

        private IGetEntidadById<Autor> _validarAutorById;
        private IGetEntidadById<Libro> _validarLibroById;

        private ISetEntidad<Autor> _setAutor;
        private ISetEntidad<Libro> _setLibro;

        private IDelEntidad _delEntidad;

        public UnidadDeTrabajo(LibreriaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IGetEntidad<T> IGetEntidad<T>() where T : class
        {
            if (_repositorios.ContainsKey(typeof(T)))
            {
                return (IGetEntidad<T>)_repositorios[typeof(T)];
            }

            var getEntidad = new GetEntidadRepo<T>(_context);
            _repositorios[typeof(T)] = getEntidad;
            return getEntidad;
        }
        public IGetEntidadPag<Autor> AutorRepoPag
        {
            get
            {
                if (_getAutorPag == null)
                {
                    _getAutorPag = new AutorRepo(_context);
                }
                return _getAutorPag;
            }
        }

        public IGetEntidadPag<LibroRtn> LibroRepoPag 
        {
            get
            {
                if (_getLibroPag == null)
                {
                    _getLibroPag = new LibroRepo(_context, _mapper);
                }
                return _getLibroPag;
            }
        }

        public IInsEntidad<Autor> AutorRepoIns
        {
            get
            {
                if (_insAutor == null)
                {
                    _insAutor = new AutorRepo(_context);
                }
                return _insAutor;
            }
        }

        public IValidarDatosEntidad<Autor> ValidarAutor
        {
            get
            {
                if (_validarAutor == null)
                {
                    _validarAutor = new AutorRepo(_context);
                }
                return _validarAutor;
            }
        }

        public IInsEntidad<Libro> LibroRepoIns
        {
            get
            {
                if (_insLibro == null)
                {
                    _insLibro = new LibroRepo(_context, _mapper);
    }
                return _insLibro;
            }
        }

        public IValidarDatosEntidad<Libro> ValidarLibro
        {
            get
            {
                if (_validarLibro == null)
                {
                    _validarLibro = new LibroRepo(_context, _mapper);
                }
                return _validarLibro;
            }
        }

        public ISetEntidad<Autor> AutorRepoSet
        {
            get
            {
                if (_setAutor == null)
                {
                    _setAutor = new AutorRepo(_context);
                }
                return _setAutor;
            }
        }


        public ISetEntidad<Libro> LibroRepoSet
        {
            get
            {
                if (_setLibro == null)
                {
                    _setLibro = new LibroRepo(_context,_mapper);
                }
                return _setLibro;
            }
        }

        public IGetEntidadById<Autor> ValidarAutorById
        {
            get
            {
                if (_validarAutorById == null)
                {
                    _validarAutorById = new AutorRepo(_context);
                }
                return _validarAutorById;
            }

        }

        public IGetEntidadById<Libro> ValidarLibroById
        {
            get
            {
                if (_validarLibroById == null)
                {
                    _validarLibroById = new LibroRepo(_context, _mapper);
                }
                return _validarLibroById;
            }
        }

        public IDelEntidad DelAutor
        {
            get
            {
                if (_delEntidad == null)
                {
                    _delEntidad = new AutorRepo(_context);
                }
                return _delEntidad;
            }
        }

        public IDelEntidad DelLibro
        {
            get
            {
                if (_delEntidad == null)
                {
                    _delEntidad = new LibroRepo(_context, _mapper);
                }
                return _delEntidad;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        public async Task GuardarCambiosAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
