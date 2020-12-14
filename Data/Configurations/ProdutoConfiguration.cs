using Microsoft.EntityFrameworkCore;

using NGWebV1.Models;

namespace NGWebV1.Data.Configurations
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Produto> builder)
        {
            builder.Property(p => p.CodProduto).HasColumnType("VARCHAR(20)");
            builder.Property(p => p.Descricao).HasColumnType("VARCHAR(20)").IsRequired();

        }
    }
}