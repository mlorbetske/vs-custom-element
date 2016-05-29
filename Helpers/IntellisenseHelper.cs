using System;
using System.Collections.Generic;

namespace VSCustomElement.Helpers
{
    /// <summary>
    /// Intellisense helper utilities.
    /// </summary>
    public static class IntellisenseHelper
    {
        private static HashSet<string> standardHtmlElements;
        private static HashSet<string> standardHtmlAttributes;
        private static HashSet<string> customHtmlElements;
        private static HashSet<string> customHtmlGlobalAttributes;
        private static Dictionary<string, HashSet<string>> attributesOfCustomHtmlElements;

        /// <summary>
        /// Initialize the static IntellisenseHelper instance.
        /// </summary>
        static IntellisenseHelper()
        {
            var standardHtmlElements = VSCustomElement.StandardHtmlElements.Split(',');
            var standardHtmlAttributes = VSCustomElement.StandardHtmlAttributes.Split(',');
            var customHtmlElements = new String[] { };
            var customHtmlGlobalAttributes = new String[] {"global" };

            IntellisenseHelper.standardHtmlElements = new HashSet<string>(standardHtmlElements);
            IntellisenseHelper.standardHtmlAttributes = new HashSet<string>(standardHtmlAttributes);
            IntellisenseHelper.customHtmlElements = new HashSet<string>(customHtmlElements);
            IntellisenseHelper.customHtmlGlobalAttributes = new HashSet<string>(customHtmlGlobalAttributes);
            IntellisenseHelper.attributesOfCustomHtmlElements = new Dictionary<string, HashSet<string>>();

            IntellisenseHelper.attributesOfCustomHtmlElements["div"] = new HashSet<string>(new String[] {"div-at"});
        }

        /// <summary>
        /// Is element a standard html element?
        /// </summary>
        /// <param name="elementName">Name of the element</param>
        /// <returns>Result</returns>
        public static bool IsStandardHtmlElement(string elementName)
        {
            return IntellisenseHelper.standardHtmlElements.Contains(HtmlHelper.Htmlize(elementName));
        }

        /// <summary>
        /// Is element a custom html element for current profile?
        /// </summary>
        /// <param name="elementName">Name of the element</param>
        /// <returns>Result</returns>
        public static bool IsCustomHtmlElement(string elementName)
        {
            return IntellisenseHelper.customHtmlElements.Contains(HtmlHelper.Htmlize(elementName));
        }

        /// <summary>
        /// Is element known by VSCustomElement extension?
        /// </summary>
        /// <param name="elementName">Name of the element</param>
        /// <returns>Result</returns>
        public static bool IsKnownHtmlElement(string elementName)
        {
            return IntellisenseHelper.IsStandardHtmlElement(elementName) ||
                   IntellisenseHelper.IsCustomHtmlElement(elementName);
        }

        /// <summary>
        /// Is attribute a standard html attribute?
        /// </summary>
        /// <param name="attributeName">Name of the attribute</param>
        /// <returns>Result</returns>
        public static bool IsStandardHtmlAttribute(string attributeName)
        {
            var trimmedAttributeName = HtmlHelper.Htmlize(attributeName);

            return trimmedAttributeName.StartsWith("data-") || IntellisenseHelper.standardHtmlAttributes.Contains(trimmedAttributeName);
        }

        /// <summary>
        /// Is attribute a custom global html attribute?
        /// </summary>
        /// <param name="attributeName">Name of the attribute</param>
        /// <returns>Result</returns>
        public static bool IsCustomHtmlGlobalAttribute(string attributeName)
        {
            return IntellisenseHelper.customHtmlGlobalAttributes.Contains(HtmlHelper.Htmlize(attributeName));
        }

        /// <summary>
        /// Is attribute known by VSCustomElement extension?
        /// </summary>
        /// <param name="attributeName">Name of the attribute</param>
        /// <returns>Result</returns>
        public static bool IsKnownHtmlAttribute(string attributeName)
        {
            return IsStandardHtmlAttribute(attributeName) ||
                   IsCustomHtmlGlobalAttribute(attributeName); 
        }

        /// <summary>
        /// Is attribute is known by VSCustomElement extension for given custom html element?
        /// </summary>
        /// <param name="elementName">Name of the element</param>
        /// <param name="attributeName">Name of the attribute</param>
        /// <returns>Result</returns>
        public static bool IsAttributeOfCustomHtmlElement(string elementName, string attributeName)
        {
            var trimmedElementName = HtmlHelper.Htmlize(elementName);
            var trimmedAttributeName = HtmlHelper.Htmlize(attributeName);

            if (IntellisenseHelper.attributesOfCustomHtmlElements.ContainsKey(trimmedElementName))
            {
                var attributesOfElement = IntellisenseHelper.attributesOfCustomHtmlElements[trimmedElementName];

                if(attributesOfElement != null)
                {
                    return attributesOfElement.Contains(trimmedAttributeName);
                }

                IntellisenseHelper.attributesOfCustomHtmlElements[trimmedElementName] = new HashSet<string>();

                return false;
            }

            return false;
        }
    }
}
