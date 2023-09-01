using ScreenSound.Data;
using ScreenSound.Models;

namespace ScreenSound.Menu;

internal class MenuAvaliarAlbum : Menu
{
    public override void Executar()
    {
        using ScreenSoundContext context = new();
        base.Executar();
        Console.Clear();
        ExibirTituloDaOpcao("***Avaliar um Álbum***");
        RetornaNota(context.Albums);
        AguardarRetornoAoMenuPrincipal();
    }

    public void RetornaNota(IQueryable<Album> albums)
    {
        using ScreenSoundContext context = new();
        Console.WriteLine("Qual é o álbum que você deseja avaliar?\n");
        Console.WriteLine("-------------------");
        foreach (var album in albums)
        {
            Console.WriteLine($" > {album.Nome}");
            Console.WriteLine("-------------------");
        }

        var nomeAlbum = Console.ReadLine()!.Trim();
        if (!context.Albums.Any(album => album.Nome == nomeAlbum))
        {
            Console.WriteLine("\u001b[31mSentimos muito, mas esse álbum não existe no nosso banco de dados!\u001b[0m");
            return;
        }
        Console.Clear();
        Console.WriteLine($"De 0 a 10, qual é a nota que o álbum '{nomeAlbum}' merece?");
        var nota = int.Parse(Console.ReadLine()!);
        ValidaAlbumEAdicionaNota(nota, nomeAlbum);
    }

    private static void ValidaAlbumEAdicionaNota(int novaAvalicao, string nomeAlbum)
    {
        Console.Clear();
        using ScreenSoundContext context = new();
        var nota = new AvaliacaoAlbum(novaAvalicao);
        var banda = context.Albums.First(album => album.Nome.Equals(nomeAlbum));
        Console.WriteLine("Adicionando nota ao álbum...");
        Thread.Sleep(1000);
        context.Entry(nota).Property("album_id").CurrentValue = banda.Id;
        context.AvaliacaoAlbums.Add(nota);
        context.SaveChanges();
        Console.Clear();
        Console.WriteLine($"\u001b[32mNota adicionada ao álbum '{nomeAlbum}'!\u001b[0m");
        Thread.Sleep(2000);
        Console.Clear();
    }
    
    private void AguardarRetornoAoMenuPrincipal()
    {
        Console.WriteLine("\nPressione Enter para retornar ao menu principal...");
        Console.ReadLine();
    }
}