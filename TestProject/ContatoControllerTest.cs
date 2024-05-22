using FluentAssertions;
using Domain.Entities;
using Domain.Entities.Enum;
using Domain.Interfaces;
using global::TechChallengeGrupo66.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace TestProject
{
    namespace TechChallengeGrupo66.Tests.Controllers
    {
        [TestFixture]
        public class ContatoControllerTests
        {
            private ContatoController _contatoController;
            private Mock<IContatoService> _contatoServiceMock;

            [SetUp]
            public void Setup()
            {
                _contatoServiceMock = new Mock<IContatoService>();
                _contatoController = new ContatoController(_contatoServiceMock.Object);
            }


            [Test]
            public async Task GetAllAsync_ShouldReturnOkResult()
            {
                // Arrange
                var contatos = new List<Contato> { new Contato(), new Contato() };
                _contatoServiceMock.Setup(x => x.GetAllAsync()).ReturnsAsync(contatos);

                // Act
                var result = await _contatoController.GetAllAsync();

                // Assert
                result.Should().BeOfType<OkObjectResult>();
                var okResult = result as OkObjectResult;
                okResult?.Value.Should().BeEquivalentTo(contatos);
            }

            [Test]
            public async Task GetByIdAsync_ShouldReturnOkResult()
            {
                // Arrange
                var id = 1;
                var contato = new Contato();
                _contatoServiceMock.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(contato);

                // Act
                var result = await _contatoController.GetByIdAsync(id);

                // Assert
                result.Should().BeOfType<OkObjectResult>();
                var okResult = result as OkObjectResult;
                okResult?.Value.Should().BeEquivalentTo(contato);
            }

            [Test]
            public async Task GetAllByRegion_ShouldReturnOkResult()
            {
                // Arrange
                var id = RegionsType.Sul;
                var contatos = new List<Contato> { 
                    new Contato() {
                        Id = 1,
                        Nome = "kiko",
                        Email = "chaves@teste.com.br",
                        DDD_ID = 43,
                        Telefone = "1234-5678"
                    },
                    new Contato() {
                        Id = 2,
                        Nome  = "Chaves do oito",
                        Email = "chaves@teste.com.br",
                        DDD_ID = 41,
                        Telefone = "1234-5678"
                    } 
                };
                _contatoServiceMock.Setup(x => x.GetAllByRegionAsync(id)).ReturnsAsync(contatos);

                // Act
                var result = await _contatoController.GetAllByRegion(id);

                // Assert
                result.Should().BeOfType<OkObjectResult>();
                var okResult = result as OkObjectResult;
                okResult?.Value.Should().BeEquivalentTo(contatos);
            }

            [Test]
            public async Task AddAsync_WithValidContato_ShouldReturnCreatedResult()
            {
                // Arrange
                var contato = new Contato() { 
                    Nome  = "Chaves do oito",
                    Email = "chaves@teste.com.br",
                    DDD_ID = 41,
                    Telefone = "1234-5678"
                };

                _contatoServiceMock.Setup(x => x.AddAsync(contato)).Returns(Task.CompletedTask);

                // Act
                var result = await _contatoController.AddAsync(contato);

                // Assert
                result.Should().BeOfType<CreatedResult>();
            }

            [Test]
            public async Task AddAsync_WithInvalidContato_ShouldReturnBadRequestResult()
            {
                // Arrange
                var contato = new Contato()
                {
                    Nome = "Chaves do oito",
                    Email = "chaves@teste.com.br",
                    DDD_ID = 99,
                    Telefone = "991234-5678"
                };
                _contatoServiceMock.Setup(x => x.AddAsync(contato)).Returns(Task.CompletedTask);
                _contatoController.ModelState.AddModelError("Error", "Invalid contato");

                // Act
                var result = await _contatoController.AddAsync(contato);

                // Assert
                result.Should().BeOfType<BadRequestObjectResult>();
            }

            [Test]
            public async Task DeleteAsync_ShouldReturnNoContentResult()
            {
                // Arrange
                var id = 1;
                _contatoServiceMock.Setup(x => x.DeleteAsync(id)).Returns(Task.CompletedTask);

                // Act
                var result = await _contatoController.DeleteAsync(id);

                // Assert
                result.Should().BeOfType<NoContentResult>();
            }

            [Test]
            public async Task UpdateAsync_WithValidContato_ShouldReturnOkResult()
            {
                // Arrange
                var contato = new Contato()
                {
                    Id = 1,
                    Nome = "kiko",
                    Email = "chaves@teste.com.br",
                    DDD_ID = 43,
                    Telefone = "1234-5678"
                };

                _contatoServiceMock.Setup(x => x.UpdateAsync(contato)).Returns(Task.CompletedTask);

                // Act
                var result = await _contatoController.UpdateAsync(contato);

                // Assert
                result.Should().BeOfType<OkObjectResult>();
                var okResult = result as OkObjectResult;
                okResult?.Value.Should().BeEquivalentTo(contato);
            }

            [Test]
            public async Task UpdateAsync_WithInvalidContato_ShouldReturnBadRequestResult()
            {
                // Arrange
                var contato = new Contato();
                _contatoServiceMock.Setup(x => x.UpdateAsync(contato)).Returns(Task.CompletedTask);
                _contatoController.ModelState.AddModelError("Error", "Invalid contato");

                // Act
                var result = await _contatoController.UpdateAsync(contato);

                // Assert
                result.Should().BeOfType<BadRequestObjectResult>();
            }
        }
    }
 }