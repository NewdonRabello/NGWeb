using Microsoft.EntityFrameworkCore.Migrations;

namespace NGWebV1.Migrations
{
    public partial class ControllersCriados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_TipoProduto_TipoProdutoId",
                table: "Produto");

            migrationBuilder.DropForeignKey(
                name: "FK_VendaProduto_Produto_ProdutoId",
                table: "VendaProduto");

            migrationBuilder.DropIndex(
                name: "IX_Fornecedores_PessoaId",
                table: "Fornecedores");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_PessoaId",
                table: "Clientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produto",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "ValorItem",
                table: "VendaProduto");

            migrationBuilder.RenameTable(
                name: "Produto",
                newName: "Produtos");

            migrationBuilder.RenameIndex(
                name: "IX_Produto_TipoProdutoId",
                table: "Produtos",
                newName: "IX_Produtos_TipoProdutoId");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "TipoFormaPagamento",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NomeRazaoSocial",
                table: "Pessoas",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedores_PessoaId",
                table: "Fornecedores",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_PessoaId",
                table: "Clientes",
                column: "PessoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_TipoProduto_TipoProdutoId",
                table: "Produtos",
                column: "TipoProdutoId",
                principalTable: "TipoProduto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VendaProduto_Produtos_ProdutoId",
                table: "VendaProduto",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_TipoProduto_TipoProdutoId",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_VendaProduto_Produtos_ProdutoId",
                table: "VendaProduto");

            migrationBuilder.DropIndex(
                name: "IX_Fornecedores_PessoaId",
                table: "Fornecedores");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_PessoaId",
                table: "Clientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos");

            migrationBuilder.RenameTable(
                name: "Produtos",
                newName: "Produto");

            migrationBuilder.RenameIndex(
                name: "IX_Produtos_TipoProdutoId",
                table: "Produto",
                newName: "IX_Produto_TipoProdutoId");

            migrationBuilder.AddColumn<double>(
                name: "ValorItem",
                table: "VendaProduto",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "TipoFormaPagamento",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "NomeRazaoSocial",
                table: "Pessoas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 60);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produto",
                table: "Produto",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedores_PessoaId",
                table: "Fornecedores",
                column: "PessoaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_PessoaId",
                table: "Clientes",
                column: "PessoaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_TipoProduto_TipoProdutoId",
                table: "Produto",
                column: "TipoProdutoId",
                principalTable: "TipoProduto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VendaProduto_Produto_ProdutoId",
                table: "VendaProduto",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
