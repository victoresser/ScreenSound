using ScreenSound.Menu;

namespace ScreenSound
{
    internal class Program
    {
        private static Dictionary<int, Menu.Menu> _opcoes = new()
        {
            { 1, new MenuRegistrarBanda() },
            { 2, new MenuAvaliarBanda() },
            { 3, new MenuRegistrarAlbum() },
            { 4, new MenuAvaliarAlbum() },
            { 5, new MenuBandasRegistradas() },
            { 6, new MenuExibirDetalhes() },
            { 7, new MenuRegistrarMusica() },
            { 0, new MenuSair() }
        };

        private static void ExibirLogo()
        {
            Console.WriteLine("""
                              
                                      ░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
                                      ██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
                                      ╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
                                      ░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
                                      ██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
                                      ╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░

                              """);
            Console.WriteLine("                                     Boas vindas ao Screen Sound 3.0!");
        }

        private static void Main()
        {
            void ExibirOpcoesDoMenu()
            {
                while (true)
                {
                    Console.Clear();
                    ExibirLogo();
                    Console.WriteLine("\n                                     Digite 1 para registrar uma banda");
                    Console.WriteLine("                                     Digite 2 para avaliar uma banda");
                    Console.WriteLine("                                     Digite 3 para registrar o álbum de uma banda");
                    Console.WriteLine("                                     Digite 4 para avaliar um álbum");
                    Console.WriteLine("                                     Digite 5 para mostrar todas as bandas");
                    Console.WriteLine("                                     Digite 6 para exibir os detalhes de uma banda");
                    Console.WriteLine("                                     Digite 7 para registrar uma música");
                    Console.WriteLine("                                     Digite 0 para sair");
                    Console.Write("\n                                     Digite a sua opção: ");
                    var opcao = int.Parse(Console.ReadLine()!);

                    if (_opcoes.TryGetValue(opcao, out var opcoe))
                    {
                        opcoe.Executar();
                        if (opcao > 0) continue;
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida");
                    }

                    break;
                }
            }

            ExibirOpcoesDoMenu();
        }
    }
}