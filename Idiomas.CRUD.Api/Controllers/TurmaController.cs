using Idiomas.CRUD.Application.Dtos;
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
        public async Task<IActionResult> BuscaTurmas()
        {

            var turma = await _turmaServices.GetAllAsync();
            return Ok(turma);
        }

        [HttpPost("criarTurma")]
        public async Task<IActionResult> CriarTurma([FromBody] TurmaDto turmaDto)
        {
            var turmaCriada = await _turmaServices.CreateAsync(turmaDto);
            return Ok(turmaCriada);
        }               

        [HttpPut("atualizar")]
        public async Task<IActionResult> AtualizarTurma([FromBody] TurmaDto turmaDTO)
        {
            var turmaAtualizada = await _turmaServices.UpdateAsync(turmaDTO);

            return Ok(turmaAtualizada);
        }

        [HttpDelete("deletarturma")]
        public async Task<IActionResult> DeletarTurma([FromBody] int id)
        {
            var turmaDeletada = await _turmaServices.DeleteAsync(id);

            return Ok(turmaDeletada);
        }





    }
}
