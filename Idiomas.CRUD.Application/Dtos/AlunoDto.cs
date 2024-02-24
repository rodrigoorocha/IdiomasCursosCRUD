using Idiomas.CRUD.Domain.CursoIdiomas.ValueObject;
using System.Text.Json.Serialization;

namespace Idiomas.CRUD.Application.Dtos
{
    public class AlunoDto
    {        
        public string Nome { get; set; }
        public Cpf Cpf { get; set; }
        public Email Email { get; set; }
        public int? TurmaId { get; set; }
        [JsonIgnore]
        public ICollection<MatriculaDto>? Matriculas { get; set; } = new List<MatriculaDto>();

    }
}
