using Api.Producer.Controllers;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TestProject
{
    [TestFixture]
    public class ContatoControllerIntegrationTest
    {
        private HttpClient _client;
        private WebApplicationFactory<ContatoController> _factory;
        [SetUp]
        public void Setup()
        {
            // Set environment variables for RabbitMQ for the test environment
            Environment.SetEnvironmentVariable("RABBITMQ_HOST", "localhost");
            Environment.SetEnvironmentVariable("RABBITMQ_USERNAME", "guest");
            Environment.SetEnvironmentVariable("RABBITMQ_PASSWORD", "guest");

            // Configura a fábrica da aplicação
            _factory = new WebApplicationFactory<ContatoController>()
                .WithWebHostBuilder(builder =>
                {
                    // Aqui você pode configurar os serviços reais se necessário
                });

            // Cria um cliente HTTP para enviar requisições à API
            _client = _factory.CreateClient();
            _client.BaseAddress = new Uri("http://localhost:5001");
        }

        [TearDown]
        public void Dispose()
        {
            _client?.Dispose();
            _factory?.Dispose();
        }

 [Test]
[Category("Integration")]
public async Task GetAllAsync_ReturnsSuccessStatusCode_And_ValidData()
{
    // Act: Envia uma requisição GET para o endpoint /GetAll
    var response = await _client.GetAsync("/GetAll");

    // Assert: Verifica se o status da resposta é 200 OK
    Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

    // Assert: Verifica se o conteúdo da resposta não é nulo
    var responseData = await response.Content.ReadAsStringAsync();
    Assert.That(responseData, Is.Not.Null);

    // Assert: Deserializa o conteúdo da resposta e verifica se há dados
    var contatos = JsonConvert.DeserializeObject<List<Contato>>(responseData);
    Assert.That(contatos, Is.Not.Empty);
}
    }


}