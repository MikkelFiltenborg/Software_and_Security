using Bunit;
using Bunit.TestDoubles;
using SoftwareTest_and_Security.Components.Pages;

namespace BlazorApp1Test
{
    public class HomeViewTest
    {
        [Fact]
        public void HomeView_TestIfUserIsLoggedIn_OnSuccess()
        {
            // Arrange
            using var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();
            authContext.SetAuthorized("mail@maim.mail");
            var cut = ctx.RenderComponent<Home>();

            // Act
            var paraElm = cut.Find("p");

            // Assert
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches("You are logged in!");
        }

        [Fact]
        public void HomeView_TestIfUserIsNotLoggedIn_OnSuccess()
        {
            // Arrange
            using var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();
            authContext.SetNotAuthorized();
            var cut = ctx.RenderComponent<Home>();

            // Act
            var paraElm = cut.Find("p");

            // Assert
            var paraElmText = paraElm.TextContent;
            paraElmText.MarkupMatches("You are not logged in!");
        }

        [Fact]
        public void HomeView_TestIfUserIsLoggedInAsAdmin_OnSuccess()
        {
            // Arrange
            using var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();
            authContext.SetRoles("Admin");
            authContext.SetAuthorized("mail@maim.mail");
            var cut = ctx.RenderComponent<Home>();

            // Act
            var paraElms = cut.FindAll("p");

            // Assert
            Assert.Contains(paraElms, paraElm => paraElm.TextContent == "You are logged in as Admin!");
        }
    }
}