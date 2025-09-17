using DecisionHelper;

class Program
{
    static void Main()
    {
        Console.Write("Enter probability of rain (0..1): ");
        if (!InputValidator.TryValidateProbability(Console.ReadLine(), out double probability, out string errorMessage))
        {
            Console.WriteLine(errorMessage);
            return;
        }

        var options = new List<(double valueIfEvent, double valueIfNotEvent)>();

        Console.WriteLine("\nOption: Home");
        double homeRain = ReadDouble("  Value if rain: ");
        double homeNoRain = ReadDouble("  Value if no rain: ");
        options.Add((homeRain, homeNoRain));

        Console.WriteLine("\nOption: Forest");
        double forestRain = ReadDouble("  Value if rain: ");
        double forestNoRain = ReadDouble("  Value if no rain: ");
        options.Add((forestRain, forestNoRain));

        var evaluationMessageService = new EvaluationMessageService();

        var decisionService = new DecisionService(evaluationMessageService);

        var result = decisionService.GetRecommendation(probability, options);

        Console.WriteLine("\nAll options:");
        foreach(var option in result.OptionEvaluations)
        {
            Console.WriteLine(option);
        }

        Console.WriteLine("\nBest option(s):");
        foreach (var best in result.BestOptions)
        {
            Console.WriteLine(best);
        }
    }

    static double ReadDouble(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (double.TryParse(Console.ReadLine(), out double value))
                return value;
            Console.WriteLine("Invalid number, try again.");
        }
    }
}
