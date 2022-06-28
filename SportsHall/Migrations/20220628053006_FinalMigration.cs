using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsHall.Migrations
{
    public partial class FinalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Trainings",
                newName: "TrainingId");

            migrationBuilder.AddColumn<string>(
                name: "ClientId",
                table: "Trainings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_ClientId",
                table: "Trainings",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_User_ClientId",
                table: "Trainings",
                column: "ClientId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_User_ClientId",
                table: "Trainings");

            migrationBuilder.DropIndex(
                name: "IX_Trainings_ClientId",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Trainings");

            migrationBuilder.RenameColumn(
                name: "TrainingId",
                table: "Trainings",
                newName: "Id");
        }
    }
}
