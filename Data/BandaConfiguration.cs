using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScreenSound.Models;

namespace ScreenSound.Data
{
    internal class BandaConfiguration : IEntityTypeConfiguration<Banda>
    {
        public void Configure(EntityTypeBuilder<Banda> builder)
        {
            builder.ToTable("artista");
            builder.Property(b => b.Id).HasColumnName("id");
            builder.Property(b => b.Nome).HasColumnName("nome_artista").HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(b => b.Detalhes).HasColumnName("detalhes").HasColumnType("VARCHAR(MAX)").IsRequired();
            builder.Property<DateTime>("created_at").HasColumnType("datetime").HasDefaultValueSql("getdate()").IsRequired();
            builder.HasAlternateKey(b => new { b.Nome });
        }
    }
}
