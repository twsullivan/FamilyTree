using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FamilyTree.Migrations
{
    public partial class AddedParentChildren : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentChildrenParentId",
                table: "People",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ParentChildren",
                columns: table => new
                {
                    ParentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChildId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentChildren", x => x.ParentId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_People_ParentChildrenParentId",
                table: "People",
                column: "ParentChildrenParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_ParentChildren_ParentChildrenParentId",
                table: "People",
                column: "ParentChildrenParentId",
                principalTable: "ParentChildren",
                principalColumn: "ParentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_ParentChildren_ParentChildrenParentId",
                table: "People");

            migrationBuilder.DropTable(
                name: "ParentChildren");

            migrationBuilder.DropIndex(
                name: "IX_People_ParentChildrenParentId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "ParentChildrenParentId",
                table: "People");
        }
    }
}
