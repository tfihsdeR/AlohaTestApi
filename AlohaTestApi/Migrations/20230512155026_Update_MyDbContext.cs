using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlohaTestApi.Migrations
{
    public partial class Update_MyDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Univercity_Cities_CityId",
                table: "Univercity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Univercity",
                table: "Univercity");

            migrationBuilder.RenameTable(
                name: "Univercity",
                newName: "Univercities");

            migrationBuilder.RenameIndex(
                name: "IX_Univercity_CityId",
                table: "Univercities",
                newName: "IX_Univercities_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Univercities",
                table: "Univercities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Univercities_Cities_CityId",
                table: "Univercities",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Univercities_Cities_CityId",
                table: "Univercities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Univercities",
                table: "Univercities");

            migrationBuilder.RenameTable(
                name: "Univercities",
                newName: "Univercity");

            migrationBuilder.RenameIndex(
                name: "IX_Univercities_CityId",
                table: "Univercity",
                newName: "IX_Univercity_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Univercity",
                table: "Univercity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Univercity_Cities_CityId",
                table: "Univercity",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
