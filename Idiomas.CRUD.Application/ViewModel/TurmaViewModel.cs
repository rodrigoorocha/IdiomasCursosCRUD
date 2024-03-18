using Idiomas.CRUD.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Idiomas.CRUD.Application.ViewModel
{
    public class TurmaViewModel
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
