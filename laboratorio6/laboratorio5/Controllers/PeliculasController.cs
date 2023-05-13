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
        public ActionResult EditarPelicula(int? identificador)
        {
           ActionResult vista;
           try
            {
                var peliculasHandler = new PeliculasHandler();
                var pelicula = peliculasHandler.ObtenerPeliculas().Find(model=>model.ID == identificador);
                if (pelicula == null)
                {
                    vista = RedirectToAction("Index");
                }
                else
                {
                    vista = View(pelicula);
                }
                
            }
            catch
            {
                vista = RedirectToAction("Index");
            }
            return vista;
        }


        public ActionResult EditarPelicula(PeliculaModelo pelicula)
        {
            try
            {
                var peliculasHandler = new PeliculasHandler();
                peliculasHandler.EditarPelicula(pelicula);
                return RedirectToAction("Index", "Peliculas");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult BorrarPelicula(int? identificador)
        {
            ActionResult vista;
            try
            {
                var peliculasHandler = new PeliculasHandler();
                var pelicula = peliculasHandler.ObtenerPeliculas().Find(model => model.ID == identificador);
                if (pelicula == null)
                {
                    vista = RedirectToAction("Index");
                }
                else
                {
                    vista = View(pelicula);
                }
            }
            catch
            {
                vista = RedirectToAction("Index");
            }
            return vista;
        }

        [HttpPost]
        public ActionResult BorrarPelicula(PeliculaModelo pelicula)
        {
            try
            {
                var peliculasHandler = new PeliculasHandler();
                peliculasHandler.BorrarPelicula(pelicula);
                return RedirectToAction("Index", "Peliculas");
            }
            catch
            {
                return View();
            }
        }
    }
}
