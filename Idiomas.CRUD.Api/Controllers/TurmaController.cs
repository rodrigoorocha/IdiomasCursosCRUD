using Idiomas.CRUD.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Idiomas.CRUD.Api.Controllers
{

    [Route("api/Controller")]
    [ApiController]
    //[Authorize]
    public class TurmaController : ControllerBase
    {
        private readonly ITurmaServices _turmaServices;

        public TurmaController(ITurmaServices turmaServices)
        {
            _turmaServices = turmaServices;

        }

        [HttpGet("buscarTurmas")]
        public async Task<IActionResult> BuscaTurmas() {
            
            var turma = await _turmaServices.GetAllAsync();
            return Ok(turma);
        }
        



    }
}
