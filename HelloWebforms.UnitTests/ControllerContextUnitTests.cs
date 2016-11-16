using HelloWebforms.Controller;
using Moq;
using NUnit.Framework;

namespace HelloWebforms.UnitTests
{
    [TestFixture]
    public class ControllerContextUnitTests
    {

        [Test]
        public void GetDebugInfo()
        {
            var session = new Mock<ISessionWrapper>();
            var application = new Mock<IApplicationWrapper>();
            var request = new Mock<IRequestWrapper>();
            var response = new Mock<IResponseWrapper>();

            ControllerContext controllerContext = new ControllerContext(
                session.Object,
                application.Object,
                request.Object,
                response.Object);
            var actual = controllerContext.GetDebugInfo();

            session.Verify(x => x.GetDebugInfo());
            application.Verify(x => x.GetDebugInfo());
            request.Verify(x => x.GetDebugInfo());
            response.Verify(x => x.GetDebugInfo());
            Assert.IsNotNull(actual);

        }



    }
}