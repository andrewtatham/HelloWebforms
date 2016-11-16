using HelloWebforms.Controller;
using Moq;
using NUnit.Framework;

namespace HelloWebforms.UnitTests
{
    [TestFixture]
    public class WebDebugControlControllerUnitTests
    {
        [Test]
        public void TODO()
        {
            var controllerContext = new Mock<IControllerContext>();
            var controller = new WebDebugControlController(controllerContext.Object);
            Assert.Inconclusive();
        }

    }
}