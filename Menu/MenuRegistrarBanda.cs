using System.Globalization;
using ScreenSound.Data;
using ScreenSound.Models;
using OpenAI_API;

namespace ScreenSound.Menu
{
    internal class MenuRegistrarBanda : Menu
    {
        public override void Executar()
        {
            using var context = new ScreenSoundContext();
            base.Executar();
            Console.Clear();
            ExibirTituloDaOpcao("***Registrar Banda***");
            
            Console.Write("Digite o nome da banda que deseja registrar: ");
            var nomeBanda = Console.ReadLine()!.Trim();
            CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nomeBanda.ToLower());

            Console.WriteLine(ValidarERegistrarBanda(nomeBanda, context)
                ? "\u001b[32mBanda registrada com sucesso!\u001b[0m"
                : "\u001b[31mEssa banda já está registrada ou o nome é inválido.\u001b[0m");
            
            ExibirBandasRegistradas(context.Bandas);
            AguardarRetornoAoMenuPrincipal();
        }

        private static bool ValidarERegistrarBanda(string nomeBanda, ScreenSoundContext context)
        {
            if (string.IsNullOrWhiteSpace(nomeBanda))
            {
                Console.WriteLine("\u001b[31mNome da banda inválido.\u001b[0m");
                return false;
            }

            if (context.Bandas.Any(b => b.Nome == nomeBanda))
            {
                return false;
            }

            var client = new OpenAIAPI("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");
            var chat = client.Chat.CreateConversation();
            chat.AppendSystemMessage($"Resuma a banda {nomeBanda} em 1 parágrafo. Adote uma linguagem informal.");
            var resposta = chat.GetResponseFromChatbotAsync().GetAwaiter().GetResult();
            var banda = new Banda { Nome = nomeBanda , Detalhes = resposta};
            context.Bandas.Add(banda);
            context.SaveChanges();
            return true;
        }

        private static void AguardarRetornoAoMenuPrincipal()
        {
            Console.WriteLine("\n\n\nPressione Enter para retornar ao menu principal...");
            Console.ReadLine();
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
    }
}
