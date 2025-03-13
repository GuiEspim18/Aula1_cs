using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;

Dictionary<string, (int vitórias, int empates, int derrotas)> jogadores = new Dictionary<string, (int, int, int)>();

Console.OutputEncoding = System.Text.Encoding.UTF8;

char ShowMenu()
{
    Console.WriteLine("😀 Olá! Vamos jogar Jokempo?");
    Console.WriteLine("1 - Sim ou 0 - Não");

    var continueMenu = Console.ReadKey().KeyChar;
    while (continueMenu != '0' && continueMenu != '1')
    {
        Console.WriteLine("\nOpção inválida. Escolha 1 ou 0.");
        continueMenu = Console.ReadKey().KeyChar;
    }

    return Console.ReadKey().KeyChar;
}

string GetPlayerName()
{
    Console.WriteLine("\nQual é o seu nome?");
    string name = Console.ReadLine();

    while (string.IsNullOrEmpty(name))
    {
        Console.WriteLine("Você precisa digitar o seu nome. Pode ser o seu apelido...");
        name = Console.ReadLine();
    }

    if (!jogadores.ContainsKey(name))
    {
        jogadores[name] = (0, 0, 0);
    }

    return name;
}

Dictionary<string, int> GetChoices()
{
    Console.WriteLine("Escolha uma opção: 0 - Pedra ✊, 1 - Papel ✋ ou 2 - Tesoura ✌");
    char option = Console.ReadKey().KeyChar;
    while (option != '0' && option != '1' && option != '2')
    {
        Console.WriteLine("\nOpção inválida. Escolha 0, 1 ou 2.");
        option = Console.ReadKey().KeyChar;
    }

    Dictionary <string, int> options = new();

    options["pc"] = new Random().Next(3);
    options["player"] = int.Parse(option.ToString());

    return options;
}

char PlayAgain()
{
    Console.WriteLine("\nQuer jogar de novo?");
    Console.WriteLine("1 - Sim, 0 - Não");
    char option = Console.ReadKey().KeyChar;
    while (option != '0' && option != '1')
    {
        option = Console.ReadKey().KeyChar;
    }
    return Console.ReadKey().KeyChar;
}

char EndMenu()
{
    Console.WriteLine("\nO que deseja fazer agora?");
    Console.WriteLine("1 - Continuar com outro jogador, 2 - Listar jogadores e estatísticas, 0 - Sair");
    char option = Console.ReadKey().KeyChar;
    while (option != '0' && option != '1' && option != '2')
    {
        option = Console.ReadKey().KeyChar;
    }
    return Console.ReadKey().KeyChar;
}

char continueProgram = ShowMenu();

while (ShowMenu() != '0')
{

    string name = GetPlayerName();

    Console.WriteLine($"Bem-vindo, {name}! Vamos começar...");

    do
    {   
        Dictionary<string, int> options = GetChoices();
       
        bool vitoria = false;

        switch (options["player"])
        {
            case '0':
                Console.WriteLine("\nVocê escolheu Pedra ✊!");
                vitoria = (options["pc"] == 2);
                break;
            case '1':
                Console.WriteLine("\nVocê escolheu Papel ✋");
                vitoria = (options["pc"] == 0);
                break;
            case '2':
                Console.WriteLine("\nVocê escolheu Tesoura ✌");
                vitoria = (options["pc"] == 1);
                break;
        }

        switch (options["pc"])
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

        if (options["player"] == options["pc"])
        {
            Console.WriteLine("\n😀 Legal! Nós empatamos!");
            jogadores[name] = (jogadores[name].vitórias, jogadores[name].empates + 1, jogadores[name].derrotas);
        }
        else if (vitoria)
        {
            Console.WriteLine("\n😀 Parabéns! Você venceu.");
            jogadores[name] = (jogadores[name].vitórias + 1, jogadores[name].empates, jogadores[name].derrotas);
        }
        else
        {
            Console.WriteLine("\n😀 Haha, eu venci! Não foi dessa vez.");
            jogadores[name] = (jogadores[name].vitórias, jogadores[name].empates, jogadores[name].derrotas + 1);
        }

        Console.WriteLine("\nQuer jogar de novo?");
        Console.WriteLine("1 - Sim, 0 - Não");
    } while (PlayAgain() == '1');


    continueProgram = EndMenu();

    if (continueProgram == '2')
    {
        Console.WriteLine("\nJogadores e suas estatísticas:\n");
        Console.WriteLine("===================================================================");
        foreach (var jogador in jogadores)
        {
            Console.WriteLine($"{jogador.Key}: {jogador.Value.vitórias} vitórias, {jogador.Value.empates} empates, {jogador.Value.derrotas} derrotas");
        }
        Console.WriteLine("===================================================================\n");

        continueProgram = PlayAgain();
    }
}

Console.WriteLine("👋 Tchau! Até a próxima");