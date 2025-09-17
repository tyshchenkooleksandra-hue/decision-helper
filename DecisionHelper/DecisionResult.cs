namespace DecisionHelper;

public class DecisionOutcome
{
    public IList<OptionEvaluation> OptionEvaluations { get; set; } = new List<OptionEvaluation>();

    public IList<OptionEvaluation> BestOptions { get; set; } = new List<OptionEvaluation>();
}

public class OptionEvaluation
{
    public int OptionIndex { get; set; }   
    public double Utility { get; set; }   
    public string Message { get; set; }    

    public override string ToString()
    {
        return $"Option {OptionIndex}: {Utility:F2} -> {Message}";
    }
}