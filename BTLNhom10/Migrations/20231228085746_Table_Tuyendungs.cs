using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLNhom10.Migrations
{
    /// <inheritdoc />
    public partial class Table_Tuyendungs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SinhNgay",
                table: "Quanlyhosos",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "NgayLamViec",
                table: "Quanlyhosos",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateTable(
                name: "Tuyendungs",
                columns: table => new
                {
                    MaQL = table.Column<string>(type: "TEXT", nullable: false),
                    PhongBan = table.Column<string>(type: "TEXT", nullable: false),
                    DoTuoi = table.Column<string>(type: "TEXT", nullable: false),
                    NamKN = table.Column<string>(type: "TEXT", nullable: false),
                    TrinhDo = table.Column<string>(type: "TEXT", nullable: false),
                    NgoaiHinh = table.Column<string>(type: "TEXT", nullable: false),
                    NgoaiNgu = table.Column<string>(type: "TEXT", nullable: false),
                    PhongVan = table.Column<string>(type: "TEXT", nullable: false),
                    YeuCau = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tuyendungs", x => x.MaQL);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tuyendungs");

            migrationBuilder.AlterColumn<int>(
                name: "SinhNgay",
                table: "Quanlyhosos",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "NgayLamViec",
                table: "Quanlyhosos",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }
    }
}
