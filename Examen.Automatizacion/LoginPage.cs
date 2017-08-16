using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Examen.Automatizacion
{
    public class LoginPage
    {
        const string url = "http://localhost:60645/";

        private readonly IWebDriver _driver;

        #region Login Page Elements
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
        #endregion

        public LoginPage()
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

        public void RegisterDataLogin_OK()
        {
            userNameText.SendKeys("daniel@quintana.com");
            passwordText.SendKeys("prueba");
        }

        public void RegisterDataLogin_ERROR()
        {
            userNameText.SendKeys("daniel@quintana.com");
            passwordText.SendKeys("prueba2");
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

        public int ContarCorporaciones()
        {
            return corporaciones.Count;
        }

    }
}
