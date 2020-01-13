using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
            ViewBag.usuarios = db.Usuarios.ToList();
            return View();
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
    }
}
