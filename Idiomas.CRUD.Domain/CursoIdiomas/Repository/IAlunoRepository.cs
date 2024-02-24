﻿using Idiomas.CRUD.Domain.Base;
using Idiomas.CRUD.Domain.CursoIdiomas.ValueObject;
using System.Threading.Tasks;

namespace Idiomas.CRUD.Domain.CursoIdiomas.Repository
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        
        
        Task<Aluno> GetAlunoByCPF(string cpf);
        Task<Aluno> GetAlunoWithTurmaMatricula(string cpf);
        Task<IEnumerable<Aluno>> GetAllAlunoWithTurmaMatricula();




    }
}
