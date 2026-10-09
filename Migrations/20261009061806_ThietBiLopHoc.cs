using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BaiTap_JavaScript_JQuery_Ajax.Migrations
{
    /// <inheritdoc />
    public partial class ThietBiLopHoc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoaiThietBis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TenLoai = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiThietBis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThietBis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TenThietBi = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    DonGia = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    SoLuong = table.Column<int>(type: "INTEGER", nullable: false),
                    LoaiThietBiId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThietBis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThietBis_LoaiThietBis_LoaiThietBiId",
                        column: x => x.LoaiThietBiId,
                        principalTable: "LoaiThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "LoaiThietBis",
                columns: new[] { "Id", "TenLoai" },
                values: new object[,]
                {
                    { 1, "Loa" },
                    { 2, "Micro" },
                    { 3, "Thiết bị xử lý âm thanh" },
                    { 4, "Phụ kiện" }
                });

            migrationBuilder.InsertData(
                table: "ThietBis",
                columns: new[] { "Id", "DonGia", "LoaiThietBiId", "SoLuong", "TenThietBi" },
                values: new object[,]
                {
                    { 1, 8490000m, 1, 8, "Loa JBL PartyBox 110" },
                    { 2, 3990000m, 1, 12, "Loa Bose SoundLink Flex" },
                    { 3, 5790000m, 1, 6, "Loa kiểm âm Yamaha HS5" },
                    { 4, 7990000m, 2, 5, "Micro không dây Shure BLX24" },
                    { 5, 2790000m, 2, 20, "Micro có dây Shure SM58" },
                    { 6, 5990000m, 2, 7, "Micro thu âm Rode NT1" },
                    { 7, 7490000m, 3, 4, "Mixer Yamaha MG10XU" },
                    { 8, 4690000m, 3, 9, "Sound card Focusrite Scarlett 2i2" },
                    { 9, 4290000m, 4, 11, "Tai nghe Audio-Technica M50x" },
                    { 10, 890000m, 4, 30, "Chân micro On-Stage MS7701B" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ThietBis_LoaiThietBiId",
                table: "ThietBis",
                column: "LoaiThietBiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThietBis");

            migrationBuilder.DropTable(
                name: "LoaiThietBis");
        }
    }
}
