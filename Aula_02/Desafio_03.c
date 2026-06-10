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

// Insere um elemento mantendo a lista ordenada
void insereOrdenado(ListaLigada lista, int info)
{

    Celula nova = novaCelula(info);

    // Verifica lista vazia
    if (lista->inicio == NULL)
    {
        lista->inicio = nova;
        lista->fim = nova;
        return;
    }

    // Ve se o valor é menor que o primeiro elemento
    if (info < lista->inicio->info)
    {
        nova->prox = lista->inicio;
        lista->inicio = nova;
        return;
    }

    Celula atual = lista->inicio;

    // Procura a posicao certa para inserir
    while (atual->prox != NULL && atual->prox->info < info)
    {
        atual = atual->prox;
    }

    nova->prox = atual->prox;
    atual->prox = nova;

    // Atualiza o fim caso o elemento seja inserido no final
    if (nova->prox == NULL)
    {
        lista->fim = nova;
    }
}

int main()
{

    ListaLigada lista = novaLista();

    // Insere os elementos mantendo a ordem
    insereOrdenado(lista, 10);
    insereOrdenado(lista, 5);
    insereOrdenado(lista, 8);
    insereOrdenado(lista, 1);
    insereOrdenado(lista, 7);

    // Exibe a lista na ordem
    llPrint(lista);

    return 0;
}