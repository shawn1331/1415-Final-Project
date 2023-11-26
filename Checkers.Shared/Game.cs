public class Game : Board
{
    public Player currentPlayer = Player.Player1;
    public GamePieces? currentPiece;
    public int PointsRed { get; private set; }
    public int PointsBlack { get; private set; }
    private Dictionary<string, int> scores = new();
    UserInput uI = new();
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
        int blackCount = 0;
        int redCount = 0;
        for (int i = 0; i < board.Count; i++)
        {
            for (int j = 0; j < board[i].Count; j++)
            {
                if (board[i][j] == GamePieces.Black || board[i][j] == GamePieces.BlackKing)
                {
                    blackCount++;
                }
                else if (board[i][j] == GamePieces.Red || board[i][j] == GamePieces.RedKing)
                {
                    redCount++;
                }
            }
        }
        if (blackCount > 0 && redCount > 0)
        {
            return false;
        }
        else if (redCount == 0)
        {
            return true;
        }
        else if (blackCount == 0)
        {
            return true;
        }
        return false;
    }

    public void IsWinner()
    {

    }

    public bool IsMoveable(int pieceRow, int pieceColumn)
    {
        for (int row = 0; row < board.Count; row++)
        {
            for (int column = 0; column < board[row].Count; column++)
            {
                if (currentPiece == GamePieces.Red && pieceRow >= 0 && pieceRow < board.Count && pieceColumn >= 0 && pieceColumn < board[row].Count && board[pieceRow - 1][pieceColumn + 1] == null || board[pieceRow - 1][pieceColumn - 1] == null)
                {
                    return true;
                }

                else if (currentPiece == GamePieces.RedKing && pieceRow >= 0 && pieceRow < board.Count && pieceColumn >= 0 && pieceColumn < board[row].Count && board[pieceRow + 1][pieceColumn + 1] == null || board[pieceRow + 1][pieceColumn - 1] == null || board[pieceRow - 1][pieceColumn + 1] == null || board[pieceRow - 1][pieceColumn - 1] == null)
                {
                    return true;
                }

                else if (currentPiece == GamePieces.Black && pieceRow >= 0 && pieceRow < board.Count && pieceColumn >= 0 && pieceColumn < board[row].Count && board[pieceRow + 1][pieceColumn + 1] == null || board[pieceRow + 1][pieceColumn - 1] == null)
                {
                    return true;
                }

                else if (currentPiece == GamePieces.BlackKing && pieceRow >= 0 && pieceRow < board.Count && pieceColumn >= 0 && pieceColumn < board[row].Count && board[pieceRow - 1][pieceColumn + 1] == null || board[pieceRow - 1][pieceColumn - 1] == null || board[pieceRow + 1][pieceColumn + 1] == null || board[pieceRow + 1][pieceColumn - 1] == null)
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
        if (IsMoveable(pieceRow, pieceColumn))
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
        else if (IsJumpable(pieceRow, pieceColumn))
        {
            board[pieceRow][pieceColumn] = null;
            board[pieceRow + movetoRow / 2][pieceColumn + moveToColumn / 2] = null;
            board[movetoRow][moveToColumn] = currentPiece;
        }
    }

    public bool IsKing(int moveToRow, int moveToColumn)
    {
        if (currentPiece == GamePieces.Black && moveToRow == 7)
        {
            return true;
        }
        else if (currentPiece == GamePieces.Red && moveToRow == 0)
        {
            return true;
        }
        return false;
    }

    public bool IsJumpable(int pieceRow, int pieceColumn)
    {
        for (int row = 0; row < board.Count; row++)
        {
            for (int column = 0; column < board[row].Count; column++)
            {
                if (currentPiece == GamePieces.Red && pieceRow >= 0 && pieceRow < board.Count && pieceColumn >= 0 && pieceColumn < board[row].Count && board[pieceRow - 1][pieceColumn + 1] == GamePieces.Black || board[pieceRow - 1][pieceColumn - 1] == GamePieces.Black || board[pieceRow - 1][pieceColumn + 1] == GamePieces.BlackKing || board[pieceRow - 1][pieceColumn - 1] == GamePieces.BlackKing)
                {
                    if (board[pieceRow - 2][pieceColumn + 2] == null || board[pieceRow - 2][pieceColumn - 2] == null)
                    {
                        return true;
                    }
                }
                else if (currentPiece == GamePieces.RedKing && pieceRow >= 0 && pieceRow < board.Count && pieceColumn >= 0 && pieceColumn < board[row].Count && board[pieceRow + 1][pieceColumn + 1] == null || board[pieceRow + 1][pieceColumn - 1] == null || board[pieceRow - 1][pieceColumn + 1] == null || board[pieceRow - 1][pieceColumn - 1] == null)
                {
                    return true;
                }

                else if (currentPiece == GamePieces.Black && pieceRow >= 0 && pieceRow < board.Count && pieceColumn >= 0 && pieceColumn < board[row].Count && board[pieceRow + 1][pieceColumn + 1] == null || board[pieceRow + 1][pieceColumn - 1] == null)
                {
                    return true;
                }

                else if (currentPiece == GamePieces.BlackKing && pieceRow >= 0 && pieceRow < board.Count && pieceColumn >= 0 && pieceColumn < board[row].Count && board[pieceRow - 1][pieceColumn + 1] == null || board[pieceRow - 1][pieceColumn - 1] == null || board[pieceRow + 1][pieceColumn + 1] == null || board[pieceRow + 1][pieceColumn - 1] == null)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void PlayGame()
    {
        while (!IsGameOver())
        {
            (int pieceRow, int pieceColumn) = uI.GetUserPieceCoordinates();
            (int moveToRow, int moveToColumn) = uI.GetUserEmptyCoordinates();
            MovePiece(pieceRow, pieceColumn, moveToRow, moveToColumn);

        }
        Console.Clear();
        IsWinner();

    }

    public void PlayGameWithComputer()
    {

    }

    public void AddScores()
    {
        if (IsGameOver())
        {
            scores[player1] = PointsBlack;
            scores[player2] = PointsRed;
        }
    }

    public void PrintScores()
    {
        foreach (var score in scores)
        {
            Console.WriteLine(score);
        }
    }

    // public void SaveScores()
    // {
    //     foreach (var score in scores)
    //     {
    //         File.WriteAllText("Scores.txt",    );
    //     }
    // }
}



