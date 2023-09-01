using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScreenSound.Models;

namespace ScreenSound.Data
{
    internal class AlbumConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.ToTable("album");
            builder.Property(a => a.Id).HasColumnName("id");
            builder.Property(a => a.Nome).HasColumnName("nome_album").HasColumnType("varchar(50)");
            builder.Property<int>("artista_id");
            builder.Property<DateTime>("created_at").HasColumnType("datetime").HasDefaultValueSql("getdate()").IsRequired();
            builder.HasOne(a => a.ArtistaBanda).WithMany(b => b.AlbumsDaBanda).HasForeignKey("artista_id").OnDelete(DeleteBehavior.ClientSetNull).IsRequired();
            builder.HasAlternateKey(a => new { a.Nome });

        }
    }
}
