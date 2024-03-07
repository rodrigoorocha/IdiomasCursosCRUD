using System.Text.Json.Serialization;

namespace Idiomas.CRUD.Application.Dtos
{
    public class TurmaDto
    {
       
        public int? TurmaId { get; set; }
        public int? Numero { get; set; }
    
        public int? AnoLetivo { get; set; }
        [JsonIgnore]
        public virtual ICollection<TurmaDto> Turmas { get; set; } = new List<TurmaDto>();
        [JsonIgnore]
        public virtual ICollection<MatriculaDto> MatriculasDto { get; set; } = new List<MatriculaDto>();
    }
}
