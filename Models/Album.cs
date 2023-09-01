namespace ScreenSound.Models;

internal class Album
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public IList<Musica> Musicas { get; set; }
    public Banda ArtistaBanda { get; set; }
    public IEnumerable<AvaliacaoAlbum> NotasAlbum { get; set; }

    public Album()
    {
        NotasAlbum = new List<AvaliacaoAlbum>();
        Musicas = new List<Musica>();
        ArtistaBanda = new Banda();
    }

    public override string ToString()
    {
        return $"Álbum ({Id}): {Nome} | Banda: {ArtistaBanda.Nome}";
    }
}