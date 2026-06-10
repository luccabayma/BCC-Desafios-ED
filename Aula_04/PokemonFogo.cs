public class PokemonFogo : Pokemon
{
    public PokemonFogo(string nome, int ataque, int defesa, int vida)
        : base(nome, ataque, defesa, vida, TipoPokemon.Fogo)
    {
    }

    public override string AtacaAtaca(Pokemon alvo)
    {
        // Pokemon de fogo causa dano extra
        return CalcularEAplicarDano(alvo, Ataque + 2);
    }
}