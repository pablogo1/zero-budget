using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZeroBudget.Data;

namespace ZeroBudget.Features.Budgets;

public class CreateModel(BudgetContext dbContext) : PageModel
{
    private readonly BudgetContext _dbContext = dbContext;

    [BindProperty]
    public BudgetHeaderViewModel BudgetDefinition { get; set; } = default!;
    public string? ErrorMessage { get; set; } = null;

    public Month[] Months { get; } = Month.Months;

    public void OnGet()
    {
        BudgetDefinition = new BudgetHeaderViewModel();
    }

    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid)
        {
            ErrorMessage = "Invalid budget definition.";
            return Page();
        }

        await Task.Yield();

        Models.Budget budget = Models.Budget.Create(
            BudgetDefinition.Name,
            BudgetDefinition.Month,
            BudgetDefinition.Year);

        _dbContext.Budgets.Add(budget);
        await _dbContext.SaveChangesAsync();

        return RedirectToPage("Details", new { id = budget.Id });
    }
}
    
public sealed class BudgetHeaderViewModel
{
    [Required]
    [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
    [Display(Name = "Budget Name")]
    [DataType(DataType.Text)]
    [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Name can only contain letters, numbers, and spaces.")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Month")]
    [DataType(DataType.Text)]
    public int Month { get; set; } = DateTime.Today.Month + 1;

    [Required]
    [Display(Name = "Year")]
    [DataType(DataType.Text)]
    public int Year { get; set; } = DateTime.Today.Year;


    public BudgetHeaderViewModel()
    {
        
    }
}


