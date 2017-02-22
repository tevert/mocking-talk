using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mocking.Controllers;
using Mocking.Tests.Helpers;

namespace Mocking.Tests
{
    [TestClass]
    public class ActionControllerTests
    {
        [TestMethod]
        public void ActionPost_SendsEmail_EmailGetsSent()
        {
            // arrange
            var testMessage = "Hello, world!";

            var mock = new EmailServiceMock();
            mock.Behaviors.Add(testMessage, true);

            var subject = new ActionController(mock);

            // act
            subject.Post(testMessage);

            // assert
            Assert.IsTrue(mock.Invocations.Contains(testMessage));
            Assert.AreEqual(1, mock.Invocations.Count);
        }
    }
}
