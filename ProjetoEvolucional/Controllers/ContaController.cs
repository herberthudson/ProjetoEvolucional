using Microsoft.AspNetCore.Mvc;
using ProjetoEvolucional.Data;
using ProjetoEvolucional.Models;
using System.Linq;

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
        public IActionResult Login(LoginVM model)
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

            }


            return View();
        }
    }
}
