using Microsoft.EntityFrameworkCore;

using NGWebV1.Models;

namespace NGWebV1.Data.Configurations
{
    public class VendaProdutoConfiguration : IEntityTypeConfiguration<VendaProduto>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<VendaProduto> builder)
        {

            builder.Property(p => p.ValorProduto).IsRequired();


        }
    }

}