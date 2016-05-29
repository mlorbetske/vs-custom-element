using Microsoft.Html.Core.Tree.Nodes;
using Microsoft.VisualStudio.Text;
using System.Threading;
using Microsoft.VisualStudio.Text.Editor;

namespace VSCustomElement.HtmlExtensions
{
    /// <summary>
    /// Remember element light bulb action.
    /// Respobsible for registering new custom html elements to VSCustomElement extension.
    /// </summary>
    internal class RememberElementLightBulbAction : BaseHtmlLightBulbAction
    {
        public RememberElementLightBulbAction():
            this(null, null, null, null, null) { }

        public RememberElementLightBulbAction(ITextView textView, ITextBuffer textBuffer, ElementNode element, AttributeNode attribute, string caption)
            : base(textView, textBuffer, element, attribute, caption)
        {

        }

        public override void Invoke(CancellationToken cancellationToken)
        {

        }
    }
}
