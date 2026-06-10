using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static string RemoverPontuacao(string texto)
    {
        // Remove os principais sinais de pontuacao
        texto = texto.Replace(".", "");
        texto = texto.Replace(",", "");
        texto = texto.Replace("!", "");
        texto = texto.Replace("?", "");
        texto = texto.Replace(":", "");
        texto = texto.Replace(";", "");

        return texto;
    }

    public static void Main(string[] args)
    {
        Dictionary<string, int> frequencia = new Dictionary<string, int>();

        int totalPalavras = 0;

        Console.WriteLine("Digite o texto (linha vazia para encerrar):");

        while (true)
        {
            string linha = Console.ReadLine();

            // Encerra a leitura quando a linha estiver vazia
            if (string.IsNullOrWhiteSpace(linha))
            {
                break;
            }

            // Converte para minusculo
            linha = linha.ToLower();

            // Remove a pontuacao
            linha = RemoverPontuacao(linha);

            // Separa as palavras da linha
            string[] palavras = linha.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (string palavra in palavras)
            {
                totalPalavras++;

                // Soma a frequencia da palavra
                if (frequencia.ContainsKey(palavra))
                {
                    frequencia[palavra]++;
                }
                else
                {
                    frequencia[palavra] = 1;
                }
            }
        }

        Console.WriteLine();
        Console.WriteLine("=== Resultado ===");

        Console.WriteLine($"Total de palavras: {totalPalavras}");
        Console.WriteLine($"Palavras distintas: {frequencia.Count}");

        Console.WriteLine();
        Console.WriteLine("Top 10 palavras mais frequentes:");

        int posicao = 1;

        // Ordena pelas maiores frequencias
        foreach (var item in frequencia.OrderByDescending(x => x.Value).Take(10))
        {
            Console.WriteLine($"{posicao}. \"{item.Key}\" - {item.Value} ocorrencias");
            posicao++;
        }
    }
}