using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Linq;
using BudgetCalculator.Services; 

namespace BudgetCalculator.Pages.Budget
{
    public class IndexModel : PageModel
    {
        private readonly BudgetService _budgetService;

        public IndexModel(BudgetService budgetService)
        {
            _budgetService = budgetService;
        }

        [BindProperty]
        public double Z { get; set; }

        [BindProperty]
        public double Y1 { get; set; }

        [BindProperty]
        public double Y2 { get; set; }

        [BindProperty]
        public double HOURS { get; set; }

        [BindProperty]
        public string OtherAdsBudgets { get; set; }

        public double? Result { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            try
            {
                var otherAdsBudgetsArray = OtherAdsBudgets.Split(',')
                                                         .Select(double.Parse)
                                                         .ToArray();
                Result = _budgetService.GoalSeekBinarySearch(Z, Y1, Y2, otherAdsBudgetsArray, HOURS);
            }
            catch (Exception ex)
            {
                // Handle the error appropriately
                ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
            }
        }
    }
}
