using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmazonLite.Migrations
{
    /// <inheritdoc />
    public partial class Amazonmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BrandLists",
                columns: table => new
                {
                    BrandID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandLists", x => x.BrandID);
                });

            migrationBuilder.CreateTable(
                name: "ProdLists",
                columns: table => new
                {
                    ProdId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProdInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProdType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProdImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdLists", x => x.ProdId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrandLists");

            migrationBuilder.DropTable(
                name: "ProdLists");
        }
    }
}
