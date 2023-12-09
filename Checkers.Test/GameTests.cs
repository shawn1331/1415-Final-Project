namespace Checkers.Test;
using System.Text;
public class GameTests // There are 21 total tests
{
    [Test]
    public void TestIsMoveable()
    {
        Game game = new();
        StringBuilder expected = new StringBuilder();
        expected.Append("  0  1  2  3  4  5  6  7" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("0|  |⚫|  |⚫|  |⚫|  |⚫|" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("1|⚫|  |⚫|  |⚫|  |⚫|  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("2|  |⚫|  |⚫|  |⚫|  |⚫|" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("3|  |  |  |  |  |  |  |  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("4|  |  |  |  |  |  |  |  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("5|🔴|  |🔴|  |🔴|  |🔴|  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("6|  |🔴|  |🔴|  |🔴|  |🔴|" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("7|🔴|  |🔴|  |🔴|  |🔴|  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+");
        Assert.IsTrue(game.IsMoveable(5, 0, 4, 1), "The piece at 5,0 is moveable");
    }

    [Test]
    public void TestIsJumpable()
    {
        Game game = new();
        Leaderboard leaderBoard = new();
        StringBuilder expected = new StringBuilder();
        expected.Append("  0  1  2  3  4  5  6  7" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("0|  |⚫|  |⚫|  |⚫|  |⚫|" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("1|⚫|  |⚫|  |⚫|  |⚫|  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("2|  |  |  |⚫|  |⚫|  |⚫|" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("3|  |  |⚫|  |  |  |  |  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("4|  |🔴|  |🔴|  |  |  |  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("5|  |  |  |  |🔴|  |🔴|  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("6|  |🔴|  |🔴|  |🔴|  |🔴|" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("7|🔴|  |🔴|  |🔴|  |🔴|  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+");
        game.currentPlayer = Player.Player1;
        game.MovePiece(5, 0, 4, 1, leaderBoard);
        game.MovePiece(2, 1, 3, 2, leaderBoard);
        game.MovePiece(5, 2, 4, 3, leaderBoard);
        game.MovePiece(3, 2, 5, 0, leaderBoard);
        Assert.IsTrue(game.IsJumpable(3, 2, 5, 0), "The piece at 4,1 is jumpable");
    }

    [Test]
    public void TestIsGameOver()
    {
        Game game = new();
        Assert.IsFalse(game.IsGameOver(), "The game is not over");
    }

    [Test]
    public void TestSwitchPlayer()
    {
        Game game = new();
        Leaderboard leaderBoard = new();
        game.MovePiece(5, 0, 4, 1, leaderBoard);
        Assert.AreEqual(Player.Player2, game.currentPlayer);
    }

    [Test]
    public void TestMovementRed()
    {
        Game game = new();
        Leaderboard leaderBoard = new();
        StringBuilder expected = new StringBuilder();
        expected.Append("  0  1  2  3  4  5  6  7" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("0|  |⚫|  |⚫|  |⚫|  |⚫|" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("1|⚫|  |⚫|  |⚫|  |⚫|  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("2|  |⚫|  |⚫|  |⚫|  |⚫|" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("3|  |  |  |  |  |  |  |  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("4|  |🔴|  |  |  |  |  |  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("5|  |  |🔴|  |🔴|  |🔴|  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("6|  |🔴|  |🔴|  |🔴|  |🔴|" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("7|🔴|  |🔴|  |🔴|  |🔴|  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+");
        game.currentPlayer = Player.Player1;
        game.MovePiece(5, 0, 4, 1, leaderBoard);
        string checkerBoard = game.BoardAsString();
        Assert.AreEqual(expected.ToString(), checkerBoard);
    }

    [Test]
    public void TestMovementBlack()
    {
        Game game = new();
        Leaderboard leaderBoard = new();
        StringBuilder expected = new StringBuilder();
        expected.Append("  0  1  2  3  4  5  6  7" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("0|  |⚫|  |⚫|  |⚫|  |⚫|" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("1|⚫|  |⚫|  |⚫|  |⚫|  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("2|  |  |  |⚫|  |⚫|  |⚫|" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("3|⚫|  |  |  |  |  |  |  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("4|  |🔴|  |  |  |  |  |  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("5|  |  |🔴|  |🔴|  |🔴|  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("6|  |🔴|  |🔴|  |🔴|  |🔴|" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("7|🔴|  |🔴|  |🔴|  |🔴|  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+");
        game.currentPlayer = Player.Player1;
        game.MovePiece(5, 0, 4, 1, leaderBoard);
        game.MovePiece(2, 1, 3, 0, leaderBoard);
        string checkerBoard = game.BoardAsString();
        Assert.AreEqual(expected.ToString(), checkerBoard);
    }

    [Test]
    public void TestJumpsRed()
    {
        Game game = new();
        Leaderboard leaderBoard = new();
        StringBuilder expected = new StringBuilder();
        expected.Append("  0  1  2  3  4  5  6  7" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("0|  |⚫|  |⚫|  |⚫|  |⚫|" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("1|⚫|  |⚫|  |⚫|  |⚫|  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("2|  |🔴|  |  |  |⚫|  |⚫|" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("3|⚫|  |  |  |  |  |  |  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("4|  |🔴|  |  |  |  |  |  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("5|  |  |  |  |🔴|  |🔴|  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("6|  |🔴|  |🔴|  |🔴|  |🔴|" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("7|🔴|  |🔴|  |🔴|  |🔴|  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+");
        game.currentPlayer = Player.Player1;
        game.MovePiece(5, 0, 4, 1, leaderBoard);
        game.MovePiece(2, 1, 3, 0, leaderBoard);
        game.MovePiece(5, 2, 4, 3, leaderBoard);
        game.MovePiece(2, 3, 3, 2, leaderBoard);
        game.MovePiece(4, 3, 2, 1, leaderBoard);
        string checkerBoard = game.BoardAsString();
        Assert.AreEqual(expected.ToString(), checkerBoard);
    }

    [Test]
    public void TestJumpsBlack()
    {
        Game game = new();
        Leaderboard leaderBoard = new();
        StringBuilder expected = new StringBuilder();
        expected.Append("  0  1  2  3  4  5  6  7" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("0|  |⚫|  |⚫|  |⚫|  |⚫|" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("1|⚫|  |⚫|  |⚫|  |⚫|  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("2|  |  |  |⚫|  |⚫|  |⚫|" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("3|  |  |  |  |  |  |  |  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("4|  |  |  |🔴|  |  |  |  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("5|  |  |⚫|  |🔴|  |🔴|  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("6|  |🔴|  |🔴|  |🔴|  |🔴|" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("7|🔴|  |🔴|  |🔴|  |🔴|  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+");
        game.currentPlayer = Player.Player1;
        game.MovePiece(5, 0, 4, 1, leaderBoard);
        game.MovePiece(2, 1, 3, 0, leaderBoard);
        game.MovePiece(5, 2, 4, 3, leaderBoard);
        game.MovePiece(3, 0, 5, 2, leaderBoard);
        string checkerBoard = game.BoardAsString();
        Assert.AreEqual(expected.ToString(), checkerBoard);
    }

    [Test]
    public void TestMultipleJumpsRed()
    {
        Game game = new();
        Leaderboard leaderBoard = new();
        StringBuilder expected = new StringBuilder();
        expected.Append("  0  1  2  3  4  5  6  7" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("0|  |⚫|  |🔴|  |⚫|  |⚫|" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("1|⚫|  |⚫|  |  |  |⚫|  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("2|  |⚫|  |  |  |  |  |⚫|" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("3|⚫|  |⚫|  |  |  |  |  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("4|  |🔴|  |  |  |  |  |🔴|" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("5|  |  |🔴|  |🔴|  |🔴|  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("6|  |🔴|  |  |  |🔴|  |  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("7|🔴|  |🔴|  |🔴|  |🔴|  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+");
        game.currentPlayer = Player.Player1;
        game.MovePiece(5, 0, 4, 1, leaderBoard);//5
        game.MovePiece(2, 1, 3, 0, leaderBoard);
        game.MovePiece(5, 4, 4, 3, leaderBoard);//5
        game.MovePiece(2, 3, 3, 2, leaderBoard);
        game.MovePiece(5, 6, 4, 7, leaderBoard);//5
        game.MovePiece(2, 5, 3, 4, leaderBoard);
        game.MovePiece(6, 3, 5, 4, leaderBoard);//5
        game.MovePiece(1, 2, 2, 1, leaderBoard);
        game.MovePiece(6, 7, 5, 6, leaderBoard);//5
        game.MovePiece(0, 3, 1, 2, leaderBoard);
        game.MovePiece(4, 3, 2, 5, leaderBoard);//10
        game.MovePiece(2, 5, 0, 3, leaderBoard);//10
        string checkerBoard = game.BoardAsString();
        int expectedPointsRed = 45;
        Assert.AreEqual(expectedPointsRed, leaderBoard.PointsRed);
    }

    [Test]
    public void TestUpgradeToKing()
    {
        Game game = new();
        Leaderboard leaderBoard = new();
        StringBuilder expected = new StringBuilder();
        expected.Append("  0  1  2  3  4  5  6  7" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("0|  |🟥|  |⚫|  |⚫|  |⚫|" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("1|⚫|  |  |  |⚫|  |⚫|  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("2|  |  |  |  |  |⚫|  |⚫|" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("3|⚫|  |  |  |  |  |  |  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("4|  |🔴|  |⚫|  |  |  |🔴|" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("5|  |  |  |  |  |  |  |  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("6|  |🔴|  |🔴|  |🔴|  |🔴|" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("7|🔴|  |🔴|  |🔴|  |🔴|  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+");
        game.currentPlayer = Player.Player1;
        game.MovePiece(5, 0, 4, 1, leaderBoard);
        game.MovePiece(2, 1, 3, 0, leaderBoard);
        game.MovePiece(5, 2, 4, 3, leaderBoard);
        game.MovePiece(2, 3, 3, 2, leaderBoard);
        game.MovePiece(4, 3, 2, 1, leaderBoard);
        game.MovePiece(1, 2, 2, 3, leaderBoard);
        game.MovePiece(5, 4, 4, 5, leaderBoard);
        game.MovePiece(2, 3, 3, 4, leaderBoard);
        game.MovePiece(5, 6, 4, 7, leaderBoard);
        game.MovePiece(0, 1, 1, 2, leaderBoard);
        game.MovePiece(4, 5, 2, 3, leaderBoard);
        game.MovePiece(1, 2, 3, 4, leaderBoard);
        game.MovePiece(2, 1, 1, 2, leaderBoard);
        game.MovePiece(3, 4, 4, 3, leaderBoard);
        game.MovePiece(1, 2, 0, 1, leaderBoard);
        string checkerBoard = game.BoardAsString();
        Assert.AreEqual(expected.ToString(), checkerBoard);
    }

    [Test]
    public void TestPointsRed1Move()
    {
        Game game = new();
        Leaderboard leaderBoard = new();
        StringBuilder expected = new StringBuilder();
        expected.Append("  0  1  2  3  4  5  6  7" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("0|  |⚫|  |⚫|  |⚫|  |⚫|" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("1|⚫|  |⚫|  |⚫|  |⚫|  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("2|  |⚫|  |⚫|  |⚫|  |⚫|" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("3|  |  |  |  |  |  |  |  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("4|  |🔴|  |  |  |  |  |  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("5|  |  |🔴|  |🔴|  |🔴|  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("6|  |🔴|  |🔴|  |🔴|  |🔴|" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("7|🔴|  |🔴|  |🔴|  |🔴|  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+");
        game.currentPlayer = Player.Player1;
        game.MovePiece(5, 0, 4, 1, leaderBoard);
        string checkerBoard = game.BoardAsString();
        int expectedRedPoints = 5;// 5 pts for move
        Assert.AreEqual(expectedRedPoints, leaderBoard.PointsRed);
    }

    [Test]
    public void TestPointsBlack()
    {
        Game game = new();
        Leaderboard leaderBoard = new();
        StringBuilder expected = new StringBuilder();
        expected.Append("  0  1  2  3  4  5  6  7" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("0|  |⚫|  |⚫|  |⚫|  |⚫|" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("1|⚫|  |⚫|  |⚫|  |⚫|  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("2|  |  |  |⚫|  |⚫|  |⚫|" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("3|  |  |  |  |  |  |  |  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("4|  |  |  |🔴|  |  |  |  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("5|  |  |⚫|  |🔴|  |🔴|  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("6|  |🔴|  |🔴|  |🔴|  |🔴|" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("7|🔴|  |🔴|  |🔴|  |🔴|  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+");
        game.currentPlayer = Player.Player1;
        game.MovePiece(5, 0, 4, 1, leaderBoard);
        game.MovePiece(2, 1, 3, 0, leaderBoard);
        game.MovePiece(5, 2, 4, 3, leaderBoard);
        game.MovePiece(3, 0, 5, 2, leaderBoard);
        string checkerBoard = game.BoardAsString();
        int expectedBlackPoints = 15;// 5pts for move 10 pts for jump 15 total
        Assert.AreEqual(expectedBlackPoints, leaderBoard.PointsBlack);
    }

    [Test]
    public void TestIsGameOverCount()
    {
        Game game = new();
        Board board = new();
        int expectedCountRed = 12;
        int expectedCountBlack = 12;
        game.IsGameOver();
        Assert.AreEqual(expectedCountBlack, game.BlackCount);
        Assert.AreEqual(expectedCountRed, game.RedCount);
    }
}