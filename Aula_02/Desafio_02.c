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

void bubbleSort(ListaLigada lista)
{

    // Verifica se a lista esta vazia
    if (lista == NULL || lista->inicio == NULL)
        return;

    int temp, trocou;

    // Percorre a lista varias vezes
    for (Celula i = lista->inicio; i != NULL; i = i->prox)
    {

        trocou = 0;

        // Compara elementos vizinhos
        for (Celula j = lista->inicio; j->prox != NULL; j = j->prox)
        {

            // Se estiver fora de ordem, troca os valores
            if (j->info > j->prox->info)
            {

                temp = j->info;
                j->info = j->prox->info;
                j->prox->info = temp;

                trocou = 1;
            }
        }

        // Se nenhuma troca foi feita, a lista ja esta ordenada
        if (trocou == 0)
        {
            break;
        }
    }
}

int main()
{
    ListaLigada lista = novaLista();

    // Insere os numeros de 10 ate 1 na lista
    for (int i = 10; i >= 1; i--)
    {
        llInsereNoFim(lista, i);
    }

    // Lista antes da ordenacao
    llPrint(lista);

    bubbleSort(lista);

    // Lista apos a ordenacao
    llPrint(lista);

    return 0;
}