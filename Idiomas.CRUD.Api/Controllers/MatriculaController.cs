using Idiomas.CRUD.Application.Dtos;
using Idiomas.CRUD.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Idiomas.CRUD.Api.Controllers
{
    public class MatriculaController : ControllerBase
    {
        private readonly IMatriculaService _matriculaService; 
        
        public MatriculaController(IMatriculaService matriculaService)
        {
            _matriculaService = matriculaService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _matriculaService.GetAllAsync();
            return Ok(result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromQuery] MatriculaDto matriculaDto)
        {
            var aluno = await _matriculaService.CreateAsync(matriculaDto);
            return Ok(aluno);
        }

   

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {

            var message = _matriculaService.DeleteAsync(id);
            return Ok(message);
        }
    }
}
