namespace ScreenSound.Models;

internal class Banda
{
    public Banda()
    {
        Musicas = new List<Musica>();
        AlbumsDaBanda = new List<Album>();
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public IEnumerable<Musica> Musicas { get; set; }
    public IList<Album> AlbumsDaBanda { get; set; }
    public IEnumerable<AvaliacaoBanda> NotasBanda { get; set; }
    public string Detalhes { get; set; }

    public override string ToString()
    {
        return $"Artista/Banda ({Id}): {Nome}";
    }
}