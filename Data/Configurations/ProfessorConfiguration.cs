using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Treinaí.Models;

namespace Treinaí.Data.Configurations
{
    public class ProfessorConfiguration : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.ToTable("Professores");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("VARCHAR(50)");

            builder.Property(x => x.Documento)
                .IsRequired()
                .HasColumnType("NVARCHAR(11)");

            builder.Property(x => x.Cref)
                .IsRequired()
                .HasColumnType("NVARCHAR(8)");

            builder.Property(x => x.Celular)
                .IsRequired()
                .HasColumnType("NVARCHAR(11)");

            builder.Property(x => x.PlanoDeTreinoId)
                .IsRequired(true);

            builder.HasIndex(x => x.Documento)
                .IsUnique();

            builder.HasMany(a => a.Planos)
                .WithOne(m => m.Professor)
                .HasForeignKey(a => a.ProfessorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
