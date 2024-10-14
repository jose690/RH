public class Usuario
{
    //Datos traidos de tabla TSE
    //public string? Cedula { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido1 { get; set; }
    public string? Apellido2 { get; set; }
    public string? FechaNacimiento { get; set; }
    public string? Genero { get; set; }
}
public class UsuarioExtended: Usuario
{
    //Datos adicionales que se almacenarán en Oferentes
    public string? IdOferente { get; set; }
    public string? Correo { get; set; }
    public string? Telefono { get; set; }
    public string? Clave { get; set; }
    public string? Activo { get; set; }
    public string? Verificado { get; set; }
}