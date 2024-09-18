using Bunit;
using Bunit.TestDoubles;
using SoftwareTest_and_Security.Components.Pages;

namespace BlazorApp1Test
{
    public class HomeCodeTest
    {

        [Fact]
        public void HomeCode_TestIfUserIsLoggedIn_OnSuccess()
        {
            // Arrange
            using var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();
            authContext.SetAuthorized("mail@maim.mail");
            var cut = ctx.RenderComponent<Home>();

            // Act
            var isAuth = cut.Instance.IsAuth;
            var isAdmin = cut.Instance.IsAdmin;

            // Assert
            Assert.True(isAuth);
            Assert.False(isAdmin);
        }

        [Fact]
        public void HomeCode_TestIfUserIsNotLoggedIn_OnSuccess()
        {
            // Arrange
            using var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();
            authContext.SetNotAuthorized();
            var cut = ctx.RenderComponent<Home>();

            // Act
            var isAuth = cut.Instance.IsAuth;
            var isAdmin = cut.Instance.IsAdmin;

            // Assert
            Assert.False(isAuth && isAdmin);
        }

        [Fact]
        public void HomeCode_TestIfUserIsLoggedInAsAdmin_OnSuccess()
        {
            // Arrange
            using var ctx = new TestContext();
            var authContext = ctx.AddTestAuthorization();
            authContext.SetRoles("Admin");
            authContext.SetAuthorized("mail@maim.mail");
            var cut = ctx.RenderComponent<Home>();

            // Act
            var isAuth = cut.Instance.IsAuth;
            var isAdmin = cut.Instance.IsAdmin;

            // Assert
            Assert.True(isAdmin && isAuth);
        }
    }
}
