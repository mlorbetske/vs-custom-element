using Microsoft.Html.Core.Tree.Nodes;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;

namespace VSCustomElement.HtmlExtensions
{
    /// <summary>
    /// Base html light bulb action.
    /// </summary>
    internal abstract class BaseHtmlLightBulbAction : HtmlSuggestedActionBase
    {
        public BaseHtmlLightBulbAction(ITextView textView, ITextBuffer textBuffer, ElementNode element, AttributeNode attribute, string caption)
            : base(textView, textBuffer, element, attribute, caption)
        {

        }
    }
}
