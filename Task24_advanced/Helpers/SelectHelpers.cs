using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task24_advanced.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public static class SelectHelpers
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public static MvcHtmlString DispayCheckBoxOL(this HtmlHelper htmlHelper, string[] words)
        {

            string result = "<ol>";
            foreach (var i in words)
            {
                var tag = new TagBuilder("input");
                tag.MergeAttribute("type", "checkbox");
                tag.MergeAttribute("name", i);
                tag.MergeAttribute("value", i);
                tag.SetInnerText(i);
                result +=  "<li><div class=\"checkbox\">"+ tag.ToString()+"</div></li>";
            }
            result += "</ol>";
            
            return new MvcHtmlString(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="radioName"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public static MvcHtmlString DispayRadioButtonOL(this HtmlHelper htmlHelper, string radioName, string[] words)
        {

            string result = "<ol>";
            foreach (var i in words)
            {

                var tag = new TagBuilder("input");
                tag.MergeAttribute("type", "radio");
                tag.MergeAttribute("name", radioName);
                tag.MergeAttribute("value", i);
                tag.SetInnerText(i);
                result += "<li><div class=\"radio\">" + tag.ToString() + "</div></li>";
            }
            result += "</ol>";

            return new MvcHtmlString(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="types"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public static MvcHtmlString DispayTextBoxOL(this HtmlHelper htmlHelper, string[] types, string[] words)
        {

            string result = "<ol>";
            for(int i = 0; i < types.Length; i++)
            {

                var tag = new TagBuilder("input");
                tag.MergeAttribute("type", types[i]);
                tag.MergeAttribute("name", words[i]);
                tag.MergeAttribute("class", "form-control");
                tag.MergeAttribute("required", "required");
                result += "<li><div class=\"form-group\">"+ words[i]+" </br>" + tag.ToString() + "</div></li>";
            }
            result += "</ol>";

            return new MvcHtmlString(result);
        }
    }
}