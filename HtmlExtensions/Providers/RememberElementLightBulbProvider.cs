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
using VSCustomElement.Helpers;

namespace VSCustomElement.HtmlExtensions
{
    [Export(typeof(IHtmlSuggestedActionProvider))]
    [ContentType(HtmlContentTypeDefinition.HtmlContentType)]
    [Name("Remember Custom Html Element Light Bulb Provider")]
    class RememberElementLightBulbProvider : BaseHtmlLightBulbProvider<RememberElementLightBulbAction>
    {
        public override bool HasSuggestedActions(ITextView textView, ITextBuffer textBuffer, int caretPosition, ElementNode element, AttributeNode attribute, HtmlPositionType positionType)
        {
            return this.IsTargetHtmlElement(element, attribute) && !IntellisenseHelper.IsKnownHtmlElement(element.Name);
        }

        protected override string GetCaption(ElementNode element, AttributeNode attribute)
        {
            return String.Format("Remember <{0}>", HtmlHelper.Htmlize(element));
        }
    }
}
