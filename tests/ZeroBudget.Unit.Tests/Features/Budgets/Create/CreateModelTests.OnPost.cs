using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Shouldly;
using ZeroBudget.Features.Budgets;
using ZeroBudget.Models;

namespace ZeroBudget.Unit.Tests.Features.Budgets.Create;

public partial class CreateModelTests
{
    [Collection("BudgetDatabase")]
    public class OnPost(BudgetDatabaseFixture fixture)
    {
        [Fact]
        public async Task Should_redirect_to_Edit_when_given_valid_BudgetDefinition()
        {
            // Arrange
            const string budgetName = "Test Budget 123";
            var model = new CreateModel(fixture.Context)
            {
                BudgetDefinition = new BudgetHeaderViewModel()
                {
                    Name = budgetName
                }
            };

            // Act
            var pageResponse = await model.OnPost();

            // Assert
            model.ErrorMessage.ShouldBeNull();
            pageResponse.ShouldBeAssignableTo<RedirectToPageResult>();
            RedirectToPageResult redirectToPageResult = (pageResponse as RedirectToPageResult)!;
            redirectToPageResult.PageName.ShouldBe("Edit");
            redirectToPageResult.RouteValues.ShouldNotBeEmpty();
            redirectToPageResult.RouteValues!.ShouldContainKey("id");
            fixture.Context.Budgets.Where(b => b.Name == budgetName).ShouldNotBeEmpty();
        }

        [Fact]
        public async Task Should_display_error_message_when_given_an_invalid_BudgetDefinition()
        {
            // Arrange
            var model = new CreateModel(fixture.Context)
            {
                BudgetDefinition = new BudgetHeaderViewModel()
                {
                    Name = "#$@#__!$error"
                }
            };
            model.ModelState.AddModelError("BudgetDefinition.Name", "Invalid name.");

            // Act
            await model.OnPost();

            // Assert
            model.ErrorMessage.ShouldBe("Invalid budget definition.");
        }
    }
}
