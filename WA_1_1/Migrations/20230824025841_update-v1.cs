using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WA_1_1.Migrations
{
    /// <inheritdoc />
    public partial class updatev1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHoaDon_HaoDon_HoaDonId",
                table: "ChiTietHoaDon");

            migrationBuilder.DropForeignKey(
                name: "FK_HaoDon_KhachHang_KhachHangId",
                table: "HaoDon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HaoDon",
                table: "HaoDon");

            migrationBuilder.RenameTable(
                name: "HaoDon",
                newName: "HoaDon");

            migrationBuilder.RenameIndex(
                name: "IX_HaoDon_KhachHangId",
                table: "HoaDon",
                newName: "IX_HoaDon_KhachHangId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HoaDon",
                table: "HoaDon",
                column: "HoaDonID");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietHoaDon_HoaDon_HoaDonId",
                table: "ChiTietHoaDon",
                column: "HoaDonId",
                principalTable: "HoaDon",
                principalColumn: "HoaDonID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_KhachHang_KhachHangId",
                table: "HoaDon",
                column: "KhachHangId",
                principalTable: "KhachHang",
                principalColumn: "KhachHangId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHoaDon_HoaDon_HoaDonId",
                table: "ChiTietHoaDon");

            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_KhachHang_KhachHangId",
                table: "HoaDon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HoaDon",
                table: "HoaDon");

            migrationBuilder.RenameTable(
                name: "HoaDon",
                newName: "HaoDon");

            migrationBuilder.RenameIndex(
                name: "IX_HoaDon_KhachHangId",
                table: "HaoDon",
                newName: "IX_HaoDon_KhachHangId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HaoDon",
                table: "HaoDon",
                column: "HoaDonID");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietHoaDon_HaoDon_HoaDonId",
                table: "ChiTietHoaDon",
                column: "HoaDonId",
                principalTable: "HaoDon",
                principalColumn: "HoaDonID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HaoDon_KhachHang_KhachHangId",
                table: "HaoDon",
                column: "KhachHangId",
                principalTable: "KhachHang",
                principalColumn: "KhachHangId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
