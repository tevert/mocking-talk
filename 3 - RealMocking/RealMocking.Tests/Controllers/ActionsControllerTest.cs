using Microsoft.VisualStudio.TestTools.UnitTesting;
using RealMocking.Controllers;
using NSubstitute;
using RealMocking.Services;

namespace RealMocking.Tests.Controllers
{
    [TestClass]
    public class ActionsControllerTest
    {
        [TestMethod]
        public void ActionsControllerPost_SendsEmail_ReturnsSuccess()
        {
            // arrange
            var testMessage = "Hello, world!";

            var emailsMock = Substitute.For<IEmailService>();
            emailsMock.SendEmail(testMessage).Returns(true);

            var subject = new ActionsController(emailsMock);

            // act
            subject.Post(testMessage);

            // Make assertions that our call happened!
            emailsMock.Received().SendEmail(testMessage);
            emailsMock.Received(1).SendEmail("Hello, world!"); // 1 is implied, but specificity helps sometimes
            emailsMock.DidNotReceive().SendEmail("this didn't happen");

            // Now let's validate our parameters more
            // Use this if you really can't predict what the argument will be - avoid using this where possible though. 
            emailsMock.Received().SendEmail(Arg.Any<string>());
            // Basically equivalent to our first test, useful in cases where types can get confused
            emailsMock.Received().SendEmail(Arg.Is(testMessage));
            // Useful for complex argument validation
            emailsMock.Received().SendEmail(Arg.Is<string>(s => 
                    s.Length > 0 &&
                    s.StartsWith("H") &&
                    s.EndsWith("!")));
        }
    }
}
