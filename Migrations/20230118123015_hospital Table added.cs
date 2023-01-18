using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class hospitalTableadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hospitals",
                columns: table => new
                {
                    HospitalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HospitalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HospitalRep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HospitalKebele = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HospitalKifleKetema = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HospitalWoreda = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitals", x => x.HospitalId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hospitals");
        }
    }
}
