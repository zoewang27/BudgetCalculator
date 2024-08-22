using BudgetCalculator.Models; 
namespace BudgetCalculator.Services;

/// <summary>
/// Base service class that provides common functionality for goal-seeking algorithms.
/// </summary>
public abstract class BaseService
{
    protected const double Tolerance = 1e-6;
    protected const int MaxIterations = 100;
    
    /// <summary>
    /// Calculates the total budget based on various parameters.
    /// </summary>
    /// <param name="Xi">The amount of budget allocated to the specific ad in question.</param>
    /// <param name="budgetModel">An instance of <see cref="BudgetModel"/> containing the details of the budget calculation.</param>
    /// <returns>The total budget required including all ad budgets, agency fees, third-party tool costs, and hours.</returns>
    protected double CalculateAdsBudgets(double Xi , BudgetModel budgetModel)
    {

        double sumOtherAds = budgetModel.AdBudgets.Sum(ad => ad.Amount);
        double thirdPartyToolBudget = budgetModel.AdBudgets
                                               .Where(ad => ad.IsUsedTool)
                                               .Sum(ad => ad.Amount);

        if (budgetModel.IsUsedToolXi)
        {
            thirdPartyToolBudget += Xi;
        }

        double totalAdsBudget = sumOtherAds + Xi;

        // X + X * Y1 + Y2 * adBudgetForTool + HOURS;
        return totalAdsBudget 
             + totalAdsBudget * budgetModel.AgencyFeePercentage 
             + thirdPartyToolBudget * budgetModel.ThirdPartyToolPercentage 
             + budgetModel.Hours;
    }
        
    
}

