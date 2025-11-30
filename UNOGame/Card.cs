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

    public int GetScoreValue()
    {
        switch(CardType)
        {
            case CardType.Zero:  return 0;
            case CardType.One:   return 1;
            case CardType.Two:   return 2;
            case CardType.Three: return 3;
            case CardType.Four:  return 4;
            case CardType.Five:  return 5;
            case CardType.Six:   return 6;
            case CardType.Seven: return 7;
            case CardType.Eight: return 8;
            case CardType.Nine:  return 9;

            case CardType.Skip:
            case CardType.Reverse:
            case CardType.PlusTwo:
                return 20;

            case CardType.Wild:
            case CardType.WildPlusFour:
                return 50;

            default: return 0;
        }
    }
}