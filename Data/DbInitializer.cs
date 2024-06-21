using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Treinaí.Models;

namespace Treinaí.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder _modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        internal void Seed()
        {
            
            _modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "9d0fdc6d-bfd2-4d6f-b5a7-f1c3e8d3f029",
                    Name = "Gestor",
                    NormalizedName = "GESTOR"
                },
                new IdentityRole
                {
                    Id = "c55cb730-961c-4b88-bc64-c1f5a93b69e4",
                    Name = "Professor",
                    NormalizedName = "PROFESSOR"
                }
            );

            var hasher = new PasswordHasher<IdentityUser>();

            
            _modelBuilder.Entity<Gestor>().HasData(

                new Gestor
                {
                    Id = "a1b2c3d4-e5f6-7g8h-9i0j-k1l2m3n4o5p6",
                    Nome = "TreinaÍ",
                    Email = "treinai@exemplo.com",
                    EmailConfirmed = true,
                    UserName = "treinai@exemplo.com",
                    NormalizedEmail = "TREINAI@EXEMPLO.COM",
                    NormalizedUserName = "TREINAI@EXEMPLO.COM",
                    PasswordHash = hasher.HashPassword(null, "ProfSenha123"),
                   
                }
            );

           
            _modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "9d0fdc6d-bfd2-4d6f-b5a7-f1c3e8d3f029",
                    UserId = "a1b2c3d4-e5f6-7g8h-9i0j-k1l2m3n4o5p6"
                }
               
            );

            _modelBuilder.Entity<TipoDeExercicio>().HasData(
                 new TipoDeExercicio { Id = 1, Nome = "Musculação", Descricao = "Exercícios de força utilizando pesos e aparelhos de musculação." },
                 new TipoDeExercicio { Id = 2, Nome = "Crossfit", Descricao = "Treinamento de alta intensidade que combina levantamento de peso, exercícios cardiovasculares e ginástica." },
                 new TipoDeExercicio { Id = 3, Nome = "Corrida", Descricao = "Exercício cardiovascular que envolve correr distâncias variadas em diferentes ritmos." },
                 new TipoDeExercicio { Id = 4, Nome = "Natação", Descricao = "Exercício aeróbico realizado na água, que trabalha todo o corpo." },
                 new TipoDeExercicio { Id = 5, Nome = "Bicicleta", Descricao = "Exercício cardiovascular realizado com o uso de uma bicicleta, pode ser feito ao ar livre ou em bicicletas ergométricas." },
                 new TipoDeExercicio { Id = 6, Nome = "Triathlon", Descricao = "Competição multidisciplinar que inclui natação, ciclismo e corrida." }

             );



        }
    }

}
