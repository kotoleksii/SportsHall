using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsHall.Migrations
{
    public partial class Training : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "UserTokens",
                schema: "Identity",
                newName: "UserTokens");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                schema: "Identity",
                newName: "UserRoles");

            migrationBuilder.RenameTable(
                name: "UserLogins",
                schema: "Identity",
                newName: "UserLogins");

            migrationBuilder.RenameTable(
                name: "UserClaims",
                schema: "Identity",
                newName: "UserClaims");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "Identity",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "RoleClaims",
                schema: "Identity",
                newName: "RoleClaims");

            migrationBuilder.RenameTable(
                name: "Role",
                schema: "Identity",
                newName: "Role");

            migrationBuilder.AddColumn<string>(
                name: "DateOfBirth",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Specialization",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkTime",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Halls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Halls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Coach = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Halls");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Specialization",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "User");

            migrationBuilder.DropColumn(
                name: "WorkTime",
                table: "User");

            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.RenameTable(
                name: "UserTokens",
                newName: "UserTokens",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                newName: "UserRoles",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "UserLogins",
                newName: "UserLogins",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "UserClaims",
                newName: "UserClaims",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "User",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "RoleClaims",
                newName: "RoleClaims",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Role",
                newSchema: "Identity");
        }
    }
}
