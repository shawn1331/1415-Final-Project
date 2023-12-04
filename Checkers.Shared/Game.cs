public class Game : Board // 2nd class Inheritance
{
    public Player currentPlayer = Player.Player1;
    public GamePieces? currentPiece;
    private bool Player1Turn { get; set; } = true;
    public int PointsRed { get; private set; }
    public int PointsBlack { get; private set; }
    private Dictionary<string, int> Leaderboard = new();
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
        if (pieceRow < 0 || pieceColumn < 0 || pieceRow > 7 || pieceColumn > 7)
        {
            return false;
        }
        else if (moveToRow < 0 || moveToColumn < 0 || moveToRow > 7 || moveToColumn > 7)
        {
            return false;
        }
        else if (Player1Turn == true && board[pieceRow][pieceColumn] == GamePieces.Red && board[moveToRow][moveToColumn] == null && pieceRow - 1 == moveToRow && (pieceColumn - 1 == moveToColumn || pieceColumn + 1 == moveToColumn))
        {
            return true;
        }
        else if (Player1Turn == true && board[pieceRow][pieceColumn] == GamePieces.RedKing && board[moveToRow][moveToColumn] == null && (pieceRow - 1 == moveToRow || pieceRow + 1 == moveToRow) && (pieceColumn - 1 == moveToColumn || pieceColumn + 1 == moveToColumn))
        {
            return true;
        }
        else if (Player1Turn == false && board[pieceRow][pieceColumn] == GamePieces.Black && board[moveToRow][moveToColumn] == null && pieceRow + 1 == moveToRow && (pieceColumn + 1 == moveToColumn || pieceColumn - 1 == moveToColumn))
        {
            return true;
        }
        else if (Player1Turn == false && board[pieceRow][pieceColumn] == GamePieces.BlackKing && board[moveToRow][moveToColumn] == null && (pieceRow + 1 == moveToRow || pieceRow - 1 == moveToRow) && (pieceColumn + 1 == moveToColumn || pieceColumn - 1 == moveToColumn))
        {
            return true;
        }
        return false;
    }

    private void SwitchPlayer()
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
            if ((pieceRow + 2 == moveToRow || pieceRow - 2 == moveToRow) && (pieceColumn + 2 == moveToColumn || pieceColumn - 2 == moveToColumn))
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

    private bool IsKing(int moveToRow)
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

    private void UpgradeToKing(int pieceRow, int pieceColumn, int moveToRow, int moveToColumn)
    {
        if (IsKing(moveToRow))
        {
            board[moveToRow][moveToColumn] = GamePieces.BlackKing;
        }
        else if (IsKing(moveToRow))
        {
            board[moveToRow][moveToColumn] = GamePieces.RedKing;
        }
    }

    public bool IsJumpable(int pieceRow, int pieceColumn, int moveToRow, int moveToColumn)
    {
        if (pieceRow < 0 || pieceColumn < 0 || pieceRow > 7 || pieceColumn > 7)
        {
            return false;
        }

        else if (moveToRow < 0 || moveToColumn < 0 || moveToRow > 7 || moveToColumn > 7)
        {
            return false;
        }

        else if (Player1Turn == true && board[pieceRow][pieceColumn] == GamePieces.Red && (board[pieceRow - 1][pieceColumn + 1] == GamePieces.Black || board[pieceRow - 1][pieceColumn - 1] == GamePieces.Black || board[pieceRow - 1][pieceColumn + 1] == GamePieces.BlackKing || board[pieceRow - 1][pieceColumn - 1] == GamePieces.BlackKing) && board[moveToRow][moveToColumn] == null && pieceRow - 2 == moveToRow && (pieceColumn - 2 == moveToColumn || pieceColumn + 2 == moveToColumn))
        {
            return true;
        }

        else if (Player1Turn == true && board[pieceRow][pieceColumn] == GamePieces.RedKing && (board[pieceRow + 1][pieceColumn + 1] == GamePieces.Black || board[pieceRow + 1][pieceColumn - 1] == GamePieces.Black || board[pieceRow - 1][pieceColumn + 1] == GamePieces.Black || board[pieceRow - 1][pieceColumn - 1] == GamePieces.Black || board[pieceRow + 1][pieceColumn + 1] == GamePieces.BlackKing || board[pieceRow + 1][pieceColumn - 1] == GamePieces.BlackKing || board[pieceRow - 1][pieceColumn + 1] == GamePieces.BlackKing || board[pieceRow - 1][pieceColumn - 1] == GamePieces.BlackKing) && board[moveToRow][moveToColumn] == null && (pieceRow + 2 == moveToRow || pieceRow - 2 == moveToRow) && (pieceColumn + 2 == moveToColumn || pieceColumn - 2 == moveToColumn))
        {
            return true;
        }

        else if (Player1Turn == false && board[pieceRow][pieceColumn] == GamePieces.Black && (board[pieceRow + 1][pieceColumn + 1] == GamePieces.Red || board[pieceRow + 1][pieceColumn - 1] == GamePieces.Red || board[pieceRow + 1][pieceColumn + 1] == GamePieces.RedKing || board[pieceRow + 1][pieceColumn - 1] == GamePieces.RedKing) && board[moveToRow][moveToColumn] == null && pieceRow + 2 == moveToRow && (pieceColumn - 2 == moveToColumn || pieceColumn + 2 == moveToColumn))
        {
            return true;
        }

        else if (Player1Turn == false && board[pieceRow][pieceColumn] == GamePieces.BlackKing && (board[pieceRow + 1][pieceColumn + 1] == GamePieces.Red || board[pieceRow + 1][pieceColumn - 1] == GamePieces.Red || board[pieceRow - 1][pieceColumn + 1] == GamePieces.Red || board[pieceRow - 1][pieceColumn - 1] == GamePieces.Red || board[pieceRow + 1][pieceColumn + 1] == GamePieces.RedKing || board[pieceRow + 1][pieceColumn - 1] == GamePieces.RedKing || board[pieceRow - 1][pieceColumn + 1] == GamePieces.RedKing || board[pieceRow - 1][pieceColumn - 1] == GamePieces.RedKing) && board[moveToRow][moveToColumn] == null && (pieceRow + 2 == moveToRow || pieceRow - 2 == moveToRow) && (pieceColumn + 2 == moveToColumn || pieceColumn - 2 == moveToColumn))
        {
            return true;
        }
        return false;
    }

    public void PlayGame()
    {
        var uI = new UserInput();
        while (true)//!IsGameOver(board.board))
        {
            PrintBoard();
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



