using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLNhom10.Migrations
{
    /// <inheritdoc />
    public partial class Add_Quanlyhosos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SoDienThoai",
                table: "Quanlyhosos",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "NgayLamViec",
                table: "Quanlyhosos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SinhNgay",
                table: "Quanlyhosos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NgayLamViec",
                table: "Quanlyhosos");

            migrationBuilder.DropColumn(
                name: "SinhNgay",
                table: "Quanlyhosos");

            migrationBuilder.AlterColumn<int>(
                name: "SoDienThoai",
                table: "Quanlyhosos",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }
    }
}
