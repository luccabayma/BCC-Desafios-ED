using System;
using System.Collections.Generic;

class Program
{
    static Treinador EscolherTreinador(string resposta, List<Treinador> treinadores)
    {
        // Procura o treinador pelo nome
        foreach (Treinador treinador in treinadores)
        {
            if (treinador.Nome.ToLower() == resposta.ToLower())
            {
                return treinador;
            }
        }

        Console.WriteLine("Treinador nao encontrado.");
        return null;
    }

    static Treinador SelecionarJogador(string label, List<Treinador> treinadores)
    {
        Console.WriteLine($"=== {label} ===");
        Console.WriteLine("Escolha seu treinador:");

        string resposta = Console.ReadLine();
        Treinador jogador = EscolherTreinador(resposta, treinadores);

        // Mostra o treinador escolhido
        if (jogador != null)
        {
            Console.WriteLine($"Treinador escolhido: {jogador.Nome}");
        }

        return jogador;
    }

    static Pokemon SelecionarPokemon(Treinador jogador)
    {
        Console.WriteLine($"\n{jogador.Nome}, escolha seu Pokemon pelo indice:");
        jogador.ListarPokemons();

        int indice = int.Parse(Console.ReadLine());

        // Escolhe o pokemon da lista
        Pokemon escolhido = jogador.EscolherPokemon(indice);

        if (escolhido == null)
        {
            Console.WriteLine("Pokemon nao encontrado.");
            return null;
        }

        escolhido.ExibirStatus();
        Console.WriteLine();

        return escolhido;
    }

    static void Batalhar(Pokemon p1, Pokemon p2)
    {
        Console.WriteLine($"\n=== BATALHA: {p1.Nome} vs {p2.Nome} ===\n");

        // A batalha continua enquanto os dois tiverem vida
        while (p1.Vida > 0 && p2.Vida > 0)
        {
            string logAtaque = p1.AtacaAtaca(p2);
            Console.WriteLine(logAtaque);
            Console.WriteLine();

            // Se o segundo pokemon morrer, encerra a batalha
            if (p2.Vida <= 0)
            {
                break;
            }

            logAtaque = p2.AtacaAtaca(p1);
            Console.WriteLine(logAtaque);
            Console.WriteLine();
        }

        // Mostra o vencedor da batalha
        if (p1.Vida > 0)
        {
            Console.WriteLine($"=== {p1.Nome} venceu a batalha! ===");
        }
        else
        {
            Console.WriteLine($"=== {p2.Nome} venceu a batalha! ===");
        }
    }

    static void Main(string[] args)
    {
        // Criando pokemons de fogo
        PokemonFogo charmander = new PokemonFogo("Charmander", 16, 8, 100);
        PokemonFogo vulpix = new PokemonFogo("Vulpix", 14, 7, 90);
        PokemonFogo ponyta = new PokemonFogo("Ponyta", 18, 6, 95);

        // Criando pokemons de agua
        PokemonAgua squirtle = new PokemonAgua("Squirtle", 12, 11, 100);
        PokemonAgua psyduck = new PokemonAgua("Psyduck", 13, 9, 95);
        PokemonAgua horsea = new PokemonAgua("Horsea", 15, 8, 80);
        PokemonAgua seel = new PokemonAgua("Seel", 11, 12, 105);

        // Criando pokemons de grama
        PokemonGrama bulbasaur = new PokemonGrama("Bulbasaur", 13, 10, 100);
        PokemonGrama oddish = new PokemonGrama("Oddish", 11, 9, 85);
        PokemonGrama bellsprout = new PokemonGrama("Bellsprout", 17, 5, 80);

        // Criando treinadores
        Treinador ash = new Treinador("Ash");
        ash.AdicionarPokemon(charmander);
        ash.AdicionarPokemon(squirtle);
        ash.AdicionarPokemon(bulbasaur);
        ash.AdicionarPokemon(ponyta);

        Treinador misty = new Treinador("Misty");
        misty.AdicionarPokemon(horsea);
        misty.AdicionarPokemon(seel);
        misty.AdicionarPokemon(psyduck);
        misty.AdicionarPokemon(oddish);

        Treinador brock = new Treinador("Brock");
        brock.AdicionarPokemon(vulpix);
        brock.AdicionarPokemon(bellsprout);

        Treinador gary = new Treinador("Gary");
        gary.AdicionarPokemon(new PokemonFogo("Charmander", 16, 8, 100));
        gary.AdicionarPokemon(new PokemonFogo("Ponyta", 18, 6, 95));
        gary.AdicionarPokemon(new PokemonAgua("Horsea", 15, 8, 80));
        gary.AdicionarPokemon(new PokemonGrama("Bellsprout", 17, 5, 80));

        List<Treinador> treinadores = new List<Treinador>();
        treinadores.Add(ash);
        treinadores.Add(misty);
        treinadores.Add(brock);
        treinadores.Add(gary);

        Console.WriteLine("=== BATALHA POKEMON ===\n");

        Console.WriteLine("=== TREINADORES ===");

        // Mostra todos os treinadores
        foreach (Treinador treinador in treinadores)
        {
            Console.WriteLine($"\n{treinador.Nome}");
            treinador.ListarPokemons();
        }

        Treinador jogador1;
        Treinador jogador2;

        // Escolhe o primeiro treinador
        do
        {
            jogador1 = SelecionarJogador("JOGADOR 1", treinadores);
        } while (jogador1 == null);

        // Escolhe o segundo treinador
        do
        {
            jogador2 = SelecionarJogador("JOGADOR 2", treinadores);
        } while (jogador2 == null);

        Pokemon pokemonJogador1;
        Pokemon pokemonJogador2;

        // Escolhe o pokemon do primeiro treinador
        do
        {
            pokemonJogador1 = SelecionarPokemon(jogador1);
        } while (pokemonJogador1 == null);

        // Escolhe o pokemon do segundo treinador
        do
        {
            pokemonJogador2 = SelecionarPokemon(jogador2);
        } while (pokemonJogador2 == null);

        Batalhar(pokemonJogador1, pokemonJogador2);
    }
}