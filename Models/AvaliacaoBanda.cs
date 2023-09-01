namespace ScreenSound.Models;

internal class AvaliacaoBanda : Avaliacao
{
    public AvaliacaoBanda(int nota) : base(nota)
    {
        Nota = nota;
    }

    public Banda Banda { get; set; }
}