namespace Checkers.Test;
using System.Text;
public class GameTests // There are 23 total tests
{

    [Test]
    public void TestIsKing()
    {

    }

    [Test]
    public void TestIsMoveable()
    {
        Board board = new Board();
        Game game = new Game();
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
        Board board = new Board();
        Game game = new Game();
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
        game.MovePiece(5, 0, 4, 1);
        game.MovePiece(2, 1, 3, 2);
        game.MovePiece(5, 2, 4, 3);
        game.MovePiece(3,2,5,0);
        Assert.IsTrue(game.IsJumpable(3, 2, 5, 1), "The piece at 5,2 is jumpable");
    }

    [Test]
    public void TestIsWinner()
    {

    }

    [Test]
    public void TestIsGameOver()
    {
        Board board = new Board();
        Game game = new Game();
        Assert.IsFalse(!game.IsGameOver(), "The game is not over");
    }

    [Test]
    public void TestSwitchPlayer()
    {
        Game game = new Game();
        Board board = new Board();
        game.MovePiece(6,1,5,2);
        Assert.AreEqual(Player.Player2, game.currentPlayer);
    }

    [Test]
    public void TestMovementRed()
    {
        Board board = new Board();
        Game game = new Game();
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
        game.MovePiece(5, 0, 4, 1);
        string checkerBoard = board.BoardAsString();
        Assert.AreEqual(expected.ToString(), checkerBoard);
    }

    [Test]
    public void TestMovementBlack()
    {
        Board board = new Board();
        Game game = new Game();
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
        game.MovePiece(5, 0, 4, 1);
        game.MovePiece(2, 1, 3, 0);
        string checkerBoard = board.BoardAsString();
        Assert.AreEqual(expected.ToString(), checkerBoard);
    }

    [Test]
    public void TestJumpsRed()
    {
        Board board = new Board();
        Game game = new Game();
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
        game.MovePiece(5, 0, 4, 1);
        game.MovePiece(2, 1, 3, 0);
        game.MovePiece(5, 2, 4, 3);
        game.MovePiece(2, 3, 3, 2);
        game.MovePiece(4, 3, 2, 1);
        string checkerBoard = board.BoardAsString();
        Assert.AreEqual(expected.ToString(), checkerBoard);
    }

    [Test]
    public void TestJumpsBlack()
    {

    }

    [Test]
    public void TestMultipleJumpsRed()
    {

    }

    [Test]
    public void TestMultipleJumpsBlack()
    {

    }

    [Test]
    public void TestUpgradeToKing()
    {
        Board board = new Board();
        Game game = new Game();
        StringBuilder expected = new StringBuilder();
        expected.Append("  0  1  2  3  4  5  6  7" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("0|  |🟥|  |⚫|  |⚫|  |⚫|" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("1|⚫|  |  |  |⚫|  |⚫|  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("2|  |  |  |  |  |⚫|  |⚫|" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("3|⚫|  |  |  |⚫|  |  |  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("4|  |🔴|  |  |  |  |  |🔴|" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("5|  |  |  |  |  |  |  |  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("6|  |🔴|  |🔴|  |🔴|  |🔴|" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+" + Environment.NewLine);
        expected.Append("7|🔴|  |🔴|  |🔴|  |🔴|  |" + Environment.NewLine);
        expected.Append(" +--+--+--+--+--+--+--+--+");
        game.currentPlayer = Player.Player1;
        game.MovePiece(5,0,4,1);
        game.MovePiece(2,1,3,0);
        game.MovePiece(5,2,4,3);
        game.MovePiece(3,4,4,3);
        game.MovePiece(4,3,2,1);
        game.MovePiece(1,2,2,3);
        game.MovePiece(5,4,4,5);
        game.MovePiece(2,3,3,4);
        game.MovePiece(5,6,4,7);
        game.MovePiece(0,1,1,2);
        game.MovePiece(4,5,2,3);
        game.MovePiece(1,2,3,4);
        game.MovePiece(2,1,1,2);
        game.MovePiece(3,4,4,3);
        game.MovePiece(1,2,0,1);
        string checkerBoard = board.BoardAsString();
        Assert.AreEqual(expected.ToString(), checkerBoard);
    }
}