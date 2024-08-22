using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Linq;
using BudgetCalculator.Services; 
using BudgetCalculator.Models; 

namespace BudgetCalculator.Pages.Budget;

public class IndexModel : PageModel
{
    private readonly IEnumerable<IGoalSeek> _goalSeeks;

    // Constructor injection of IGoalSeek service collection
    public IndexModel(IEnumerable<IGoalSeek> goalSeeks, ILogger<IndexModel> logger)
    {
        _goalSeeks = goalSeeks;
    }

    [BindProperty]
    public double num { get; set; }

    [BindProperty]
    
    public bool UsedThirdPartyToolXi { get; set; }

    [BindProperty]
    public double Z { get; set; }

    [BindProperty]
    public double Y1 { get; set; }

    [BindProperty]
    public double Y2 { get; set; }

    [BindProperty]
    public double HOURS { get; set; }
    
    public Dictionary<string, (double budget, int iterations)> Results { get; set; } = new Dictionary<string, (double budget, int iterations)>();


    public void OnPost()
    {
        try
        {
            // Initialize a new instance of BudgetModel with values from the form.
            var budgetModel = new BudgetModel
            {
                AdBudgets = new List<AdBudget>(), 
                TotalBudgetExpected = Z,
                AgencyFeePercentage = Y1,
                ThirdPartyToolPercentage = Y2,
                Hours = HOURS,
                IsUsedToolXi = UsedThirdPartyToolXi
            };

            // Loop through each ad budget entry based on the number of entries specified.
            for (int i = 0; i < num; i++)
            {
                // Get budget amount
                string singleBudgetKey = $"BudgetItems[{i}].amount";
                string singleBudgetValue = Request.Form[singleBudgetKey];

                double.TryParse(singleBudgetValue, out double result);


                // Check if this ad used the third-party tool
                string checkboxKey = $"BudgetItems[{i}].usedTool";
                bool isUsedTool = Request.Form.ContainsKey(checkboxKey) ? true : false;
                
                budgetModel.AdBudgets.Add(new AdBudget
                {
                    Amount = result,
                    IsUsedTool = isUsedTool
                });

            }
            
            // Iterate through each implementation of the IGoalSeek interface.
            foreach (var goalSeek in _goalSeeks)
            {
                var result = goalSeek.FindTheBestBudget(budgetModel);
                var implementationName = goalSeek.GetType().Name;
                Results[implementationName] = (result.budget, result.iterations);
            }
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}"); 
        }
    }
}





