public class Game
{
    public Player currentPlayer = Player.Player1;
    public GamePieces? currentPiece;
    public int PointsRed { get; private set; }
    public int PointsBlack { get; private set; }
    private Dictionary<string, int> scores = new();
    UserInput uI = new();
    Board board = new();
    public void PrintMenu()
    {
        Console.WriteLine(@"Welcome to Checkers! Would you like to: 
                            1. Play a 2 Player Game
                            2. Play against the computer
                            3. Print the Leaderboard
                            4. Exit the Game ");
    }
    public bool IsGameOver(List<List<GamePieces?>> board)
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

    public bool IsMoveable(List<List<GamePieces?>> board, int pieceRow, int pieceColumn)
    {
        for (int row = 0; row < board.Count; row++)
        {
            for (int column = 0; column < board[row].Count; column++)
            {
                if (currentPlayer == Player.Player1 && board[pieceRow][pieceColumn] == GamePieces.Red && pieceRow >= 0 && pieceRow < board.Count && pieceColumn >= 0 && pieceColumn < board[row].Count || board[pieceRow - 1][pieceColumn + 1] == null || board[pieceRow - 1][pieceColumn - 1] == null)
                {
                    return true;
                }

                else if (currentPlayer == Player.Player1 && board[pieceRow][pieceColumn] == GamePieces.RedKing && pieceRow >= 0 && pieceRow < board.Count && pieceColumn >= 0 && pieceColumn < board[row].Count || board[pieceRow + 1][pieceColumn + 1] == null || board[pieceRow + 1][pieceColumn - 1] == null || board[pieceRow - 1][pieceColumn + 1] == null || board[pieceRow - 1][pieceColumn - 1] == null)
                {
                    return true;
                }

                else if (currentPlayer == Player.Player2 && board[pieceRow][pieceColumn] == GamePieces.Black && pieceRow >= 0 && pieceRow < board.Count && pieceColumn >= 0 && pieceColumn < board[row].Count || board[pieceRow + 1][pieceColumn + 1] == null || board[pieceRow + 1][pieceColumn - 1] == null)
                {
                    return true;
                }

                else if (currentPlayer == Player.Player2 && board[pieceRow][pieceColumn] == GamePieces.BlackKing && pieceRow >= 0 && pieceRow < board.Count && pieceColumn >= 0 && pieceColumn < board[row].Count || board[pieceRow - 1][pieceColumn + 1] == null || board[pieceRow - 1][pieceColumn - 1] == null || board[pieceRow + 1][pieceColumn + 1] == null || board[pieceRow + 1][pieceColumn - 1] == null)
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

    public void MovePiece(List<List<GamePieces?>> board, int pieceRow, int pieceColumn, int moveToRow, int moveToColumn)
    {
        if (IsMoveable(board, pieceRow, pieceColumn))
        {
            board[moveToRow][moveToColumn] = board[pieceRow][pieceColumn];
            board[pieceRow][pieceColumn] = null;
        }
        else if (IsJumpable(board, pieceRow, pieceColumn, moveToRow, moveToColumn))
        {
            board[moveToRow][moveToColumn] = board[pieceRow][pieceColumn];
            board[pieceRow + moveToRow / 2][pieceColumn + moveToColumn / 2] = null;
            board[pieceRow][pieceColumn] = null;
        }
        else
        {
            UpgradeToKing(board, pieceRow, pieceColumn, moveToRow, moveToColumn);
        }
    }

    public bool IsKing(List<List<GamePieces?>> board, int pieceRow, int pieceColumn, int moveToRow)
    {
        if (currentPlayer == Player.Player2 && board[pieceRow][pieceColumn] == GamePieces.Black && moveToRow == 7)
        {
            return true;
        }
        else if (currentPlayer == Player.Player1 && board[pieceRow][pieceColumn] == GamePieces.Red && moveToRow == 0)
        {
            return true;
        }
        return false;
    }

    public void UpgradeToKing(List<List<GamePieces?>> board, int pieceRow, int pieceColumn, int moveToRow, int moveToColumn)
    {
        if (IsKing(board, pieceRow, pieceColumn, moveToRow))
        {
            board[moveToRow][moveToColumn] = GamePieces.BlackKing;
        }
        else if(IsKing(board, pieceRow, pieceColumn, moveToRow))
        {
            board[moveToRow][moveToColumn] = GamePieces.RedKing;
        }
    }

    public bool IsJumpable(List<List<GamePieces?>> board, int pieceRow, int pieceColumn, int moveToRow, int moveToColumn)
    {
        for (int row = 0; row < board.Count; row++)
        {
            for (int column = 0; column < board[row].Count; column++)
            {
                if (currentPlayer == Player.Player1 && board[pieceRow][pieceColumn] == GamePieces.Red && pieceRow >= 0 && pieceRow < board.Count && pieceColumn >= 0 && pieceColumn < board[row].Count && board[pieceRow - 1][pieceColumn + 1] == GamePieces.Black || board[pieceRow - 1][pieceColumn - 1] == GamePieces.Black || board[pieceRow - 1][pieceColumn + 1] == GamePieces.BlackKing || board[pieceRow - 1][pieceColumn - 1] == GamePieces.BlackKing && board[moveToRow][moveToColumn] == null || board[moveToRow][moveToColumn] == null)
                {
                    return true;
                }
                else if (currentPlayer == Player.Player1 && board[pieceRow][pieceColumn] == GamePieces.RedKing && pieceRow >= 0 && pieceRow < board.Count && pieceColumn >= 0 && pieceColumn < board[row].Count && board[pieceRow + 1][pieceColumn + 1] == GamePieces.Black || board[pieceRow + 1][pieceColumn - 1] == GamePieces.Black || board[pieceRow - 1][pieceColumn + 1] == GamePieces.Black || board[pieceRow - 1][pieceColumn - 1] == GamePieces.Black || board[pieceRow + 1][pieceColumn + 1] == GamePieces.BlackKing || board[pieceRow + 1][pieceColumn - 1] == GamePieces.BlackKing || board[pieceRow - 1][pieceColumn + 1] == GamePieces.BlackKing || board[pieceRow - 1][pieceColumn - 1] == GamePieces.BlackKing && board[moveToRow][moveToColumn] == null || board[moveToRow][moveToColumn] == null || board[moveToRow][moveToColumn] == null || board[moveToRow][moveToColumn] == null)
                {
                    return true;
                }
                else if (currentPlayer == Player.Player2 && board[pieceRow][pieceColumn] == GamePieces.Black && pieceRow >= 0 && pieceRow < board.Count && pieceColumn >= 0 && pieceColumn < board[row].Count && board[pieceRow + 1][pieceColumn + 1] == GamePieces.Red || board[pieceRow + 1][pieceColumn - 1] == GamePieces.Red || board[pieceRow + 1][pieceColumn + 1] == GamePieces.RedKing || board[pieceRow + 1][pieceColumn - 1] == GamePieces.RedKing && board[pieceRow + 2][pieceColumn + 2] == null || board[pieceRow + 2][pieceColumn - 2] == null)
                {
                    return true;
                }
                else if (currentPlayer == Player.Player2 && board[pieceRow][pieceColumn] == GamePieces.BlackKing && pieceRow >= 0 && pieceRow < board.Count && pieceColumn >= 0 && pieceColumn < board[row].Count && board[pieceRow + 1][pieceColumn + 1] == GamePieces.Red || board[pieceRow + 1][pieceColumn - 1] == GamePieces.Red || board[pieceRow - 1][pieceColumn + 1] == GamePieces.Red || board[pieceRow - 1][pieceColumn - 1] == GamePieces.Red || board[pieceRow + 1][pieceColumn + 1] == GamePieces.RedKing || board[pieceRow + 1][pieceColumn - 1] == GamePieces.RedKing || board[pieceRow - 1][pieceColumn + 1] == GamePieces.RedKing || board[pieceRow - 1][pieceColumn - 1] == GamePieces.RedKing && board[moveToRow][moveToColumn] == null || board[moveToRow][moveToColumn] == null || board[moveToRow][moveToColumn] == null || board[moveToRow][moveToColumn] == null)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void PlayGame()
    {
        while (true)//!IsGameOver(board.board))
        {
            board.PrintBoard();
            (int pieceRow, int pieceColumn) = uI.GetUserPieceCoordinates();
            (int moveToRow, int moveToColumn) = uI.GetUserEmptyCoordinates();
            MovePiece(board.board, pieceRow, pieceColumn, moveToRow, moveToColumn);
            SwitchPlayer();

        }
        Console.Clear();
        IsWinner();

    }

    public void PlayGameWithComputer()
    {

    }

    // public void AddScores()
    // {
    //     if (IsGameOver())
    //     {
    //         scores[player1] = PointsBlack;
    //         scores[player2] = PointsRed;
    //     }
    // }

    // public void PrintScores()
    // {
    //     foreach (var score in scores)
    //     {
    //         Console.WriteLine(score);
    //     }
    // }

    // public void SaveScores()
    // {
    //     foreach (var score in scores)
    //     {
    //         File.WriteAllText("Scores.txt",    );
    //     }
    // }
}



