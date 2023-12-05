public class GamePieces  // 3rd class
{
    public string? Symbol { get; set; }//auto property
    public GamePieces()
    {

    }

    public GamePieces(string symbol)
    {
        Symbol = symbol;
    }

    public override string ToString()//overriding a method
    {
        return Symbol;
    }

    public static GamePieces? Black => new("⚫");
    public static GamePieces? Red => new("🔴");
    public static GamePieces? BlackKing => new("⬛");
    public static GamePieces? RedKing => new("🟥");
}