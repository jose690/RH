using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using RH.Data;
using Microsoft.Data.SqlClient;

public class UsuarioController : Controller
{
    private readonly TSEContext _context;
    private readonly OferenteContext _context2;

    public UsuarioController(TSEContext context, OferenteContext context2)
    {
        _context = context;
        _context2 = context2;
    }

    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Registro()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> BuscarUsuario(string cedula, string tipoIdentificacion)
    {
        if (tipoIdentificacion != "Cédula de identificación")
        {
            ModelState.AddModelError(string.Empty, "Solo puede buscar con Cédula de Identificación.");
            return View("Registro");
        }

        // Busca el usuario en la base de datos usando EF
        var usuario = await _context.TSE
            .FromSqlInterpolated($"EXEC sp_ObtenerDatosPorCedula_JoseGuzman {cedula}")
            .FirstOrDefaultAsync(); 

        if (usuario == null)
        {
            ModelState.AddModelError(string.Empty, "La cédula no existe.");
            return View("Registro");
        }

        // Devuelve la vista de registro con el usuario encontrado
        return View("Registro", usuario);
    }

    [HttpPost]
    public async Task<JsonResult> Registrar(Usuario oUsuario)
    {
        // Agregar el nuevo usuario a la base de datos usando EF
        _context2.Oferente.Add(oUsuario);
        await _context.SaveChangesAsync();

        return Json(new { success = true, message = "Usuario registrado con éxito." });
    }
}
