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
        if(Colour == Colour.None)
            return $"{CardType}";
        return $"{Colour}-{CardType}";
    }

    public bool CanBePlayed(Card otherCard, Colour currentColour)
    {
        if(CardType == CardType.Wild || CardType == CardType.WildPlusFour)
            return true;

        if(Colour == currentColour)
            return true;

        if(CardType == otherCard.CardType)
            return true;

        return false;
    }
}