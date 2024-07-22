namespace Dominio.Modelo;

public class AuditoriaAutor
{
    public int IdAuditoriaAutor { get; set; }

    public int? FkIdAutor { get; set; }

    public string Nombre { get; set; } = null!;

    public int? AnoNac { get; set; }

    public int? AnoFal { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

}
