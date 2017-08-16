using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;

namespace Examen.Automatizacion
{
    public class CorporacionPage
    {
        const string url = "http://localhost:60645/";

        private readonly IWebDriver _driver;

        #region Corporacion Page Elements
        [FindsBy(How = How.CssSelector, Using = "a[ui-sref='login']")]
        private IWebElement loginLink = null;

        [FindsBy(How = How.CssSelector, Using = "input#userName")]
        private IWebElement userNameText = null;

        [FindsBy(How = How.CssSelector, Using = "input#password")]
        private IWebElement passwordText = null;

        [FindsBy(How = How.CssSelector, Using = "button[type='submit']")]
        private IWebElement loginButton = null;

        [FindsBy(How = How.CssSelector, Using = ".alert.alert-danger")]
        private IWebElement divAlert = null;

        [FindsBy(How = How.CssSelector, Using = "corporacion-card")]
        private IList<IWebElement> corporaciones = null;

        [FindsBy(How = How.CssSelector, Using = "body > div > div > div > div:nth-child(2) > button")]
        private IWebElement btnNuevaCorporacion = null;


        [FindsBy(How = How.CssSelector, Using = "corporacion-form > div > div:nth-child(2) > input")]
        private IWebElement txtNombreCorporacion = null;

        [FindsBy(How = How.CssSelector, Using = "corporacion-form > div > div:nth-child(3) > input")]
        private IWebElement txtCalle = null;

        [FindsBy(How = How.CssSelector, Using = "corporacion-form > div > div:nth-child(4) > input")]
        private IWebElement txtCiudad = null;

        [FindsBy(How = How.CssSelector, Using = "corporacion-form > div > div:nth-child(5) > input")]
        private IWebElement txtProvincia = null;

        [FindsBy(How = How.CssSelector, Using = "corporacion-form > div > div:nth-child(6) > input")]
        private IWebElement txtPais = null;

        [FindsBy(How = How.CssSelector, Using = "corporacion-form > div > div:nth-child(7) > input")]
        private IWebElement txtCodigoEmail = null;

        [FindsBy(How = How.CssSelector, Using = "corporacion-form > div > div:nth-child(8) > input")]
        private IWebElement txtNroTelefono = null;

        [FindsBy(How = How.CssSelector, Using = "corporacion-form > div > div:nth-child(9) > input")]
        private IWebElement txtFecha = null;

        [FindsBy(How = How.CssSelector, Using = "corporacion-form > div > div:nth-child(10) > input")]
        private IWebElement txtCodCorporacion = null;
        
        [FindsBy(How = How.CssSelector, Using = "button[type=submit].btn-success")]
        private IWebElement btnGuardarCorporacion = null;

        [FindsBy(How = How.CssSelector, Using = "body > div > div > div > div.alert.alert-success.alert-dismissable")]
        private IWebElement divCorporacionCreada = null;
        
        #endregion

        public CorporacionPage()
        {
            _driver = Driver.Instance;
            PageFactory.InitElements(_driver, this);
        }

        public void GoToUrl()
        {
            Driver.Instance.Navigate().GoToUrl(url);
        }

        public void EsperarNavegador(int segundos)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(segundos);
        }

        public void GoToLogin()
        {
            loginLink.Click();
        }

        public void RegisterDataLogin()
        {
            userNameText.SendKeys("daniel@quintana.com");
            passwordText.SendKeys("prueba");
        }        

        public void SignIn()
        {
            loginButton.Click();
        }

        public bool GetLoginLink()
        {
            return loginLink == null;
        }

        public bool GetDivAlert()
        {
            return divAlert != null;
        }

        public void MostrarModalDeCreacion()
        {
            btnNuevaCorporacion.Click();
        }

        public void RegistrarDataNuevaCorporacion()
        {
            txtNombreCorporacion.SendKeys("Daniel Corp");
            txtCalle.SendKeys("Arturo");
            txtCiudad.SendKeys("Lima");
            txtProvincia.SendKeys("Li");
            txtPais.SendKeys("Pe");
            txtCodigoEmail.SendKeys("gmail");
            txtNroTelefono.SendKeys("123456789");
            txtFecha.SendKeys("08/08/17");
            txtCodCorporacion.SendKeys("12");
        }

        public void GuardarCorporacion()
        {
            btnGuardarCorporacion.Click();
        }

        public int ContarCorporaciones()
        {
            return corporaciones.Count;
        }

        public bool ValidarCreacionExitosa()
        {
            return divCorporacionCreada != null;
        }
    }
}
