using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TechChallengeGrupo66.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Controller : ControllerBase
    {
        private readonly IContatoService _contatoService;

        public Controller(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }   


        [HttpGet,Route("/GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {

           var result = await _contatoService.GetAll();
                        
            return Ok(result);
        }

    }
}
