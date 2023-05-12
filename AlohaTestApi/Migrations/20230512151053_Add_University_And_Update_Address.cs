using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlohaTestApi.Migrations
{
    public partial class Add_University_And_Update_Address : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Cities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Univercity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Univercity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Univercity_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_AddressId",
                table: "Cities",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Univercity_CityId",
                table: "Univercity",
                column: "CityId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Addresses_AddressId",
                table: "Cities",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Addresses_AddressId",
                table: "Cities");

            migrationBuilder.DropTable(
                name: "Univercity");

            migrationBuilder.DropIndex(
                name: "IX_Cities_AddressId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Addresses");
        }
    }
}
