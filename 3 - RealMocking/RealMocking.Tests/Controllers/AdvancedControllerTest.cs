using Microsoft.VisualStudio.TestTools.UnitTesting;
using RealMocking.Controllers;
using NSubstitute;
using RealMocking.Services;
using Moq;
using Ploeh.AutoFixture;

namespace RealMocking.Tests.Controllers
{
    [TestClass]
    public class AdvancedControllerTest
    {
        [TestMethod]
        public void AdvancedControllerPost_GetsMessageAndSendsEmail_ReturnsSuccess()
        {
            // arrange
            var name = "Tyler";
            var testMessage = "Hello";

            var messagesMock = Substitute.For<IMessageBuilder>();
            messagesMock.Greeting(name).Returns(testMessage);

            var emailsMock = Substitute.For<IEmailService>();
            emailsMock.SendEmail(testMessage).Returns(true);

            var subject = new AdvancedController(emailsMock, messagesMock);

            // act
            subject.Post(name);

            // assert
            messagesMock.Received().Greeting(name);
            emailsMock.Received().SendEmail(testMessage);
        }

        [TestMethod]
        public void Moq_AdvancedControllerPost_GetsMessageAndSendsEmail_ReturnsSuccess()
        {
            // arrange
            var name = "Tyler";
            var testMessage = "Hello";

            var messagesMock = new Mock<IMessageBuilder>();
            messagesMock.Setup(m => m.Greeting(name)).Returns(testMessage);

            var emailsMock = new Mock<IEmailService>();
            emailsMock.Setup(m => m.SendEmail(testMessage)).Returns(true);

            var subject = new AdvancedController(emailsMock.Object, messagesMock.Object);

            // act
            subject.Post(name);

            // assert
            messagesMock.Verify(m => m.Greeting(name));
            emailsMock.Verify(m => m.SendEmail(testMessage));
        }

        [TestMethod]
        public void AutoFixture_AdvancedControllerPost_GetsMessageAndSendsEmail_ReturnsSuccess()
        {
            // arrange
            // https://github.com/AutoFixture/AutoFixture/wiki/Cheat-Sheet
            var fixture = new Fixture();
            var name = fixture.Create<string>();
            var testMessage = fixture.Create<string>();

            var messagesMock = Substitute.For<IMessageBuilder>();
            messagesMock.Greeting(name).Returns(testMessage);

            var emailsMock = Substitute.For<IEmailService>();
            emailsMock.SendEmail(testMessage).Returns(true);

            var subject = new AdvancedController(emailsMock, messagesMock);

            // act
            subject.Post(name);

            // assert
            messagesMock.Received().Greeting(name);
            emailsMock.Received().SendEmail(testMessage);
        }
    }
}
