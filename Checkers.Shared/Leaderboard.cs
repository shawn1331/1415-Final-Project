using System.Text.Json;
public class Leaderboard // 4th class
{
    public int PointsRed { get; set; }
    public int PointsBlack { get; set; }
    public Dictionary<string, int> Scoreboard { get; set; } = new();
    const string file = "LeaderboardFile.json";
    static public void LeaderboardOptions()
    {
        Console.WriteLine(@"Would you like to:
                            1. Print all names and scores in the Leaderboard
                            2. Print all names in the Leaderboard
                            3. Print the 5 highest scores in the Leaderboard
                            4. Print the players with the 5 highest scores in the Leaderboard");
    }
    public void LoadLeaderboard()
    {
        if (File.Exists(file))//working with file
        {
            string jsonData = File.ReadAllText(file);
            Scoreboard = JsonSerializer.Deserialize<Dictionary<string, int>>(jsonData);
        }
    }
    public void AddScores(string redPlayer, string blackPlayer)
    {
        Scoreboard[redPlayer] = PointsRed;
        Scoreboard[blackPlayer] = PointsBlack;
    }
    public void SaveScoresToFile()// load file add contents of current dictionary to the file dictionary and then save updated file dictionary
    {
        string jsonData = JsonSerializer.Serialize(Scoreboard);// working with file
        File.WriteAllText(file, jsonData);
    }
    public void PrintAllNamesAndScores()
    {
        foreach (var score in Scoreboard)
        {
            Console.WriteLine($"{score.Key}: {score.Value}");
        }
    }
    public void PrintAllNames()//1st query expression
    {
        IEnumerable<string> names = from key in Scoreboard.Keys select key;
        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
    }
    public void Print5HighestScores()//2nd query expression
    {
        IEnumerable<int> highestscores = (from value in Scoreboard.Values orderby value descending select value).Take(5);
        foreach (var score in highestscores)
        {
            Console.WriteLine(score);
        }
    }
    public void Print5NamesWithHighestScore()//3rd query expression
    {
        IEnumerable<string> names = (from name in Scoreboard.Keys orderby Scoreboard.Values descending select name).Take(5);
        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
    }
}