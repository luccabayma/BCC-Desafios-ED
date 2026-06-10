public class PokemonAgua : Pokemon
{
    public PokemonAgua(string nome, int ataque, int defesa, int vida)
        : base(nome, ataque, defesa, vida, TipoPokemon.Agua)
    {
    }

    public override string AtacaAtaca(Pokemon alvo)
    {
        string textoAtaque = CalcularEAplicarDano(alvo, Ataque);

        // Recupera vida apos atacar
        this.Vida += 2;

        // Impede que a vida ultrapasse o limite
        if (this.Vida > this.VidaMaxima)
            this.Vida = this.VidaMaxima;

        return textoAtaque +
               $"\n{Nome} recuperou 2 pontos de vida.";
    }
}