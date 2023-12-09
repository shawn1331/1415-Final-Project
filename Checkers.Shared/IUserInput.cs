public interface IUserInput   // an interface
{
    public int GetUserMenuSelection();
    public void HandleMenuOptions(Game game, int menuSelection, Leaderboard leaderBoard);
    public int GetUserLeaderboardOption();
    public (int,int) GetUserPieceCoordinates();
    public (int, int) GetUserEmptyCoordinates();
    public (string?, string?) GetPlayerNames();
    public void PlayGame(Game game, Leaderboard leaderBoard);
    

}