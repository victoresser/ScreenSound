using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScreenSound.Models;

namespace ScreenSound.Data;

public class AvaliacaoConfiguration<T> : IEntityTypeConfiguration<T> where T : Avaliacao
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.Property(a => a.Nota).HasColumnName("rating").IsRequired();
        builder.Property<DateTime>("rated_at").HasColumnType("datetime").HasDefaultValueSql("getdate()").IsRequired();
    }
}