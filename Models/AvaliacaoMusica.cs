namespace ScreenSound.Models;

internal class AvaliacaoMusica : Avaliacao
{
    public AvaliacaoMusica(int nota) : base(nota)
    {
        Nota = nota;
    }

    public Musica Musica { get; set; }
}