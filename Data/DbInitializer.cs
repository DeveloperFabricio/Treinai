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
            // Definindo os roles Professor e Aluno
            _modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "9d0fdc6d-bfd2-4d6f-b5a7-f1c3e8d3f029",
                    Name = "Professor",
                    NormalizedName = "PROFESSOR"
                },
                new IdentityRole
                {
                    Id = "c55cb730-961c-4b88-bc64-c1f5a93b69e4",
                    Name = "Aluno",
                    NormalizedName = "ALUNO"
                }
            );

            var hasher = new PasswordHasher<ApplicationUser>();

            // Criando um professor
            _modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "a1b2c3d4-e5f6-7g8h-9i0j-k1l2m3n4o5p6",
                    Nome = "Professor João",
                    Email = "professor.joao@exemplo.com",
                    EmailConfirmed = true,
                    UserName = "professor.joao@exemplo.com",
                    NormalizedEmail = "PROFESSOR.JOAO@EXEMPLO.COM",
                    NormalizedUserName = "PROFESSOR.JOAO@EXEMPLO.COM",
                    PasswordHash = hasher.HashPassword(null, "ProfSenha123"),
                   
                }
            );

            // Criando um aluno
            _modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "z1x2c3v4-b5n6-m7a8-s9d0-f1g2h3j4k5l6",
                    Nome = "Aluno Maria",
                    Email = "aluno.maria@exemplo.com",
                    EmailConfirmed = true,
                    UserName = "aluno.maria@exemplo.com",
                    NormalizedEmail = "ALUNO.MARIA@EXEMPLO.COM",
                    NormalizedUserName = "ALUNO.MARIA@EXEMPLO.COM",
                    PasswordHash = hasher.HashPassword(null, "AlunoSenha123"),
                   
                }
            );

            // Associando os usuários aos seus roles
            _modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "9d0fdc6d-bfd2-4d6f-b5a7-f1c3e8d3f029",
                    UserId = "a1b2c3d4-e5f6-7g8h-9i0j-k1l2m3n4o5p6"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "c55cb730-961c-4b88-bc64-c1f5a93b69e4",
                    UserId = "z1x2c3v4-b5n6-m7a8-s9d0-f1g2h3j4k5l6"
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
