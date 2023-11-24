using API.models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
public class AuthController : Controller
{
    private readonly UserManager<Usuario> _userManager;
    private readonly SignInManager<Usuario> _signInManager;

    public AuthController(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] Usuario model)
    {
        var user = new Usuario
        {
            NombreUsuario = model.NombreUsuario,
            IdPersona = model.IdPersona,
            Nivel = model.Nivel,
            Estado = model.Estado
        };

        var result = await _userManager.CreateAsync(user, model.Contraseña);

        if (result.Succeeded)
        {
       
            return Ok(new { Message = "Usuario registrado exitosamente" });
        }

        return BadRequest(result.Errors);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] Usuario model)
    {
        var result = await _signInManager.PasswordSignInAsync(model.NombreUsuario, model.Contraseña, false, false);

        if (result.Succeeded)
        {
          
            return Ok(new { Message = "Inicio de sesión exitoso" });
        }

        return BadRequest(new { Message = "Inicio de sesión fallido" });
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
       
        return Ok(new { Message = "Cierre de sesión exitoso" });
    }
}