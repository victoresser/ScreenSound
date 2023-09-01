using System.Globalization;
using ScreenSound.Data;
using ScreenSound.Models;
using OpenAI_API;

namespace ScreenSound.Menu;

internal class MenuRegistrarMusica : Menu
{
    public override void Executar()
    {
        using ScreenSoundContext context = new();
        base.Executar();
        ExibirTituloDaOpcao("***Registrar uma nova música***");
        RegistraMusica(context);
        AguardarRetornoAoMenuPrincipal();
    }
    

    private Banda RecebeBanda()
    {
        using ScreenSoundContext context = new();
        Console.WriteLine("Qual é o nome da banda à qual pertence esta música?");
        ExibirBandasRegistradas(context.Bandas);
        var nome = Console.ReadLine()!.Trim();


        Banda banda;
        if (context.Bandas.Any(b => b.Nome.Equals(nome)))
        {
            Console.WriteLine("Banda encontrada!");
            banda = context.Bandas.First(b => b.Nome.Equals(nome));
            return banda;
        }
        
        Console.WriteLine("Esta banda não existe no nosso banco de dados, mas não se preocupe,\nVamos criar esta banda e inserí-la no banco de dados.");
        var client = new OpenAIAPI("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");
        var chat = client.Chat.CreateConversation();
        chat.AppendSystemMessage($"Resuma a banda {nome} em 1 parágrafo. Adote uma linguagem informal.");
        var resposta = chat.GetResponseFromChatbotAsync().GetAwaiter().GetResult();
        banda = new Banda() { Nome = nome, Detalhes = resposta};
        context.Bandas.Add(banda);
        context.SaveChanges();
        var novaBanda = context.Bandas.First(b => b.Nome.Equals(nome));
        return novaBanda;
    }

    private Album RecebeAlbum(string nomeMusica, Banda banda)
    {
        using ScreenSoundContext context = new();
        Console.Clear();
        Console.WriteLine($"A Música {nomeMusica} pertence à algum Album?");
        ExibirAlbumsRegistrados(context.Albums);
        
        var nome = Console.ReadLine()!.Trim();
        CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nome.ToLower());
        Album album;

        if (context.Albums.Any(a => a.Nome.Equals(nome)))
        {
            Console.WriteLine("\u001b[31mEncontramos o Album!\u001b[0m");
            album = context.Albums.First(a => a.Nome.Equals(nome));
            return album;
        }
        Console.Clear();
        album = new Album { Nome = nome, ArtistaBanda = banda };
        context.Entry(album).Property("artista_id").CurrentValue = banda.Id;
        context.Albums.Add(album);
        context.SaveChanges();
        return album;
    }

    private void RegistraMusica(ScreenSoundContext context)
    {
        Console.WriteLine("Qual é o nome da música que deseja registrar?");
        var nome = Console.ReadLine()!.Trim();
        CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nome.ToLower());

        if (context.Musicas.Any(m => m.Nome.Equals(nome)))
        {
            Console.WriteLine("Esta música já existe, tente novemente.");
            return;
        }
        Console.Clear();
        Console.WriteLine("Qual é a duração em segundos desta música?");
        var duracao = short.Parse(Console.ReadLine()!);
        Console.WriteLine("\nE estará disponivel no Plano Basic? (SIM) ou (NÃO)");
        var disponivel = Console.ReadLine()!.ToUpper();
        var banda = RecebeBanda();
        var album = RecebeAlbum(nome, banda);

        var musica = new Musica
        {
            Nome = nome,
            Artista = banda,
            Album = album,
            Duracao = duracao
        };
        
        if (disponivel == "SIM")
        {
            musica.Disponivel = true;
        }
        
        context.Entry(musica).Property("artista_id").CurrentValue = banda.Id;
        context.Entry(musica).Property("album_id").CurrentValue = album.Id;
        
        context.Musicas.Add(musica);
        context.SaveChanges();
    }
    
    private static void ExibirBandasRegistradas(IQueryable<Banda> bandas)
    {
        Console.WriteLine("Bandas registradas:");
        Console.WriteLine("\n-------------------");
        foreach (var banda in bandas)
        {
            Console.WriteLine($" > {banda.Nome}");
            Console.WriteLine("-------------------");
        }
        Console.WriteLine();
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
        Console.WriteLine("\nPressione Enter para retornar ao menu principal...");
        Console.ReadLine();
    }
}