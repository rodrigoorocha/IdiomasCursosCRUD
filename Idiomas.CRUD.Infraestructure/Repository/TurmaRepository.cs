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
        
      
    }
}
