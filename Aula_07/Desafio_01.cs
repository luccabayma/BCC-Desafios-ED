using System;
using System.Collections.Generic;

public class Node
{
    public int Key { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }
    public int Altura { get; set; }

    // Construtor
    public Node(int key)
    {
        Key = key;
        Left = null;
        Right = null;
        Altura = 1;
    }
}

// BST comum
public class BST
{
    public Node Raiz { get; set; }

    private Node InsertB(Node raiz, int valor)
    {
        // Se encontrou uma posicao vazia, cria o no
        if (raiz == null)
        {
            return new Node(valor);
        }

        // Valores menores ficam na esquerda
        if (valor < raiz.Key)
        {
            raiz.Left = InsertB(raiz.Left, valor);
        }
        else
        {
            // Valores maiores ficam na direita
            raiz.Right = InsertB(raiz.Right, valor);
        }

        return raiz;
    }

    public void Insert(int valor)
    {
        Raiz = InsertB(Raiz, valor);
    }

    private int AlturaB(Node raiz)
    {
        // Arvore vazia tem altura 0
        if (raiz == null)
        {
            return 0;
        }

        int alturaEsquerda = AlturaB(raiz.Left);
        int alturaDireita = AlturaB(raiz.Right);

        // Retorna a maior altura entre os lados
        return Math.Max(alturaEsquerda, alturaDireita) + 1;
    }

    public int Altura()
    {
        return AlturaB(Raiz);
    }
}

// AVL balanceada
public class AVL
{
    public Node Raiz { get; set; }

    private int AlturaN(Node no)
    {
        if (no == null)
        {
            return 0;
        }

        return no.Altura;
    }

    private int FatorBalanceamento(Node no)
    {
        if (no == null)
        {
            return 0;
        }

        return AlturaN(no.Left) - AlturaN(no.Right);
    }

    private Node RotacaoDireita(Node y)
    {
        Node x = y.Left;
        Node temp = x.Right;

        // Faz a rotacao para direita
        x.Right = y;
        y.Left = temp;

        // Atualiza as alturas
        y.Altura = Math.Max(AlturaN(y.Left), AlturaN(y.Right)) + 1;
        x.Altura = Math.Max(AlturaN(x.Left), AlturaN(x.Right)) + 1;

        return x;
    }

    private Node RotacaoEsquerda(Node x)
    {
        Node y = x.Right;
        Node temp = y.Left;

        // Faz a rotacao para esquerda
        y.Left = x;
        x.Right = temp;

        // Atualiza as alturas
        x.Altura = Math.Max(AlturaN(x.Left), AlturaN(x.Right)) + 1;
        y.Altura = Math.Max(AlturaN(y.Left), AlturaN(y.Right)) + 1;

        return y;
    }

    private Node InsertA(Node raiz, int valor)
    {
        // Se encontrou uma posicao vazia, cria o no
        if (raiz == null)
        {
            return new Node(valor);
        }

        // Insere como em uma BST comum
        if (valor < raiz.Key)
        {
            raiz.Left = InsertA(raiz.Left, valor);
        }
        else
        {
            raiz.Right = InsertA(raiz.Right, valor);
        }

        // Atualiza a altura do no
        raiz.Altura = Math.Max(AlturaN(raiz.Left), AlturaN(raiz.Right)) + 1;

        int balanceamento = FatorBalanceamento(raiz);

        // Caso esquerda esquerda
        if (balanceamento > 1 && valor < raiz.Left.Key)
        {
            return RotacaoDireita(raiz);
        }

        // Caso direita direita
        if (balanceamento < -1 && valor > raiz.Right.Key)
        {
            return RotacaoEsquerda(raiz);
        }

        // Caso esquerda direita
        if (balanceamento > 1 && valor > raiz.Left.Key)
        {
            raiz.Left = RotacaoEsquerda(raiz.Left);
            return RotacaoDireita(raiz);
        }

        // Caso direita esquerda
        if (balanceamento < -1 && valor < raiz.Right.Key)
        {
            raiz.Right = RotacaoDireita(raiz.Right);
            return RotacaoEsquerda(raiz);
        }

        return raiz;
    }

    public void Insert(int valor)
    {
        Raiz = InsertA(Raiz, valor);
    }

    public int Altura()
    {
        return AlturaN(Raiz);
    }
}

public class Program
{
    static Random random = new Random();

    static List<int> GerarNumerosDistintos(int quantidade)
    {
        List<int> numeros = new List<int>();

        // Gera numeros sem repetir
        while (numeros.Count < quantidade)
        {
            int valor = random.Next(1, quantidade * 10 + 1);

            if (!numeros.Contains(valor))
            {
                numeros.Add(valor);
            }
        }

        return numeros;
    }

    static void NovaSimulacao()
    {
        Console.Write("Digite a quantidade de amostras: ");
        int A = int.Parse(Console.ReadLine());

        Console.Write("Digite a quantidade de elementos para cada amostra: ");
        int N = int.Parse(Console.ReadLine());

        double somaBST = 0;
        double somaAVL = 0;

        // Executa todas as amostras
        for (int i = 0; i < A; i++)
        {
            BST bst = new BST();
            AVL avl = new AVL();

            List<int> valores = GerarNumerosDistintos(N);

            // Insere os mesmos valores nas duas arvores
            foreach (int valor in valores)
            {
                bst.Insert(valor);
                avl.Insert(valor);
            }

            somaBST += bst.Altura();
            somaAVL += avl.Altura();
        }

        double mediaBST = somaBST / A;
        double mediaAVL = somaAVL / A;
        double mediaGeral = (mediaBST + mediaAVL) / 2;

        Console.WriteLine();
        Console.WriteLine($"Experimento com A = {A} e N = {N}");
        Console.WriteLine("----------------------------------");
        Console.WriteLine($"Altura media geral:     {mediaGeral}");
        Console.WriteLine($"Altura media BST comum: {mediaBST}");
        Console.WriteLine($"Altura media AVL:       {mediaAVL}");
        Console.WriteLine("----------------------------------");
    }

    public static void Main(string[] args)
    {
        int opcao;

        do
        {
            Console.WriteLine("Menu: 1) nova simulacao ou 2) sair");
            opcao = int.Parse(Console.ReadLine());

            if (opcao == 1)
            {
                NovaSimulacao();
            }

        } while (opcao != 2);

        Console.WriteLine("Tchau!");
    }
}