using Idiomas.CRUD.Domain.Base;
using Idiomas.CRUD.Domain.CursoIdiomas.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idiomas.CRUD.Domain.CursoIdiomas
{
    public class Aluno: Entity<Guid>
    {
        public Aluno(string nome, Cpf cpf, Email email)
        {
            Nome = nome;
            Cpf = cpf;
            Email = email;
        }

        protected Aluno() { }

        

        public string Nome { get; set; }
        public Cpf Cpf { get; set; }   
        public Email Email { get; set; }

        public Guid TurmaId { get; set; }
        public Turma Turma { get; set; }

        public void Update(string nome, Cpf cpf, Email email)
        {
            Email = email;
            Nome = nome;
            Cpf = cpf;
            
        }
    }
}
