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
        [HttpGet("GetAlunoByCpf")]
        public async Task<IActionResult> GetAlunoByCpf(string cpf)
        {
            var result = await _alunoService.GetAlunoWithTurmaMatricula(cpf);
            return Ok(result);
        }


        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] AlunoDto alunoCreateDto)
        {           
            var aluno = await _alunoService.CreateAsync(alunoCreateDto);
            return Ok(aluno);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id, AlunoDto alunoDto)
        {
            alunoDto.Id = id;
            var aluno = await _alunoService.UpdateAsync(alunoDto);
            return Ok(aluno);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {         

            var message = await _alunoService.DeleteAsync(id);
            return Ok(message);
        }
    }
}
