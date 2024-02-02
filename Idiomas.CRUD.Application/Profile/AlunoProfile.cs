

using Idiomas.CRUD.Application.Dtos;
using Idiomas.CRUD.Domain.CursoIdiomas;

namespace Idiomas.CRUD.Application.Profile
{
    public class AlunoProfile : AutoMapper.Profile
    {
        public AlunoProfile()
        {
            CreateMap<Aluno, AlunoDto>();
            CreateMap<AlunoDto, Aluno>();
        }

    }
}
