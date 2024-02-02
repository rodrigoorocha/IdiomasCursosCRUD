using Idiomas.CRUD.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Idiomas.CRUD.Api.Controllers
{
    [Route("api/Controller")]
    [ApiController]
    //[Authorize]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoServices _alunoService;

        public AlunoController(IAlunoServices alunoService)
        {
            _alunoService = alunoService;
        }
        [HttpGet]
        public async Task<IActionResult> BuscarTodos()
        {
            var result = await _alunoService.GetAllAsync();
            return Ok(result);
        }
    }
}
