/*
 * The BudgetService class is used for budget-related calculations.
 */

namespace BudgetCalculator.Services;

public class BudgetService
{
    private const double Tolerance = 1e-6;
    private const int MaxIterations = 100;
    

    public double CalculateTotalBudget(double Xi, double sumOtherAds,  double Z, double Y1, double Y2, double toolAd, double HOURS)
    {
        double X = sumOtherAds + Xi;
        return X + X * Y1 + Y2 * toolAd + HOURS;
    }


    public (double budget, int iterations) GoalSeekBinarySearch(double sumOtherAds, double Z, double Y1, double Y2, bool UsedThirdPartyToolXi, double toolAd, double HOURS)
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


    public (double budget, int iterations) GoalSeekNewtonMethod(double sumOtherAds, double Z, double Y1, double Y2, bool UsedThirdPartyToolXi, double toolAd, double HOURS)
    {
        double X1 = Z / 2;
        int iterationCount = 0;


        for (int i = 0; i < MaxIterations; i++)
        {
            iterationCount++;

             double toolAdFinal = toolAd; 
            if (UsedThirdPartyToolXi) toolAdFinal = toolAd + X1;

            double currentBudget = CalculateTotalBudget(X1, sumOtherAds,  Z, Y1,  Y2,  toolAdFinal,  HOURS);
            double f_X1 = Z - currentBudget;
            double f_prime_X1 = -1 * (1 + Y1 + Y2);

            if (Math.Abs(f_X1) < Tolerance)
            {
                return (X1,iterationCount); 
            }

            if (f_prime_X1 == 0)
            {
                throw new Exception("Derivative is zero, Newton's method fails.");
            }

            // Newton's method update
            X1 = X1 - f_X1 / f_prime_X1;
        }
        throw new Exception("Max iterations reached, solution not found.");
    }
}
