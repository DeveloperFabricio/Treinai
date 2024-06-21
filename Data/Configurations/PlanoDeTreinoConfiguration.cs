using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Treinaí.Models;

namespace Treinaí.Data.Configurations
{
    public class PlanoDeTreinoConfiguration : IEntityTypeConfiguration<PlanoDeTreino>
    {
        public void Configure(EntityTypeBuilder<PlanoDeTreino> builder)
        {
            builder.ToTable("PlanosdeTreinos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Observacao)
                .IsRequired(false)
                .HasColumnType("VARCHAR(500)");

            builder.Property(x => x.AlunoId)
                .IsRequired();

            builder.Property(x => x.ProfessorId)
               .IsRequired();
        }
    }
}
