

using Idiomas.CRUD.Application.Dtos;
using Idiomas.CRUD.Application.ViewModel;
using Idiomas.CRUD.Domain;
using Idiomas.CRUD.Domain.CursoIdiomas;
using Idiomas.CRUD.Domain.CursoIdiomas.ValueObject;

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

            //CreateMap<Aluno, AlunoViewModel>();

            //CreateMap<AlunoViewModel, Aluno>();
            CreateMap<Aluno, AlunoViewModel>()
           // Para mapear o valor do e-mail
           .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Valor))
           // Para mapear o valor do CPF
           .ForMember(dest => dest.Cpf, opt => opt.MapFrom(src => src.Cpf.Numero));

            CreateMap<AlunoViewModel, Aluno>()
                // Você pode adicionar outras configurações aqui, se necessário
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => new Email(src.Email)))
                .ForMember(dest => dest.Cpf, opt => opt.MapFrom(src => new Cpf(src.Cpf)));

           
        }

    }
}
