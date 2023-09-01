namespace ScreenSound.Models;

internal class AvaliacaoAlbum : Avaliacao
{
    public AvaliacaoAlbum(int nota) : base(nota)
    {
        Nota = nota;
    }

    public Album Album { get; set; }
    
}