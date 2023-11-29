// Shawn Miner 11/10/23 Checkers 1415 Final Project
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Game game = new Game();
Board board = new Board();
UserInput input = new();
bool exit = false;
Console.BackgroundColor = ConsoleColor.DarkGray;
// Console.ForegroundColor = ConsoleColor.White;

while (true)
{
    game.PlayGame();
}

// while (exit == false)
// {
//     game.PrintMenu();
//     int menuSelection = input.GetUserMenuSelection();
//     if (menuSelection == 1)
//     {
//         game.PlayGame();
//     }
//     else if (menuSelection == 2)
//     {
//         game.PlayGameWithComputer();
//     }
//     else if (menuSelection == 3)
//     {

//     }
//     else if (menuSelection == 4)
//     {
//         exit = true;
//     }
    
// }
// Console.BackgroundColor = ConsoleColor.Black;
// Console.Clear();
// Console.WriteLine("Thank you for playing. Goodbye.");
