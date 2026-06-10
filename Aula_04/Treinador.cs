using System;
using System.Collections.Generic;

public class Treinador
{
    public string Nome { get; set; }
    public LinkedList<Pokemon> Pokemons { get; set; }

    public Treinador(string nome)
    {
        Nome = nome;
        Pokemons = new LinkedList<Pokemon>();
    }

    public void AdicionarPokemon(Pokemon p)
    {
        Pokemons.AddLast(p);
    }

    public void ListarPokemons()
    {
        Console.WriteLine($"\nPokemons de {Nome}:");

        int i = 0;

        // Percorre a lista mostrando os pokemons
        foreach (Pokemon pokemon in Pokemons)
        {
            Console.Write($"[{i}] ");
            pokemon.ExibirStatus();
            i++;
        }
    }

    public Pokemon EscolherPokemon(int indice)
    {
        // Verifica se o indice e valido
        if (indice < 0 || indice >= Pokemons.Count)
        {
            Console.WriteLine("Indice invalido.");

            // Retorna null se nao houver pokemon
            if (Pokemons.Count < 1)
            {
                return null;
            }

            // Retorna o primeiro pokemon como padrao
            return Pokemons.First.Value;
        }

        LinkedListNode<Pokemon> atual = Pokemons.First;

        // Percorre a lista ate o indice escolhido
        for (int i = 0; i < indice; i++)
        {
            atual = atual.Next;
        }

        return atual.Value;
    }
}