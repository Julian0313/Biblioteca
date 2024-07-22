using AutoMapper;
using Dominio.Utilidades;
using Dominio.Modelo;
using Dominio.Dto;

namespace Repositorio.Utilidades
{
    public class PerfildeMapeo : Profile
    {
        public PerfildeMapeo()
        {
            CreateMap<Libro, LibroRtn>()
                .ForMember(dest => dest.FkIdAutor, opt => opt.MapFrom(src => src.Autor.Nombre))
                .ForMember(dest => dest.FkIdEstado, opt => opt.MapFrom(src => src.Estado.Descripcion));

            CreateMap<LibroDto, Libro>()
              .ForMember(dest => dest.IdLibro, opt => opt.MapFrom(src => src.IdLibro))
              .ForMember(dest => dest.FkIdAutor, opt => opt.MapFrom(src => src.FkIdAutor))
              .ForMember(dest => dest.FkIdEstado, opt => opt.MapFrom(src => src.FkIdEstado))
              .ForMember(dest => dest.Titulo, opt => opt.MapFrom(src => src.Titulo))
              .ForMember(dest => dest.AnoPublicacion, opt => opt.MapFrom(src => src.AnoPublicacion));
        }
    }
}
