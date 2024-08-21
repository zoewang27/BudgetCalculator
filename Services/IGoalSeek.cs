namespace BudgetCalculator.Services
{
    public interface IGoalSeek
    {
        (double budget, int iterations) FindTheBestBudget(double sumOtherAds, double Z, double Y1, double Y2, bool UsedThirdPartyToolXi, double toolAd, double HOURS);
    }
}


