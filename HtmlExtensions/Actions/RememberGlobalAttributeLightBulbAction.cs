﻿using Microsoft.Html.Core.Tree.Nodes;
using Microsoft.VisualStudio.Text;
using System.Threading;
using Microsoft.VisualStudio.Text.Editor;

namespace VSCustomElement.HtmlExtensions
{
    /// <summary>
    /// Remember global attribute light bulb action.
    /// Respobsible for registering new custom global html attributes to VSCustomElement extension.
    /// </summary>
    internal class RememberGlobalAttributeLightBulbAction : BaseHtmlLightBulbAction
    {
        public RememberGlobalAttributeLightBulbAction():
            this(null, null, null, null, null) { }

        public RememberGlobalAttributeLightBulbAction(ITextView textView, ITextBuffer textBuffer, ElementNode element, AttributeNode attribute, string caption)
            : base(textView, textBuffer, element, attribute, caption)
        {

        }

        public override void Invoke(CancellationToken cancellationToken)
        {

        }
    }
}
