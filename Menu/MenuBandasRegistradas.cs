using System.Globalization;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ScreenSound.Data;
using ScreenSound.Models;

namespace ScreenSound.Menu;

internal class MenuBandasRegistradas : Menu
{
    public override void Executar()
    {
        base.Executar();
        ExibirTituloDaOpcao("***Lista de Bandas Registradas***");
        
        RetornaBandas();
        
        AguardarRetornoAoMenuPrincipal();
    }

    private void RetornaBandas()
    {
        using ScreenSoundContext context = new();
        var bandas = context.Bandas.Include(b => b.AlbumsDaBanda).Include(banda => banda.Musicas).ToList();
        foreach (var banda in bandas)
        {
            Console.WriteLine($"{banda.Nome}:");
            Console.WriteLine($" - Álbums: {banda.AlbumsDaBanda.Count}");
            Console.WriteLine($" - Músicas: {banda.Musicas.Count()}");
        }
    }
    
    private void AguardarRetornoAoMenuPrincipal()
    {
        Console.WriteLine("\nPressione Enter para retornar ao menu principal...");
        Console.ReadLine();
    }
}