using Idiomas.CRUD.Domain.Base;
using Idiomas.CRUD.Domain.CursoIdiomas.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idiomas.CRUD.Domain.CursoIdiomas
{
    public class Aluno: Entity<int>
    {     

        protected Aluno() { }
        public string Nome { get; set; }
        public Cpf Cpf { get; set; }
        public Email Email { get; set; }
        public List<Matricula> Matriculas { get; set; } = new List<Matricula>();

        public void Update(string nome, Cpf cpf, Email email)
        {
            Email = email;
            Nome = nome;
            Cpf = cpf;
            
        }

       
    }
}
