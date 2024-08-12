namespace BudgetCalculator.Services
{
    public class BudgetService
    {
        public double CalculateTotalBudget(double X_target, double Z, double Y1, double Y2, double[] otherAdsBudgets, double HOURS)
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
                double currentBudget = CalculateTotalBudget(mid, Z, Y1, Y2, otherAdsBudgets, HOURS);

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
