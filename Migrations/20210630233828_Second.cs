using Microsoft.EntityFrameworkCore.Migrations;

namespace Alvin_P2_AP2.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CobrosDetalle_CobrosDetalle_VentaId",
                table: "CobrosDetalle");

            migrationBuilder.DropForeignKey(
                name: "FK_CobrosDetalle_Ventas_VentaId1",
                table: "CobrosDetalle");

            migrationBuilder.DropIndex(
                name: "IX_CobrosDetalle_VentaId1",
                table: "CobrosDetalle");

            migrationBuilder.DropColumn(
                name: "VentaId1",
                table: "CobrosDetalle");

            migrationBuilder.AddForeignKey(
                name: "FK_CobrosDetalle_Ventas_VentaId",
                table: "CobrosDetalle",
                column: "VentaId",
                principalTable: "Ventas",
                principalColumn: "VentaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CobrosDetalle_Ventas_VentaId",
                table: "CobrosDetalle");

            migrationBuilder.AddColumn<int>(
                name: "VentaId1",
                table: "CobrosDetalle",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CobrosDetalle_VentaId1",
                table: "CobrosDetalle",
                column: "VentaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CobrosDetalle_CobrosDetalle_VentaId",
                table: "CobrosDetalle",
                column: "VentaId",
                principalTable: "CobrosDetalle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CobrosDetalle_Ventas_VentaId1",
                table: "CobrosDetalle",
                column: "VentaId1",
                principalTable: "Ventas",
                principalColumn: "VentaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
