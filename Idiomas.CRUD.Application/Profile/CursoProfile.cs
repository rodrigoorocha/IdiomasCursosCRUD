﻿

using Idiomas.CRUD.Application.Dtos;
using Idiomas.CRUD.Domain;
using Idiomas.CRUD.Domain.CursoIdiomas;

namespace Idiomas.CRUD.Application.Profile
{
    public class CursoProfile : AutoMapper.Profile
    {
        public CursoProfile()
        {
            CreateMap<AlunoInputDto, Aluno>();

            CreateMap<Aluno, AlunoDto>();
            CreateMap<AlunoDto, Aluno>();
            CreateMap<Turma, TurmaDto>();
            CreateMap<TurmaDto, Turma>();
            CreateMap<Matricula, MatriculaDto>();
            CreateMap<MatriculaDto, Matricula>();

            
            
        }

    }
}
