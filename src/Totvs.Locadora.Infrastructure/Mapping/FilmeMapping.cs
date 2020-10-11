using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Totvs.Locadora.Core.Models;

namespace Totvs.Locadora.Infrastructure.Mapping
{
    public class FilmeMapping : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Titulo).IsRequired().HasColumnType("varchar(80)").HasMaxLength(80);
            builder.Property(f => f.Genero).IsRequired().HasColumnType("varchar(40)").HasMaxLength(40);
            builder.Property(f => f.DataLancamento).IsRequired();
            builder.Property(f => f.Preco).IsRequired();
        }
    }
}
