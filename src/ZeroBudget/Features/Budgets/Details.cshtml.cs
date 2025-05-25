using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZeroBudget.Features.Budgets;

public class DetailsModel : PageModel
{
    // public BudgetDetail BudgetDetail { get; set; } = default!;
    public string BudgetName { get; set; } = string.Empty;

    public void OnGet()
    {
        var incomeItems = new List<BudgetItem>
        {
            new("Salary", new BudgetAmount(5000), new BudgetAmount(4500)),
            new("Freelance", new BudgetAmount(2000), new BudgetAmount(2500)),
        };
        var expensesItems = new List<ExpenseItem>
        {
            new("Rent", 1500, 1500),
            new("Groceries", 500, 600),
            new("Utilities", 300, 250)
        };
        var income = new IncomeCategory(incomeItems);
        var expenses = new ExpenseCategory(expensesItems);
        List<PartialBudget> partialBudgets = [
            new PartialBudget("Q1", income, expenses),
            new PartialBudget("Q2", income, expenses)
        ];
        BudgetDetail = new BudgetDetail("may-2025", 2025, Month.May, partialBudgets);
    }
}

// public record BudgetDetail(string Key, int Year, Month Month, List<BudgetItem> Income, List<BudgetItem> Expenses)
// {
//     public BudgetAmount TotalIncome => Income.Aggregate(
//         BudgetAmount.Zero, 
//         (total, current) => total with { Actual = total.Actual + current.ActualAmount, Planned = total.Planned + current.PlannedAmount });
//     public BudgetAmount TotalExpenses => Expenses.Aggregate(
//         BudgetAmount.Zero, 
//         (total, current) => total with { Actual = total.Actual + current.ActualAmount, Planned = total.Planned + current.PlannedAmount });
//     public BudgetAmount TotalDifference => [(TotalIncome, TotalExpenses)].;
// };


public record BudgetAmount(decimal Planned, decimal Actual)
{
    public decimal Difference => Planned - Actual;
    public static BudgetAmount Zero => new(0, 0);
};
public record BudgetItem(string Name, List<BudgetAmount> Amounts)
{
    public decimal PlannedAmount => Amounts.Sum(a => a.Planned);
    public decimal ActualAmount => Amounts.Sum(a => a.Actual);
};

// public record IncomeCategory(List<BudgetItem> Items)
// {
//     public decimal TotalPlannedAmount => Items.Sum(i => i.PlannedAmount);
// };
// public record ExpenseCategory(List<BudgetItem> Items)
// {
//     public decimal TotalPlannedAmount => Items.Sum(i => i.PlannedAmount);
//     public decimal TotalActualAmount => Items.Sum(i => i.ActualAmount);
//     public decimal TotalDifference => TotalPlannedAmount - TotalActualAmount;
// };

// Model
