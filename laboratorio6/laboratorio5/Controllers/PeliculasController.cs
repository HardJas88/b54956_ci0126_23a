using laboratorio6.Handlers;
using laboratorio6.Models;
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
        [HttpGet]
        public IActionResult CrearPelicula() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult CrearPelicula(PeliculaModelo pelicula)
        {
            ViewBag.ExitoAlCrear = false;
            try
            {
                if (ModelState.IsValid)
                {
                    PeliculasHandler peliculasHandler = new PeliculasHandler();
                    ViewBag.ExitoAlCrear = peliculasHandler.CrearPelicula(pelicula);

                    if (ViewBag.ExitoAlCrear)
                    {
                        ViewBag.Message = "La pelicula " + pelicula.Nombre + "fue creada con exito.";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch
            {
                ViewBag.Message = "Algo salio mal y no fue posible crear la pelicula";
                return View();
            }
            
        }
    }
}
