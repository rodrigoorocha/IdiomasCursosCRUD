using Idiomas.CRUD.Domain.CursoIdiomas;
using Idiomas.CRUD.Domain.CursoIdiomas.ValueObject;

namespace Idiomas.CRUD.Application.Dtos
{
    public class AlunoDto
    {
     
        public string Nome { get; set; }
        public Cpf Cpf { get; set; }
        public Email Email { get; set; }

        public Guid TurmaId { get; set; }
        

    }
}
