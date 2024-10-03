foreach (int color in Enum.GetValues(typeof(CardColor)))
{
    foreach (int rank in Enum.GetValues(typeof(CardRank)))
    {   
        Card card = new Card( (CardColor)color, (CardRank) rank);
        Console.WriteLine($"The {card.Color} {card.Rank}" );
    }
}

class Card(CardColor color, CardRank rank)
{
    public CardColor Color { get; } = color;
    public CardRank Rank { get; } = rank;

    public bool IsSymbolCard => Rank is CardRank.Dollar or CardRank.Percent or CardRank.Caret or CardRank.Ampersand;
    public bool IsNumberCard => !IsSymbolCard;
   
}

enum CardColor
{
    Red,
    Green,
    Blue,
    Yellow
}

enum CardRank
{
    One,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Dollar,
    Percent,
    Caret,
    Ampersand
}