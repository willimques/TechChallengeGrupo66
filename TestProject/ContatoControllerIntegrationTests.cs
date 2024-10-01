using Api.Producer.Controllers;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Moq;
using System.Text;
using MassTransit;

namespace TestProject
{
    [TestFixture]
    public class ContatoControllerIntegrationTest
    {
        private HttpClient _client;
        private WebApplicationFactory<ContatoController> _factory;
        private Mock<IPublishEndpoint> _mockPublishEndpoint;

        [SetUp]
        public void Setup()
        {
            // Configura a fábrica da aplicação
            _factory = new WebApplicationFactory<ContatoController>()
                .WithWebHostBuilder(builder =>
                {
                    // Aqui você pode configurar os serviços reais se necessário
                });

            // Cria um cliente HTTP para enviar requisições à API
            _client = _factory.CreateClient();
            _client.BaseAddress = new Uri("https://localhost:5001");

            // Inicializa o mock do PublishEndpoint
            _mockPublishEndpoint = new Mock<IPublishEndpoint>();
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

        [Test]
        [Category("Integration")]
        public async Task AddAsync_ShouldPublishMessageToMassTransit()
        {
            // Arrange: Cria um novo contato
            var newContato = new Contato
            {
                Nome = "Teste",
                Telefone = "123456789"
            };
            var content = new StringContent(JsonConvert.SerializeObject(newContato), Encoding.UTF8, "application/json");

            // Act: Envia uma requisição POST para o endpoint /Add
            var response = await _client.PostAsync("/Add", content);

            // Assert: Verifica se o status da resposta é 201 Created
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Created));

            // Verifica se o PublishEndpoint foi chamado uma vez
            _mockPublishEndpoint.Verify(x => x.Publish(It.IsAny<object>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }

       
}