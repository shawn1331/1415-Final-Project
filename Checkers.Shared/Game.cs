public class Game : Board // 2nd class & Inheritance
{
    public Player currentPlayer = Player.Player1;
    private readonly GamePieces? currentPiece;
    private bool Player1Turn { get; set; } = true;
    public bool exit = false;
    public int RedCount { get; set; } = 0;
    public int BlackCount { get; set; } = 0;
    static public void PrintMenu()//static function
    {
        Console.WriteLine(@"Welcome to Checkers! Would you like to: 
                            1. Play a 2 Player Game
                            2. Print the Leaderboard
                            3. Exit the Game ");
    }

    public void CoinFlip()
    {
        Random rand = new();
        int evenOrOdd = rand.Next(1, 21);
        if (evenOrOdd % 2 == 1)
        {
            SwitchPlayer();
        }
        else
        {

        }
    }
    public bool IsGameOver() 
    {
        BlackCount = 0;
        RedCount = 0;
        for (int i = 0; i < board.Count; i++)
        {
            for (int j = 0; j < board[i].Count; j++)
            {
                // Console.WriteLine($"Checking position {i},{j} {board[i][j]}");
                if (board[i][j]?.Symbol == GamePieces.Black?.Symbol || board[i][j]?.Symbol == GamePieces.BlackKing?.Symbol)
                {
                    BlackCount++;
                }
                else if (board[i][j]?.Symbol == GamePieces.Red?.Symbol || board[i][j]?.Symbol == GamePieces.RedKing?.Symbol)
                {
                    RedCount++;
                }
            }
        }
        // Console.WriteLine($"Blackcount:{BlackCount}, Redcount:{RedCount}");
        if (BlackCount > 0 && RedCount > 0)
        {
            return false;
        }
        else if (RedCount == 0)
        {
            return true;
        }
        else if (BlackCount == 0)
        {
            return true;
        }
        else if (RedCount < 3)
        {
            Console.WriteLine($"Red do you surrender? You only have {RedCount} pieces left. y/n?");
            string surrender = Console.ReadLine().ToLower();
            if (surrender == "y" || surrender == "yes")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (BlackCount < 3)
        {
            Console.WriteLine($"Black do you surrender? You only have {BlackCount} pieces left. y/n?");
            string surrender = Console.ReadLine().ToLower();
            if (surrender == "y" || surrender == "yes")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    public void IsWinner()
    {
        if (Player1Turn == true)
        {
            Console.Write("/nBlack wins congratulations!");
        }
        else if (Player1Turn == false)
        {
            Console.Write("/nRed wins congratulations!");
        }
    }

    public bool IsMoveable(int pieceRow, int pieceColumn, int moveToRow, int moveToColumn)
    {
        if (Player1Turn == true && board[pieceRow][pieceColumn]?.Symbol == GamePieces.Red?.Symbol && board[moveToRow][moveToColumn] == null
        && pieceRow - 1 == moveToRow
        && pieceColumn - 1 == moveToColumn || pieceColumn + 1 == moveToColumn)
        {
            return true;
        }
        else if (Player1Turn == true && board[pieceRow][pieceColumn]?.Symbol == GamePieces.RedKing?.Symbol && board[moveToRow][moveToColumn] == null
        && (pieceRow - 1 == moveToRow || pieceRow + 1 == moveToRow)
        && pieceColumn - 1 == moveToColumn || pieceColumn + 1 == moveToColumn)
        {
            return true;
        }
        else if (Player1Turn == false && board[pieceRow][pieceColumn]?.Symbol == GamePieces.Black?.Symbol && board[moveToRow][moveToColumn] == null
        && pieceRow + 1 == moveToRow
        && pieceColumn + 1 == moveToColumn || pieceColumn - 1 == moveToColumn)
        {
            return true;
        }
        else if (Player1Turn == false && board[pieceRow][pieceColumn]?.Symbol == GamePieces.BlackKing?.Symbol && board[moveToRow][moveToColumn] == null
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

    public void MovePiece(int pieceRow, int pieceColumn, int moveToRow, int moveToColumn, Leaderboard leaderBoard)
    {
        if (board[pieceRow][pieceColumn] == null)
        {
            throw new NullReferenceException($"Cannot move piece, piece not found at {pieceRow} {pieceColumn}.");
        }
        else if (IsMoveable(pieceRow, pieceColumn, moveToRow, moveToColumn) && !IsJumpable(pieceRow, pieceColumn, moveToRow, moveToColumn))
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
        UpgradeToKing(pieceRow, moveToRow, moveToColumn, leaderBoard);
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

    private void UpgradeToKing(int pieceRow, int moveToRow, int moveToColumn, Leaderboard leaderBoard)
    {
        if (IsKing(moveToRow) && moveToRow == 7 && pieceRow == 5 || pieceRow == 6)
        {
            board[moveToRow][moveToColumn] = GamePieces.BlackKing;
            leaderBoard.PointsBlack += 15;
        }
        else if (IsKing(moveToRow) && moveToRow == 0 && pieceRow == 1 || pieceRow == 2)
        {
            board[moveToRow][moveToColumn] = GamePieces.RedKing;
            leaderBoard.PointsRed += 15;
        }
    }
    public bool IsJumpable(int pieceRow, int pieceColumn, int moveToRow, int moveToColumn)
    {
        if (Player1Turn == true && board[pieceRow][pieceColumn] == GamePieces.Red && (board[pieceRow - 1][pieceColumn + 1] == GamePieces.Black || board[pieceRow - 1][pieceColumn - 1] == GamePieces.Black || board[pieceRow - 1][pieceColumn + 1] == GamePieces.BlackKing || board[pieceRow - 1][pieceColumn - 1] == GamePieces.BlackKing)
        && board[moveToRow][moveToColumn] == null && pieceRow - 2 == moveToRow
        && pieceColumn - 2 == moveToColumn || pieceColumn + 2 == moveToColumn)
        {
            return true;
        }

        else if (Player1Turn == true && board[pieceRow][pieceColumn] == GamePieces.RedKing && (board[pieceRow + 1][pieceColumn + 1] == GamePieces.Black || board[pieceRow + 1][pieceColumn - 1] == GamePieces.Black || board[pieceRow - 1][pieceColumn + 1] == GamePieces.Black || board[pieceRow - 1][pieceColumn - 1] == GamePieces.Black || board[pieceRow + 1][pieceColumn + 1] == GamePieces.BlackKing || board[pieceRow + 1][pieceColumn - 1] == GamePieces.BlackKing || board[pieceRow - 1][pieceColumn + 1] == GamePieces.BlackKing || board[pieceRow - 1][pieceColumn - 1] == GamePieces.BlackKing)
        && board[moveToRow][moveToColumn] == null
        && pieceRow + 2 == moveToRow || pieceRow - 2 == moveToRow
        && pieceColumn + 2 == moveToColumn || pieceColumn - 2 == moveToColumn)
        {
            return true;
        }

        else if (Player1Turn == false && board[pieceRow][pieceColumn] == GamePieces.Black && (board[pieceRow + 1][pieceColumn + 1] == GamePieces.Red || board[pieceRow + 1][pieceColumn - 1] == GamePieces.Red || board[pieceRow + 1][pieceColumn + 1] == GamePieces.RedKing || board[pieceRow + 1][pieceColumn - 1] == GamePieces.RedKing)
        && board[moveToRow][moveToColumn] == null
        && pieceRow + 2 == moveToRow
        && pieceColumn - 2 == moveToColumn || pieceColumn + 2 == moveToColumn)
        {
            return true;
        }

        else if (Player1Turn == false && board[pieceRow][pieceColumn] == GamePieces.BlackKing && (board[pieceRow + 1][pieceColumn + 1] == GamePieces.Red || board[pieceRow + 1][pieceColumn - 1] == GamePieces.Red || board[pieceRow - 1][pieceColumn + 1] == GamePieces.Red || board[pieceRow - 1][pieceColumn - 1] == GamePieces.Red || board[pieceRow + 1][pieceColumn + 1] == GamePieces.RedKing || board[pieceRow + 1][pieceColumn - 1] == GamePieces.RedKing || board[pieceRow - 1][pieceColumn + 1] == GamePieces.RedKing || board[pieceRow - 1][pieceColumn - 1] == GamePieces.RedKing)
        && board[moveToRow][moveToColumn] == null
        && pieceRow + 2 == moveToRow || pieceRow - 2 == moveToRow
        && pieceColumn + 2 == moveToColumn || pieceColumn - 2 == moveToColumn)
        {
            return true;
        }
        return false;
    }
    public string PlayerSurrender()
    {
        if (Player1Turn == true)
        {
            Console.Write($"Red do you surrender? You only have {RedCount} pieces left! y/n");
            string redSurrender = Console.ReadLine().ToLower();
            return redSurrender;
        }
        else
        {
            Console.Write($"Black do you surrender? You only have {BlackCount} pieces left! y/n?");
            string blackSurrender = Console.ReadLine().ToLower();
            return blackSurrender;
        }
    }
}