using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TechChallengeGrupo66.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class Controller : ControllerBase
    {
        private readonly IContatoService _contatoService;

        public Controller(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }
        
        [HttpGet, Route("/GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {

           var result = await _contatoService.GetAllAsync();                        
            return Ok(result);
        }

        [HttpGet, Route("/GetById")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] int id)
        {

            var result = await _contatoService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet, Route("/GetAllByRegion")]
        public async Task<IActionResult> GetAllByRegion([FromQuery] int id)
        {

            var result = await _contatoService.GetAllByRegionAsync(id);
            return Ok(result);
        }

        [HttpPost, Route("/Add")]
        public async Task<IActionResult> AddAsync(Contato item)
        {
            await _contatoService.AddAsync(item);
            return Created();
        }

        [HttpDelete, Route("/Remove")]
        public async Task<IActionResult> DeleteAsync([FromQuery] int id)
        {
            await _contatoService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost, Route("/Update")]
        public async Task<IActionResult> UpdateAsync(Contato item)
        {
            await _contatoService.UpdateAsync(item);
            return Ok(item);
        }

    }
}
