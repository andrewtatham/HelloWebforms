using System;
using Moq;
using NUnit.Framework;

namespace HelloWebforms.UnitTests
{
    [TestFixture]
    public class WebDebugControlUnitTests
    {
        [Test]
        [Ignore("ASP.NET is bleugh - controls are null")]
        public void Page_Load()
        {
            var controller = new Mock<IWebDebugControlController>();
            controller.Setup(x => x.SessionID).Returns("1234");
            WebDebugControl control = new WebDebugControl();
            control.InitController(controller.Object);

            control.Page_Load(null, EventArgs.Empty);

            controller.Verify(x => x.OnLoad());
            Assert.AreEqual("1234", control.codeBehindLiteral.Text);

        }

    }
}