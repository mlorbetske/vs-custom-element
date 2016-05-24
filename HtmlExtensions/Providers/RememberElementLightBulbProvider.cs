using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Microsoft.Web.Core.ContentTypes;
using Microsoft.Html.Core.Tree.Utility;
using Microsoft.Html.Core.Tree.Nodes;
using Microsoft.Html.Editor.SuggestedActions;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Utilities;
using Microsoft.VisualStudio.Language.Intellisense;
using VSCustomElement.Helpers;

namespace VSCustomElement.HtmlExtensions
{
    [Export(typeof(IHtmlSuggestedActionProvider))]
    [ContentType(HtmlContentTypeDefinition.HtmlContentType)]
    [Name("Html Remember Element Light Bulb Provider")]
    class RememberElementLightBulbProvider : IHtmlSuggestedActionProvider
    {
        public IEnumerable<ISuggestedAction> GetSuggestedActions(ITextView textView, ITextBuffer textBuffer, int caretPosition, ElementNode element, AttributeNode attribute, HtmlPositionType positionType)
        {
            return new ISuggestedAction[] {
                new RememberElementLightBulbAction(textView, textBuffer, element, attribute, GetRememberElementCaption(element))
            };
        }

        public bool HasSuggestedActions(ITextView textView, ITextBuffer textBuffer, int caretPosition, ElementNode element, AttributeNode attribute, HtmlPositionType positionType)
        {
            if(element == null)
            {
                return false;
            }
            else if (attribute == null)
            {
                return HasSuggestedElementActions(textView, textBuffer, caretPosition, element, attribute, positionType);
            }

            return HasSuggestedAttributeActions(textView, textBuffer, caretPosition, element, attribute, positionType);
        }

        private bool HasSuggestedElementActions(ITextView textView, ITextBuffer textBuffer, int caretPosition, ElementNode element, AttributeNode attribute, HtmlPositionType positionType)
        {
            if (element != null && !String.IsNullOrEmpty(element.Name))
            {
                return !HTMLHelper.IsStandardHtmlElement(element.Name);
            }

            return false;
        }

        private bool HasSuggestedAttributeActions(ITextView textView, ITextBuffer textBuffer, int caretPosition, ElementNode element, AttributeNode attribute, HtmlPositionType positionType)
        {
            if (attribute != null && !String.IsNullOrEmpty(attribute.Name) && !HTMLHelper.IsHtmlGlobalAttribute(attribute.Name))
            {
                return true;
            }

            return false;
        }

        private string GetRememberElementCaption(ElementNode element)
        {
            if (element != null && !String.IsNullOrEmpty(element.Name))
            {
                return String.Format("Remember <{0}>", element.Name.Trim().ToLower());
            }

            return String.Empty;
        }
    }
}
