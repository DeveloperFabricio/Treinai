using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Treinaí.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Documento = table.Column<string>(type: "NVARCHAR(11)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Celular = table.Column<string>(type: "NVARCHAR(11)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tipos de Exercícios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(60)", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipos de Exercícios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exercicios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoDeExercicioId = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercicios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercicios_Tipos de Exercícios_TipoDeExercicioId",
                        column: x => x.TipoDeExercicioId,
                        principalTable: "Tipos de Exercícios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Documento = table.Column<string>(type: "NVARCHAR(11)", nullable: false),
                    Cref = table.Column<string>(type: "NVARCHAR(8)", nullable: false),
                    Celular = table.Column<string>(type: "NVARCHAR(11)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlanoDeTreinoId = table.Column<int>(type: "int", nullable: false),
                    TipoDeExercicioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Professores_Tipos de Exercícios_TipoDeExercicioId",
                        column: x => x.TipoDeExercicioId,
                        principalTable: "Tipos de Exercícios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Planos de Treinos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Observacao = table.Column<string>(type: "VARCHAR(500)", nullable: true),
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    ProfessorId = table.Column<int>(type: "int", nullable: false),
                    HoraTreino = table.Column<TimeSpan>(type: "time", nullable: false),
                    DataTreino = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planos de Treinos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Planos de Treinos_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Planos de Treinos_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9d0fdc6d-bfd2-4d6f-b5a7-f1c3e8d3f029", null, "Professor", "PROFESSOR" },
                    { "c55cb730-961c-4b88-bc64-c1f5a93b69e4", null, "Aluno", "ALUNO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a1b2c3d4-e5f6-7g8h-9i0j-k1l2m3n4o5p6", 0, "4e28ce5f-6c20-4eee-ac64-e72603a62920", "professor.joao@exemplo.com", true, false, null, "Professor João", "PROFESSOR.JOAO@EXEMPLO.COM", "PROFESSOR.JOAO@EXEMPLO.COM", "AQAAAAIAAYagAAAAEFXyai/aaJ7sernMOQStpC4DD8rclTp8/cqUJQx4B5NVi02s7OL0gUPQUBhPDx1QLg==", null, false, "2f5a55c8-6d7a-4eb3-a3b4-ee5f48edb667", false, "professor.joao@exemplo.com" },
                    { "z1x2c3v4-b5n6-m7a8-s9d0-f1g2h3j4k5l6", 0, "2cf76687-7659-4de4-9838-8fed7d93fd9e", "aluno.maria@exemplo.com", true, false, null, "Aluno Maria", "ALUNO.MARIA@EXEMPLO.COM", "ALUNO.MARIA@EXEMPLO.COM", "AQAAAAIAAYagAAAAEEhqgzkSjf4NWdCY8Rk1bnVT43lJIezus7CjHXdifUXUWjaUaEIKica4oIxAHu+6Gw==", null, false, "eb0870d1-617a-4da8-bc6f-d1c2acda5144", false, "aluno.maria@exemplo.com" }
                });

            migrationBuilder.InsertData(
                table: "Tipos de Exercícios",
                columns: new[] { "Id", "Descricao", "Nome" },
                values: new object[,]
                {
                    { 1, "Exercícios de força utilizando pesos e aparelhos de musculação.", "Musculação" },
                    { 2, "Treinamento de alta intensidade que combina levantamento de peso, exercícios cardiovasculares e ginástica.", "Crossfit" },
                    { 3, "Exercício cardiovascular que envolve correr distâncias variadas em diferentes ritmos.", "Corrida" },
                    { 4, "Exercício aeróbico realizado na água, que trabalha todo o corpo.", "Natação" },
                    { 5, "Exercício cardiovascular realizado com o uso de uma bicicleta, pode ser feito ao ar livre ou em bicicletas ergométricas.", "Bicicleta" },
                    { 6, "Competição multidisciplinar que inclui natação, ciclismo e corrida.", "Triathlon" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "9d0fdc6d-bfd2-4d6f-b5a7-f1c3e8d3f029", "a1b2c3d4-e5f6-7g8h-9i0j-k1l2m3n4o5p6" },
                    { "c55cb730-961c-4b88-bc64-c1f5a93b69e4", "z1x2c3v4-b5n6-m7a8-s9d0-f1g2h3j4k5l6" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_Documento",
                table: "Alunos",
                column: "Documento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exercicios_TipoDeExercicioId",
                table: "Exercicios",
                column: "TipoDeExercicioId");

            migrationBuilder.CreateIndex(
                name: "IX_Planos de Treinos_AlunoId",
                table: "Planos de Treinos",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Planos de Treinos_ProfessorId",
                table: "Planos de Treinos",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Professores_Documento",
                table: "Professores",
                column: "Documento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Professores_TipoDeExercicioId",
                table: "Professores",
                column: "TipoDeExercicioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercicios");

            migrationBuilder.DropTable(
                name: "Planos de Treinos");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Professores");

            migrationBuilder.DropTable(
                name: "Tipos de Exercícios");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9d0fdc6d-bfd2-4d6f-b5a7-f1c3e8d3f029", "a1b2c3d4-e5f6-7g8h-9i0j-k1l2m3n4o5p6" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c55cb730-961c-4b88-bc64-c1f5a93b69e4", "z1x2c3v4-b5n6-m7a8-s9d0-f1g2h3j4k5l6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d0fdc6d-bfd2-4d6f-b5a7-f1c3e8d3f029");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c55cb730-961c-4b88-bc64-c1f5a93b69e4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1b2c3d4-e5f6-7g8h-9i0j-k1l2m3n4o5p6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "z1x2c3v4-b5n6-m7a8-s9d0-f1g2h3j4k5l6");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "AspNetUsers");
        }
    }
}
