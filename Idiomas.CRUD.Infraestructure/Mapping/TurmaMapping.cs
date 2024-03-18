 using Idiomas.CRUD.Domain.CursoIdiomas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Idiomas.CRUD.Infraestructure.Mapping
{
    public class TurmaMapping : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            builder.ToTable("Turmas");
            builder.HasKey(a => a.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.AnoLetivo).IsRequired();


            builder.HasMany(x => x.Alunos)
                 .WithMany(x => x.Turmas);
                
        }
    }
}
