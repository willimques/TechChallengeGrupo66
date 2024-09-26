using Domain.Entities;
using Domain.Entities.Enum;
using Domain.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace TechChallengeGrupo66.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoService _contatoService;
        private IValidator<Contato> validator = new ContatoValidator();


        public ContatoController(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        [HttpGet, Route("/GetAll")]
        [SwaggerOperation(
            Summary = "Carrega todos os contatos",
            OperationId = "GetAll",
            Tags = new[] { "LISTAR" }
        )]
        public async Task<IActionResult> GetAllAsync()
        {

            var result = await _contatoService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet, Route("/GetById")]
        [SwaggerOperation(
            Summary = "Carrega um contato por Id",
            OperationId = "GetByIdAsync",
            Tags = new[] { "LISTAR" }
        )]
        public async Task<IActionResult> GetByIdAsync([FromQuery] int id)
        {
            var result = await _contatoService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet, Route("/GetAllByRegion")]
        [SwaggerOperation(
            Summary = "Carrega todos os contatos de uma Região",
            Description = "<br/> 1- Norte <br/> 2- Nordeste <br/> 3- Centro-Oeste <br/> 4- Sudeste <br/> 5- Sul",
            OperationId = "GetAllByRegion",
            Tags = new[] { "LISTAR" }
        )]
        public async Task<IActionResult> GetAllByRegion([FromQuery] RegionsType id)
        {
            var result = await _contatoService.GetAllByRegionAsync(id);
            return Ok(result);
        }


        [HttpPost, Route("/Add")]
        [SwaggerOperation(
            Summary = "Adicionar contatos",
            Description = "Metodos para adicionar contatos",
            OperationId = "Add",
            Tags = new[] { "CRUD" }
        )]
        public async Task<IActionResult> AddAsync(Contato item)
        {
            var validationResult = validator.Validate(item);            

            try
            {
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult);
                }

                await _contatoService.AddQueueAsync(item);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete, Route("/Remove")]
        [SwaggerOperation(
            Summary = "Remover contatos",
            Description = "Metodo para Remover contatos",
            OperationId = "Remove",
            Tags = new[] { "CRUD" }
        )]
        public async Task<IActionResult> DeleteAsync([FromQuery] int id)
        {
            await _contatoService.DeleteQueueAsync(id);
            return NoContent();
        }

        [HttpPost, Route("/Update")]
        [SwaggerOperation(
            Summary = "Update contatos",
            Description = "Metodo para Update de contatos",
            OperationId = "Update",
            Tags = new[] { "CRUD" }
        )]
        public async Task<IActionResult> UpdateAsync(Contato item)
        {
            try
            {
                var validationResult = validator.Validate(item);

                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult);
                }

                await _contatoService.UpdateQueueAsync(item);
                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
