using Microsoft.Html.Core.Tree.Nodes;
using Microsoft.Html.Editor.SuggestedActions;
using Microsoft.VisualStudio.Text;
using System;
using System.Threading;
using Microsoft.VisualStudio.Text.Editor;

namespace VSCustomElement.HtmlExtensions
{
    internal class RememberElementLightBulbAction : HtmlSuggestedActionBase
    {
        public RememberElementLightBulbAction(ITextView textView, ITextBuffer textBuffer, ElementNode element, AttributeNode attribute, string caption)
            : base(textView, textBuffer, element, attribute, caption)
        {

        }

        public override void Invoke(CancellationToken cancellationToken)
        {

        }
    }
}
