using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public static IHtmlContent ViewingControlsFor<TModel, TResult>(this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TResult>> expression)
        {
            var htmlStrings = new List<object>
            {
                new HtmlString("<div class=\"form-group\">"),
                htmlHelper.LabelFor(expression, new {@class = "control-label col-md-2"}),
                new HtmlString("<div class=\"col-md-10\" style=\"margin-top:10px\">"),
                htmlHelper.DisplayFor(expression, new {htmlAttributes = new {@class = "form-control"}}),
                new HtmlString("</div>"),
                new HtmlString("</div>")
            };
            return new HtmlContentBuilder(htmlStrings);
        }

        public static IHtmlContent SortColumnHeaderFor<TModel, TResult>(
            this IHtmlHelper<TModel> htmlHelper, object sortString,
            Expression<Func<TModel, TResult>> expression)
        {
            var linkName = htmlHelper.DisplayNameFor(expression);
            string action = "Index";
            var htmlStrings = new List<object>
            {
                new HtmlString("<th>"),
                htmlHelper.ActionLink(linkName, action, new {SortOrder = sortString}),
                new HtmlString("</th>")
            };
            return new HtmlContentBuilder(htmlStrings);
        }

        public static IHtmlContent EditDetailDeleteFor<TModel, TResult>(
            this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TResult>> expression)
        {
            string edit = "Edit";
            string details = "Details";
            string delete = "Delete";
            var index = htmlHelper.ValueFor(expression);
            var htmlStrings = new List<object>
            {
                new HtmlString("<th>"),
                htmlHelper.ActionLink("Edit", edit, new {id = index}),
                new HtmlString(" | "),
                htmlHelper.ActionLink("Details", details, new {id = index}),
                new HtmlString(" | "),
                htmlHelper.ActionLink("Delete", delete, new {id = index}),
                new HtmlString("</th>")
            };
            return new HtmlContentBuilder(htmlStrings);
        }

    }
}
