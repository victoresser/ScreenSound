using Microsoft.EntityFrameworkCore;
using ScreenSound.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ScreenSound.Data;

internal class AvaliacaoBandaConfiguration : AvaliacaoConfiguration<AvaliacaoBanda>
{
    public override void Configure(EntityTypeBuilder<AvaliacaoBanda> builder)
    {
        base.Configure(builder);
        builder.ToTable("avaliacao_banda");
        builder.Property(ab => ab.Id).HasColumnName("id");
        builder.Property<DateTime>("rated_at").HasColumnType("datetime").HasDefaultValueSql("getdate()");
        builder.HasOne(ab => ab.Banda).WithMany(banda => banda.NotasBanda).HasForeignKey("banda_id");
    }
}