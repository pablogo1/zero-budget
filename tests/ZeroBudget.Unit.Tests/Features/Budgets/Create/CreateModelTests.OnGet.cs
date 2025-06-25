using ZeroBudget.Features.Budgets;

namespace ZeroBudget.Unit.Tests.Features.Budgets.Create;

public partial class CreateModelTests
{
    [Collection("BudgetDatabase")]
    public class OnGet(BudgetDatabaseFixture fixture)
    {
        [Fact]
        public void Should_return_page_with_empty_name()
        {
            // Arrange
            var model = new CreateModel(fixture.Context);

            // Act
            model.OnGet();

            // Assert
            model.BudgetDefinition.ShouldNotBeNull();
            model.BudgetDefinition.Name.ShouldBe(string.Empty);
        }
    }
}
