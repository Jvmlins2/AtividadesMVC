using Atividade3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Atividade3.Controllers
{
public class AlimentoController : Controller
{
    private readonly ApplicationDbContext _context;

        public AlimentoController(ApplicationDbContext context)
        {
            _context = context;
        }

    public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("UsuarioId") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var alimentos = _context.Alimentos
                .OrderBy(Alimento => Alimento.Nome)
                .ToList();

            return View(alimentos);
        }

     public IActionResult Create()
        {
            if (HttpContext.Session.GetInt32("UsuarioId") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }

         [HttpPost]
        public IActionResult Create(Alimento alimento)
        {
            if (HttpContext.Session.GetInt32("UsuarioId") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (!ModelState.IsValid)
            {
                return View(alimento);
            }

            _context.Alimentos.Add(alimento);
            _context.SaveChanges();

            TempData["Sucesso"] = "Alimento cadastrado com sucesso!";
            return RedirectToAction("Index");
        }
     public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetInt32("UsuarioId") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var alimento = _context.Alimentos.FirstOrDefault(a => a.AlimentoID == id);

            if (alimento == null)
            {
                return NotFound();
            }

            return View(alimento);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetInt32("UsuarioId") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var alimento = _context.Alimentos.FirstOrDefault(a => a.AlimentoID == id);

            if (alimento != null)
            {
                _context.Alimentos.Remove(alimento);
                _context.SaveChanges();
            }

            TempData["Sucesso"] = "Alimento excluído com sucesso!";
            return RedirectToAction("Index");
        }
}
}