using System.Text.Encodings.Web;
using ScreenSound.Data;
using ScreenSound.Models;

namespace ScreenSound.Menu;

internal class MenuAvaliarBanda : Menu
{
    public override void Executar()
    {
        using ScreenSoundContext context = new();
        base.Executar();
        Console.Clear();
        ExibirTituloDaOpcao("***Avaliar uma Banda***");
        RetornaNota(context.Bandas);
        AguardarRetornoAoMenuPrincipal();
    }

    public void RetornaNota(IQueryable<Banda> bandas)
    {
        using ScreenSoundContext context = new();
        Console.WriteLine("Qual é a banda que você deseja avaliar?\n");
        Console.WriteLine("-------------------");
        foreach (var banda in bandas)
        {
            Console.WriteLine($" > {banda.Nome}");
            Console.WriteLine("-------------------");
        }

        var nomeBanda = Console.ReadLine()!.Trim();
        if (!context.Bandas.Any(banda => banda.Nome == nomeBanda))
        {
            Console.WriteLine("\u001b[31mSentimos muito, mas essa banda não existe no nosso banco de dados!\u001b[0m");
            return;
        }
        Console.Clear();
        Console.WriteLine($"De 0 a 10, qual é a nota que a banda '{nomeBanda}' merece?");
        var nota = int.Parse(Console.ReadLine()!);
        ValidaBandaEAdicionaNota(nota, nomeBanda);
    }

    private static void ValidaBandaEAdicionaNota(int novaAvalicao, string nomeDaBanda)
    {
        Console.Clear();
        using ScreenSoundContext context = new();
        var nota = new AvaliacaoBanda(novaAvalicao);
        var banda = context.Bandas.First(banda => banda.Nome.Equals(nomeDaBanda));
        Console.WriteLine("Adicionando nota à banda ou artista...");
        Thread.Sleep(1000);
        context.Entry(nota).Property("banda_id").CurrentValue = banda.Id;
        context.AvaliacaoBandas.Add(nota);
        context.SaveChanges();
        Console.Clear();
        Console.WriteLine($"\u001b[32mNota adicionada à banda {nomeDaBanda}!\u001b[0m");
        Thread.Sleep(2000);
        Console.Clear();
    }
    
    private void AguardarRetornoAoMenuPrincipal()
    {
        Console.WriteLine("\nPressione Enter para retornar ao menu principal...");
        Console.ReadLine();
    }
}