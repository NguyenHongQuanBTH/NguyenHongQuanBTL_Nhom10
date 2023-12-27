using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLNhom10.Migrations
{
    /// <inheritdoc />
    public partial class Table_Quanlyhosos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quanlyhosos",
                columns: table => new
                {
                    MaNV = table.Column<string>(type: "TEXT", nullable: false),
                    TenNV = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    SoDienThoai = table.Column<int>(type: "INTEGER", nullable: false),
                    SoTaiKhoan = table.Column<int>(type: "INTEGER", nullable: false),
                    PhongBan = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quanlyhosos", x => x.MaNV);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quanlyhosos");
        }
    }
}
