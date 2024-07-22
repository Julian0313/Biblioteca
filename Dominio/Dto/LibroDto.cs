namespace Dominio.Dto
{
    public class LibroDto
    {
        public int IdLibro { get; set; }

        public int FkIdAutor { get; set; }

        public int FkIdEstado { get; set; }

        public string Titulo { get; set; }

        public int? AnoPublicacion { get; set; }
    }
}
