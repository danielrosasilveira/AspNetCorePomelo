using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AspNetCorePomelo.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCorePomelo.Controllers
{
    [Route("usuarios")]
    public class UsuarioController : Controller
    {
        DataContext db = new DataContext();

        [Route("")]
        [Route("~/")]
        [Route("index")]
        public IActionResult Index()
        {
            if (ViewBag.login != null)
            {
                ViewBag.usuarios = db.Usuarios.ToList();
                return View();
            }
            else
            {
                return View(nameof(Login));
            }
        }

        [HttpGet]
        [Route("Add")]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        [Route("Add")]
        public IActionResult Add(Usuarios usu)
        {
            db.Usuarios.Add(usu);
            db.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            db.Usuarios.Remove(db.Usuarios.Find(id));
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            return View(db.Usuarios.Find(id));
        }

        [HttpPost]
        [Route("Edit/{id}")]
        public IActionResult Edit(Usuarios usu)
        {
            db.Entry(usu).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Route("Buscar")]
        public IActionResult Buscar(string nome)
        {
            ViewBag.usuarios = db.Usuarios.Where(x => x.Nome.Contains(nome));
            return View(nameof(Index));
        }


        [HttpGet]
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [Route("Login")]
        public IActionResult Login(string usuario, string senha)
        {
            ViewBag.login = db.Usuarios.Where(x => x.Usuario.Contains(usuario) && x.Senha.Contains(senha)).FirstOrDefault();

            if (ViewBag.login != null)
            {
                ViewBag.usuarios = db.Usuarios.ToList();

                return View("index");
            }
            else
            {
                ViewBag.Erro = "Dados Incorretos!!";
                return View("login");
            }
        }
    }
}
