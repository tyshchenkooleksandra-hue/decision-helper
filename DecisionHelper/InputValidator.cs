namespace DecisionHelper;

public static class InputValidator
{
    public static bool TryValidateProbability(string input, out double probability, out string errorMessage)
    {
        errorMessage = string.Empty;

        if (!double.TryParse(input, out probability))
        {
            errorMessage = "Error: you must enter a number.";
            return false;
        }

        if (probability < 0 || probability > 1)
        {
            errorMessage = "Error: probability must be between 0 and 1.";
            return false;
        }

        return true;
    }

    public static bool TryValidateScore(string input, out double score, out string errorMessage)
    {
        errorMessage = string.Empty;

        if (!double.TryParse(input, out score))
        {
            errorMessage = "Error: you must enter a number.";
            return false;
        }

        if (score < 0 || score > 100)
        {
            errorMessage = "Error: score must be between 0 and 100.";
            return false;
        }

        return true;
    }
}