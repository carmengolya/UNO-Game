public class Game
{
    private List<Player> _players = new List<Player>();
    private Deck _deck;
    private List<Card> _thrownOnes = new List<Card>();
    private int _currentPlayerIndex = 0;
    private int _direction = 1; // -1 if reversed
    private Colour _currentColour;

    public void Start()
    {
        Console.Write("Number of players (2-10): ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Name of the player {i + 1}: ");
            string? name = Console.ReadLine();
            _players.Add(new Player(name));
        }

        _deck = new Deck();

        foreach (var p in _players)
        {
            p.GetCard(_deck, 7);
        }

        Card first;
        do
        {
            first = _deck.GetCardFromDeck();
        } while(first.CardType == CardType.Wild || first.CardType == CardType.WildPlusFour);

        _thrownOnes.Add(first);
        _currentColour = first.Colour;

        Console.WriteLine($"First card on the table: {first}");

        while(true)
        {
            var player = _players[_currentPlayerIndex];
            Console.WriteLine("\n------------------------------------\n");
            Console.WriteLine($"{player.Name}'s turn");
            Console.WriteLine($"Current card on the table: {_thrownOnes.Last()}");
            Console.WriteLine($"Current colour on the table: {_currentColour}");

            Console.WriteLine(player);

            var upperCard = _thrownOnes.Last();
            var playableCards = player.Hand
                .Select((c, idx) => new { c, idx })
                .Where(x => x.c.CanBePlayed(upperCard, _currentColour))
                .ToList();

            if(playableCards.Count == 0)
            {
                Console.WriteLine($"{player.Name} can't play, draw one card!");
                player.GetCard(_deck, 1);
                NextPlayer();
                continue;
            }

            Console.WriteLine("Choose the index of one card or type -1 to draw one.");
            int choice = int.Parse(Console.ReadLine());

            if(choice == -1)
            {
                player.GetCard(_deck, 1);
                NextPlayer();
                continue;
            }

            if(choice < 0 || choice >= player.Hand.Count)
            {
                Console.WriteLine("Invalid index, next player.");
                continue;
            }

            var chosenCard = player.Hand[choice];
            if(!chosenCard.CanBePlayed(upperCard, _currentColour))
            {
                Console.WriteLine("You can't play this card! Draw one card or choose another one to play.");
                continue;
            }

            player.Hand.RemoveAt(choice);
            _thrownOnes.Add(chosenCard);

            if(player.HasNoCards)
            {
                Console.WriteLine($"\nPlayer {player.Name} has one this round!");
                break;
            }
            else if(player.HasOneCard)
            {
                Console.WriteLine($"{player.Name} says UNO!");
            }

            ApplyCardEffects(chosenCard);
        }
    }

    private void ApplyCardEffects(Card card)
    {
        if(card.Colour != Colour.None)
        {
            _currentColour = card.Colour;
        }

        switch(card.CardType)
        {
            case CardType.Skip:
                Console.WriteLine("Next player is skipped!");
                _currentColour = card.Colour;
                SkipNextPlayer();
                break;

            case CardType.Reverse:
                Console.WriteLine("Direction reversed!");
                _currentColour = card.Colour;
                if (_players.Count == 2)
                {
                    SkipNextPlayer();
                }
                else
                {
                    _direction *= -1;
                    NextPlayer();
                }
                break;

            case CardType.PlusTwo:
                _currentColour = card.Colour;
                int idxPlus2 = GetNextPlayerIndex();
                Console.WriteLine($"Next player ({_players[idxPlus2].Name}) draws 2 cards and is skipped!");
                _players[idxPlus2].GetCard(_deck, 2);
                _currentPlayerIndex = idxPlus2;
                SkipNextPlayer();
                break;

            case CardType.Wild:
                Console.WriteLine("Choose a colour: 0-Red, 1-Yellow, 2-Green, 3-Blue");
                _currentColour = (Colour)int.Parse(Console.ReadLine());
                NextPlayer();
                break;

            case CardType.WildPlusFour:
                Console.WriteLine("Choose a colour: 0-Red, 1-Yellow, 2-Green, 3-Blue");
                _currentColour = (Colour)int.Parse(Console.ReadLine());

                int idxPlus4 = GetNextPlayerIndex();
                Console.WriteLine($"Next player ({_players[idxPlus4].Name}) draws 4 cards and is skipped!");
                _players[idxPlus4].GetCard(_deck, 4);
                _currentPlayerIndex = idxPlus4;
                SkipNextPlayer();
                break;

            default:
                _currentColour = card.Colour;
                NextPlayer();
                break;
        }
    }

    private int GetNextPlayerIndex()
    {
        int count = _players.Count;
        return (_currentPlayerIndex + _direction + count) % count;
    }

    private void NextPlayer()
    {
        _currentPlayerIndex = GetNextPlayerIndex();
    }

    private void SkipNextPlayer()
    {
        int count = _players.Count;
        _currentPlayerIndex = (_currentPlayerIndex + 2 * _direction + count) % count;
    }
}