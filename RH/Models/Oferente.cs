using System.ComponentModel.DataAnnotations.Schema;

[Table("Oferentes")]
public class Oferente
{
    //Datos traidos de tabla TSE
    public string? Identificacion { get; set; }
    //public string? Nombre { get; set; }
    //public string? Apellido1 { get; set; }
    //public string? Apellido2 { get; set; }
    public string? Correo { get; set; }
    public string? Telefono { get; set; }
    public string? Clave { get; set; }
    public string? Activo { get; set; }
    public string? Verificado { get; set; }
}