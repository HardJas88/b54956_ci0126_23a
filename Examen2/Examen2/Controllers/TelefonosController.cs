using Examen2.Handlers;
using Examen2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Examen2.Controllers
{
    public class TelefonosController : Controller
    {
        public IActionResult Index()
        {
            TelefonosHandler telefonosHandler = new TelefonosHandler();
            var telefonos = telefonosHandler.ObtenerTelefonos();
            ViewBag.MainTitle = "Lista de Telefonos";
            return View(telefonos);
        }

        [HttpGet]
        public ActionResult CrearTelefono()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearTelefono(TelefonoModelo telefono)
        {
            ViewBag.ExitoAlCrear = false;
            try
            {
                if (ModelState.IsValid)
                {
                    TelefonosHandler telefonosHandler = new TelefonosHandler();
                    ViewBag.ExitoAlCrear = telefonosHandler.CrearTelefono(telefono);

                    if (ViewBag.ExitoAlCrear)
                    {
                        ViewBag.Message = "El telefono " + telefono.Marca + "fue creada con exito.";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch
            {
                ViewBag.Message = "Algo salio mal y no fue posible crear el telefono";
                return View();
            }

        }

        [HttpGet]
        public ActionResult EditarTelefono(int? identificador)
        {
            ActionResult vista;
            try
            {
                var telefonosHandler = new TelefonosHandler();
                var telefono = telefonosHandler.ObtenerTelefonos().Find(model => model.ID == identificador);
                if (telefono == null)
                {
                    vista = RedirectToAction("Index");
                }
                else
                {
                    vista = View(telefono);
                }
            }
            catch
            {
                vista = RedirectToAction("Index");
            }
            return vista;
        }

        [HttpPost]
        public ActionResult EditarTelefono(TelefonoModelo telefono)
        {
            try
            {
                var telefonosHandler = new TelefonosHandler();
                telefonosHandler.EditarTelefono(telefono);
                return RedirectToAction("Index", "Telefonos");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult BorrarTelefono(int? identificador)
        {
            ActionResult vista;
            try
            {
                var telefonosHandler = new TelefonosHandler();
                var telefono = telefonosHandler.ObtenerTelefonos().Find(model => model.ID == identificador);
                if (telefono == null)
                {
                    vista = RedirectToAction("Index");
                }
                else
                {
                    vista = View(telefono);
                }
            }
            catch
            {
                vista = RedirectToAction("Index");
            }
            return vista;
        }

        [HttpPost]
        public ActionResult BorrarTelefono(TelefonoModelo telefono)
        {
            try
            {
                var telefonosHandler = new TelefonosHandler();
                telefonosHandler.BorrarTelefono(telefono);
                return RedirectToAction("Index", "Telefonos");
            }
            catch
            {
                return View();
            }
        }
    }
}
