using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Treinaí.Models;

namespace Treinaí.Data.Configurations
{
    public class AlunoConfiguration : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("Alunos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("VARCHAR(50)");

            builder.Property(x => x.Documento)
                .IsRequired()
                .HasColumnType("NVARCHAR(11)");

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnType("VARCHAR(50)");

            builder.Property(x => x.Celular)
                .IsRequired()
                .HasColumnType("NVARCHAR(11)");

            builder.HasIndex(x => x.Documento)
                .IsUnique();

            builder.HasMany(a => a.Planos)
                .WithOne(p => p.Aluno)
                .HasForeignKey(a => a.AlunoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
