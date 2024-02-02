using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idiomas.CRUD.Domain.Base
{
    public class Entity<T>
    {
        public virtual T Id { get; set; }
        //public Guid Id { get; protected set; }

        

    }
}
