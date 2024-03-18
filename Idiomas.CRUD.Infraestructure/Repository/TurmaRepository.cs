using Idiomas.CRUD.Domain.CursoIdiomas.Repository;
using Idiomas.CRUD.Domain.CursoIdiomas;
using Idiomas.CRUD.Infraestructure.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Idiomas.CRUD.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Idiomas.CRUD.Infraestructure.Repository
{
    public class TurmaRepository : Repository<Turma>, ITurmaRepository
    {

        public TurmaRepository(IdiomasContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Turma>> GetAllTurmaWithAlunos()
        {
            var query = await this.Query
               .Include(x => x.Matricula)
               .ToListAsync();

            return query;
        }

        public async Task<Turma> GetTurmaById(int id)
        {
            var query = await this.Query.FirstOrDefaultAsync(x => x.Id.Equals(id));
            return query;
        }

        public async Task<Turma> GetTurmaById(int? id)
        {
            var query = await this.Query.FirstOrDefaultAsync(x => x.Id.Equals(id));
            return query;
        }
    }
}
