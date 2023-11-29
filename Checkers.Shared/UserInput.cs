public struct UserInput : IUserInput
{

    public int GetUserMenuSelection()
    {
        bool successful = int.TryParse(Console.ReadLine(), out int userMenuSelection);
        if (!successful)
        {
            Console.WriteLine("I need a number from 1 to 4.");
            return GetUserMenuSelection();
        }
        return userMenuSelection;
    }

    public (int, int) GetUserPieceCoordinates()
    {
        Console.WriteLine("Enter the Row and Column of the piece you want to move and then the Row and Column of where you want it moved to.");
        Console.Write("The Row of the piece: ");
        bool successful = int.TryParse(Console.ReadLine(), out int userPieceRow);
        if (!successful)
        {
            Console.WriteLine("I need a number from 0 to 7");
            return GetUserPieceCoordinates();
        }
        Console.Write("The Column of the piece: ");
        successful = int.TryParse(Console.ReadLine(), out int userPieceColumn);
        if (!successful)
        {
            Console.WriteLine("I need a number from 0 to 7");
            return GetUserPieceCoordinates();
        }
        return (userPieceRow, userPieceColumn);
    }

    public (int, int) GetUserEmptyCoordinates()
    {
        Console.Write("The Row you want to move to: ");
        bool successful = int.TryParse(Console.ReadLine(), out int userRowToMoveTo);
        if (!successful)
        {
            Console.WriteLine("I need a number from 0 to 7");
            return GetUserEmptyCoordinates();
        }
        Console.Write("The Column you want to move to: ");
        successful = int.TryParse(Console.ReadLine(), out int userColumnToMoveTo);
        if (!successful)
        {
            Console.WriteLine("I need a number from 0 to 7");
            return GetUserEmptyCoordinates();
        }
        return (userRowToMoveTo, userColumnToMoveTo);
    }

    public (string?, string?) GetUserName()
    {
        Console.Write("Player1 please enter your name: ");
        string? userName1 = Console.ReadLine();
        Console.Write("\nPlayer2 please enter your name: ");
        string? userName2 = Console.ReadLine();
        return(userName1, userName2);
    }
}