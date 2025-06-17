using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZeroBudget.Features.Budgets;

public class EditModel(ILogger<EditModel> logger) : PageModel
{
    public readonly ILogger<EditModel> _logger = logger;

    [BindProperty]
    public BudgetViewModel Budget { get; set; } = new();

    public void OnGet()
    {
        Budget.IncomeItems =
        [
            new(1, 1, "Salary", 5000),
            new(2, 1, "Freelance", 2000),
        ];
        Budget.ExpenseItems =
        [
            new(10, 4, "Rent", 1500),
            new(11, 4, "Groceries", 500),
            new(12, 4, "Utilities", 300),
        ];
        Budget.BudgetKey = "XXysz";
        Budget.BudgetName = "1st May 2025 - 15th May 2025";
    }

    public IActionResult OnPostSave()
    {
        // Handle form submission logic here
        // For example, save the budget data to a database or update the budget details
        Debug.WriteLine(Budget.IncomeItems);
        _logger.LogInformation("Budget items updated successfully.");
        _logger.LogInformation(JsonSerializer.Serialize(Budget));

        return Page();
    }

    public IActionResult OnPostAddIncomeItem()
    {
        _logger.LogInformation("Adding income item");
        string? categoryName = Request.Form["IncomeCategory"];
        string? plannedAmountText = Request.Form["PlannedAmount"];
        if (string.IsNullOrEmpty(categoryName) || string.IsNullOrEmpty(plannedAmountText))
        {
            ModelState.AddModelError(string.Empty, "Category name and planned amount are required.");
            return Page();
        }
        Budget.IncomeItems.Add(new BudgetItem(0, 99, categoryName, Convert.ToDecimal(plannedAmountText)));
        return Page();
    }

    public IActionResult OnPostAddExpenseItem()
    {
        _logger.LogInformation("Adding expense item");
        string? categoryName = Request.Form["ExpenseCategory"];
        string? plannedAmountText = Request.Form["PlannedAmount"];
        if (string.IsNullOrEmpty(categoryName) || string.IsNullOrEmpty(plannedAmountText))
        {
            ModelState.AddModelError(string.Empty, "Category name and planned amount are required.");
            return Page();
        }
        Budget.ExpenseItems.Add(new BudgetItem(0, 99, categoryName, Convert.ToDecimal(plannedAmountText)));
        return Page();
    }

}

public class BudgetViewModel
{
    public string BudgetKey { get; set; } = "XXysz";
    public string BudgetName { get; set; } = string.Empty;

    public List<BudgetItem> IncomeItems { get; set; } = [];
    public List<BudgetItem> ExpenseItems { get; set; } = [];

    public decimal TotalIncome => IncomeItems.Sum(item => item.PlannedAmount);
    public decimal TotalExpenses => ExpenseItems.Sum(item => item.PlannedAmount);
}

public record BudgetItem(int Id, int CategoryId, string CategoryName, decimal PlannedAmount);
