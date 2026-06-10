using System;
using Spectre.Console;

public abstract class Pokemon
{
    public string Nome { get; set; }
    public int Ataque { get; set; }
    public int Defesa { get; set; }
    public int Vida { get; set; }
    public int VidaMaxima { get; set; }
    public TipoPokemon Tipo { get; protected set; }

    protected static Random random = new Random();

    public Pokemon(string nome, int ataque, int defesa, int vida, TipoPokemon tipo)
    {
        Nome = nome;
        Ataque = ataque;
        Defesa = defesa;
        Vida = vida;
        VidaMaxima = vida;
        Tipo = tipo;
    }

    // Exibe os dados do pokemon
    public void ExibirStatus()
    {
        Console.WriteLine($"{Nome} - Tipo: {Tipo}, Vida: {Vida}/{VidaMaxima}, Ataque: {Ataque}, Defesa: {Defesa}");
    }

    public abstract void Atacar(Pokemon alvo);

    public Panel MontarPainelStatus(bool mostrarVidaCompleta)
    {
        double porcentagemVida = (double)Vida / VidaMaxima;
        int quantidadeBlocos = (int)Math.Ceiling(porcentagemVida * 12);

        // Mantem a barra dentro dos limites
        if (quantidadeBlocos < 0)
        {
            quantidadeBlocos = 0;
        }

        if (quantidadeBlocos > 12)
        {
            quantidadeBlocos = 12;
        }

        string barraVida = new string('█', quantidadeBlocos)
                         + new string('░', 12 - quantidadeBlocos);

        string corVida = porcentagemVida > 0.5 ? "green" : "red";

        string texto = $"[bold]{Nome}[/] [{Tipo}]\n";
        texto += $"HP [{corVida}]{barraVida}[/]\n";

        // Mostra os pontos de vida atuais
        if (mostrarVidaCompleta)
        {
            texto += $"{Vida}/{VidaMaxima}";
        }

        return new Panel(new Markup(texto))
            .Border(BoxBorder.Rounded);
    }

    // Calcula o dano causado ao alvo
    protected int CalcularDano(Pokemon alvo, int ataqueUsado)
    {
        int dano = ataqueUsado - alvo.Defesa;

        // Garante que o dano minimo seja 1
        if (dano < 1)
        {
            dano = 1;
        }

        return dano;
    }

    // Aplica o dano ao pokemon alvo
    protected void AplicarDano(Pokemon alvo, int dano)
    {
        alvo.Vida -= dano;

        // Evita que a vida fique negativa
        if (alvo.Vida < 0)
        {
            alvo.Vida = 0;
        }
    }
}