// Shawn Miner 11/10/23 Checkers 1415 Final Project
Game game = new Game();
Board board = new Board();
UserInput input = new();
bool exit = false;
Console.BackgroundColor = ConsoleColor.DarkGray;
Console.ForegroundColor = ConsoleColor.White;
while (exit == false)
{
    game.PrintMenu();
    int menuSelection = input.GetUserMenuSelection();
    if (menuSelection == 1)
    {

    }
    else if (menuSelection == 2)
    {

    }
    else if (menuSelection == 3)
    {

    }
    else if (menuSelection == 4)
    {
        exit = true;
    }
    
}
Console.BackgroundColor = ConsoleColor.Black;
