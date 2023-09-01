using System.Globalization;
using ScreenSound.Data;
using ScreenSound.Models;

namespace ScreenSound.Menu;

internal class MenuRegistrarAlbum : Menu
{
    public override void Executar()
    {
        base.Executar();
        ExibirTituloDaOpcao("***Registrar Álbum***");
        using ScreenSoundContext context = new();
        var nomeAlbum = RecebeAlbum();
        var nomeBanda = RecebeBanda();
        Console.Clear();

        ValidaBandaEAlbum(context, nomeAlbum, nomeBanda);
        
        RegistraAlbum(context, nomeAlbum, nomeBanda);
        ExibirAlbumsRegistrados(context.Albums);
        AguardarRetornoAoMenuPrincipal();
    }

    private static string RecebeAlbum()
    {
        using ScreenSoundContext context = new();
        Console.Write("Digite o nome do álbum que deseja registrar: ");
        ExibirAlbumsRegistrados(context.Albums);
        Console.WriteLine("\nAlbum: ");
        var nome = Console.ReadLine()!.Trim();
        CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nome.ToLower());
        Console.Clear();
        return nome;
    }
    
    private static string RecebeBanda()
    {
        using ScreenSoundContext context = new();
        Console.Write("A qual banda pertence este álbum?");
        ExibirBandasRegistradas(context.Bandas);
        Console.WriteLine("\nBanda: ");
        var nome = Console.ReadLine()!.Trim();
        CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nome.ToLower());
        return nome;
    }

    private static void ValidaBandaEAlbum(ScreenSoundContext context, string nomeAlbum, string nomeBanda)
    {
        if (context.Albums.Any(album => album.Nome == nomeAlbum))
        {
            Console.WriteLine("\u001b[31mErro | Álbum já existente!\u001b[0m");
            AguardarRetornoAoMenuPrincipal();
        }

        if (!context.Bandas.Any(banda => banda.Nome == nomeBanda))
        {
            Console.WriteLine("Identificamos que esta banda não existe, estamos cadastrando ela, só um segundo...");
            context.Bandas.Add(new Banda { Nome = nomeBanda });
            context.SaveChanges();
            Console.WriteLine("Banda cadastrada!");
        }
        
        Thread.Sleep(2000);
        Console.Clear();
    }

    private static void RegistraAlbum(ScreenSoundContext context, string nomeAlbum, string nomeBanda)
    {
        var banda = context.Bandas.First(banda => banda.Nome.Equals(nomeBanda));
        var album = new Album { Nome = nomeAlbum, ArtistaBanda = banda };
        context.Entry(album).Property("artista_id").CurrentValue = banda.Id;
        context.Albums.Add(album);
        context.SaveChanges();
        Console.WriteLine("\u001b[32mÁlbum cadastrado com sucesso!\u001b[0m");
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
    
    private static void ExibirAlbumsRegistrados(IQueryable<Album> albums)
    {
        Console.WriteLine("\nAlbums registrados:");
        Console.WriteLine("\n-------------------");
        foreach (var album in albums)
        {
            Console.WriteLine($" > {album.Nome}");
            Console.WriteLine("-------------------");
        }
    }
    
    private static void AguardarRetornoAoMenuPrincipal()
    {
        Console.WriteLine("\n\n\nPressione Enter para retornar ao menu principal...");
        Console.ReadLine();
    }
}