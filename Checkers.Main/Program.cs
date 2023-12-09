// Shawn Miner 11/10/23 Checkers 1415 Final Project
using System.Text;
Console.OutputEncoding = Encoding.UTF8;
Game game = new Game();
UserInput input = new();
Leaderboard leaderBoard = new Leaderboard();
Console.BackgroundColor = ConsoleColor.DarkGray;
leaderBoard.LoadLeaderboard();

 var (redPlayer, blackPlayer) = input.GetPlayerNames();
while (game.exit == false)
{
    Game.PrintMenu();
    int menuSelection = input.GetUserMenuSelection();
    input.HandleMenuOptions(game, menuSelection, leaderBoard);
}
leaderBoard.AddScores(redPlayer, blackPlayer);
leaderBoard.SaveScoresToFile();
Console.BackgroundColor = ConsoleColor.Black;
Console.Clear();
Console.WriteLine("Thank you for playing!");