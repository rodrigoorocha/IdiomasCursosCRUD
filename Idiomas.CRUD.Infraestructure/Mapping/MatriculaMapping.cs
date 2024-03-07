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
            builder.HasKey(a => a.MatriculaId);
            builder.Property(x => x.MatriculaId).ValueGeneratedOnAdd();

;           
                  
        }
    }
}
