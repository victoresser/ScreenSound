using System.Globalization;
using Microsoft.EntityFrameworkCore;
using ScreenSound.Data;
using ScreenSound.Models;

namespace ScreenSound.Menu;

internal class MenuExibirDetalhes : Menu
{
    public override void Executar()
    {
        using ScreenSoundContext context = new();
        base.Executar();
        ExibirTituloDaOpcao("Exibir Detalhes de uma banda");
        
        var nomeBanda = RecebeBanda();
        Console.WriteLine(ValidarERetornarBanda(nomeBanda, context)
            ? $"\n\u001b[32mEstes são os detelhes da banda {nomeBanda}\u001b[0m"
            : $"\u001b[31mSentimos muito, mas esta banda não está no nosso banco de dados ou\nnão tem informações para serem exibidas.\u001b[0m"
            );
        
        AguardarRetornoAoMenuPrincipal();
    }
    private static string RecebeBanda()
    {
        using ScreenSoundContext context = new();
        Console.Write("Sobre qual banda você deseja saber mais??");
        ExibirBandasRegistradas(context.Bandas);
        Console.WriteLine("\nBanda: ");
        var nome = Console.ReadLine()!.Trim();
        CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nome.ToLower());
        return nome;
    }
    
    private static bool ValidarERetornarBanda(string nomeBanda, ScreenSoundContext context)
    {
        if (string.IsNullOrWhiteSpace(nomeBanda))
        {
            Console.WriteLine("\u001b[31mNome da banda inválido.\u001b[0m");
            return false;
        }

        if (!context.Bandas.Any(b => b.Nome == nomeBanda))
        {
            return false;
        }

        var banda = context.Bandas.First(b => b.Nome.Equals(nomeBanda));
        var albumsDaBanda = context.Albums.Include(album => album.Musicas).First(b => b.ArtistaBanda == banda);
        Console.WriteLine(banda.Nome);
        Console.WriteLine(banda.Detalhes);
        foreach (var album in albumsDaBanda.Nome.ToList())
        {
            Console.WriteLine(album);
            Console.WriteLine(albumsDaBanda.Musicas.ToList());
        }
        
        return true;
    }
    private static void ExibirBandasRegistradas(IQueryable<Banda> bandas)
    {
        Console.WriteLine("\nBandas registradas:");
        Console.WriteLine("\n-------------------");
        foreach (var banda in bandas)
        {
            Console.WriteLine($" > {banda.Nome}");
            Console.WriteLine("-------------------");
        }
    }
    
    private static void AguardarRetornoAoMenuPrincipal()
    {
        Console.WriteLine("\nPressione Enter para retornar ao menu principal...");
        Console.ReadLine();
    }
}