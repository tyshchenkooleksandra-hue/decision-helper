namespace DecisionHelper;

public class EvaluationMessageService
{
    private readonly List<(double Evaluation, string Message)> rules = new List<(double Evaluation, string Message)>
    {
        (8, "Excellent"),
        (5, "Good"),
        (3, "Average"),
        (0, "Poor")
    };

    public string GetMessage(double utility)
    {
        return rules.FirstOrDefault(r => utility >= r.Evaluation).Message ?? "No evaluation";
    }
}
