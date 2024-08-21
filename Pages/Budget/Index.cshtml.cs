using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Linq;
using BudgetCalculator.Services; 

namespace BudgetCalculator.Pages.Budget;

public class IndexModel : PageModel
{
    private readonly IEnumerable<IGoalSeek> _goalSeeks;

    // Constructor injection of IGoalSeek service collection
    public IndexModel(IEnumerable<IGoalSeek> goalSeeks)
    {
        _goalSeeks = goalSeeks;
    }

    [BindProperty]
    public double X1 { get; set; }

    [BindProperty]
    public double X2 { get; set; }

    [BindProperty]
    public double X3 { get; set; }

    [BindProperty]
    public bool UsedThirdPartyToolX1 { get; set; }

    [BindProperty]
    public bool UsedThirdPartyToolX2 { get; set; }

    [BindProperty]
    public bool UsedThirdPartyToolX3 { get; set; }

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

    public void OnGet()
    {
    }

    public void OnPost()
    {
        try
        {
            double sumOtherAds = X1 + X2 + X3;

            double sumToolAd = 0;
            if (UsedThirdPartyToolX1) sumToolAd += X1;
            if (UsedThirdPartyToolX2) sumToolAd += X2;
            if (UsedThirdPartyToolX3) sumToolAd += X3;

            foreach (var goalSeek in _goalSeeks)
            {
                var result = goalSeek.FindTheBestBudget(sumOtherAds, Z, Y1, Y2, UsedThirdPartyToolXi, sumToolAd, HOURS);
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

