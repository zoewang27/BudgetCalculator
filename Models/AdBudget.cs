using System.ComponentModel.DataAnnotations;
namespace BudgetCalculator.Models;
    
/// <summary>
/// Represents a single advertisement budget entry.
/// </summary>
public class AdBudget
{
    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "The value must be non-negative.")]
    public double Amount { get; set; }
    
    [Required]
    public bool IsUsedTool { get; set; }
}