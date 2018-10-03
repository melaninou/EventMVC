using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace EventProject.Extensions
{
    public static class HtmlExtensions
    {
        public static IHtmlContent EditingControlsFor<TModel, TResult>(this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TResult>> expression)
        {
            var htmlStrings = new List<object>
            {
                new HtmlString("<div class=\"form-group\">"),
                htmlHelper.LabelFor(expression, new {@class = "control-label col-md-2"}),
                new HtmlString("<div class=\"col-md-4\">"),
                htmlHelper.EditorFor(expression, new {htmlAttributes = new {@class = "form-control"}}),
                htmlHelper.ValidationMessageFor(expression, "", new {@class = "text-danger"}), //shows required message
                new HtmlString("</div>"),
                new HtmlString("</div>")
            };
            return new HtmlContentBuilder(htmlStrings);
        }

    }
}
