public class Game : Board // 2nd class
{
    public Player currentPlayer = Player.Player1;
    public GamePieces? currentPiece;
    private bool Player1Turn { get; set; } = true;
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

    public bool IsMoveable(int pieceRow, int pieceColumn, int moveToRow, int moveToColumn)
    {
        if (pieceRow < 1 || pieceColumn < 1 || pieceRow > 8 || pieceColumn > 8)
        {
            return false;
        }
        else if (moveToRow < 1 || moveToColumn < 1 || moveToRow > 8 || moveToColumn > 8)
        {
            return false;
        }
        else if (Player1Turn == true && board[pieceRow][pieceColumn] == GamePieces.Red && board[moveToRow][moveToColumn] == null && (board[pieceRow - 1][pieceColumn - 1] == board[moveToRow][moveToColumn] || board[pieceRow - 1][pieceColumn + 1] == board[moveToRow][moveToColumn]))
        {
            return true;
        }
        else if (Player1Turn == true && board[pieceRow][pieceColumn] == GamePieces.RedKing && board[moveToRow][moveToColumn] == null && (board[pieceRow + 1][pieceColumn + 1] == board[moveToRow][moveToColumn] || board[pieceRow + 1][pieceColumn - 1] == board[moveToRow][moveToColumn] || board[pieceRow - 1][pieceColumn + 1] == board[moveToRow][moveToColumn] || board[pieceRow - 1][pieceColumn - 1] == board[moveToRow][moveToColumn]))
        {
            return true;
        }
        else if (Player1Turn == false && board[pieceRow][pieceColumn] == GamePieces.Black && board[moveToRow][moveToColumn] == null && (board[pieceRow + 1][pieceColumn + 1] == board[moveToRow][moveToColumn] || board[pieceRow + 1][pieceColumn - 1] == board[moveToRow][moveToColumn]))
        {
            return true;
        }
        else if (Player1Turn == false && board[pieceRow][pieceColumn] == GamePieces.BlackKing && board[moveToRow][moveToColumn] == null && (board[pieceRow - 1][pieceColumn + 1] == board[moveToRow][moveToColumn] || board[pieceRow - 1][pieceColumn - 1] == board[moveToRow][moveToColumn] || board[pieceRow + 1][pieceColumn + 1] == board[moveToRow][moveToColumn] || board[pieceRow + 1][pieceColumn - 1] == board[moveToRow][moveToColumn]))
        {
            return true;
        }
        return false;
    }

    public void SwitchPlayer()
    {
        if (currentPlayer == Player.Player1)
        {
            currentPlayer = Player.Player2;
            Player1Turn = false;
        }
        else
        {
            currentPlayer = Player.Player1;
            Player1Turn = true;
        }
    }

    public void MovePiece(int pieceRow, int pieceColumn, int moveToRow, int moveToColumn)
    {
        if (IsMoveable(pieceRow, pieceColumn, moveToRow, moveToColumn) && !IsJumpable(pieceRow, pieceColumn, moveToRow, moveToColumn))
        {
            board[moveToRow][moveToColumn] = board[pieceRow][pieceColumn];
            board[pieceRow][pieceColumn] = null;
        }
        else if (IsJumpable(pieceRow, pieceColumn, moveToRow, moveToColumn) && !IsMoveable(pieceRow, pieceColumn, moveToRow, moveToColumn))
        {
            board[moveToRow][moveToColumn] = board[pieceRow][pieceColumn];
            board[(pieceRow + moveToRow) / 2][(pieceColumn + moveToColumn) / 2] = null;
            board[pieceRow][pieceColumn] = null;
        }
        else if (IsJumpable(pieceRow, pieceColumn, moveToRow, moveToColumn) && IsMoveable(pieceRow, pieceColumn, moveToRow, moveToColumn))
        {
            if (board[pieceRow + 2][pieceColumn + 2] == board[moveToRow][moveToColumn] || board[pieceRow + 2][pieceColumn - 2] == board[moveToRow][moveToColumn] || board[pieceRow - 2][pieceColumn - 2] == board[moveToRow][moveToColumn] || board[pieceRow - 2][pieceColumn + 2] == board[moveToRow][moveToColumn])
            {
                board[moveToRow][moveToColumn] = board[pieceRow][pieceColumn];
                board[(pieceRow + moveToRow) / 2][(pieceColumn + moveToColumn) / 2] = null;
                board[pieceRow][pieceColumn] = null;
            }
            else
            {
                board[moveToRow][moveToColumn] = board[pieceRow][pieceColumn];
                board[pieceRow][pieceColumn] = null;
            }
        }
        UpgradeToKing(pieceRow, pieceColumn, moveToRow, moveToColumn);
        SwitchPlayer();
    }

    public bool IsKing(int pieceRow, int pieceColumn, int moveToRow, int moveToColumn)
    {
        if (Player1Turn == false && moveToRow == 8)
        {
            return true;
        }
        else if (Player1Turn == true && moveToRow == 1)
        {
            return true;
        }
        return false;
    }

    public void UpgradeToKing(int pieceRow, int pieceColumn, int moveToRow, int moveToColumn)
    {
        if (IsKing(pieceRow, pieceColumn, moveToRow, moveToColumn))
        {
            board[moveToRow][moveToColumn] = GamePieces.BlackKing;
        }
        else if (IsKing(pieceRow, pieceColumn, moveToRow, moveToColumn))
        {
            board[moveToRow][moveToColumn] = GamePieces.RedKing;
        }
    }

    public bool IsJumpable(int pieceRow, int pieceColumn, int moveToRow, int moveToColumn)
    {
        if (pieceRow < 1 || pieceColumn < 1 || pieceRow > 8 || pieceColumn > 8)
        {
            return false;
        }

        else if (moveToRow < 1 || moveToColumn < 1 || moveToRow > 8 || moveToColumn > 8)
        {
            return false;
        }

        else if (Player1Turn == true && board[pieceRow][pieceColumn] == GamePieces.Red && (board[pieceRow - 1][pieceColumn + 1] == GamePieces.Black || board[pieceRow - 1][pieceColumn - 1] == GamePieces.Black || board[pieceRow - 1][pieceColumn + 1] == GamePieces.BlackKing || board[pieceRow - 1][pieceColumn - 1] == GamePieces.BlackKing) && board[moveToRow][moveToColumn] == null && (board[moveToRow][moveToColumn] == board[pieceRow - 2][pieceColumn + 2] || board[moveToRow][moveToColumn] == board[pieceRow - 2][pieceColumn - 2]))
        {
            return true;
        }

        else if (Player1Turn == true && board[pieceRow][pieceColumn] == GamePieces.RedKing && (board[pieceRow + 1][pieceColumn + 1] == GamePieces.Black || board[pieceRow + 1][pieceColumn - 1] == GamePieces.Black || board[pieceRow - 1][pieceColumn + 1] == GamePieces.Black || board[pieceRow - 1][pieceColumn - 1] == GamePieces.Black || board[pieceRow + 1][pieceColumn + 1] == GamePieces.BlackKing || board[pieceRow + 1][pieceColumn - 1] == GamePieces.BlackKing || board[pieceRow - 1][pieceColumn + 1] == GamePieces.BlackKing || board[pieceRow - 1][pieceColumn - 1] == GamePieces.BlackKing) && board[moveToRow][moveToColumn] == null && (board[moveToRow][moveToColumn] == board[pieceRow + 2][pieceColumn + 2] || board[moveToRow][moveToColumn] == board[pieceRow + 2][pieceColumn - 2] || board[moveToRow][moveToColumn] == board[pieceRow - 2][pieceColumn + 2] || board[moveToRow][moveToColumn] == board[pieceRow - 2][pieceColumn - 2]))
        {
            return true;
        }

        else if (Player1Turn == false && board[pieceRow][pieceColumn] == GamePieces.Black && (board[pieceRow + 1][pieceColumn + 1] == GamePieces.Red || board[pieceRow + 1][pieceColumn - 1] == GamePieces.Red || board[pieceRow + 1][pieceColumn + 1] == GamePieces.RedKing || board[pieceRow + 1][pieceColumn - 1] == GamePieces.RedKing) && board[moveToRow][moveToColumn] == null && (board[pieceRow + 2][pieceColumn + 2] == board[moveToRow][moveToColumn] || board[pieceRow + 2][pieceColumn - 2] == board[moveToRow][moveToColumn]))
        {
            return true;
        }

        else if (Player1Turn == false && board[pieceRow][pieceColumn] == GamePieces.BlackKing && (board[pieceRow + 1][pieceColumn + 1] == GamePieces.Red || board[pieceRow + 1][pieceColumn - 1] == GamePieces.Red || board[pieceRow - 1][pieceColumn + 1] == GamePieces.Red || board[pieceRow - 1][pieceColumn - 1] == GamePieces.Red || board[pieceRow + 1][pieceColumn + 1] == GamePieces.RedKing || board[pieceRow + 1][pieceColumn - 1] == GamePieces.RedKing || board[pieceRow - 1][pieceColumn + 1] == GamePieces.RedKing || board[pieceRow - 1][pieceColumn - 1] == GamePieces.RedKing) && board[moveToRow][moveToColumn] == null && (board[moveToRow][moveToColumn] == board[pieceRow + 2][pieceColumn + 2] || board[moveToRow][moveToColumn] == board[pieceRow + 2][pieceColumn - 2] || board[moveToRow][moveToColumn] == board[pieceRow - 2][pieceColumn + 2] || board[moveToRow][moveToColumn] == board[pieceRow - 2][pieceColumn - 2]))
        {
            return true;
        }
        return false;
    }

    public void PlayGame()
    {
        while (true)//!IsGameOver(board.board))
        {
            PrintBoard();
            (int pieceRow, int pieceColumn) = uI.GetUserPieceCoordinates();
            (int moveToRow, int moveToColumn) = uI.GetUserEmptyCoordinates();
            MovePiece(pieceRow, pieceColumn, moveToRow, moveToColumn);
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



