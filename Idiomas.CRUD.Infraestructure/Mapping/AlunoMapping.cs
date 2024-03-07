using Idiomas.CRUD.Domain.CursoIdiomas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Idiomas.CRUD.Infraestructure.Mapping
{
    public class AlunoMapping : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {

            builder.ToTable("Alunos");
            builder.HasKey(a => a.AlunoId);
            builder.Property(x => x.AlunoId).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(200);

            builder.OwnsOne(x => x.Cpf, p =>
            {
                p.Property(f => f.Numero);
            }).Navigation(x => x.Cpf);

            builder.OwnsOne(x => x.Email, p =>
            {
                p.Property(f => f.Valor).HasColumnName("Email").IsRequired().HasMaxLength(1024);
            });

            builder.HasMany(x => x.Turmas).WithMany(x=>x.Alunos);

            
        }
    }
}
