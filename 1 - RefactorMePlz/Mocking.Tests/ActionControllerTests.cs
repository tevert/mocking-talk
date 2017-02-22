using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mocking.Controllers;

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
            
            var subject = new ActionController();

            // act
            subject.Post(testMessage);

            // assert
        }
    }
}
