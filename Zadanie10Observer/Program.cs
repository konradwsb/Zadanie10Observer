
public class Program
{
    public static void Main(string[] args)
    {
        Game game = new Game();
        Player player1 = new Player("Player1", game);
        Player player2 = new Player("Player2", game);

        while (true)
        {
            // Player 1 sets the secret number
            Console.WriteLine($"{player1.GetName()}, podaj sekretna liczbe:");
            int secretNumber = int.Parse(Console.ReadLine().Trim());
            game.SetSecretNumber(player1.GetName(), secretNumber);

            // Player 2 guesses
            while (true)
            {
                Console.WriteLine($"{player2.GetName()}, zgadnij liczbe:");
                int guess = int.Parse(Console.ReadLine().Trim());
                if (game.MakeGuess(player2.GetName(), guess))
                {
                    game.UpdateAttempts(player1.GetName(), game.GetAttempts());
                    break;
                }
            }

            // Display current scores
            game.DisplayScores();

            // Player 2 sets the secret number
            Console.WriteLine($"{player2.GetName()}, podaj sekretna liczbe:");
            secretNumber = int.Parse(Console.ReadLine().Trim());
            game.SetSecretNumber(player2.GetName(), secretNumber);

            // Player 1 guesses
            while (true)
            {
                Console.WriteLine($"{player1.GetName()}, zgadnij liczbe:");
                int guess = int.Parse(Console.ReadLine().Trim());
                if (game.MakeGuess(player1.GetName(), guess))
                {
                    game.UpdateAttempts(player2.GetName(), game.GetAttempts());
                    break;
                }
            }

            // Display current scores
            game.DisplayScores();

            Console.WriteLine("Czy chcesz kontynuować? (tak/nie)");
            if (Console.ReadLine().ToLower() != "tak")
            {
                break;
            }
        }
    }
}




