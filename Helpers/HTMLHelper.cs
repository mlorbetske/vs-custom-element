using System;
using System.Collections.Generic;

namespace VSCustomElement.Helpers
{
    public static class HTMLHelper
    {
        private static HashSet<string> standardHtmlElements;
        private static HashSet<string> standardHtmlAttributes;

        static HTMLHelper()
        {
            var standardHtmlElements = VSCustomElement.StandardHtmlElements.Split(',');
            var standardHtmlAttributes = VSCustomElement.StandardHtmlAttributes.Split(',');

            HTMLHelper.standardHtmlElements = new HashSet<string>(standardHtmlElements);
            HTMLHelper.standardHtmlAttributes = new HashSet<string>(standardHtmlAttributes);
        }

        public static bool IsStandardHtmlElement(string elementName)
        {
            if (String.IsNullOrEmpty(elementName))
            {
                return false;
            }

            return HTMLHelper.standardHtmlElements.Contains(elementName.Trim().ToLower());
        }

        public static bool IsHtmlGlobalAttribute(string attributeName)
        {
            if (String.IsNullOrEmpty(attributeName))
            {
                return false;
            }

            var trimmedAttributeName = attributeName.Trim().ToLower();

            return trimmedAttributeName.StartsWith("data-") || HTMLHelper.standardHtmlAttributes.Contains(trimmedAttributeName);
        }
    }
}
