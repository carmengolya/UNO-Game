public class Player
{
    public string Name { get; set; }
    public List<Card> Hand { get; set; } = new List<Card>();

    public Player(string name)
    {
        Name = name;
    }

    public void GetCard(Deck deck, int number = 1)
    {
        for (int i = 0; i < number; i++)
        {
            var card = deck.GetCardFromDeck();
            if (card != null)
                Hand.Add(card);
        }
    }

    public override string ToString()
    {
        string result = $"Hand of {Name}:";
        for (int i = 0; i < Hand.Count; i++)
        {
            result += $"({i}){Hand[i]}; ";
        }

        return result;
    }

    public bool HasOneCard => Hand.Count == 1;
    public bool HasNoCards => Hand.Count == 0;
}