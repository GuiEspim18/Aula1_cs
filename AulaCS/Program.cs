
// See https://aka.ms/new-console-template for more information
using AulaCS;
using System;

Console.OutputEncoding = System.Text.Encoding.UTF8;

List<Player> players = new List<Player>();
Player player;

if (players.Count > 0)
{
    Console.WriteLine("Deseja adicionar um novo player? ");
    Console.WriteLine("1 - Sim ou 0 - Não");
    char opt = Console.ReadKey().KeyChar;
    if (opt == '1')
    {
        AddPlayer();
    }

} else if (players.Count == 0)
{
    AddPlayer();
}


ChoosePlayer();

Console.WriteLine($"😀 Olá {player.name}! Vamos jogar Jokempo?");
Console.WriteLine("1 - Sim ou 0 - Não");

var continuar = Console.ReadKey().KeyChar;

if (continuar != '0' && continuar != '1')
{
    Console.WriteLine("Opção Errada!");
}
else
{
    while (continuar == '1')
    {
        Console.WriteLine("Então vamos começar...");
        Console.WriteLine("Escolha uma opção: 0 - Pedra ✊, 1 - Papel ✋ ou 2 - Tesoura ✌");
        var opcao = Console.ReadKey().KeyChar;

        if (opcao != '0' &&  opcao != '1' && opcao == '2')
        {
            Console.Write("Escolha uma opção válida!");
            break;
        }

        var opcaoPC = new Random().Next(3);

        bool vitoria = false;

        switch (opcao)
        {
            case '0':
                Console.WriteLine("\nVocê escoheu Pedra ✊!");
                vitoria = (opcaoPC == 2);
                break;
            case '1':
                Console.WriteLine("\nVocê escoheu Papel ✋");
                vitoria = (opcaoPC == 0);
                break;
            case '2':
                Console.WriteLine("\nVocê escoheu Tesoura ✌");
                vitoria = (opcaoPC == 1);
                break;
        }

        switch (opcaoPC)
        {
            case 0:
                Console.WriteLine("\nEu escolhi Pedra ✊!");
                break;
            case 1:
                Console.WriteLine("\nEu escolhi Papel ✋");
                break;
            case 2:
                Console.WriteLine("\nEu escolhi Tesoura ✌");
                break;
        }

        if (int.Parse(opcao.ToString()) == opcaoPC)
        {
            Console.WriteLine("\n😀 Legal! Nós empatamos!");
            player.statistic.Add(1);
        }    
        else if (vitoria)
        {
            Console.WriteLine("\n😀 Parabéns! Você venceu.");
            player.statistic.Add(0);
        }
        else
        {
            Console.WriteLine("\n😀 Haha, eu venci! Não foi dessa vez. Você pode ter mais sorte na próxima.");
            player.statistic.Add(2);
        }

        ShowStatisc();

        Console.WriteLine("\nQuer jogar de novo?");
        Console.WriteLine("1 - Sim ou 0 - Não");
        continuar = Console.ReadKey().KeyChar;
    }
    Console.WriteLine("👋 Tchau! Até a próxima");
}

void AddPlayer()
{
    Console.Write("Escreva o seu nome:");
    string name = Console.ReadLine();

    players.Add(new Player(name));

}

void ChoosePlayer()
{
    Console.WriteLine("Escolha um player");
    for (int i = 0; i < players.Count; i++)
    {
        Console.WriteLine($"{i} {players[i].name}");
    }
    int index = (int)Console.ReadKey().KeyChar;
    player = players[index];
}

void ShowStatisc()
{
    Console.WriteLine($"{player.name}");
    int defeats = 0;
    int draws = 0;
    int victories = 0;
    foreach (int statistic in player.statistic)
    {
        switch (statistic)
        {
            case 0: victories++; break;
            case 1: draws++; break;
            case 2: defeats++; break;
        }
    }
    Console.WriteLine($"{victories} Vitórias");
    Console.WriteLine($"{defeats} Derrotas");
    Console.WriteLine($"{draws} Empates");


}