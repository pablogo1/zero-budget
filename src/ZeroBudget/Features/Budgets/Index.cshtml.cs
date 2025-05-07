using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZeroBudget.Features.Budgets;

public class IndexModel(ILogger<IndexModel> logger) : PageModel
{
    public IEnumerable<(string Key, string Month, int Year)> Budgets { get; set; } = [];

    public void OnGet()
    {
        logger.LogInformation("Getting all budgets");
        Budgets =
        [
            ("january-2025", "January", 2025),
            ("february-2025", "February", 2025),
            ("march-2025", "March", 2025),
            ("may-2025", "May", 2025)
        ];
    }
}
