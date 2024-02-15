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
        public async Task<IActionResult> BuscarTodos()
        {
            var result = await _alunoService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById([FromQuery] Guid id)
        {
            var aluno = await _alunoService.GetByIdAsync(id);       
            return Ok(aluno);
        }

        [HttpDelete("Deletar")]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            var aluno = await _alunoService.Delete(id);
            return Ok(aluno);
        }
        [HttpPut("Atualizar")]
        public async Task<IActionResult> Update([FromQuery] Guid id, AlunoDto alunoDto)
        {
            var aluno = await _alunoService.Update(id, alunoDto);
            return Ok(aluno);
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Create([FromBody] AlunoDto alunoDto)
        {
           
            var aluno = await _alunoService.Create(alunoDto);
            return Ok(aluno);
        }
    }
}
