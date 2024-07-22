namespace Dominio.Modelo;

public class Libro
{
    public int IdLibro { get; set; }

    public int? FkIdAutor { get; set; }

    public int? FkIdEstado { get; set; }

    public string Titulo { get; set; } = null!;

    public int? AnoPublicacion { get; set; }
    public virtual Autor Autor { get; set; }
    public virtual Estado Estado { get; set; }
}
