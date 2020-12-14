using Microsoft.EntityFrameworkCore;

using NGWebV1.Models;

namespace NGWebV1.Data.Configurations
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Endereco> builder)
        {

            builder.Property(p => p.Cep).HasColumnType("char(8)");
            builder.Property(p => p.Complemento).HasColumnType("VARCHAR(20)");
            builder.Property(p => p.Descricao).HasColumnType("VARCHAR(20)");
            builder.Property(p => p.Logradouro).HasColumnType("VARCHAR(60)");





        }
    }
}
