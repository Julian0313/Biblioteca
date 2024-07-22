namespace Dominio.Modelo;

public class Autor
{
    public int IdAutor { get; set; }

    public string Nombre { get; set; } = null!;

    public int? AnoNac { get; set; }

    public int? AnoFal { get; set; }
}
