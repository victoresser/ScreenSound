namespace ScreenSound.Models;

public class Avaliacao
{
    public Avaliacao(int nota)
    {
        if (nota <= 0) nota = 0;
        if (nota >= 10) nota = 10;
        Nota = nota;
    }

    public int Id { get; set; }
    public int Nota { get; set; }

    public static Avaliacao Parse(string texto)
    {
        var nota = int.Parse(texto);
        return new Avaliacao(nota);
    }
}