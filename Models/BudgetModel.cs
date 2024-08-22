using System.ComponentModel.DataAnnotations;

namespace BudgetCalculator.Models;

/// <summary>
/// Represents the budget model for calculating the specific ad budgets.
/// </summary>
public class BudgetModel
{
    [Required]
    public List<AdBudget> AdBudgets { get; set; } 

    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "The value must be non-negative.")]
    public double TotalBudgetExpected { get; set; }

    [Required]
    [Range(0, 1, ErrorMessage = "Agency Fee Percentage must be between 0 and 1.")]
    public double AgencyFeePercentage { get; set; }

    [Required]
    [Range(0, 1, ErrorMessage = "Agency Fee Percentage must be between 0 and 1.")]
    public double ThirdPartyToolPercentage { get; set; }

    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "The value must be non-negative.")]
    public double Hours { get; set; }

    [Required]
    public bool IsUsedToolXi { get; set; }
}

