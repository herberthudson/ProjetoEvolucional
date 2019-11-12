using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ProjetoEvolucional.Data;
using ProjetoEvolucional.Models;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjetoEvolucional.Controllers
{
    public class ContaController : Controller
    {
        private readonly ProjetoEvolucionalDataContext _ctx;

        public ContaController(ProjetoEvolucionalDataContext ctx)
        {
            _ctx = ctx;
        }

        public IActionResult Login(string returnUrl) => View();
     
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            var usuario = _ctx.Usuarios.FirstOrDefault(u => u.Login == model.Login);

            if (usuario == null)
                ModelState.AddModelError("Login", "Login Não encontrado!");
            else
            {
                if (usuario.Senha != model.Senha)
                {
                    ModelState.AddModelError("Senha", "Senha Incorreta"); 
                }
            }

            if (ModelState.IsValid)
            {
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuario.Login));
                identity.AddClaim(new Claim(ClaimTypes.Name, usuario.Nome));

                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    principal
                );

                return RedirectToAction("Index", "Home");
            }


            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login");
        }
    }
}
