using System;
using ZeroBudget.Features.Budgets;

namespace ZeroBudget.Unit.Tests.Features.Budgets.Details;

public partial class DetailsModelTests
{
    public class OnGet
    {
        [Fact]
        public void Should_return_page_with_budget_name_and_month()
        {
            // Arrange
            var model = new DetailsModel();

            // Act
            model.OnGet();

            // Assert
            model.BudgetDefinition.ShouldNotBeNull();
            model.BudgetDefinition.Name.ShouldBe("May Budget");
            model.BudgetDefinition.Month.ShouldBe(Month.May);
            model.BudgetDefinition.Year.ShouldBe(2025);
        }
    }
}
