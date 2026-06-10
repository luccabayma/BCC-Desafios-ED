#include <stdio.h>
#include <stdlib.h>

struct no
{
    int info;
    struct no *prox;
};

struct no *novoNo(int info)
{
    struct no *novo = malloc(sizeof(struct no));
    novo->info = info;
    return novo;
}

void insert_last(struct no *lista, int info)
{
    struct no *novo = novoNo(info);

    // Encontra o ultimo no
    struct no *curr = lista;
    while (curr->prox != NULL)
    {
        curr = curr->prox;
    }

    // Liga o último no ao novo elemento
    curr->prox = novo;
}

void print_list(struct no *lista)
{
    struct no *curr = lista;

    // Imprime o valor do no
    while (curr != NULL)
    {
        printf("%d\n", curr->info);
        curr = curr->prox;
    }
}

int main()
{
    struct no *lista = novoNo(1);
    insert_last(lista, 2);
    insert_last(lista, 3);

    print_list(lista);

    return 0;
}