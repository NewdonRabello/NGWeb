using Microsoft.EntityFrameworkCore;

using NGWebV1.Models;

namespace NGWebV1.Data.Configurations
{
    public class TipoProdutoConfiguration : IEntityTypeConfiguration<TipoProduto>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TipoProduto> builder)
        {

            builder.Property(p => p.Descricao).HasColumnType("VARCHAR(20)").IsRequired();

        }
    }

}