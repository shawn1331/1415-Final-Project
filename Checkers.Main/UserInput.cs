public struct UserInput : IUserInput  // use of a struct & interface inheritance
{

    public int GetUserMenuSelection()
    {
        bool successful = int.TryParse(Console.ReadLine(), out int userMenuSelection);
        if (!successful || userMenuSelection > 3 || userMenuSelection < 1)
        {
            Console.WriteLine("I need a number from 1 to 3.");
            return GetUserMenuSelection();// recursion & input validation
        }
        return userMenuSelection;
    }
    public int GetUserLeaderboardOption()
    {
        bool successful = int.TryParse(Console.ReadLine(), out int userLeaderboardOption);
        if (!successful || userLeaderboardOption > 4 || userLeaderboardOption < 1)
        {
            Console.WriteLine("I need a number from 1 to 4.");
            return GetUserLeaderboardOption();// recursion & input validation
        }
        return userLeaderboardOption;
    }
    public (int, int) GetUserPieceCoordinates()
    {
        Console.WriteLine("Enter the Row and Column of the piece you want to move and then the Row and Column of where you want it moved to.");
        Console.Write("The Row of the piece: ");

        bool successful = int.TryParse(Console.ReadLine(), out int userPieceRow);
        if (!successful || userPieceRow > 7 || userPieceRow < 0)
        {
            Console.WriteLine("I need a number from 0 to 7");
            return GetUserPieceCoordinates();//recursion & input validation
        }
        Console.Write("The Column of the piece: ");
        successful = int.TryParse(Console.ReadLine(), out int userPieceColumn);
        if (!successful || userPieceColumn > 7 || userPieceColumn < 0)
        {
            Console.WriteLine("I need a number from 0 to 7");
            return GetUserPieceCoordinates();//recursion & input validation
        }

        return (userPieceRow, userPieceColumn);
    }

    public (int, int) GetUserEmptyCoordinates()
    {
        Console.Write("The Row you want to move to: ");
        bool successful = int.TryParse(Console.ReadLine(), out int userRowToMoveTo);
        if (!successful || userRowToMoveTo > 7 || userRowToMoveTo < 0)
        {
            Console.WriteLine("I need a number from 0 to 7");
            return GetUserEmptyCoordinates();//recursion & input validation
        }
        Console.Write("The Column you want to move to: ");
        successful = int.TryParse(Console.ReadLine(), out int userColumnToMoveTo);
        if (!successful || userColumnToMoveTo > 7 || userColumnToMoveTo < 0)
        {
            Console.WriteLine("I need a number from 0 to 7");
            return GetUserEmptyCoordinates();//recursion & input validation
        }
        return (userRowToMoveTo, userColumnToMoveTo);
    }

    public (string?, string?) GetPlayerNames()
    {
        Console.Write("Red please enter your name: ");
        string? userRed = Console.ReadLine();
        Console.Write("\nBlack please enter your name: ");
        string? userBlack = Console.ReadLine();
        if (userRed == " " || userBlack == " ")
        {
            Console.WriteLine("You must enter a name, it cannot be blank.");
            return GetPlayerNames();// recurison & input validation
        }
        return (userRed, userBlack);
    }

    public void HandleMenuOptions(Game game, int menuSelection, Leaderboard leaderBoard)
    {
        if (menuSelection == 1)
        {
            game.CoinFlip();
            try
            {
                PlayGame(game, leaderBoard);
            }
            catch (NullReferenceException)
            {

            }
        }
        else if (menuSelection == 2)
        {
            Leaderboard.LeaderboardOptions();
            int leaderboardOption = GetUserLeaderboardOption();
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
        else if (menuSelection == 3)
        {
            game.exit = true;
        }
    }

    public void PlayGame(Game game, Leaderboard leaderBoard)
    {
        while (!game.IsGameOver())
        {
            game.PrintBoard();
            game.IsGameOver();
            if (game.currentPlayer == Player.Player1)
            {
                Console.WriteLine("Reds turn.");
            }
            else
            {
                Console.WriteLine("Blacks turn");
            }
            (int pieceRow, int pieceColumn) = GetUserPieceCoordinates();
            (int moveToRow, int moveToColumn) = GetUserEmptyCoordinates();
            game.MovePiece(pieceRow, pieceColumn, moveToRow, moveToColumn, leaderBoard);
        }
        Console.Clear();
        game.IsWinner();
    }
}