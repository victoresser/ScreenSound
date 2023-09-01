using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScreenSound.Models;

namespace ScreenSound.Data
{
    internal class MusicaConfiguration : IEntityTypeConfiguration<Musica>
    {
        public void Configure(EntityTypeBuilder<Musica> builder)
        {
            builder.ToTable("musica");
            builder.Property(m => m.Id).HasColumnName("id");
            builder.Property(m => m.Nome).HasColumnName("nome_musica").HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(m => m.Duracao).HasColumnName("duracao").HasColumnType("smallint").IsRequired();
            builder.Property(m => m.Disponivel).HasColumnName("disponivel");
            builder.Property<DateTime>("created_at").HasColumnType("datetime").HasDefaultValueSql("getdate()").IsRequired();
            builder.HasOne(m => m.Artista).WithMany(mu => mu.Musicas).HasForeignKey("artista_id").OnDelete(DeleteBehavior.ClientSetNull).IsRequired();
            builder.HasOne(m => m.Album).WithMany(mu => mu.Musicas).HasForeignKey("album_id").OnDelete(DeleteBehavior.ClientSetNull).IsRequired();
            builder.HasAlternateKey(m => new { m.Nome });
        }
    }
}
