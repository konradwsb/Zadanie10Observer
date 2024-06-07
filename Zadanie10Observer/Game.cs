public class Game : ISubject
{
    private List<IObserver> observers;
    private string currentPlayer;
    private int secretNumber;
    private int attempts;
    private Dictionary<string, int> scores;

    public Game()
    {
        observers = new List<IObserver>();
        scores = new Dictionary<string, int>
        {
            { "Player1", 0 },
            { "Player2", 0 }
        };
    }

    public void Attach(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update(scores);
        }
    }

    public void SetSecretNumber(string player, int number)
    {
        currentPlayer = player;
        secretNumber = number;
        attempts = 0;
        NotifyObservers();
    }

    public bool MakeGuess(string player, int guess)
    {
        attempts++;
        if (guess == secretNumber)
        {
            Console.WriteLine($"{player} zgadł poprawnie liczbę {secretNumber} po {attempts} próbach!");
            NotifyObservers();
            return true;
        }
        else
        {
            Console.WriteLine($"{player} zgadł niepoprawnie. Spróbuj ponownie.");
            return false;
        }
    }

    public void UpdateAttempts(string player, int attempts)
    {
        scores[player] += attempts;
    }

    public int GetAttempts()
    {
        return attempts;
    }

    public void DisplayScores()
    {
        Console.WriteLine($"Wynik: Player1: {scores["Player1"]} vs Player2: {scores["Player2"]}");
    }
}