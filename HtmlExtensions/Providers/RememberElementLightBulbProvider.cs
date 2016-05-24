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
            if(element == null || String.IsNullOrEmpty(element.Name) || attribute != null)
            {
                return false;
            }

            return !HTMLHelper.IsStandardHtmlElement(element.Name);
        }

        private string GetRememberElementCaption(ElementNode element)
        {
            if (element != null && !String.IsNullOrEmpty(element.Name))
            {
                return String.Format("Remember Custom <{0}> Element", element.Name.Trim().ToLower());
            }

            return String.Empty;
        }
    }
}
