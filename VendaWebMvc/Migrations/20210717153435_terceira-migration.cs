using Microsoft.EntityFrameworkCore.Migrations;

namespace VendaWebMvc.Migrations
{
    public partial class terceiramigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoricoDeVendas_Vendedors_VendedorId",
                table: "HistoricoDeVendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendedors_Departamento_DepartamentoId",
                table: "Vendedors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vendedors",
                table: "Vendedors");

            migrationBuilder.RenameTable(
                name: "Vendedors",
                newName: "Vendedores");

            migrationBuilder.RenameIndex(
                name: "IX_Vendedors_DepartamentoId",
                table: "Vendedores",
                newName: "IX_Vendedores_DepartamentoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vendedores",
                table: "Vendedores",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricoDeVendas_Vendedores_VendedorId",
                table: "HistoricoDeVendas",
                column: "VendedorId",
                principalTable: "Vendedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendedores_Departamento_DepartamentoId",
                table: "Vendedores",
                column: "DepartamentoId",
                principalTable: "Departamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoricoDeVendas_Vendedores_VendedorId",
                table: "HistoricoDeVendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendedores_Departamento_DepartamentoId",
                table: "Vendedores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vendedores",
                table: "Vendedores");

            migrationBuilder.RenameTable(
                name: "Vendedores",
                newName: "Vendedors");

            migrationBuilder.RenameIndex(
                name: "IX_Vendedores_DepartamentoId",
                table: "Vendedors",
                newName: "IX_Vendedors_DepartamentoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vendedors",
                table: "Vendedors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricoDeVendas_Vendedors_VendedorId",
                table: "HistoricoDeVendas",
                column: "VendedorId",
                principalTable: "Vendedors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendedors_Departamento_DepartamentoId",
                table: "Vendedors",
                column: "DepartamentoId",
                principalTable: "Departamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
