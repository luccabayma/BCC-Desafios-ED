using System;

public class PokemonGrama : Pokemon
{
    public PokemonGrama(string nome, int ataque, int defesa, int vida)
        : base(nome, ataque, defesa, vida, TipoPokemon.Grama)
    {
    }

    public override string AtacaAtaca(Pokemon alvo)
    {
        int ataqueFinal = Ataque;

        // Sorteia a chance de ataque critico
        bool ataqueCritico = random.Next(100) < 20;

        // Dobra o ataque em caso de critico
        if (ataqueCritico)
        {
            ataqueFinal *= 2;
        }

        string textoAtaque = CalcularEAplicarDano(alvo, ataqueFinal);

        // Exibe uma mensagem quando o critico acontecer
        if (ataqueCritico)
        {
            return $"Ataque critico!\n{textoAtaque}";
        }

        return textoAtaque;
    }
}