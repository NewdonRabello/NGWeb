using Microsoft.EntityFrameworkCore;

using NGWebV1.Models;

namespace NGWebV1.Data.Configurations
{
    public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Pessoa> builder)
        {

            builder.Property(p => p.NomeRazaoSocial).HasColumnType("VARCHAR(60)").IsRequired();
            builder.Property(p => p.CpfCnpj).HasColumnType("VARCHAR(14)");





        }
    }
}
