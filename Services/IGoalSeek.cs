using BudgetCalculator.Models; 
namespace BudgetCalculator.Services
{
    /*
    Defines a contract for goal-seeking algorithms to find the optimal budget.
    */
    public interface IGoalSeek
    {

        (double budget, int iterations) FindTheBestBudget(BudgetModel budgetModel);
    }
}



