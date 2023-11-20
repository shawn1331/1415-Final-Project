using System.Text;
public class Board 
{
    public List<List<GamePieces?>> board { get; } = new List<List<GamePieces?>>
    {
        new List<GamePieces?>()  {null, GamePieces.Black, null, GamePieces.Black, null, GamePieces.Black, null, GamePieces.Black },
        new List<GamePieces?>()  {GamePieces.Black, null, GamePieces.Black, null, GamePieces.Black, null, GamePieces.Black, null},
        new List<GamePieces?>()  {null, GamePieces.Black, null, GamePieces.Black, null, GamePieces.Black, null, GamePieces.Black},
        new List<GamePieces?>()  {null, null, null, null, null, null, null, null},
        new List<GamePieces?>()  {null, null, null, null, null, null, null, null},
        new List<GamePieces?>()  {GamePieces.Red, null, GamePieces.Red, null, GamePieces.Red, null, GamePieces.Red, null},
        new List<GamePieces?>()  {null, GamePieces.Red, null, GamePieces.Red, null, GamePieces.Red, null, GamePieces.Red},
        new List<GamePieces?>()  {GamePieces.Red, null, GamePieces.Red, null, GamePieces.Red, null, GamePieces.Red, null}
    };

    public string GamePiecesToString(GamePieces? currentPiece)
    {
        return currentPiece?.ToString()?? "  ";
        // for (int i = 0; i < board.Count; i++)
        // {
        //     for (int j = 0; j < board[i].Count; j++)
        //     {
        //         if (currentPiece == GamePieces.Black)
        //         {
        //             return currentPiece?.ToString();
        //         }
        //         else if (currentPiece == GamePieces.Red)
        //         {
        //             return "🔴";
        //         }
        //         else if (currentPiece == GamePieces.BlackKing)
        //         {
        //             return "⬛";
        //         }
        //         else if (currentPiece == GamePieces.RedKing)
        //         {
        //             return "🟥";
        //         }
        //         else
        //         {
        //             return "  ";
        //         }
        //     }
        // }
        // return null;
    }

    public string BoardAsString()
    {
        StringBuilder boardString = new StringBuilder();
        boardString.Append("  0  1  2  3  4  5  6  7" + Environment.NewLine);
        boardString.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        boardString.Append($"0|{GamePiecesToString(board[0][0])}|{GamePiecesToString(board[0][1])}|{GamePiecesToString(board[0][2])}|{GamePiecesToString(board[0][3])}|{GamePiecesToString(board[0][4])}|{GamePiecesToString(board[0][5])}|{GamePiecesToString(board[0][6])}|{GamePiecesToString(board[0][7])}|" + Environment.NewLine);
        boardString.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        boardString.Append($"1|{GamePiecesToString(board[1][0])}|{GamePiecesToString(board[1][1])}|{GamePiecesToString(board[1][2])}|{GamePiecesToString(board[1][3])}|{GamePiecesToString(board[1][4])}|{GamePiecesToString(board[1][5])}|{GamePiecesToString(board[1][6])}|{GamePiecesToString(board[1][7])}|" + Environment.NewLine);
        boardString.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        boardString.Append($"2|{GamePiecesToString(board[2][0])}|{GamePiecesToString(board[2][1])}|{GamePiecesToString(board[2][2])}|{GamePiecesToString(board[2][3])}|{GamePiecesToString(board[2][4])}|{GamePiecesToString(board[2][5])}|{GamePiecesToString(board[2][6])}|{GamePiecesToString(board[2][7])}|" + Environment.NewLine);
        boardString.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        boardString.Append($"3|{GamePiecesToString(board[3][0])}|{GamePiecesToString(board[3][1])}|{GamePiecesToString(board[3][2])}|{GamePiecesToString(board[3][3])}|{GamePiecesToString(board[3][4])}|{GamePiecesToString(board[3][5])}|{GamePiecesToString(board[3][6])}|{GamePiecesToString(board[3][7])}|" + Environment.NewLine);
        boardString.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        boardString.Append($"4|{GamePiecesToString(board[4][0])}|{GamePiecesToString(board[4][1])}|{GamePiecesToString(board[4][2])}|{GamePiecesToString(board[4][3])}|{GamePiecesToString(board[4][4])}|{GamePiecesToString(board[4][5])}|{GamePiecesToString(board[4][6])}|{GamePiecesToString(board[4][7])}|" + Environment.NewLine);
        boardString.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        boardString.Append($"5|{GamePiecesToString(board[5][0])}|{GamePiecesToString(board[5][1])}|{GamePiecesToString(board[5][2])}|{GamePiecesToString(board[5][3])}|{GamePiecesToString(board[5][4])}|{GamePiecesToString(board[5][5])}|{GamePiecesToString(board[5][6])}|{GamePiecesToString(board[5][7])}|" + Environment.NewLine);
        boardString.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        boardString.Append($"6|{GamePiecesToString(board[6][0])}|{GamePiecesToString(board[6][1])}|{GamePiecesToString(board[6][2])}|{GamePiecesToString(board[6][3])}|{GamePiecesToString(board[6][4])}|{GamePiecesToString(board[6][5])}|{GamePiecesToString(board[6][6])}|{GamePiecesToString(board[6][7])}|" + Environment.NewLine);
        boardString.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        boardString.Append($"7|{GamePiecesToString(board[7][0])}|{GamePiecesToString(board[7][1])}|{GamePiecesToString(board[7][2])}|{GamePiecesToString(board[7][3])}|{GamePiecesToString(board[7][4])}|{GamePiecesToString(board[7][5])}|{GamePiecesToString(board[7][6])}|{GamePiecesToString(board[7][7])}|" + Environment.NewLine);
        boardString.Append(" +--+--+--+--+--+--+--+--+");
        return boardString.ToString();
    }

    public void PrintBoard()
    {
        Console.Clear();
        string checkerBoard = BoardAsString();
        for (int i = 0; i < checkerBoard.Length; i++)
        {
            Console.Write(checkerBoard[i]);
        }
    }

   
}
    

