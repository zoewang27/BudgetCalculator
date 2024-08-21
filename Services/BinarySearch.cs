
namespace BudgetCalculator.Services;

public class BinarySearch : BaseClass, IGoalSeek
{
    public (double budget, int iterations) FindTheBestBudget(double sumOtherAds, double Z, double Y1, double Y2, bool UsedThirdPartyToolXi, double toolAd, double HOURS)
    {
        double low = 0;
        double high = Z;  
        double mid = 0;
        int iterationCount = 0;

        for (int i = 0; i < MaxIterations; i++)
        {
            iterationCount++;
            mid = (low + high) / 2;

            double toolAdFinal = toolAd; 
            if (UsedThirdPartyToolXi) toolAdFinal = toolAd + mid;

            double currentBudget = CalculateTotalBudget(mid, sumOtherAds,  Z, Y1,  Y2,  toolAdFinal,  HOURS);

            if (Math.Abs(Z - currentBudget) < Tolerance)
            {
                return (mid, iterationCount);
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

        return (mid, iterationCount);
        
    }
}