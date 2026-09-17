using Atividade2.Data;
using Atividade2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Atividade2.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Dashboard()
        {
            // valida se existe login realizado
            if(HttpContext.Session.GetInt32("UsuarioId") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var usuarioId = HttpContext.Session.GetString("UsuarioId");

            var usuario = _context.Usuarios.FirstOrDefault(usuario => usuario.UsuarioID.ToString() == usuarioId);

            return View(usuario);
        }
    }
}
