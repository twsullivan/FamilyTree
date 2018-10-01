using Microsoft.EntityFrameworkCore.Migrations;

namespace FamilyTree.Migrations
{
    public partial class ParentCHildtoPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonId1",
                table: "People",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_PersonId1",
                table: "People",
                column: "PersonId1");

            migrationBuilder.AddForeignKey(
                name: "FK_People_People_PersonId1",
                table: "People",
                column: "PersonId1",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_People_PersonId1",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_PersonId1",
                table: "People");

            migrationBuilder.DropColumn(
                name: "PersonId1",
                table: "People");
        }
    }
}
