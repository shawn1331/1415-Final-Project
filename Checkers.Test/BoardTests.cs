using System.Text;
namespace Checkers.Test;
public class BoardTests
{
    [Test]
    public void TestBoard()
    {
        Board board = new Board();
        string checkerBoard = board.BoardAsString();
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
        Assert.AreEqual(expected.ToString(), checkerBoard);
    }

    [Test]
    public void TestPrintBoard()
    {
        Board board = new Board();
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
        Console.WriteLine(expected.ToString());
        board.PrintBoard();
    }
}