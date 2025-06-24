using Microsoft.AspNetCore.Mvc;
using Shouldly;
using ZeroBudget.Features.Budgets;

namespace ZeroBudget.Unit.Tests.Features.Budgets.Create;

public partial class CreateModelTests
{
    public class OnPost
    {
        [Fact]
        public void Should_redirect_to_Details_when_given_valid_BudgetDefinition()
        {
            // Arrange
            var model = new CreateModel
            {
                BudgetDefinition = new BudgetHeaderViewModel()
                {
                    Name = "Test Budget"
                }
            };

            // Act
            var pageResponse = model.OnPost();

            // Assert
            model.ErrorMessage.ShouldBeNull();
            pageResponse.ShouldBeAssignableTo<RedirectToPageResult>();
            (pageResponse as RedirectToPageResult)!.RouteValues.ShouldNotBeEmpty();
        }

        [Fact]
        public void Should_display_error_message_when_given_an_invalid_BudgetDefinition()
        {
            // Arrange
            var model = new CreateModel
            {
                BudgetDefinition = new BudgetHeaderViewModel()
                {
                    Name = "#$@#__!$error"
                }
            };
            model.ModelState.AddModelError("BudgetDefinition.Name", "Invalid name.");

            // Act
            model.OnPost();

            // Assert
            model.ErrorMessage.ShouldBe("Invalid budget definition.");
        }
    }
}
