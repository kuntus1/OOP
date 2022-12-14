using Newtonsoft.Json;
using TicTacToe.Account;
using TicTacToe.Enum;

namespace TicTacToe.Games;

public class SingleGame : Game
{
    [JsonConstructor]
    public SingleGame(GameAccount player) : base(player, GameType.Single)
    {
    }

    public SingleGame(GameAccount player, int rating) : base(player, rating, GameType.Single)
    {
    }

    public override void Play()
    {
        var result = IsWinPlayer();
        switch (result)
        {
            case GameStatus.Win: Player.WinGame(this); break;
            case GameStatus.Lose: Player.LoseGame(this); break;
            case GameStatus.Draw: Player.DrawGame(this); break;
            case GameStatus.Playing:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    protected override int Rating
    {
        get => _rating;
        private protected init
        {
            if (value < 0)
            {
                throw new ArgumentException("Error: 'rating can't have negative value'");
            }

            if (value > Player.CurrentRating)
            {
                throw new ArgumentException("Error: 'Game rating  can't be more players rating'");
            }

            _rating = value;
        }
    }

    public override int GetRating => Rating;
}