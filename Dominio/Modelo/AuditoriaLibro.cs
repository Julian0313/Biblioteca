namespace Dominio.Modelo;

public class AuditoriaLibro
{
    public int IdAuditoriaLibro { get; set; }

    public int? FkIdLibro { get; set; }

    public int? FkIdAutor { get; set; }

    public int? FkIdEstado { get; set; }

    public string Titulo { get; set; } = null!;

    public int? AnoPublicacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }
}
