namespace ScreenSound.Models;

internal class Musica
{

    public int Id { get; set; }
    public required string Nome { get; set; }
    public short Duracao { get; set; }
    public bool Disponivel { get; set; }
    public Banda Artista { get; set; }
    public Album Album { get; set; }
    public IEnumerable<AvaliacaoMusica> AvaliacaoMusicas { get; set; }

    public Musica(bool disponivel = true)
    {
        Artista = new Banda();
        Album = new Album();
        Disponivel = disponivel;
    }

    public override string ToString()
    {
        return Disponivel != true 
            ? $"Musica ({Id}): {Nome} | Artista: {Artista.Nome} | Disponibilidade: Plano Plus+" 
            : $"Musica ({Id}): {Nome} | Artista: {Artista.Nome} | Disponibilidade: Plano Basic";
    }

}