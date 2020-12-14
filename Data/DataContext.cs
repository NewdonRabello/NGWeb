using Microsoft.EntityFrameworkCore;

using NGWebV1.Models;

namespace NGWebV1.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<TipoProduto> TipoProduto { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Venda> Vendas { get; set; }

        public DbSet<TipoFormaPagamento> TipoFormaPagamento { get; set; }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<User> Users {get; set;}











    }
}