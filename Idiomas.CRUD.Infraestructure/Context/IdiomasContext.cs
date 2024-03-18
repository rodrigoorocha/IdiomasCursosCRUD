using Idiomas.CRUD.Domain;
using Idiomas.CRUD.Domain.CursoIdiomas;
using Microsoft.EntityFrameworkCore;

namespace Idiomas.CRUD.Infraestructure.Context
{
    public class IdiomasContext : DbContext 
    {

        public IdiomasContext(DbContextOptions<IdiomasContext> options) : base(options)
        {

        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdiomasContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
