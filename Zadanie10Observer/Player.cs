public class Player : IObserver
{
    private string playerName;
    private Game game;

    public Player(string playerName, Game game)
    {
        this.playerName = playerName;
        this.game = game;
        game.Attach(this);
    }

    public string GetName()
    {
        return playerName;
    }

    public void Update(Dictionary<string, int> scores)
    {
        Console.WriteLine($"Wynik: Player1: {scores["Player1"]} vs Player2: {scores["Player2"]}");
    }
}
