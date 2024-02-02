using Idiomas.CRUD.Domain.CursoIdiomas;
using Idiomas.CRUD.Domain.CursoIdiomas.Repository;
using Idiomas.CRUD.Infraestructure.Context;
using Idiomas.CRUD.Infraestructure.DataBase;


namespace Idiomas.CRUD.Infraestructure.Repository
{
    public class AlunoRepository : Repository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(IdiomasContext context) : base(context)
        {
        }
    }
}
