#include <stdio.h>
#include <stdlib.h>

typedef struct no
{
    int info;
    struct no *prox;
} No;

typedef No *Celula;

typedef struct lista
{
    Celula inicio;
    Celula fim;
} Lista;

typedef Lista *ListaLigada;

ListaLigada novaLista()
{
    ListaLigada l = malloc(sizeof(Lista));
    if (!l)
        return NULL;

    l->inicio = NULL;
    l->fim = NULL;

    return l;
}

Celula novaCelula(int info)
{
    Celula celula = (Celula)malloc(sizeof(No));

    celula->info = info;
    celula->prox = NULL;

    return celula;
}

void llPrint(ListaLigada lista)
{

    for (Celula aux = lista->inicio; aux != NULL; aux = aux->prox)
    {
        printf("%d", aux->info);

        if (aux->prox != NULL)
            printf(" -> ");
    }

    printf("\n");
}

void llInsereNoFim(ListaLigada lista, int info)
{
    Celula nova = novaCelula(info);

    // Se a lista estiver vazia, o novo no sera o inicio e fim
    if (lista->inicio == NULL)
    {
        lista->inicio = nova;
        lista->fim = nova;
        return;
    }

    lista->fim->prox = nova;

    lista->fim = nova;
}

int somaLista(ListaLigada lista)
{
    int soma = 0;

    // Percorre a lista soamnado os valores
    for (Celula aux = lista->inicio; aux != NULL; aux = aux->prox)
    {
        soma += aux->info;
    }

    return soma;
}

int main()
{
    ListaLigada lista = novaLista();

    // Insere os numeros de 1 a 10 na lista
    for (int i = 1; i <= 10; i++)
    {
        llInsereNoFim(lista, i);
    }

    llPrint(lista);

    int soma = somaLista(lista);

    printf("\nA soma é de %d", soma);

    return 0;
}