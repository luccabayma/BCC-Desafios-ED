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

    struct no *curr = lista;
    while (curr->prox != NULL)
    {
        curr = curr->prox;
    }

    curr->prox = novo;
}

void print_list(struct no *lista)
{
    struct no *curr = lista;

    while (curr != NULL)
    {
        printf("%d\n", curr->info);
        curr = curr->prox;
    }
}

// Procura o valor informado e remove
void remove_value(struct no *lista, int value)
{
    struct no *curr = lista;

    // Vai ate o fim
    while (curr->prox != NULL)
    {

        // Se o no seguinte for o valor procurado, remove ele
        if (curr->prox->info == value)
        {
            curr->prox = curr->prox->prox;
            return;
        }

        curr = curr->prox;
    }
}

int main()
{
    struct no *lista = novoNo(1);

    insert_last(lista, 2);
    insert_last(lista, 3);
    insert_last(lista, 4);
    insert_last(lista, 5);

    // Lista pré remoção
    print_list(lista);

    // Remove o valor 3
    remove_value(lista, 3);

    printf("-----\n");

    // Lista pós remoção
    print_list(lista);

    return 0;
}