namespace BudgetCalculator.Services;

public class NewtonMethod : BaseClass, IGoalSeek
{

    public (double budget, int iterations) FindTheBestBudget(double sumOtherAds, double Z, double Y1, double Y2, bool UsedThirdPartyToolXi, double toolAd, double HOURS)
    {
        double Xi = Z / 2;
        int iterationCount = 0;
        for (int i = 0; i < MaxIterations; i++)
        {
            iterationCount++;

            double toolAdFinal = toolAd; 
            if (UsedThirdPartyToolXi) toolAdFinal = toolAd + Xi;

            double currentBudget = CalculateTotalBudget(Xi, sumOtherAds,  Z, Y1,  Y2,  toolAdFinal,  HOURS);
            double f_Xi = Z - currentBudget;
            double f_prime_Xi = -1 * (1 + Y1 + Y2);

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
        }
        throw new Exception("Max iterations reached, solution not found.");
    }

}