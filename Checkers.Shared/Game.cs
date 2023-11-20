public class Game : Board
{
    public Player currentPlayer = Player.Player1;
    public GamePieces? currentPiece;
    public void PrintMenu()
    {
        Console.WriteLine(@"Welcome to Checkers! Would you like to: 
                            1. Play a 2 Player Game
                            2. Play against the computer
                            3. Print the Leaderboard
                            4. Exit the Game ");
    }
    public bool IsGameOver()
    {
        return false;
    }

    public void IsWinner()
    {

    }

    public bool IsMoveable()
    {
        for (int row = 0; row < board.Count; row++)
        {
            for (int column = 0; column < board[row].Count; column++)
            {
                if (currentPiece == GamePieces.Red && row >= 0 && row < board.Count && board[row - 1][column + 1] == null || board[row - 1][column - 1] == null)
                {
                    return true;
                }

                else if (currentPiece == GamePieces.RedKing && board[row + 1][column + 1] == null || board[row + 1][column - 1] == null || board[row - 1][column + 1] == null || board[row - 1][column - 1] == null)
                {
                    return true;
                }

                else if (currentPiece == GamePieces.Black && board[row + 1][column + 1] == null || board[row + 1][column - 1] == null)
                {
                    return true;
                }

                else if (currentPiece == GamePieces.BlackKing && board[row - 1][column + 1] == null || board[row - 1][column - 1] == null || board[row + 1][column + 1] == null || board[row + 1][column - 1] == null)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void SwitchPlayer()
    {
        if (currentPlayer == Player.Player1)
        {
            currentPlayer = Player.Player2;
        }
        else
        {
            currentPlayer = Player.Player1;
        }
    }

    public void MovePiece(int pieceRow, int pieceColumn, int movetoRow, int moveToColumn)
    {
        if (IsMoveable())
        {
            for (int row = 0; row < board.Count; row++)
            {
                for (int column = 0; column < board[row].Count; column++)
                {
                    board[pieceRow][pieceColumn] = null;
                    board[movetoRow][moveToColumn] = currentPiece;
                }
            }
        }
        SwitchPlayer();
    }

    public bool IsKing()
    {
        return false;
    }

    public bool IsJumpable()
    {
        return false;
    }

}