using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Treinaí.Models;

namespace Treinaí.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<TipoDeExercicio> TiposDeExercicio { get; set; }
        public DbSet<Exercicio> Exercicios { get; set; }
        public DbSet<PlanoDeTreino> PlanosDeTreino { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());  

            new DbInitializer(modelBuilder).Seed();

            base.OnModelCreating(modelBuilder);

           
        }
    }
}
