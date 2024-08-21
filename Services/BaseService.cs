public abstract class BaseClass
{
    protected const double Tolerance = 1e-6;
    protected const int MaxIterations = 100;

    protected double CalculateTotalBudget(double Xi, double sumOtherAds, double Z, double Y1, double Y2, double toolAd, double HOURS)
    {
        double X = sumOtherAds + Xi;
        return X + X * Y1 + Y2 * toolAd + HOURS;
    }
}