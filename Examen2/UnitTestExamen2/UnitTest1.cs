using Examen2.Handlers;
using Examen2.Controllers;
using Examen2.Models;


namespace UnitTestExamen2
{
    [TestClass]
    public class UnitTest1
    {
        // Prueba que comprueba que se obtenga los datos de la DB
        [TestMethod]
        public void ObtenerTelefonos_verificaSiSeObtieneTelefonosCorrectamente()
        {

            TelefonosHandler handlers = new TelefonosHandler();

            List<TelefonoModelo> telefonos = handlers.ObtenerTelefonos();

            Assert.IsNotNull(telefonos);
        }


        // Prueba que crear un telefono y comprueba que se creara
        [TestMethod]
        public void CrearTelefono_DebeRetornarTrue_SiSeCreaCorrectamente()
        {
            TelefonosHandler handler = new TelefonosHandler();
            TelefonoModelo telefono = new TelefonoModelo
            {
                Marca = "Samsung",
                Modelo = "Tab",
                Color = "Negro",
                Cores = 1,
                Android = true
            };

            bool result = handler.CrearTelefono(telefono);

            Assert.IsTrue(result);

        }

        // prueba que crea un telefono y comprueba que la marca del telefono se
        //encuentre en la base de datos
        [TestMethod]
        public void CrearTelefono_VerificarSiEncuentraCreadoEnLaBaseConNombre()
        {
            TelefonosHandler handler = new TelefonosHandler();
            TelefonoModelo telefono = new TelefonoModelo
            {
                Marca = "Motorola",
                Modelo = "neo",
                Color = "Negro",
                Cores = 8,
                Android = true
            };

            bool result = handler.CrearTelefono(telefono);
            List<TelefonoModelo> listaTelefono = handler.ObtenerTelefonos();

            Assert.IsTrue(result);
            Assert.IsTrue(listaTelefono.Any(e => e.Marca == "Motorola"));
        }

        // Prueba para verificar que un color se edita de manera correcta
        [TestMethod]
        public void EditarTelefono_SiSeEditoColorCorrectamente()
        {
            TelefonosHandler handler = new TelefonosHandler();
            TelefonoModelo telefono = new TelefonoModelo
            {
                ID = 40,
                Marca = "Iphone",
                Modelo = "7",
                Color = "morado", // cambio color
                Cores = 2,
                Android = false
            };

            bool editarExitoso = handler.EditarTelefono(telefono);

            Assert.IsTrue(editarExitoso);

        }


        // Prueba para verificar que los cores se cambian manera correcta
        [TestMethod]
        public void EditarTelefono_SiSeEditoCoresCorrectamente()
        {
            TelefonosHandler handler = new TelefonosHandler();
            TelefonoModelo telefono = new TelefonoModelo
            {
                ID = 25,
                Marca = "Iphone",
                Modelo = "8",
                Color = "verde",
                Cores = 1, //cambia cores
                Android = false
            };

            bool editarExitoso = handler.EditarTelefono(telefono);

            Assert.IsTrue(editarExitoso);

        }

        // Prueba para verificar que se borran de manera correcta
        [TestMethod]
        public void BorrarTelefono_SiSeBorraCorrectamenteDaTrue()
        {

            TelefonosHandler handler = new TelefonosHandler();
            TelefonoModelo telefono = new TelefonoModelo
            {
                ID = 30
            };

            bool result = handler.BorrarTelefono(telefono);

            Assert.IsTrue(result);
        }

        // Prueba para verificar que no se borran telefonos que no existen de manera correcta
        [TestMethod]
        public void BorrarTelefono_SiNoSePuedeBorrarDaFalse()
        {
            TelefonosHandler handler = new TelefonosHandler();
            TelefonoModelo telefono = new TelefonoModelo
            {
                ID = 999 // ID inexistente
            };

            bool result = handler.BorrarTelefono(telefono);

            Assert.IsFalse(result);

        }
    }
}