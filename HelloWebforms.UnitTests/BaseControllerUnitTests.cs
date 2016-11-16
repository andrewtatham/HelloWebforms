using HelloWebforms.Controller;
using Moq;
using NUnit.Framework;

namespace HelloWebforms.UnitTests
{
    [TestFixture]
    public class BaseControllerUnitTests
    {
        [Test]
        public void OnLoad()
        {
            var controllerContext = new Mock<IControllerContext>();
            controllerContext.Setup(x => x.Application.IncrementPageLoadCounter());
            controllerContext.Setup(x => x.Session.SetUpdated());

            BaseController controller = new BaseController(controllerContext.Object);
            var actual = controller.OnLoad();

            controllerContext.Verify(x => x.Application.IncrementPageLoadCounter());
            controllerContext.Verify(x => x.Session.SetUpdated());
        }


        [Test]
        public void GetDebugInfo()
        {
            var controllerContext = new Mock<IControllerContext>();
            BaseController controller = new BaseController(controllerContext.Object);

            var actual = controller.GetDebugInfo();
            controllerContext.Verify(x => x.GetDebugInfo());
        }


    }
}