using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Treinaí.Models;

namespace Treinaí.Data.Configurations
{
    public class TipoDeExercicioConfiguration : IEntityTypeConfiguration<TipoDeExercicio>
    {
        public void Configure(EntityTypeBuilder<TipoDeExercicio> builder)
        {
            builder.ToTable("TiposdeExercícios");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nome)
                .IsRequired(true)
                .HasColumnType("VARCHAR(60)");

            builder.Property(e => e.Descricao)
                .IsRequired(false)
                .HasColumnType("VARCHAR(500)");

            builder.HasMany(e => e.Professores)
                .WithOne(e => e.TipoDeExercicio)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
