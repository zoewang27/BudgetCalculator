using BudgetCalculator.Models; 
namespace BudgetCalculator.Services;

public class BinarySearch : BaseService, IGoalSeek
{
    /// <summary>
    /// <summary>Finds the best budget that meets the criteria using the Binary Search method.
    /// <summary>
    public (double budget, int iterations) FindTheBestBudget(BudgetModel budgetModel)
    {
        double low = 0;
        double high = budgetModel.TotalCampaignBudget;  
        double mid = 0;
        int iterationCount = 0;

        while (iterationCount < MaxIterations)
        {
            iterationCount++;
            mid = (low + high) / 2;

            // Calculate the total budget for the current midpoint
            double currentBudget = CalculateAdsBudgets(mid, budgetModel);

            if (Math.Abs(budgetModel.TotalCampaignBudget - currentBudget) < Tolerance)
            {
                return (mid, iterationCount);
            }

            if (currentBudget < budgetModel.TotalCampaignBudget)
            {
                low = mid; 
            }
            else
            {
                high = mid;
            }

            if (mid < 1)
            {
                return (0, iterationCount);
            }
        }
        
        return (mid, iterationCount);
        
    }
}