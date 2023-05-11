using laboratorio6.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace laboratorio6.Controllers
{
    public class PeliculasController : Controller
    {
        public IActionResult Index()
        {
            PeliculasHandler peliculasHandler = new PeliculasHandler();
            var peliculas = peliculasHandler.ObtenerPeliculas();
            ViewBag.MainTitle = "Lista de Peliculas";
            return View(peliculas);
        }
    }
}
