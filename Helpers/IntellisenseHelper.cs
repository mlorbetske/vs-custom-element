using System;
using System.Collections.Generic;

namespace VSCustomElement.Helpers
{
    public static class IntellisenseHelper
    {
        private static HashSet<string> standardHtmlElements;
        private static HashSet<string> standardHtmlAttributes;
        private static HashSet<string> customHtmlElements;
        private static HashSet<string> customHtmlGlobalAttributes;

        static IntellisenseHelper()
        {
            var standardHtmlElements = VSCustomElement.StandardHtmlElements.Split(',');
            var standardHtmlAttributes = VSCustomElement.StandardHtmlAttributes.Split(',');
            var customHtmlElements = new String[] { };
            var customHtmlGlobalAttributes = new String[] { };

            IntellisenseHelper.standardHtmlElements = new HashSet<string>(standardHtmlElements);
            IntellisenseHelper.standardHtmlAttributes = new HashSet<string>(standardHtmlAttributes);
            IntellisenseHelper.customHtmlElements = new HashSet<string>(customHtmlElements);
            IntellisenseHelper.customHtmlGlobalAttributes = new HashSet<string>();
        }

        /// <summary>
        /// Is element a standard html element?
        /// </summary>
        /// <param name="elementName">Name of the element</param>
        /// <returns>Result</returns>
        public static bool IsStandardHtmlElement(string elementName)
        {
            if (String.IsNullOrEmpty(elementName))
            {
                return false;
            }

            return IntellisenseHelper.standardHtmlElements.Contains(elementName.Trim().ToLower());
        }

        /// <summary>
        /// Is element a custom html element for current profile?
        /// </summary>
        /// <param name="elementName">Name of the element</param>
        /// <returns>Result</returns>
        public static bool IsCustomHtmlElement(string elementName)
        {
            if(String.IsNullOrEmpty(elementName))
            {
                return false;
            }

            return IntellisenseHelper.customHtmlElements.Contains(elementName.Trim().ToLower());
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
            if (String.IsNullOrEmpty(attributeName))
            {
                return false;
            }

            var trimmedAttributeName = attributeName.Trim().ToLower();

            return trimmedAttributeName.StartsWith("data-") || IntellisenseHelper.standardHtmlAttributes.Contains(trimmedAttributeName);
        }

        /// <summary>
        /// Is attribute a custom global html attribute?
        /// </summary>
        /// <param name="attributeName">Name of the attribute</param>
        /// <returns>Result</returns>
        public static bool IsCustomHtmlGlobalAttribute(string attributeName)
        {
            if (String.IsNullOrEmpty(attributeName))
            {
                return false;
            }

            return IntellisenseHelper.customHtmlGlobalAttributes.Contains(attributeName.Trim().ToLower());
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
    }
}
