using Idiomas.CRUD.Domain.CursoIdiomas.Repository;
using Idiomas.CRUD.Domain.CursoIdiomas;
using Idiomas.CRUD.Infraestructure.DataBase;
using Idiomas.CRUD.Domain;
using Idiomas.CRUD.Infraestructure.Context;

namespace Idiomas.CRUD.Infraestructure.Repository
{
    public class MatriculaRepository : Repository<Matricula>, IMatriculaRepository
    {
        public MatriculaRepository(IdiomasContext context) : base(context)
        {
        }


    }
}
