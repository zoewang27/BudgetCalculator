/*
 * The BudgetService class is used for budget-related calculations.
 * 
 * 1. The CalculateTotalBudget method computes the total budget based on the given parameters.
 *    - Input parameters include the target budget X_target, Agency fee percentage Y1 and Third-party tool fee percentage Y2, an array of other ad budgets, and the fixed cost HOURS.
 *    - The output is the computed total budget.
 * 
 * 2. The GoalSeekBinarySearch method uses a binary search algorithm to find the value of X that makes the total budget close to the target value Z.
 *    - Input parameters include the total campaign budget Z for budget calculations, Y1 and Y2, an array of other ad budgets, HOURS, and optional parameters for tolerance and maximum iterations.
 *    - The output is the value of X that results in a total budget close to the Z.
 */

namespace BudgetCalculator.Services
{
    public class BudgetService
    {
        public double CalculateTotalBudget(double X_target, double Y1, double Y2, double[] otherAdsBudgets, double HOURS)
        {
            double sumOtherAds = 0;
            foreach (var budget in otherAdsBudgets)
            {
                sumOtherAds += budget;
            }

            double X = sumOtherAds + X_target;
            double totalBudget = X + X * Y1 + Y2 * X + HOURS;
            return totalBudget;
        }

        public double GoalSeekBinarySearch(double Z, double Y1, double Y2, double[] otherAdsBudgets, double HOURS, double tolerance = 1e-6, int maxIterations = 100)
        {
            double low = 0;
            double high = Z;  
            double mid = 0;

            for (int i = 0; i < maxIterations; i++)
            {
                mid = (low + high) / 2;
                double currentBudget = CalculateTotalBudget(mid, Y1, Y2, otherAdsBudgets, HOURS);

                if (Math.Abs(currentBudget - Z) < tolerance)
                {
                    return mid;
                }

                if (currentBudget < Z)
                {
                    low = mid; 
                }
                else
                {
                    high = mid;
                }
            }

            return mid; 
        }
    }
}
