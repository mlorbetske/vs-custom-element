using Microsoft.Html.Core.Tree.Nodes;
using Microsoft.VisualStudio.Text;
using System.Threading;
using Microsoft.VisualStudio.Text.Editor;

namespace VSCustomElement.HtmlExtensions
{
    /// <summary>
    /// Remember attribute light bulb action.
    /// Respobsible for registering new custom html attributes for custom element to VSCustomElement extension.
    /// </summary>
    internal class RememberAttributeLightBulbAction : BaseHtmlLightBulbAction
    {
        public RememberAttributeLightBulbAction():
            this(null, null, null, null, null) { }

        public RememberAttributeLightBulbAction(ITextView textView, ITextBuffer textBuffer, ElementNode element, AttributeNode attribute, string caption)
            : base(textView, textBuffer, element, attribute, caption)
        {

        }

        public override void Invoke(CancellationToken cancellationToken)
        {

        }
    }
}
