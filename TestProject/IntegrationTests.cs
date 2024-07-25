using System.Net;
using System.Text;
using Domain.Entities.Enum;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using TechChallengeGrupo66.Controllers;

namespace TestProject
{

    [TestFixture]
    public class ContatoControllerTests
    {
        private HttpClient _client;
        private const string BaseUrl = "/api/Contato";

        [SetUp]
        public void Setup()
        {
            // Configuração do cliente HTTP para os testes de integração
            // Configuração mínima do cliente HTTP para os testes de integração
            var appFactory = new WebApplicationFactory<ContatoController>().WithWebHostBuilder(builder =>
            {
                // Aqui você pode configurar serviços específicos, como bancos de dados em memória ou serviços mockados
            });

            _client = appFactory.CreateClient();
        }

        [TearDown]
        public void TearDown()
        {
            _client.Dispose();
        }

        [Test]
        public async Task GetAllAsync_ReturnsOk()
        {
            // Arrange

            // Act
            var response = await _client.GetAsync($"{BaseUrl}/GetAll");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task GetByIdAsync_ReturnsOk()
        {
            // Arrange
            var id = 1; // Defina um ID válido para o teste

            // Act
            var response = await _client.GetAsync($"{BaseUrl}/GetById?id={id}");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task GetAllByRegion_ReturnsOk()
        {
            // Arrange
            var id = RegionsType.Norte; // Defina uma região válida para o teste

            // Act
            var response = await _client.GetAsync($"{BaseUrl}/GetAllByRegion?id={id}");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task AddAsync_ReturnsCreated()
        {
            // Arrange
            var contato = new Contato
            {
                // Defina os campos do contato para o teste
                Nome = "Fulano",
                Email = "fulano@example.com",
                Telefone = "999999999",
                // Outros campos necessários conforme sua entidade Contato
            };
            var content = new StringContent(JsonConvert.SerializeObject(contato), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync($"{BaseUrl}/Add", content);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }

        [Test]
        public async Task DeleteAsync_ReturnsNoContent()
        {
            // Arrange
            var id = 1; // Defina um ID válido para o teste

            // Act
            var response = await _client.DeleteAsync($"{BaseUrl}/Remove?id={id}");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public async Task UpdateAsync_ReturnsOk()
        {
            // Arrange
            var contato = new Contato
            {
                // Defina os campos do contato para o teste
                Id = 1, // Defina um ID válido para o teste
                Nome = "Fulano Atualizado",
                Email = "fulano_atualizado@example.com",
                Telefone = "999999999",
                // Outros campos necessários conforme sua entidade Contato
            };
            var content = new StringContent(JsonConvert.SerializeObject(contato), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync($"{BaseUrl}/Update", content);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}