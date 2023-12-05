// Shawn Miner 11/10/23 Checkers 1415 Final Project
using System.Text;
Console.OutputEncoding = Encoding.UTF8;
Game game = new Game();
Board board = new Board();
UserInput input = new();
Leaderboard leaderBoard = new Leaderboard();
Console.BackgroundColor = ConsoleColor.DarkGray;
leaderBoard.LoadLeaderboard();

while (true)
{
    game.PlayGame();
}

// while (game.exit == false)
// {
//     game.PrintMenu();
//     int menuSelection = input.GetUserMenuSelection();
//     game.HandleMenuOptions(menuSelection);
// }
// leaderBoard.AddScores(redPlayer,blackPlayer);
// leaderBoard.SaveScoresToFile();
// 
// Console.BackgroundColor = ConsoleColor.Black;
// Console.Clear();
// Console.WriteLine("Thank you for playing. Goodbye.");
