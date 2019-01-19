using System.IO;
using Aids;
using EventProject.Extensions;
using Facade.Event;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.WebEncoders.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.EventProject.Extensions
{
    [TestClass]
    public class HtmlExtensionsTests :BaseTests
    {
        private IHtmlHelper<EventViewModel> helper;
        private StringWriter writer;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(HtmlExtensions);
            helper = new mockHtmlHelper<EventViewModel>();
            writer = new StringWriter();
        }
        //TODO
        [TestMethod]
        public void EditingControlsForTest()
        {
            var v = helper.EditingControlsFor(x => x.Name);
            v.WriteTo(writer, new HtmlTestEncoder());
            const string expected =
                "<div class=\"form-group\">" +
                "LabelFor Name { class = control-label col-md-2 }" +
                "<div class=\"col-md-4\">" +
                "EditorFor Name { htmlAttributes = { class = form-control } }" +
                "ValidationMessageFor Name { class = text-danger }" +
                "</div>" +
                "</div>";
            Assert.AreEqual(expected, writer.ToString());
        }

        //TODO
        [TestMethod]
        public void ViewingControlsForTest()
        {
            var v = helper.ViewingControlsFor(x => x.Name);
            v.WriteTo(writer, new HtmlTestEncoder());
            const string expected =
                "<div class=\"form-group\">" +
                "LabelFor Name { class = control-label col-md-2 }" +
                "<div class=\"col-md-10\" style=\"margin-top:10px\">" +
                "DisplayFor Name { htmlAttributes = { class = form-control } }" +
                "</div>" +
                "</div>";
            Assert.AreEqual(expected, writer.ToString());
        }


        [TestMethod]
        public void SortColumnHeaderForTest()
        {
            var s = GetRandom.String();
            var v = helper.SortColumnHeaderFor(s, x => x.Name);
            v.WriteTo(writer, new HtmlTestEncoder());
            var expected =
                "<th>" +
                "ActionLink Index { SortOrder = " +
                s +
                " }" +
                "</th>";
            Assert.AreEqual(expected, writer.ToString());
        }

        [TestMethod]
        public void EditDetailDeleteForTest()
        {
            Assert.Inconclusive();
        }
    }
}
