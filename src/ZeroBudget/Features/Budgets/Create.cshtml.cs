using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZeroBudget.Features.Budgets;

public class BudgetEntry
{
    public string Name { get; set; }
    public decimal Amount { get; set; }

    public BudgetEntry(string name, decimal amount)
    {
        Name = name;
        Amount = amount;
    }

    public BudgetEntry()
    {
        
    }
}

public class Entries
{
    public List<BudgetEntry> IncomeEntries { get; set; } = [];
}

public class CreateModel : PageModel
{
    // public HashSet<BudgetEntry> IncomeEntries { get; set; } = [];
    [BindProperty(SupportsGet = true)]
    public Entries Entries { get; set; } //= new();

    public void OnGet()
    {
        Entries.IncomeEntries.Add(new BudgetEntry("Salary", 0m));
        Entries.IncomeEntries.Add(new BudgetEntry("Side hustle", 0m));
    }

    public void OnPost(Entries entries)
    {
        var test = this.Entries;
        // Do nothing
        // Entries.IncomeEntries[0] = Entries.IncomeEntries[0] with { Amount = 1000m };
        // if (!ModelState.IsValid)
        // {
        //     return;
        // }

        // // Save the budget to the database

        // return;
    }

    // public Task OnPostAsync()
    // {
    //     if (!ModelState.IsValid)
    //     {
    //         return Task.CompletedTask;
    //     }

    //     // Save the budget to the database

    //     return Task.CompletedTask;
    // }
}
