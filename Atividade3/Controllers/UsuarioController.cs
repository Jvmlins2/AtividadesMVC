using Atividade3.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Atividade3.Models;

namespace Atividade3.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Login/Index
        // Exibe a tela de login
        public IActionResult Index()
        {
            // se já estiver logado, manda direto pra listagem de produtos
            if (HttpContext.Session.GetString("UsuarioId") != null)
            {
                return RedirectToAction("Index", "Produto");
            }

            return View();
        }

        // POST: /Login/Index
        // Recebe email e senha do formulário e valida
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(LoginViewModel model)
        {
            if (model == null)
            {
                TempData["Erro"] = "Dados inválidos.";
                return View();
            }

            if (string.IsNullOrWhiteSpace(model.Email) || string.IsNullOrWhiteSpace(model.Senha))
            {
                TempData["Erro"] = "Email ou senha inválidos.";
                return View(model);
            }

            // normaliza email e gera o hash da senha digitada pra comparar com o hash salvo no banco
            string email = model.Email.Trim();
            byte[] senhaHash = HashService.GerarHashBytes(model.Senha);

            // AsEnumerable() traz os registros pra memória ANTES de comparar,
            // porque byte[] não pode ser comparado com == diretamente numa query LINQ-to-SQL
            var usuario = _context.Usuarios
                .AsEnumerable()
                .FirstOrDefault(u =>
                    string.Equals(u.Email?.Trim(), email, StringComparison.OrdinalIgnoreCase) &&
                    u.Senha != null && u.Senha.SequenceEqual(senhaHash));

            if (usuario == null)
            {
                TempData["Erro"] = "Email ou senha inválidos.";
                return View(model);
            }

            // guarda o id do usuário logado na sessão (Guid vira string)
            HttpContext.Session.SetString("UsuarioId", usuario.UsuarioID.ToString());
            HttpContext.Session.SetString("Nome", usuario.Nome ?? string.Empty);

            return RedirectToAction("Index", "Produto");
        }

        // GET: /Login/Sair
        // Encerra a sessão (logout)
        public IActionResult Sair()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}