using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Examen.Automatizacion.Tests
{
    [TestClass]
    public class CorporacionPageTests
    {
        private readonly CorporacionPage _corporacionPage;

        public CorporacionPageTests()
        {
            Driver.GetInstance();
            _corporacionPage = new CorporacionPage();
        }

        [TestMethod]
        public void Registrar_Corporacion_Automation()
        {
            _corporacionPage.GoToUrl();
            _corporacionPage.EsperarNavegador(1);

            _corporacionPage.GoToLogin();
            _corporacionPage.RegisterDataLogin();
            _corporacionPage.SignIn();

            _corporacionPage.EsperarNavegador(2);

            _corporacionPage.MostrarModalDeCreacion();
            _corporacionPage.EsperarNavegador(2);
            _corporacionPage.RegistrarDataNuevaCorporacion();
            _corporacionPage.GuardarCorporacion();

            _corporacionPage.EsperarNavegador(1);

            var creacionExitosa = _corporacionPage.ValidarCreacionExitosa();           

            creacionExitosa.Should().BeTrue();

            Driver.CloseInstance();
        }
    }
}
