using System.Drawing;

public class Deck
{
    private Stack<Card> _cards;
    private static Random _rnd = new Random();

    public Deck()
    {
        var cardList = new List<Card>();

        var colours = new[] {Colour.Blue, Colour.Green, Colour.Red, Colour.Yellow};
        var types = new[] {CardType.One, CardType.Two, CardType.Three, CardType.Four, 
                           CardType.Five, CardType.Six, CardType.Seven, CardType.Eight, 
                           CardType.Nine
                        };
        foreach(Colour c in colours)
        {
            // 4 zero cards(one per each colour)
            cardList.Add(new Card(c, CardType.Zero));
            
            foreach(CardType ct in types)
            {
                // two cards per colour, 8 cards in total for numbers 1 through 9
                cardList.Add(new Card(c, ct));
                cardList.Add(new Card(c, ct));
            }

            // two cards per colour, 8 cards in total for Skip card
            cardList.Add(new Card(c, CardType.Skip));
            cardList.Add(new Card(c, CardType.Skip));

            // two cards per colour, 8 cards in total for Reverse card
            cardList.Add(new Card(c, CardType.Reverse));
            cardList.Add(new Card(c, CardType.Reverse));

            // two cards per colour, 8 cards in total for PlusTwo card
            cardList.Add(new Card(c, CardType.PlusTwo));
            cardList.Add(new Card(c, CardType.PlusTwo));
        }

        for(int i = 0; i < 4; i++)
        {
            cardList.Add(new Card(Colour.None, CardType.Wild));
            cardList.Add(new Card(Colour.None, CardType.WildPlusFour));
        }

        cardList = cardList.OrderBy(x => _rnd.Next()).ToList();
        _cards = new Stack<Card>(cardList);
    }

    public Card GetCardFromDeck()
    {
        if(_cards.Count == 0)
            throw new InvalidOperationException("[DECK] The deck is empty!");

        return _cards.Pop();
    }

    public void RefillFromDiscard(List<Card> thrownOnes)
    {
        Card top = thrownOnes.Last();
        var cardsToShuffle = thrownOnes.Take(thrownOnes.Count- 1).ToList();
        _cards.Clear();

        foreach(var c in cardsToShuffle)
            _cards.Push(c);

        var shuffled = cardsToShuffle.OrderBy(x => _rnd.Next()).ToList();
        _cards = new Stack<Card>(shuffled);
    }

    public int CardsNumber => _cards.Count;
}