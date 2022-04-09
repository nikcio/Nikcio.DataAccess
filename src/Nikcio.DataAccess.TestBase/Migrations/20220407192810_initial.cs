using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nikcio.DataAccess.TestBase.Migrations {
    public partial class initial : Migration {
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.CreateTable(
                name: "TEST_Addresses",
                columns: table => new {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_TEST_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TEST_Houses",
                columns: table => new {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Windows = table.Column<int>(type: "int", nullable: false),
                    Doors = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_TEST_Houses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TEST_Houses_TEST_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "TEST_Addresses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TEST_Houses_AddressId",
                table: "TEST_Houses",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropTable(
                name: "TEST_Houses");

            migrationBuilder.DropTable(
                name: "TEST_Addresses");
        }
    }
}
