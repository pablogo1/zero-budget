using System;
using Microsoft.Extensions.Logging;
using ZeroBudget.Features.Budgets;

namespace ZeroBudget.Unit.Tests.Features.Budgets.Details;

public partial class DetailsModelTests
{
    public class OnGet
    {
        private readonly ILoggerFactory _loggerFactory;

        public OnGet()
        {
            _loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
                builder.SetMinimumLevel(LogLevel.Debug);
            });
        }

        [Fact]
        public void Should_return_page_with_budget_name_as_month_and_year()
        {
            // Arrange
            var model = new EditModel(_loggerFactory.CreateLogger<EditModel>());

            // Act
            model.OnGet();

            // Assert
            model.Budget.BudgetName.ShouldBe("1st May 2025 - 15th May 2025");
        }

        [Fact]
        public void Should_return_income_and_expense_items()
        {
            // Arrange
            var model = new EditModel(_loggerFactory.CreateLogger<EditModel>());

            // Act
            model.OnGet();

            // Assert
            model.Budget.ShouldNotBeNull();
            model.Budget.IncomeItems.ShouldNotBeNull();
            model.Budget.ExpenseItems.ShouldNotBeNull();
            model.Budget.IncomeItems.Count.ShouldBe(2);
            model.Budget.ExpenseItems.Count.ShouldBe(3);
        }
    }
}
