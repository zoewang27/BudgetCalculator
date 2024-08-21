using Xunit;
using BudgetCalculator.Services;
using System;

namespace BudgetCalculator.Tests.Services
{
    public class BinarySearchTests
    {
        private readonly BinarySearch _binarySearch;

        public BinarySearchTests()
        {
            _binarySearch = new BinarySearch();
        }

        [Fact]
        public void FindTheBestBudget_ShouldReturnCorrectBudget()
        {
            double sumOtherAds = 100;
            double Z = 150;
            double Y1 = 0.1;
            double Y2 = 0.05;
            bool UsedThirdPartyToolXi = true;
            double toolAd = 20;
            double HOURS = 10;

            var result = _binarySearch.FindTheBestBudget(sumOtherAds, Z, Y1, Y2, UsedThirdPartyToolXi, toolAd, HOURS);

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
        public void FindTheBestBudget_ShouldHandleEdgeCases()
        {
            // Arrange
            double sumOtherAds = 0;
            double Z = 0;
            double Y1 = 0;
            double Y2 = 0;
            bool UsedThirdPartyToolXi = false;
            double toolAd = 0;
            double HOURS = 0;

            // Act
            var result = _binarySearch.FindTheBestBudget(sumOtherAds, Z, Y1, Y2, UsedThirdPartyToolXi, toolAd, HOURS);

            // Assert
            Assert.Equal(0, result.budget, 1e-6);
            Assert.InRange(result.iterations, 1, 100);
        }
    }
}
