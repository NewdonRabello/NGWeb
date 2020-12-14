using Microsoft.EntityFrameworkCore;

using NGWebV1.Models;

namespace NGWebV1.Data.Configurations
{
    public class FornecedorConfiguration : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Fornecedor> builder)
        {

        }
    }
}