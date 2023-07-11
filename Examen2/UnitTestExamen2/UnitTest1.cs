using Examen2.Handlers;
using Examen2.Controllers;
using Examen2.Models;


namespace UnitTestExamen2
{
    [TestClass]
    public class UnitTest1
    {
        /* Prueba que comprueba que se obtenga los datos de la DB
            R1/ No se necesitan valores de entrada porque ya existen datos en la Base de datos desde donde se extraen los datos.
            R2/ Se logra el resultado correcto debido a que la prueba comprueba que se devuelvan los datos de la Base de datos y 
            cuando esto ocurre la prueba pasa correctamente.
         */
        [TestMethod]
        public void ObtenerTelefonos_verificaSiSeObtieneTelefonosCorrectamente()
        {
            TelefonosHandler handlers = new TelefonosHandler();

            List<TelefonoModelo> telefonos = handlers.ObtenerTelefonos();

            Assert.IsNotNull(telefonos);
        }

        /* Prueba que comprueba que se obtenga los datos de DB y verifica que los datos tengo una Marca
         R1/ No se necesitan valores de entrada porque ya existen datos en la Base de datos desde donde se extraen los datos.
         R2/ Se logra el resultado correcto debido a que la prueba comprueba que se devuelvan los datos de la Base de datos y 
            que exista una marca con un nombre en particular y cuando esto ocurre la prueba pasa correctamente.
         */

        [TestMethod]
        public void ObtenerTelefonos_DebeRetornarTelefonosCorrectamente()
        {

            TelefonosHandler handler = new TelefonosHandler();

            List<TelefonoModelo> telefonos = handler.ObtenerTelefonos();

            Assert.IsNotNull(telefonos);

            Assert.IsTrue(telefonos.Any(e => e.Marca == "Samsung"));

        }


        /* Prueba que crear un telefono y comprueba que se creara
            R1/Se crea un objeto con valores de un teléfono como son Marca,
            Modelo, Color, Cores y Android?. Estos elementos son los necesarios para la creación exitosa de un teléfono.
            R2/ Al utilizar un objeto teléfono con los valores esperados para su creación, la prueba logra culminarse con éxito.
         */
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

        /* prueba que crea un telefono y comprueba que la marca del telefono se
            encuentre en la base de datos
            R1/ Se crea un objeto con valores de un teléfono como son Marca, Modelo,
            Color, Cores y Android?. Estos elementos son los necesarios para la creación exitosa de un teléfono.
            R2/Al ingresar los valores correctos para la creación de teléfono, entonces se genera correctamente 
               el teléfono, además se comprueba que en la lista de todos los teléfonos, exista su marca.
         */
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

            Assert.IsTrue(listaTelefono.Any(e => e.Marca == "Motorola"));
        }

        /* Prueba para verificar que no se borran telefonos que no existen de manera correcta
         *  R1/ Recibe un ID del teléfono que necesita borrar, esto porque necesita una identificación del elemento que va a ser borrado.
            R2/ Si se logra de manera incorrecta realizar el borrado del teléfono, entonces devuelve true como un proceso que se realizó bien.
         */
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

        /* Prueba para verificar que se borran de manera correcta
         *  R1/ Recibe un ID del teléfono que necesita borrar, esto porque necesita una identificación del elemento que va a ser borrado.
            R2/ Si se logra de manera correcta realizar el borrado del teléfono, entonces devuelve true como un proceso que se realizó bien.
         */
        [TestMethod]
        public void BorrarTelefono_SiSeBorraCorrectamenteDaTrue()
        {
            TelefonosHandler handler = new TelefonosHandler();
            TelefonoModelo telefono = new TelefonoModelo
            {
                ID = 60 // se le debe colocar el ID de l telefono por borrar
            };

            bool result = handler.BorrarTelefono(telefono);

            Assert.IsTrue(result);
        }

        /* Prueba para verificar que un color se edita de manera correcta
            R1/ Se edita un objeto que contenga los elementos de un teléfono como son el ID, Marca,
            Modelo, Color, Cores y Android. Estos elementos son los necesarios para la edición exitosa de un teléfono.
            R2/ Se comprueba que al intentar editar un teléfono, se pueda realizar de manera correcta la edición del color,
            cuando ocurre, el resultado en el assert el True.
         */
        [TestMethod]
        public void EditarTelefono_SiSeEditoColorCorrectamente()
        {
            TelefonosHandler handler = new TelefonosHandler();
            TelefonoModelo telefono = new TelefonoModelo
            {
                ID = 40,
                Marca = "Iphone",
                Modelo = "7",
                Color = "gris", // cambio color
                Cores = 2,
                Android = false
            };

            bool editarExitoso = handler.EditarTelefono(telefono);

            Assert.IsTrue(editarExitoso);

        }


        /* Prueba para verificar que los cores se cambian manera correcta
         *  R1/ Se edita un objeto que contenga los elementos de un teléfono como son el ID, Marca,
         *  Modelo, Color, Cores y Android. Estos elementos son los necesarios para la edición exitosa de un teléfono.
            R2/ Se comprueba que al intentar editar un teléfono, se pueda realizar de manera correcta la
            cantidad de cores, cuando ocurre, el resultado en el assert el True.
         */
        [TestMethod]
        public void EditarTelefono_SiSeEditoCoresCorrectamente()
        {
            TelefonosHandler handler = new TelefonosHandler();
            TelefonoModelo telefono = new TelefonoModelo
            {
                ID = 57,
                Marca = "Iphone",
                Modelo = "8",
                Color = "dorado",
                Cores = 9, //cambia cores
                Android = false
            };

            bool editarExitoso = handler.EditarTelefono(telefono);

            Assert.IsTrue(editarExitoso);

        }

        
    }
}