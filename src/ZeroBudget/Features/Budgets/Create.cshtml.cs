using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZeroBudget.Features.Budgets;

public class CreateModel : PageModel
{
    [BindProperty]
    public BudgetDefinition BudgetDefinition { get; set; } = default!;
    public string? ErrorMessage { get; set; } = null;

    public void OnGet()
    {
        BudgetDefinition = new BudgetDefinition();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            ErrorMessage = "Invalid budget definition.";
            return Page();
        }

        // ErrorMessage = "Test";

        // Save the budget to the database

        // Redirect to the budget details page
        // return RedirectToPage("Details", new { id = budgetDefinition.Id });
        return RedirectToPage("Details");
    }
}

public sealed class BudgetDefinition
{
    [Required]
    [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
    [Display(Name = "Budget Name")]
    [DataType(DataType.Text)]
    [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Name can only contain letters, numbers, and spaces.")]
    public string Name { get; set; } = string.Empty;

    public BudgetDefinition()
    {
        
    }
}
