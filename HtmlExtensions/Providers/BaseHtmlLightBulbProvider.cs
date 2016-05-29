using System;
using Microsoft.Html.Core.Tree.Nodes;

namespace VSCustomElement.HtmlExtensions
{
    abstract class BaseHtmlLightBulbProvider
    {
        protected abstract string GetCaption(ElementNode element, AttributeNode attribute);

        protected bool IsTargetHtmlElement(ElementNode element, AttributeNode attribute)
        {
            return element != null && !String.IsNullOrEmpty(element.Name) && attribute == null;
        }

        protected bool IsTargetHtmlAttribute(ElementNode element, AttributeNode attribute)
        {
            return IsTargetHtmlElement(element, null) && attribute != null && !String.IsNullOrEmpty(attribute.Name);
        }
    }
}
