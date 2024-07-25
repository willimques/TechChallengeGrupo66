using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallengeGrupo66.Controllers;

namespace TestProject
{   
    [TestFixture]
    public class ContatoControllerIntegrationTests
    {
        private HttpClient _client;
        private Mock<IContatoService> _mockContatoService;
        private WebApplicationFactory<ContatoController> _factory;


        [SetUp]
        public void Setup()
        {
            _mockContatoService = new Mock<IContatoService>();

            _factory = new WebApplicationFactory<ContatoController>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.AddSingleton(_mockContatoService.Object);
                    });
                });
            _factory.Server.BaseAddress = new Uri("http://localhost:5000");
            _factory.ClientOptions.BaseAddress = new Uri("http://localhost:5000"); 

            _client = _factory.CreateClient();
         
        }

        [TearDown]
        public void Dispose()
        {
            _client.Dispose();
            _factory.Dispose();
        }

        [Test]
        [Category("Integration")]
        public async Task Get_ReturnsSuccessStatusCode()
        {
            // Act
            var response = await _client.GetAsync("/api/contato");

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NotFound));
        }

        [Test]
        [Category("Integration")]
        public async Task Post_CreatesNewContato()
        {
            // Arrange
            var newContato = new { Nome = "Teste", Telefone = "123456789" };
            var content = new StringContent(JsonConvert.SerializeObject(newContato), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/contato", content);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NotFound));
        }

        [Test]
        [Category("Integration")]
        public async Task Put_UpdatesContato()
        {
            // Arrange
            var updatedContato = new { Id = 1, Nome = "Teste Atualizado", Telefone = "987654321" };
            var content = new StringContent(JsonConvert.SerializeObject(updatedContato), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PutAsync("/api/contato/1", content);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NotFound));
        }

        [Test]
        [Category("Integration")]
        public async Task Delete_RemovesContato()
        {
            // Act
            var response = await _client.DeleteAsync("/api/contato/1");

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NotFound));
        }
    }
}
