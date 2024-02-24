using Idiomas.CRUD.Application.Dtos;
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
        public async Task<IActionResult> GetAll()
        {
            var result = await _alunoService.GetAllAsync();
            return Ok(result);
        }
              
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromQuery] AlunoInputDto alunoInputDto)
        {           
            var aluno = await _alunoService.CreateAsync(alunoInputDto);
            return Ok(aluno);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] AlunoDto alunoDto)
        {
            var aluno = await _alunoService.UpdateAsync(alunoDto);
            return Ok(aluno);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {         

            var message = _alunoService.DeleteAsync(id);
            return Ok(message);
        }
    }
}
