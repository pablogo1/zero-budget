using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZeroBudget.Features.Budgets;

public class CreateModel : PageModel
{
    [BindProperty]
    public BudgetDefinition BudgetDefinition { get; set; } = default!;
    public string? ErrorMessage { get; set; } = null;

    public Month[] Months { get; } = Month.Months;

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

    [Required]
    [Display(Name = "Month")]
    [DataType(DataType.Text)]
    public int Month { get; set; } = DateTime.Today.Month + 1;

    [Required]
    [Display(Name = "Year")]
    [DataType(DataType.Text)]
    public int Year { get; set; } = DateTime.Today.Year;


    public BudgetDefinition()
    {
        
    }
}

public record Month(int Number, string Name)
{
    public static Month[] Months =>
    [
        new Month(1, "January"),
        new Month(2, "February"),
        new Month(3, "March"),
        new Month(4, "April"),
        new Month(5, "May"),
        new Month(6, "June"),
        new Month(7, "July"),
        new Month(8, "August"),
        new Month(9, "September"),
        new Month(10, "October"),
        new Month(11, "November"),
        new Month(12, "December")
    ];
}
