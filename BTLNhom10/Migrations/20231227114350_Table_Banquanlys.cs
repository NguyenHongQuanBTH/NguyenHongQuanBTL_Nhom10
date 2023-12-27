﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLNhom10.Migrations
{
    /// <inheritdoc />
    public partial class Table_Banquanlys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banquanlys",
                columns: table => new
                {
                    MaNV = table.Column<string>(type: "TEXT", nullable: false),
                    TenNV = table.Column<string>(type: "TEXT", nullable: false),
                    QueQuan = table.Column<string>(type: "TEXT", nullable: false),
                    Tuoi = table.Column<int>(type: "INTEGER", nullable: false),
                    GioiTinh = table.Column<string>(type: "TEXT", nullable: false),
                    NamKN = table.Column<string>(type: "TEXT", nullable: false),
                    ChucVu = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banquanlys", x => x.MaNV);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banquanlys");
        }
    }
}
