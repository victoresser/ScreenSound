using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScreenSound.Models;

namespace ScreenSound.Data;

internal class AvaliacaoAlbumConfiguration : AvaliacaoConfiguration<AvaliacaoAlbum>
{
    public override void Configure(EntityTypeBuilder<AvaliacaoAlbum> builder)
    {
        base.Configure(builder);
        builder.ToTable("avalicao_album");
        builder.Property(aa => aa.Id).HasColumnName("id");
        builder.Property<DateTime>("rated_at").HasColumnType("datetime").HasDefaultValueSql("getdate()");
        builder.HasOne(aa => aa.Album).WithMany(album => album.NotasAlbum).HasForeignKey("album_id");
    }
}