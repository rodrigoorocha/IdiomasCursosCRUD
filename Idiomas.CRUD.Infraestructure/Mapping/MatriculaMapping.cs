using Idiomas.CRUD.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Idiomas.CRUD.Infraestructure.Mapping
{
    public class MatriculaMapping : IEntityTypeConfiguration<Matricula>
    {
        public void Configure(EntityTypeBuilder<Matricula> builder)
        {
            builder.ToTable("Matriculas");
            builder.HasKey(a => a.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

;           builder.HasOne(x => x.Aluno);
            builder.HasOne(x => x.Turma);


        }
    }
}
