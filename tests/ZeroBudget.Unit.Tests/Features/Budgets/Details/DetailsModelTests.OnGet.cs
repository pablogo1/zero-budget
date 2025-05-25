using System;
using ZeroBudget.Features.Budgets;

namespace ZeroBudget.Unit.Tests.Features.Budgets.Details;

public partial class DetailsModelTests
{
    public class OnGet
    {
        [Fact]
        public void Should_return_page_with_budget_name_as_month_and_year()
        {
            // Arrange
            var model = new DetailsModel();

            // Act
            model.OnGet();

            // Assert
            model.BudgetName.ShouldBe("May 2025 Budget");
        }

        [Fact]
        public void Should_return_income_and_expense_items()
        {
            // Arrange
            var model = new DetailsModel();

            // Act
            model.OnGet();

            // Assert
            model.Income.ShouldNotBeNull();
            model.Expenses.ShouldNotBeNull();
            model.Income.Count.ShouldBe(2);
            model.Expenses.Count.ShouldBe(3);
        }
    }
}
