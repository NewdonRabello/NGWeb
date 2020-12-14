using Microsoft.EntityFrameworkCore;

using NGWebV1.Models;

namespace NGWebV1.Data.Configurations
{
    public class VendaFormaPagamentoConfiguration : IEntityTypeConfiguration<VendaFormaPagamento>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<VendaFormaPagamento> builder)
        {

            builder.Property(p => p.Valor).IsRequired();


        }
    }

}