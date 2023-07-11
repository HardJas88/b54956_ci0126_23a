using Examen2.Handlers;
using Examen2.Controllers;
using Examen2.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace UnitTestExamen2.FuncionalTest
{
    [TestClass]
    public class FuncionalTest1
    {
        /* 
         *  R1/ La prueba tiene como objetivo automatizar la creación de un telefono
         *  R2/ La prueba logra crear de una manera correcta un nuevo telefono y
         *  lograr probar que esta funcionando de manera optima.
         */
        [TestMethod]
        public void CreatePhone() 
        {
            ChromeDriver driver = new ChromeDriver();
            string urlStart = "https://localhost:7140/Telefonos";
            driver.Url = urlStart;
            driver.Navigate().GoToUrl(urlStart);
            driver.FindElement(By.Id("BottonCrear")).Click();
            driver.FindElement(By.Id("Marca")).SendKeys("Huawei");
            driver.FindElement(By.Id("Modelo")).SendKeys("p80 pro");
            driver.FindElement(By.Id("Color")).SendKeys("RED");
            driver.FindElement(By.Id("Cores")).SendKeys("5");
            driver.FindElement(By.Id("Android")).SendKeys("true");
            driver.FindElement(By.Id("BottonConfirmarCreacion")).Click();
            string URLEnd = "https://localhost:7140/telefonos/CrearTelefono"; 
            Assert.AreEqual(URLEnd , driver.Url);
        }

        /* 
         *  R1/ El objetivo es lograr editar un elemento del telefono, en este caso el color
         *  R2/ Se logra cambiar el color de un telefono de manera correcta.
         */
        [TestMethod]
        public void EditePhone()
        {
            ChromeDriver driver = new ChromeDriver();
            string urlStart = "https://localhost:7140/Telefonos";
            driver.Url = urlStart;
            driver.Navigate().GoToUrl(urlStart);
            // aqui se le debe indicar el ID del telefono que quiere editar
            driver.FindElement(By.Id("BotonEditar: 56")).Click();
            IWebElement colorEditarInput = driver.FindElement(By.Id("ColorEditar"));
            colorEditarInput.Clear(); 
            colorEditarInput.SendKeys("Red"); //editar Color 
            driver.FindElement(By.Id("BottonEditar")).Click();
            string URLEnd = "https://localhost:7140/Telefonos";
            Assert.AreEqual(URLEnd, driver.Url);
        }

        /* 
         *  R1/ El objetivo es elminar un telefono
         *  R2/ Se cumple con lo esperado al poder borrar un telefono 
         */
        [TestMethod]
        public void DeletePhone()
        {
            ChromeDriver driver = new ChromeDriver();
            string urlStart = "https://localhost:7140/Telefonos";
            driver.Url = urlStart;
            driver.Navigate().GoToUrl(urlStart);
            // aqui se le debe indicar el ID del telefono que quiere editar
            driver.FindElement(By.Id("BotonBorrar: 27")).Click();
            driver.FindElement(By.Id("BottonConfirmarBorrado")).Click();
            string URLEnd = "https://localhost:7140/Telefonos";
            Assert.AreEqual(URLEnd, driver.Url);
        }

        /* 
         *  R1/ Se busca poder comprobar que se obtengan los datos
         *  R2/ Se logra el objetivo al poder recuperar los datos de la base de datos.
         */
        [TestMethod]
        public void GetPhone()
        {
            ChromeDriver driver = new ChromeDriver();
            string urlStart = "https://localhost:7140";
            driver.Url = urlStart;
            driver.Navigate().GoToUrl(urlStart);
            driver.FindElement(By.Id("BotonTelefono")).Click();
            string URLEnd = "https://localhost:7140/Telefonos";
            Assert.AreEqual(URLEnd, driver.Url);
        }


    }
}
