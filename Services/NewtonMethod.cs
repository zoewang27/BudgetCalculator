using BudgetCalculator.Models; 
namespace BudgetCalculator.Services;

public class NewtonMethod : BaseService, IGoalSeek
{
    /// <summary>
    /// <summary> Finds the best budget that meets the criteria using the Newton Method.
    /// <summary>
     public (double budget, int iterations) FindTheBestBudget(BudgetModel budgetModel)
    {
        double Xi = budgetModel.TotalCampaignBudget / 2;
        int iterationCount = 0;

        while (iterationCount < MaxIterations)
        {
            iterationCount++;

            double currentBudget = CalculateAdsBudgets(Xi, budgetModel);
            
            // Calculate the difference between the expected total budget and the current budget estimate
            double f_Xi = budgetModel.TotalCampaignBudget- currentBudget;

            // Calculate the derivative of the function with respect to Xi.
            double f_prime_Xi = -1 * (1 + budgetModel.AgencyFeePercentage + budgetModel.ThirdPartyToolPercentage);

            if (Math.Abs(f_Xi) < Tolerance)
            {
                return (Xi,iterationCount); 
            }

            if (f_prime_Xi == 0)
            {
                throw new Exception("Derivative is zero, Newton's method fails.");
            }

            // Newton's method update
            Xi = Xi - f_Xi / f_prime_Xi;


            if (Xi < 0)
            {
                return (0,iterationCount); 
            }
        }
        throw new Exception("Max iterations reached, solution not found.");
    }

}