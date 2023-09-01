using Microsoft.EntityFrameworkCore;
using ScreenSound.Models;

namespace ScreenSound.Data;

internal class ScreenSoundContext : DbContext
{
    public DbSet<Banda> Bandas { get; set; }
    public DbSet<Musica> Musicas { get; set; }
    public DbSet<Album> Albums { get; set; }
    public DbSet<AvaliacaoAlbum> AvaliacaoAlbums { get; set; }
    public DbSet<AvaliacaoBanda> AvaliacaoBandas { get; set; }
    public DbSet<AvaliacaoMusica> AvaliacaoMusicas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ScreenSoundDB;Trusted_connection=true;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Musica
        modelBuilder.ApplyConfiguration(new MusicaConfiguration());

        // Banda
        modelBuilder.ApplyConfiguration(new BandaConfiguration());

        // Album
        modelBuilder.ApplyConfiguration(new AlbumConfiguration());
        
        // Avaliação Album
        modelBuilder.ApplyConfiguration(new AvaliacaoAlbumConfiguration());
        
        // Avaliação Banda
        modelBuilder.ApplyConfiguration(new AvaliacaoBandaConfiguration());
        
        // Avaliação Musica
        modelBuilder.ApplyConfiguration(new AvaliacaoMusicaConfiguration());
    }
}