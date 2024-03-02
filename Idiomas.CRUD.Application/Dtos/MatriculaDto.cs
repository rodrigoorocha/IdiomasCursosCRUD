
namespace Idiomas.CRUD.Application.Dtos
{
    public class MatriculaDto
    {
        public int? AlunoId { get; set; }
        public int? TurmaId { get; set; }
        public AlunoDto AlunoDto { get; set; }
        public TurmaDto TurmaDto { get; set; }
    }
}
