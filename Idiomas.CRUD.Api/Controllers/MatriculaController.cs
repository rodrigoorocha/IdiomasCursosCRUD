using Idiomas.CRUD.Application.Dtos;
using Idiomas.CRUD.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Idiomas.CRUD.Api.Controllers
{
    [Route("api/Controller")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        private readonly IMatriculaService _matriculaService; 
        
        public MatriculaController(IMatriculaService matriculaService)
        {
            _matriculaService = matriculaService;
        }
        [HttpGet("Buscar Matricula")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _matriculaService.GetAllAsync();
            return Ok(result);
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Create([FromBody] MatriculaInputDto matriculaInputDto)
        {
                        
            var matricula = await _matriculaService.CriarMatriculaAsync(matriculaInputDto);
            return Ok(matricula);
        }

   

        [HttpDelete("Deletar")]
        public async Task<IActionResult> Delete(int id)
        {

            var message = await _matriculaService.DeleteAsync(id);
            return Ok(message);
        }
    }
}
