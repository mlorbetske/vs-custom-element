using System;
using System.Collections.Generic;

namespace VSCustomElement.Helpers
{
    public static class HTMLHelper
    {
        private static HashSet<string> standardHtmlElements;
        private static HashSet<string> htmlGlobalAttributes;

        static HTMLHelper()
        {
            var standardHtmlElements = new String[] {
                "a", "abbr", "acronym", "address", "applet", "area", "article", "aside",
                "audio", "b", "base", "basefont", "bdi", "bdo", "big", "blockquote", "body",
                "br", "button", "canvas", "caption", "center", "cite", "code", "col", "colgroup",
                "datalist", "dd", "del", "details", "dfn", "dialog", "dir", "div", "dl", "dt",
                "em", "embed", "fieldset", "figcaption", "figure", "font", "footer", "form",
                "frame", "frameset", "h1", "h2", "h3", "h4", "h5", "h6", "head", "header",
                "hr", "html", "i", "iframe", "img", "input", "ins", "kbd", "keygen", "label",
                "legend", "li", "link", "main", "map", "mark", "menu", "menuitem", "meta",
                "meter", "nav", "noframes", "noscript", "object", "ol", "optgroup", "option",
                "output", "p", "param", "pre", "progress", "q", "rp", "rt", "ruby", "s", "samp",
                "script", "section", "select", "small", "source", "span", "strike", "strong",
                "style", "sub", "summary", "sup", "table", "tbody", "tr", "textarea", "tfoot",
                "th", "thead", "time", "title", "tr", "track", "tt", "u", "ul", "var", "video", "wbr"
            };

            var htmlGlobalAttributes = new String[]{
                "accesskey", "class", "contenteditable", "dir", "draggable", "dropzone", "hidden",
                "id", "lang", "spellcheck", "style", "tabindex", "title", "translate", "onafterprint"
            };

            HTMLHelper.standardHtmlElements = new HashSet<string>(standardHtmlElements);
            HTMLHelper.htmlGlobalAttributes = new HashSet<string>(htmlGlobalAttributes);
        }

        public static bool IsStandardHtmlElement(string elementName)
        {
            if(String.IsNullOrEmpty(elementName))
            {
                return false;
            }

            return HTMLHelper.standardHtmlElements.Contains(elementName.Trim().ToLower());
        }

        public static bool IsHtmlGlobalAttribute(string attributeName)
        {
            if(String.IsNullOrEmpty(attributeName))
            {
                return false;
            }

            var trimmedAttributeName = attributeName.Trim().ToLower();

            return trimmedAttributeName.StartsWith("data-") || HTMLHelper.htmlGlobalAttributes.Contains(trimmedAttributeName);
        }
    }
}
