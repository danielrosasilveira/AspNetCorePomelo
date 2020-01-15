using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCorePomelo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCorePomelo.Controllers
{
    [Route("clientes")]
    public class ClienteController : Controller
    {
        DataContext db = new DataContext();

        [Route("")]
        [Route("~/")]
        [Route("index")]
        public IActionResult Index()
        {
            if (ViewBag.login != null)
            {
                ViewBag.clientes = db.Clientes.ToList();
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
        public IActionResult Add(ClientesModel cli)
        {
            db.Clientes.Add(cli);
            db.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            db.Clientes.Remove(db.Clientes.Find(id));
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            return View(db.Clientes.Find(id));
        }

        [HttpPost]
        [Route("Edit/{id}")]
        public IActionResult Edit(ClientesModel cli)
        {
            db.Entry(cli).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Route("Buscar")]
        public IActionResult Buscar(string nome)
        {
            ViewBag.clientes = db.Clientes.Where(x => x.Nome.Contains(nome));
            return View(nameof(Index));
        }


        [HttpGet]
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

    }
}