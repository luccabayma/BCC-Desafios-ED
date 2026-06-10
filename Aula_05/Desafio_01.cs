using System;

public class Node
{
    public int Key { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }

    // Construtor do no
    public Node(int key)
    {
        Key = key;
        Left = null;
        Right = null;
    }
}

// Arvore Busca Binaria BST
public class BST
{
    public Node Raiz { get; set; }

    public BST()
    {
        Raiz = null;
    }

    private Node InsertB(int value, Node raiz)
    {
        if (raiz == null)
        {
            return new Node(value);
        }

        // Valores menores ficam na esquerda
        if (value < raiz.Key)
        {
            raiz.Left = InsertB(value, raiz.Left);
        }
        else
        {
            // Valores maiores ficam na direita
            raiz.Right = InsertB(value, raiz.Right);
        }

        return raiz;
    }

    public void Insert(int value)
    {
        // Atualiza a raiz apos a insercao
        Raiz = InsertB(value, Raiz);
    }

    private Node SearchB(int value, Node raiz)
    {
        // Se nao encontrar ou se achar o valor
        if (raiz == null || raiz.Key == value)
        {
            return raiz;
        }

        // Vai pra esquerda se o valor for menor
        if (value < raiz.Key)
        {
            return SearchB(value, raiz.Left);
        }

        // Vai pra direita se o valor for maior
        return SearchB(value, raiz.Right);
    }

    public Node Search(int value)
    {
        return SearchB(value, Raiz);
    }
}

public class Program
{
    public static void Main()
    {
        BST arvore = new BST();

        // Insere os valores na arvore
        arvore.Insert(10);
        arvore.Insert(5);
        arvore.Insert(15);
        arvore.Insert(3);

        // Busca um valor existente
        Node result = arvore.Search(5);
        Console.WriteLine(result != null ? $"Encontrado: {result.Key}" : "Nao encontrado");

        // Busca um valor que nao existe
        Node notFound = arvore.Search(99);
        Console.WriteLine(notFound != null ? $"Encontrado: {notFound.Key}" : "Nao encontrado");
    }
}