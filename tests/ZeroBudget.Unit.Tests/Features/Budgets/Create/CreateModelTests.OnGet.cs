using Shouldly;
using ZeroBudget.Features.Budgets;

namespace ZeroBudget.Unit.Tests.Features.Budgets.Create;

public partial class CreateModelTests
{
    public class OnGet
    {
        [Fact]
        public void Should_return_page_with_empty_name()
        {
            // Arrange
            var model = new CreateModel();

            // Act
            model.OnGet();

            // Assert
            model.BudgetDefinition.ShouldNotBeNull();
            model.BudgetDefinition.Name.ShouldBe(string.Empty);
        }
    }
}
