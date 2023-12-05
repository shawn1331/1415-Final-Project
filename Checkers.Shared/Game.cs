public class Game : Board // 2nd class & Inheritance
{
    public Player currentPlayer = Player.Player1;
    public GamePieces? currentPiece;
    private bool Player1Turn { get; set; } = true;
    public bool exit = false;
    static public void PrintMenu()//static function
    {
        Console.WriteLine(@"Welcome to Checkers! Would you like to: 
                            1. Play a 2 Player Game
                            2. Play against the computer
                            3. Print the Leaderboard
                            4. Exit the Game ");
    }
    public void HandleMenuOptions(int menuSelection)
    {
        var uI = new UserInput();
        var leaderBoard = new Leaderboard();
        if (menuSelection == 1)
        {
            CoinFlip();
            var (redPlayer, blackPlayer) = uI.GetPlayerNames();
            PlayGame();
        }
        else if (menuSelection == 2)
        {

        }
        else if (menuSelection == 3)
        {
            Leaderboard.LeaderboardOptions();
            int leaderboardOption = uI.GetUserMenuSelection();
            if (leaderboardOption == 1)
            {
                leaderBoard.PrintAllNamesAndScores();
            }
            else if (leaderboardOption == 2)
            {
                leaderBoard.PrintAllNames();
            }
            else if (leaderboardOption == 3)
            {
                leaderBoard.Print5HighestScores();
            }
            else if (leaderboardOption == 4)
            {
                leaderBoard.Print5NamesWithHighestScore();
            }
        }
        else if (menuSelection == 4)
        {
            exit = true;
        }
    }
    public void CoinFlip()
    {
        Random rand = new Random();
        int evenOrOdd = rand.Next(1, 21);
        if (evenOrOdd % 2 == 0)
        {
            Player1Turn = true;
        }
        else
        {
            Player1Turn = false;
            SwitchPlayer();
        }
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
        // if (pieceRow < 0 || pieceColumn < 0 || pieceRow > 7 || pieceColumn > 7)
        // {
        //     return false;
        // }
        // else if (moveToRow < 0 || moveToColumn < 0 || moveToRow > 7 || moveToColumn > 7)
        // {
        //     return false;
        // }
        if (Player1Turn == true && board[pieceRow][pieceColumn] == GamePieces.Red && board[moveToRow][moveToColumn] == null
        && pieceRow - 1 == moveToRow
        && pieceColumn - 1 == moveToColumn || pieceColumn + 1 == moveToColumn)
        {
            return true;
        }
        else if (Player1Turn == true && board[pieceRow][pieceColumn] == GamePieces.RedKing && board[moveToRow][moveToColumn] == null
        && (pieceRow - 1 == moveToRow || pieceRow + 1 == moveToRow)
        && pieceColumn - 1 == moveToColumn || pieceColumn + 1 == moveToColumn)
        {
            return true;
        }
        else if (Player1Turn == false && board[pieceRow][pieceColumn] == GamePieces.Black && board[moveToRow][moveToColumn] == null
        && pieceRow + 1 == moveToRow
        && pieceColumn + 1 == moveToColumn || pieceColumn - 1 == moveToColumn)
        {
            return true;
        }
        else if (Player1Turn == false && board[pieceRow][pieceColumn] == GamePieces.BlackKing && board[moveToRow][moveToColumn] == null
        && (pieceRow + 1 == moveToRow || pieceRow - 1 == moveToRow)
        && pieceColumn + 1 == moveToColumn || pieceColumn - 1 == moveToColumn)
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
        var leaderBoard = new Leaderboard();
        if (IsMoveable(pieceRow, pieceColumn, moveToRow, moveToColumn) && !IsJumpable(pieceRow, pieceColumn, moveToRow, moveToColumn))
        {
            board[moveToRow][moveToColumn] = board[pieceRow][pieceColumn];
            board[pieceRow][pieceColumn] = null;
            if (Player1Turn == true)
            {
                leaderBoard.PointsRed += 5;
            }
            else
            {
                leaderBoard.PointsBlack += 5;
            }
        }
        else if (IsJumpable(pieceRow, pieceColumn, moveToRow, moveToColumn) && !IsMoveable(pieceRow, pieceColumn, moveToRow, moveToColumn))
        {
            board[moveToRow][moveToColumn] = board[pieceRow][pieceColumn];
            board[(pieceRow + moveToRow) / 2][(pieceColumn + moveToColumn) / 2] = null;
            board[pieceRow][pieceColumn] = null;
            if (Player1Turn == true)
            {
                leaderBoard.PointsRed += 10;
            }
            else
            {
                leaderBoard.PointsBlack += 10;
            }
        }
        else if (IsJumpable(pieceRow, pieceColumn, moveToRow, moveToColumn) && IsMoveable(pieceRow, pieceColumn, moveToRow, moveToColumn))
        {
            if ((pieceRow + 2 == moveToRow || pieceRow - 2 == moveToRow) && (pieceColumn + 2 == moveToColumn || pieceColumn - 2 == moveToColumn))
            {
                board[moveToRow][moveToColumn] = board[pieceRow][pieceColumn];
                board[(pieceRow + moveToRow) / 2][(pieceColumn + moveToColumn) / 2] = null;
                board[pieceRow][pieceColumn] = null;
                if (Player1Turn == true)
                {
                    leaderBoard.PointsRed += 10;
                }
                else
                {
                    leaderBoard.PointsBlack += 10;
                }
            }
            else
            {
                board[moveToRow][moveToColumn] = board[pieceRow][pieceColumn];
                board[pieceRow][pieceColumn] = null;
                if (Player1Turn == true)
                {
                    leaderBoard.PointsRed += 5;
                }
                else
                {
                    leaderBoard.PointsBlack += 5;
                }
            }
        }
        UpgradeToKing(pieceRow, pieceColumn, moveToRow, moveToColumn);
        SwitchPlayer();
    }

    private bool IsKing(int moveToRow)
    {
        if (Player1Turn == false && moveToRow == 7)
        {
            return true;
        }
        else if (Player1Turn == true && moveToRow == 0)
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
        // if (pieceRow < 0 || pieceColumn < 0 || pieceRow > 7 || pieceColumn > 7)
        // {
        //     return false;
        // }

        // else if (moveToRow < 0 || moveToColumn < 0 || moveToRow > 7 || moveToColumn > 7)
        // {
        //     return false;
        // }

         if (Player1Turn == true && board[pieceRow][pieceColumn] == GamePieces.Red && (board[pieceRow - 1][pieceColumn + 1] == GamePieces.Black || board[pieceRow - 1][pieceColumn - 1] == GamePieces.Black || board[pieceRow - 1][pieceColumn + 1] == GamePieces.BlackKing || board[pieceRow - 1][pieceColumn - 1] == GamePieces.BlackKing)
        && board[moveToRow][moveToColumn] == null && pieceRow - 2 == moveToRow
        || pieceColumn - 2 == moveToColumn || pieceColumn + 2 == moveToColumn)
        {
            return true;
        }

        else if (Player1Turn == true && board[pieceRow][pieceColumn] == GamePieces.RedKing && (board[pieceRow + 1][pieceColumn + 1] == GamePieces.Black || board[pieceRow + 1][pieceColumn - 1] == GamePieces.Black || board[pieceRow - 1][pieceColumn + 1] == GamePieces.Black || board[pieceRow - 1][pieceColumn - 1] == GamePieces.Black || board[pieceRow + 1][pieceColumn + 1] == GamePieces.BlackKing || board[pieceRow + 1][pieceColumn - 1] == GamePieces.BlackKing || board[pieceRow - 1][pieceColumn + 1] == GamePieces.BlackKing || board[pieceRow - 1][pieceColumn - 1] == GamePieces.BlackKing)
        && board[moveToRow][moveToColumn] == null
        || pieceRow + 2 == moveToRow || pieceRow - 2 == moveToRow
        || pieceColumn + 2 == moveToColumn || pieceColumn - 2 == moveToColumn)
        {
            return true;
        }

        else if (Player1Turn == false && board[pieceRow][pieceColumn] == GamePieces.Black && (board[pieceRow + 1][pieceColumn + 1] == GamePieces.Red || board[pieceRow + 1][pieceColumn - 1] == GamePieces.Red || board[pieceRow + 1][pieceColumn + 1] == GamePieces.RedKing || board[pieceRow + 1][pieceColumn - 1] == GamePieces.RedKing)
        && board[moveToRow][moveToColumn] == null
        && pieceRow + 2 == moveToRow
        || pieceColumn - 2 == moveToColumn || pieceColumn + 2 == moveToColumn)
        {
            return true;
        }

        else if (Player1Turn == false && board[pieceRow][pieceColumn] == GamePieces.BlackKing && (board[pieceRow + 1][pieceColumn + 1] == GamePieces.Red || board[pieceRow + 1][pieceColumn - 1] == GamePieces.Red || board[pieceRow - 1][pieceColumn + 1] == GamePieces.Red || board[pieceRow - 1][pieceColumn - 1] == GamePieces.Red || board[pieceRow + 1][pieceColumn + 1] == GamePieces.RedKing || board[pieceRow + 1][pieceColumn - 1] == GamePieces.RedKing || board[pieceRow - 1][pieceColumn + 1] == GamePieces.RedKing || board[pieceRow - 1][pieceColumn - 1] == GamePieces.RedKing)
        && board[moveToRow][moveToColumn] == null
        || pieceRow + 2 == moveToRow || pieceRow - 2 == moveToRow
        || pieceColumn + 2 == moveToColumn || pieceColumn - 2 == moveToColumn)
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
}