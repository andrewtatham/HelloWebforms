using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using System.Web;
using HelloWebforms.Helpers;

namespace HelloWebforms.UnitTests
{
    [TestFixture]
    public class DefaultPageUnitTests
    {
        [Test]
        [Ignore("ASP.NET is bleugh - controls are null")]
        public void Page_Load()
        {
            var controller = new Mock<IDefaultController>();

            _Default page = new _Default();
            page.InitController(controller.Object);

            page.Page_Load(null, EventArgs.Empty);

            controller.Verify(x => x.OnLoad());
        }


    }
}