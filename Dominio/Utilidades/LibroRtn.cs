namespace Dominio.Utilidades;

public class LibroRtn
{

    public int IdLibro { get; set; }

    public string FkIdAutor { get; set; }

    public string FkIdEstado { get; set; }

    public string Titulo { get; set; }

    public int? AnoPublicacion { get; set; }

}
