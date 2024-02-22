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
        public  async Task<IActionResult> BuscaTurmas() {
            
            var turma = await _turmaServices.GetAllAsync();
            return Ok(turma);
        }

        [HttpPost("criarTurma")]
        public async Task<IActionResult> CriarTurma([FromBody] TurmaDto turmaDto)
        {
            var turmaCriada = await _turmaServices.Create(turmaDto);
            return Ok(turmaCriada);
        }

        [HttpGet("buscarTurmaPorId")]
        public async Task<IActionResult> BuscarTurmaPorId([FromQuery] Guid id)
        {
            var turma = await _turmaServices.GetByIdAsync(id);
           
            return Ok(turma);
        }

        [HttpPut("atualizarTurma")]
        public async Task<IActionResult> AtualizarTurma([FromBody] Guid id,  TurmaDto turmaDto)
        {
            var turmaAtualizada = await _turmaServices.Update(id, turmaDto);
           
            return Ok(turmaAtualizada);
        }

        [HttpDelete("deletarTurma")]
        public async Task<IActionResult> DeletarTurma([FromBody] Guid id)
        {
            var turmaDeletada = await _turmaServices.Delete(id);
           
            return Ok(turmaDeletada);
        }





    }
}
