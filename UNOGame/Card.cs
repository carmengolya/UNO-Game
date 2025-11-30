public class Card
{
    public Colour Colour { get; set; }
    public CardType CardType { get; set; }

    public Card(Colour colour, CardType cardType)
    {
        Colour = colour;
        CardType = cardType;
    }

    public override string ToString()
    {
        string text;

        if(Colour == Colour.None)
            text = $"{CardType}";
        else
            text = $"{Colour}-{CardType}";
        
        return Colour switch
        {
            Colour.Blue   =>  $"\x1B[34m{text}\x1B[0m",
            Colour.Yellow =>  $"\x1B[33m{text}\x1B[0m",
            Colour.Red    =>  $"\x1B[31m{text}\x1B[0m",
            Colour.Green  =>  $"\x1B[32m{text}\x1B[0m",
            _             =>  text
        };
    }

    public bool CanBePlayed(Card topCard, Colour currentColour)
    {
        if(CardType == CardType.Wild || CardType == CardType.WildPlusFour)
            return true;

        if(Colour == currentColour)
            return true;

        if(CardType == topCard.CardType)
            return true;

        return false;
    }
}