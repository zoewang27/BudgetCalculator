using Xunit;
using BudgetCalculator.Services;
using System;

namespace BudgetCalculator.Tests.Services
{
    public class NewtonMethodTests
    {
        private readonly NewtonMethod _newtonMethod;

        public NewtonMethodTests()
        {
            _newtonMethod = new NewtonMethod();
        }

        [Fact]
        public void FindTheBestBudget_ShouldReturnCorrectBudget()
        {
            // Arrange
            double sumOtherAds = 100;
            double Z = 150;
            double Y1 = 0.1;
            double Y2 = 0.05;
            bool UsedThirdPartyToolXi = true;
            double toolAd = 20;
            double HOURS = 10;

            var result = _newtonMethod.FindTheBestBudget(sumOtherAds, Z, Y1, Y2, UsedThirdPartyToolXi, toolAd, HOURS);

            // Compute the expected budget
            double Xi = result.budget;
            double computedBudget = sumOtherAds + Xi
                + (sumOtherAds + Xi) * Y1 
                + Y2 * (toolAd + Xi)
                + HOURS;

            Assert.True(Math.Abs(Z - computedBudget) < 1e-6, $"Expected budget: {Z}, but got: {computedBudget}");
            Assert.InRange(result.iterations, 1, 100);
        }

        [Fact]
        public void FindTheBestBudget_ShouldThrowException_WhenDerivativeIsZero()
        {
     
            double sumOtherAds = 100;
            double Z = 150;
            double Y1 = -1; // Causes derivative to be zero
            double Y2 = 0;
            bool UsedThirdPartyToolXi = false;
            double toolAd = 20;
            double HOURS = 10;


            var exception = Assert.Throws<Exception>(() => _newtonMethod.FindTheBestBudget(sumOtherAds, Z, Y1, Y2, UsedThirdPartyToolXi, toolAd, HOURS));
            Assert.Equal("Derivative is zero, Newton's method fails.", exception.Message);
        }
    }
}
