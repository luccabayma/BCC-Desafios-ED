public enum TipoPokemon
{
    Fogo,
    Agua,
    Grama
}

public static class TipoPokemonExtension
{
    // Verifica se o tipo possui vantagem no ataque
    public static double PegarVantagem(this TipoPokemon atacante, TipoPokemon defensor)
    {
        if (atacante == TipoPokemon.Fogo && defensor == TipoPokemon.Grama)
            return 2.0;

        if (atacante == TipoPokemon.Agua && defensor == TipoPokemon.Fogo)
            return 2.0;

        if (atacante == TipoPokemon.Grama && defensor == TipoPokemon.Agua)
            return 2.0;

        return 1.0;
    }

    // Verifica se o tipo recebe menos dano
    public static double ReceberMenosDano(this TipoPokemon defensor, TipoPokemon atacante)
    {
        if (atacante == TipoPokemon.Fogo && defensor == TipoPokemon.Agua)
            return 0.5;

        if (atacante == TipoPokemon.Agua && defensor == TipoPokemon.Grama)
            return 0.5;

        if (atacante == TipoPokemon.Grama && defensor == TipoPokemon.Fogo)
            return 0.5;

        return 1.0;
    }
}