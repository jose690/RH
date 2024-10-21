using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RH.Data;
using RH.Models;
namespace RH.Controllers;

public class HomeController : Controller
{
    private readonly TSEContext _context;
    private readonly OferenteContext _context2;

    public HomeController(TSEContext context, OferenteContext context2)
    {
        _context = context;
        _context2 = context2;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Registro()
    {
        return View("Registro");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public async Task<IActionResult> BuscarUsuario([FromQuery] string cedula, [FromQuery] string tipoIdentificacion)
    {
        if (tipoIdentificacion != "Cédula de identificación")
        {
            ModelState.AddModelError(string.Empty, "Solo puede buscar con Cédula de Identificación.");
            return Json(new { success = false, message = "Tipo de identificación no válido." });
        }

        var usuario = await _context.TSE
            .FromSqlInterpolated($"EXEC sp_ObtenerDatosPorCedula_JoseGuzman {cedula}")
            .ToListAsync();

        if (usuario == null || usuario.Count == 0)
        {
            return Json(new { success = false, message = "La cédula no existe." });
        }

        var user = usuario.FirstOrDefault();

        if (user == null)
        {
            return Json(new { success = false, message = "El usuario no fue encontrado." });
        }

        string generoTexto = "Desconocido";
        if (user.Genero != null)
        {
            generoTexto = user.Genero == "1" ? "M" : user.Genero == "2" ? "F" : "Desconocido";
        }

        return Json(new
        {
            success = true,
            cedula = user.Cedula ?? "Sin cedula",
            nombre = user.Nombre ?? "Sin nombre", // Asegúrate de que no sea null
            apellido1 = user.Apellido1 ?? "Sin apellido",
            apellido2 = user.Apellido2 ?? "Sin apellido",
            fechaNacimiento = user.FechaNacimiento ?? "Sin fecha",
            genero = generoTexto
        });
    }

    [HttpPost]
    public async Task<IActionResult> RegistrarOferente([FromBody] RegistrarOferenteRequest request)
    {
        if (!ModelState.IsValid)
        {
            return Json(new { success = false, message = "Datos inválidos." });
        }

        string identificacion = request.Cedula ?? "Sin cedula";
        string nombre = request.Nombre ?? "Sin nombre";
        string apellido1 = request.Apellido1 ?? "Sin apellido";
        string apellido2 = request.Apellido2 ?? "Sin apellido";
        string correo = request.Correo ?? "Sin correo";
        string telefono = request.Telefono ?? "Sin telefono";
        string clave = "123";
        bool activo = true; // Activo por defecto
        bool verificado = false; // No verificado por defecto

        // Verificar si el oferente ya existe
        var existente = await _context2.Oferentes
            .FirstOrDefaultAsync(o => o.Identificacion == identificacion);

        if (existente != null)
        {
            return Json(new { success = false, message = "El oferente ya existe." });
        }
        try
        {
            // Ejecutar el procedimiento almacenado para insertar el oferente
            await _context2.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC sp_InsertarOferente_JoseGuzman {identificacion}, {nombre}, {apellido1}, {apellido2}, {correo}, {telefono}, {clave}, {activo}, {verificado}");

            return Json(new { success = true, message = "Registro exitoso" });
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = ex.Message });
        }
    }
}
