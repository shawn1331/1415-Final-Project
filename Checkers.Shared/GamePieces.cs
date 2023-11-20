public class GamePieces
{
    public string Symbol { get; set; }
    public GamePieces()
    {
      
    }

    public GamePieces(string symbol)
    {
        Symbol = symbol;
    }

    public override string ToString()
    {
        return Symbol;
    }

    public static GamePieces Black => new ("⚫");
    public static GamePieces Red => new ("🔴");
    public static GamePieces BlackKing => new ("⬛");
    public static GamePieces RedKing => new ("🟥");
}