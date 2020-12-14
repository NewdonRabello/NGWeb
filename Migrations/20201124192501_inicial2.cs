using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NGWebV1.Migrations
{
    public partial class inicial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ValorTotal",
                table: "Vendas",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Vendas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Vendas",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "VendaProduto",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "VendaProduto",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "VendaFormaPagamento",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "VendaFormaPagamento",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "TipoProduto",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TipoProduto",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "TipoFormaPagamento",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TipoFormaPagamento",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Produto",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Produto",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Pessoas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Pessoas",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Fornecedores",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Fornecedores",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Endereco",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Endereco",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Clientes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Clientes",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "VendaProduto");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "VendaProduto");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "VendaFormaPagamento");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "VendaFormaPagamento");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "TipoProduto");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TipoProduto");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "TipoFormaPagamento");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TipoFormaPagamento");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Clientes");

            migrationBuilder.AlterColumn<double>(
                name: "ValorTotal",
                table: "Vendas",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
