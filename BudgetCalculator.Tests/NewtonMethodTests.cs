using BudgetCalculator.Models;
using BudgetCalculator.Services;
using Xunit;
using System.Linq;

namespace BudgetCalculator.Tests;
public class NewtonMethodTests
{
    [Fact]
    public void FindTheBestBudget_ValidInputs_ShouldReturnExpectedBudget()
    {
        // Arrange
        var newtonMethod = new NewtonMethod();
        var budgetModel = new BudgetModel
        {
            AdBudgets = new List<AdBudget>
            {
                new AdBudget { Amount = 100, IsUsedTool = false },
                new AdBudget { Amount = 150, IsUsedTool = true }
            },
            TotalBudgetExpected = 400,
            AgencyFeePercentage = 0.1,
            ThirdPartyToolPercentage = 0.05,
            Hours = 50,
            IsUsedToolXi = true 
        };

        // Act
        var result = newtonMethod.FindTheBestBudget(budgetModel);

        // Compute the expected budget using the same logic as CalculateAdsBudgets
        double sumOtherAds = budgetModel.AdBudgets.Sum(ad => ad.Amount);
        double thirdPartyToolBudget = budgetModel.AdBudgets
                                               .Where(ad => ad.IsUsedTool)
                                               .Sum(ad => ad.Amount);

        if (budgetModel.IsUsedToolXi) 
        {
            thirdPartyToolBudget += result.budget;
        }

        double Xi = result.budget;
        double computedBudget = sumOtherAds + Xi
            + (sumOtherAds + Xi) * budgetModel.AgencyFeePercentage 
            + thirdPartyToolBudget * budgetModel.ThirdPartyToolPercentage 
            + budgetModel.Hours;

        // Assert
        Assert.True(Math.Abs(budgetModel.TotalBudgetExpected - computedBudget) < 1e-6, 
                    $"Expected budget: {budgetModel.TotalBudgetExpected}, but got: {computedBudget}");
        Assert.InRange(result.iterations, 1, 100);
    }

    [Fact]
    public void FindTheBestBudget_BudgetTooLow_ShouldReturnZero()
    {
        // Arrange
        var newtonMethod = new NewtonMethod();
        var budgetModel = new BudgetModel
        {
            AdBudgets = new List<AdBudget>
            {
                new AdBudget { Amount = 10, IsUsedTool = false }
            },
            TotalBudgetExpected = 1,
            AgencyFeePercentage = 0.1,
            ThirdPartyToolPercentage = 0.05,
            Hours = 50,
            IsUsedToolXi = false
        };

        // Act
        var result = newtonMethod.FindTheBestBudget(budgetModel);

        // Assert
        Assert.Equal(0, result.budget);
    }

    [Fact]
    public void FindTheBestBudget_NoAdBudgets_ShouldReturnZero()
    {
        // Arrange
        var newtonMethod = new NewtonMethod();
        var budgetModel = new BudgetModel
        {
            AdBudgets = new List<AdBudget>(), // No ad budgets
            TotalBudgetExpected = 200,
            AgencyFeePercentage = 0.1,
            ThirdPartyToolPercentage = 0.05,
            Hours = 50,
            IsUsedToolXi = false
        };

        // Act
        var result = newtonMethod.FindTheBestBudget(budgetModel);

                // Compute the expected budget using the same logic as CalculateAdsBudgets
        double sumOtherAds = budgetModel.AdBudgets.Sum(ad => ad.Amount);
        double thirdPartyToolBudget = budgetModel.AdBudgets
                                               .Where(ad => ad.IsUsedTool)
                                               .Sum(ad => ad.Amount);

        if (budgetModel.IsUsedToolXi) 
        {
            thirdPartyToolBudget += result.budget;
        }

        double Xi = result.budget;
        double computedBudget = sumOtherAds + Xi
            + (sumOtherAds + Xi) * budgetModel.AgencyFeePercentage 
            + thirdPartyToolBudget * budgetModel.ThirdPartyToolPercentage 
            + budgetModel.Hours;

        // Assert
        Assert.True(Math.Abs(budgetModel.TotalBudgetExpected - computedBudget) < 1e-6, 
                    $"Expected budget: {budgetModel.TotalBudgetExpected}, but got: {computedBudget}");
        Assert.InRange(result.iterations, 1, 100);
    }

    [Fact]
    public void FindTheBestBudget_LargeTotalBudget_ShouldReturnValidBudget()
    {
        // Arrange
        var newtonMethod = new NewtonMethod();
        var budgetModel = new BudgetModel
        {
            AdBudgets = new List<AdBudget>
            {
                new AdBudget { Amount = 5000, IsUsedTool = false },
                new AdBudget { Amount = 7000, IsUsedTool = true }
            },
            TotalBudgetExpected = 1000000, // Large budget
            AgencyFeePercentage = 0.1,
            ThirdPartyToolPercentage = 0.05,
            Hours = 10000,
            IsUsedToolXi = true
        };

        // Act
        var result = newtonMethod.FindTheBestBudget(budgetModel);

        // Compute the expected budget using the same logic as CalculateAdsBudgets
        double sumOtherAds = budgetModel.AdBudgets.Sum(ad => ad.Amount);
        double thirdPartyToolBudget = budgetModel.AdBudgets
                                                .Where(ad => ad.IsUsedTool)
                                                .Sum(ad => ad.Amount);

        if (budgetModel.IsUsedToolXi)
        {
            thirdPartyToolBudget += result.budget;
        }

        double Xi = result.budget;
        double computedBudget = sumOtherAds + Xi
            + (sumOtherAds + Xi) * budgetModel.AgencyFeePercentage 
            + thirdPartyToolBudget * budgetModel.ThirdPartyToolPercentage 
            + budgetModel.Hours;

        // Assert
        Assert.True(Math.Abs(budgetModel.TotalBudgetExpected - computedBudget) < 1e-6, 
                    $"Expected budget: {budgetModel.TotalBudgetExpected}, but got: {computedBudget}");
        Assert.InRange(result.iterations, 1, 100);
    }




}
