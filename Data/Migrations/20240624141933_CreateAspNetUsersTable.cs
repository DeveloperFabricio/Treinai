using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Treinaí.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateAspNetUsersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1b2c3d4-e5f6-7g8h-9i0j-k1l2m3n4o5p6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "988f85e2-b131-4e5a-8d02-0cb99190cfa4", "AQAAAAIAAYagAAAAELyQ3tMa8uEKYsfa5J3ATZ5Ek1J047rpntw8ibTLfT3r6oizvL1ccQZURb5T/Fk4jg==", "d009a8b4-9f8c-4c4c-bc7e-9170a6932aad" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1b2c3d4-e5f6-7g8h-9i0j-k1l2m3n4o5p6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6af485b5-a5c8-4203-a25d-e010cee109db", "AQAAAAIAAYagAAAAEJba+5cB0jKEIT/yReySqBdiJO4s6oqnB/DAPcnsh5+1gzXBRWnXq7MgZCV6dD50TA==", "0c8cf28f-a1fe-4327-b3ab-b4bb3d9756b2" });
        }
    }
}
