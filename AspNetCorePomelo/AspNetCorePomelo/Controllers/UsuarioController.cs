using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspNetCorePomelo.Models;

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

    }
}
