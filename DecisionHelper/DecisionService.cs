namespace DecisionHelper;

public class DecisionService
{
    private readonly EvaluationMessageService evaluationMessageService;

    public DecisionService(EvaluationMessageService evaluationMessageService)
    {
        this.evaluationMessageService = evaluationMessageService;
    }

    public DecisionOutcome GetRecommendation(double eventProbability, IList<(double valueIfEvent, double valueIfNotEvent)> options)
    {
        var optionEvaluations = new List<OptionEvaluation>();

        var (firstValueIfEvent, firstValueIfNotEvent) = options[0];
        double firstUtility = eventProbability * firstValueIfEvent + (1 - eventProbability) * firstValueIfNotEvent;

        var firstEvaluation = new OptionEvaluation
        {
            OptionIndex = 0,
            Utility = firstUtility,
            Message = evaluationMessageService.GetMessage(firstUtility)
        };

        optionEvaluations.Add(firstEvaluation);

        double maxUtility = firstUtility;

        for (int i = 1; i < options.Count; i++)
        {
            var (valueIfEvent, valueIfNotEvent) = options[i];
            double utility = eventProbability * valueIfEvent + (1 - eventProbability) * valueIfNotEvent;

            var evaluation = new OptionEvaluation
            {
                OptionIndex = i,
                Utility = utility,
                Message = evaluationMessageService.GetMessage(utility)
            };

            optionEvaluations.Add(evaluation);

            if (utility > maxUtility)
            {
                maxUtility = utility;
            }
        }

        var bestOptions = optionEvaluations.Where(e => e.Utility == maxUtility).ToList();

        return new DecisionOutcome
        {
            OptionEvaluations = optionEvaluations,
            BestOptions = bestOptions
        };
    }

}
