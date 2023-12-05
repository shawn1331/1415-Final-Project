public struct UserInput : IUserInput  // use of a struct & interface inheritance
{

    public int GetUserMenuSelection()
    {
        bool successful = int.TryParse(Console.ReadLine(), out int userMenuSelection);
        if (!successful || userMenuSelection > 4 || userMenuSelection < 1)
        {
            Console.WriteLine("I need a number from 1 to 4.");
            return GetUserMenuSelection();// recursion & input validation
        }
        return userMenuSelection;
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
        return(userRed, userBlack);
    }
}