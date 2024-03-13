

using Idiomas.CRUD.Application.Dtos;
using Idiomas.CRUD.Domain;
using Idiomas.CRUD.Domain.CursoIdiomas;

namespace Idiomas.CRUD.Application.Profile
{
    public class CursoProfile : AutoMapper.Profile
    {
        public CursoProfile()
        {
            CreateMap<AlunoCreateDto, Aluno>();

            CreateMap<MatriculaInputDto, Matricula>();
            CreateMap<Matricula, MatriculaInputDto>();

            CreateMap<Aluno, AlunoDto>()
                .ForMember(dest => dest.TurmasDto, opt => opt.MapFrom(src => src.Turmas));

            CreateMap<AlunoDto, Aluno>()
                .ForMember(dest => dest.Turmas, opt => opt.Ignore());

            CreateMap<Turma, TurmaDto>();
            CreateMap<TurmaDto, Turma>();
            CreateMap<Matricula, MatriculaDto>();
                //.ForMember(dest => dest.Turma, opt => opt.Ignore());
            CreateMap<MatriculaDto, Matricula>();



        }

    }
}
