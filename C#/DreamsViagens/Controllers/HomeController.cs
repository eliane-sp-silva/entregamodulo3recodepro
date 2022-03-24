using DreamsViagens.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DreamsViagens.Controllers
{
    public class HomeController : Controller
    {
        

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Destino()
        {
            return View();
        }
        public IActionResult Cadastro()
        {
            return View();
        }
        public IActionResult Promocao()
        {
            return View();
        }
        public IActionResult Contato()
        {
            return View();
        }

    }
}