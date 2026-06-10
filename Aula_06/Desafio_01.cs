using System;
using System.Collections.Generic;

public class Node
{
    public int Key { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }

    // Construtor
    public Node(int key)
    {
        this.Key = key;
    }
}

// Arvore Busca Binaria BST
public class BST
{
    public Node Raiz { get; set; }

    private Node InsertB(int valor, Node raiz)
    {
        if (raiz == null)
        {
            return new Node(valor);
        }

        // Valores menores ficam na esquerda
        if (valor < raiz.Key)
        {
            raiz.Left = InsertB(valor, raiz.Left);
        }
        else
        {
            // Valores maiores ficam na direita
            raiz.Right = InsertB(valor, raiz.Right);
        }

        return raiz;
    }

    public void Insert(int valor)
    {
        // Atualiza a raiz apos inserir
        this.Raiz = InsertB(valor, this.Raiz);
    }

    private Node SearchB(int valor, Node raiz)
    {
        // Se encontrar ou se chegar no fim
        if (raiz == null || raiz.Key == valor)
            return raiz;

        // Vai pra esquerda se for menor
        if (valor < raiz.Key)
        {
            return SearchB(valor, raiz.Left);
        }
        else
        {
            // Vai pra direita se for maior
            return SearchB(valor, raiz.Right);
        }
    }

    public Node Search(int valor)
    {
        return SearchB(valor, this.Raiz);
    }

    private Node MaximoN(Node raiz)
    {
        // O maior valor fica mais a direita
        if (raiz == null || raiz.Right == null)
            return raiz;

        return MaximoN(raiz.Right);
    }

    public Node Maximo()
    {
        return MaximoN(this.Raiz);
    }

    public Node MaxIterativo()
    {
        Node atual = this.Raiz;

        // Vai ate o ultimo no da direita
        while (atual != null && atual.Right != null)
        {
            atual = atual.Right;
        }

        return atual;
    }

    private Node MinimoN(Node raiz)
    {
        // O menor valor fica mais a esquerda
        if (raiz == null || raiz.Left == null)
            return raiz;

        return MinimoN(raiz.Left);
    }

    public Node Minimo()
    {
        return MinimoN(this.Raiz);
    }

    public Node MinIterativo()
    {
        Node atual = this.Raiz;

        // Vai ate o ultimo no da esquerda
        while (atual != null && atual.Left != null)
        {
            atual = atual.Left;
        }

        return atual;
    }

    private void InOrder(Node raiz)
    {
        if (raiz == null) return;

        InOrder(raiz.Left);
        Console.Write(raiz.Key + " ");
        InOrder(raiz.Right);
    }

    public void PrintInOrder()
    {
        // Imprime os valores em ordem crescente
        InOrder(this.Raiz);
        Console.WriteLine();
    }

    public void PrintInOrderIterativo()
    {
        Stack<Node> pilha = new Stack<Node>();
        Node atual = this.Raiz;

        // Percorre a arvore usando pilha
        while (atual != null || pilha.Count > 0)
        {
            while (atual != null)
            {
                pilha.Push(atual);
                atual = atual.Left;
            }

            atual = pilha.Pop();
            Console.Write(atual.Key + " ");

            atual = atual.Right;
        }

        Console.WriteLine();
    }

    private void CoolPrintN(Node raiz, int nivel)
    {
        if (raiz == null) return;

        // Imprime espaços conforme o nivel
        for (int i = 0; i < nivel; i++)
        {
            Console.Write("    ");
        }

        Console.WriteLine(raiz.Key);

        // Imprime os filhos da esquerda e direita
        CoolPrintN(raiz.Left, nivel + 1);
        CoolPrintN(raiz.Right, nivel + 1);
    }

    public void CoolPrint()
    {
        CoolPrintN(this.Raiz, 0);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        BST bst = new BST();

        // Insere os valores na arvore
        bst.Insert(15);
        bst.Insert(10);
        bst.Insert(8);
        bst.Insert(12);
        bst.Insert(20);
        bst.Insert(21);

        Console.WriteLine("In-order traversal (Sorted keys):");
        bst.PrintInOrder();

        Console.WriteLine("In-order iterativo:");
        bst.PrintInOrderIterativo();

        Node maximo = bst.Maximo();
        Node maxIterativo = bst.MaxIterativo();

        Console.WriteLine("Max value (recursivo e iterativo):");
        Console.WriteLine($"{maximo.Key} {maxIterativo.Key}");

        Node minimo = bst.Minimo();
        Node minIterativo = bst.MinIterativo();

        Console.WriteLine("Min value (recursivo e iterativo):");
        Console.WriteLine($"{minimo.Key} {minIterativo.Key}");

        Console.WriteLine("Visualizacao mais legal:");
        bst.CoolPrint();
    }
}