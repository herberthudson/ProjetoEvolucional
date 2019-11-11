using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoEvolucional.Data;

namespace ProjetoEvolucional.Controllers
{
    [Authorize]

    public class HelloController: Controller
    {

        private readonly ProjetoEvolucionalDataContext _context;

        public HelloController(ProjetoEvolucionalDataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
