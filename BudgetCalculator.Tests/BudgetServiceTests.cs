using Xunit;
using BudgetCalculator.Services; 

namespace BudgetCalculator.Tests
{
    public class BudgetServiceTests
    {
        private readonly BudgetService _budgetService;

        public BudgetServiceTests()
        {
            _budgetService = new BudgetService(); 
        }

        [Fact]
        public void Test_CalculateTotalBudget()
        {
            double Z = 10000;
            double Y1 = 0.10;
            double Y2 = 0.05;
            double HOURS = 2000;
            double[] otherAdsBudgets = { 1000, 1500, 2000 }; 

            double result = _budgetService.CalculateTotalBudget(Z, Y1, Y2, otherAdsBudgets, HOURS);

            Assert.True(result >= 0, "The calculated total budget should be non-negative.");
        }

        [Fact]
        public void Test_GoalSeekBinarySearch()
        {
            double Z = 10000;
            double Y1 = 0.10;
            double Y2 = 0.05;
            double HOURS = 2000;
            double[] otherAdsBudgets = { 1000 }; 

            double result = _budgetService.GoalSeekBinarySearch(Z, Y1, Y2, otherAdsBudgets, HOURS);

            Assert.True(result >= 0, "The result of the goal-seek binary search should be non-negative.");
        }
    }
}
