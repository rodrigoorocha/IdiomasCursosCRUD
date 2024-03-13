using System.Text.Json.Serialization;

namespace Idiomas.CRUD.Application.Dtos
{
    public class MatriculaDto
    {
        public int? MatriculaId { get; set; }
        public int? AlunoId { get; set; }
        public int? TurmaId { get; set; }
        public virtual AlunoDto Aluno { get; set; }    
        public virtual TurmaDto Turma { get; set; }
    }
}
