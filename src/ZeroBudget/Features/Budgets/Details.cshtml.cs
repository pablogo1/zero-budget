using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZeroBudget.Features.Budgets;

public class DetailsModel : PageModel
{
    public BudgetDefinition BudgetDefinition { get; set; } = default!;

    public void OnGet()
    {
        BudgetDefinition = new BudgetDefinition("May Budget", 2025, Month.May);
    }
}

public class BudgetDefinition
{
    // public int Id { get; set; }
    public string Name { get; }
    public int Year { get; }
    public Month Month { get; } = default!;

    public BudgetDefinition(string name, int year, Month month)
    {
        Name = name;
        Year = year;
        Month = month;
    }
}
