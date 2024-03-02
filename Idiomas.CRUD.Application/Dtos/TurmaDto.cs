using System.Text.Json.Serialization;

namespace Idiomas.CRUD.Application.Dtos
{
    public class TurmaDto
    {
        public int? Id { get; set; }
        public string Numero { get; set; }
        public int AnoLetivo { get; set; }
        [JsonIgnore]
        public ICollection<MatriculaDto> Matriculas { get; set; } = new List<MatriculaDto>();

    }
}
