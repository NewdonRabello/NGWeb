using Microsoft.EntityFrameworkCore;

using NGWebV1.Models;

namespace NGWebV1.Data.Configurations
{
    public class TipoFormaPagamentoConfiguration : IEntityTypeConfiguration<TipoFormaPagamento>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TipoFormaPagamento> builder)
        {

            builder.Property(p => p.Descricao).HasColumnType("VARCHAR(20)").IsRequired();

        }
    }

}