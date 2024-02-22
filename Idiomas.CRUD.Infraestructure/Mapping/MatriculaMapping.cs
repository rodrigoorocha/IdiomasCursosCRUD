using Idiomas.CRUD.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idiomas.CRUD.Infraestructure.Mapping
{
    public class MatriculaMapping : IEntityTypeConfiguration<Matricula>
    {
        public void Configure(EntityTypeBuilder<Matricula> builder)
        {
            builder.ToTable("Matriculas");
            builder.HasKey(a => a.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(m => m.Aluno)
                   .WithMany(a => a.Matriculas)
                   .HasForeignKey(m => m.AlunoId);

            builder.HasOne(m => m.Turma)
                   .WithMany(t => t.Matriculas)
                   .HasForeignKey(m => m.TurmaId);
        }
    }
}
