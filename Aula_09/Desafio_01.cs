using System;
using System.Collections.Generic;

public class Program
{
    static Dictionary<string, List<string>> CriarMapa()
    {
        Dictionary<string, List<string>> mapa = new Dictionary<string, List<string>>();

        mapa["São Paulo"] = new List<string> { "Rio de Janeiro", "Curitiba", "Belo Horizonte" };
        mapa["Rio de Janeiro"] = new List<string> { "São Paulo", "Belo Horizonte", "Vitória" };
        mapa["Belo Horizonte"] = new List<string> { "São Paulo", "Rio de Janeiro", "Brasília" };
        mapa["Curitiba"] = new List<string> { "São Paulo", "Florianópolis" };
        mapa["Florianópolis"] = new List<string> { "Curitiba", "Porto Alegre" };
        mapa["Porto Alegre"] = new List<string> { "Florianópolis" };
        mapa["Brasília"] = new List<string> { "Belo Horizonte", "Goiânia" };
        mapa["Goiânia"] = new List<string> { "Brasília" };
        mapa["Vitória"] = new List<string> { "Rio de Janeiro" };
        mapa["Salvador"] = new List<string> { "Recife" };
        mapa["Recife"] = new List<string> { "Salvador", "Fortaleza" };
        mapa["Fortaleza"] = new List<string> { "Recife" };

        return mapa;
    }

    static void ListarCidades(Dictionary<string, List<string>> mapa)
    {
        Console.WriteLine("\nCidades e conexoes:");

        // Percorre todas as cidades do mapa
        foreach (var cidade in mapa)
        {
            Console.WriteLine($"{cidade.Key}: [{string.Join(", ", cidade.Value)}]");
        }
    }

    static bool CidadeExiste(Dictionary<string, List<string>> mapa, string cidade)
    {
        return mapa.ContainsKey(cidade);
    }

    static void VerificarConexaoDireta(Dictionary<string, List<string>> mapa)
    {
        Console.Write("Cidade 1: ");
        string cidade1 = Console.ReadLine();

        Console.Write("Cidade 2: ");
        string cidade2 = Console.ReadLine();

        // Verifica se as duas cidades existem
        if (!CidadeExiste(mapa, cidade1) || !CidadeExiste(mapa, cidade2))
        {
            Console.WriteLine("Uma das cidades nao existe no mapa.");
            return;
        }

        // Verifica se existe estrada direta
        if (mapa[cidade1].Contains(cidade2))
        {
            Console.WriteLine($"{cidade1} e {cidade2} possuem conexao direta!");
        }
        else
        {
            Console.WriteLine($"{cidade1} e {cidade2} NAO possuem conexao direta.");
        }
    }

    static bool DFS(
        Dictionary<string, List<string>> mapa,
        string atual,
        string destino,
        HashSet<string> visitados,
        List<string> ordem)
    {
        // Marca a cidade como visitada
        visitados.Add(atual);
        ordem.Add(atual);

        if (atual == destino)
        {
            return true;
        }

        // Visita as cidades vizinhas
        foreach (string vizinho in mapa[atual])
        {
            if (!visitados.Contains(vizinho))
            {
                if (DFS(mapa, vizinho, destino, visitados, ordem))
                {
                    return true;
                }
            }
        }

        return false;
    }

    static void ExisteRotaDFS(Dictionary<string, List<string>> mapa)
    {
        Console.Write("Origem: ");
        string origem = Console.ReadLine();

        Console.Write("Destino: ");
        string destino = Console.ReadLine();

        // Verifica se as cidades existem
        if (!CidadeExiste(mapa, origem) || !CidadeExiste(mapa, destino))
        {
            Console.WriteLine("Uma das cidades nao existe no mapa.");
            return;
        }

        HashSet<string> visitados = new HashSet<string>();
        List<string> ordem = new List<string>();

        bool encontrou = DFS(mapa, origem, destino, visitados, ordem);

        Console.WriteLine($"DFS visitando: {string.Join(" -> ", ordem)}");

        if (encontrou)
        {
            Console.WriteLine($"Rota encontrada! E possivel ir de {origem} ate {destino}.");
        }
        else
        {
            Console.WriteLine($"Rota NAO encontrada. Nao e possivel ir de {origem} ate {destino}.");
        }
    }

    static List<string> BFS(Dictionary<string, List<string>> mapa, string origem, string destino)
    {
        Queue<string> fila = new Queue<string>();
        HashSet<string> visitados = new HashSet<string>();
        Dictionary<string, string> pai = new Dictionary<string, string>();

        fila.Enqueue(origem);
        visitados.Add(origem);

        // Percorre o grafo
        while (fila.Count > 0)
        {
            string atual = fila.Dequeue();

            if (atual == destino)
            {
                break;
            }

            foreach (string vizinho in mapa[atual])
            {
                if (!visitados.Contains(vizinho))
                {
                    visitados.Add(vizinho);
                    pai[vizinho] = atual;
                    fila.Enqueue(vizinho);
                }
            }
        }

        // Caso nao tenha chegado ao destino
        if (!visitados.Contains(destino))
        {
            return null;
        }

        List<string> caminho = new List<string>();
        string cidade = destino;

        // Faz o caminho voltando pelos países
        while (cidade != origem)
        {
            caminho.Add(cidade);
            cidade = pai[cidade];
        }

        caminho.Add(origem);
        caminho.Reverse();

        return caminho;
    }

    static void MenorRotaBFS(Dictionary<string, List<string>> mapa)
    {
        Console.Write("Origem: ");
        string origem = Console.ReadLine();

        Console.Write("Destino: ");
        string destino = Console.ReadLine();

        // Verifica se as cidades existem
        if (!CidadeExiste(mapa, origem) || !CidadeExiste(mapa, destino))
        {
            Console.WriteLine("Uma das cidades nao existe no mapa.");
            return;
        }

        List<string> caminho = BFS(mapa, origem, destino);

        if (caminho == null)
        {
            Console.WriteLine($"Nao existe rota entre {origem} e {destino}.");
            return;
        }

        Console.WriteLine($"Menor rota (BFS): {string.Join(" -> ", caminho)}");
        Console.WriteLine($"Paradas: {caminho.Count - 1}");
    }

    public static void Main(string[] args)
    {
        Dictionary<string, List<string>> mapa = CriarMapa();

        int opcao;

        Console.WriteLine("=== Bora Viajar! ===");

        do
        {
            Console.WriteLine();
            Console.WriteLine("Menu: 1) listar cidades  2) conexao direta  3) existe rota? (DFS)  4) menor rota (BFS)  5) sair");
            opcao = int.Parse(Console.ReadLine());

            if (opcao == 1)
            {
                ListarCidades(mapa);
            }
            else if (opcao == 2)
            {
                VerificarConexaoDireta(mapa);
            }
            else if (opcao == 3)
            {
                ExisteRotaDFS(mapa);
            }
            else if (opcao == 4)
            {
                MenorRotaBFS(mapa);
            }

        } while (opcao != 5);

        Console.WriteLine("Boa viagem!");
    }
}