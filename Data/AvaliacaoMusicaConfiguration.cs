using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScreenSound.Models;

namespace ScreenSound.Data;

internal class AvaliacaoMusicaConfiguration : AvaliacaoConfiguration<AvaliacaoMusica>
{
    public override void Configure(EntityTypeBuilder<AvaliacaoMusica> builder)
    {
        base.Configure(builder);
        builder.ToTable("avaliacao_musica");
        builder.Property(am => am.Id).HasColumnName("id");
        builder.Property<DateTime>("rated_at").HasColumnType("datetime").HasDefaultValueSql("getdate()");
        builder.HasOne(am => am.Musica).WithMany(musica => musica.AvaliacaoMusicas).HasForeignKey("musica_id");
    }
}