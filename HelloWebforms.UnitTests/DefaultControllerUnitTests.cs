using HelloWebforms.Controller;
using Moq;
using NUnit.Framework;

namespace HelloWebforms.UnitTests
{
    [TestFixture]
    public class DefaultControllerUnitTests
    {
        [Test]
        public void TODO()
        {
            var controllerContext = new Mock<IControllerContext>();
            var controller = new DefaultController(controllerContext.Object);
            Assert.Inconclusive();
        }

    }
}