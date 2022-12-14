using TicTacToe.Data;
using TicTacToe.Games;

namespace TicTacToe.Services;

public static class GameService
{
    public static void Add(Game game)
    {
        DbContext.Histories.Add(game);
    }

    public static List<Game> Get()
    {
        return DbContext.Histories;
    }

    public static IEnumerable<int> GetIDs()
    {
        return DbContext.Histories.Select(x => x.GameId).ToList();
    }
}