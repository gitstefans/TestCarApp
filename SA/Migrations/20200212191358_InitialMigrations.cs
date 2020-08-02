using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SA.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    make = table.Column<string>(maxLength: 50, nullable: false),
                    model = table.Column<string>(maxLength: 50, nullable: false),
                    year = table.Column<int>(nullable: true),
                    engine_size = table.Column<decimal>(type: "decimal(5, 2)", nullable: true),
                    power_kw = table.Column<int>(nullable: true),
                    fuel_type = table.Column<string>(maxLength: 50, nullable: true),
                    body_type = table.Column<string>(maxLength: 50, nullable: true),
                    price = table.Column<decimal>(type: "money", nullable: true),
                    Image = table.Column<string>(nullable: true),
                    OriginalImageName = table.Column<string>(nullable: true),
                    contact = table.Column<string>(maxLength: 50, nullable: true),
                    is_deleted = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car");
        }
    }
}
