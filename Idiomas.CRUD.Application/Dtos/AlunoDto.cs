using Idiomas.CRUD.Domain.CursoIdiomas.ValueObject;
using System.Text.Json.Serialization;

namespace Idiomas.CRUD.Application.Dtos
{
    public class AlunoDto
    {
        [JsonIgnore]
        public int? Id { get; set; } = null;
        public string Nome { get; set; }
        public Cpf Cpf { get; set; }
        public Email Email { get; set; }
        public virtual ICollection<TurmaDto>? TurmasDto { get; set; } = new List<TurmaDto>(); 
        //public List<int> TurmaIds { get; set; }   

    }
}
