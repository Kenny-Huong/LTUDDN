using Microsoft.EntityFrameworkCore.Migrations;

namespace VD_BANG.Migrations
{
    public partial class tbHocSinh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "hocSinhs",
                columns: table => new
                {
                    maHocSinh = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hoTen = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hocSinhs", x => x.maHocSinh);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hocSinhs");
        }
    }
}
