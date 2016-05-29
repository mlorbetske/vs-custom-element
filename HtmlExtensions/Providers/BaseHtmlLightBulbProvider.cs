using System;
using Microsoft.Html.Core.Tree.Nodes;
using Microsoft.Html.Editor.SuggestedActions;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text;
using Microsoft.Html.Core.Tree.Utility;
using System.Collections.Generic;

namespace VSCustomElement.HtmlExtensions
{
    /// <summary>
    /// Base html light bulb provider.
    /// </summary>
    /// <typeparam name="TAction">Type of the corresponsing html light bulb action</typeparam>
    abstract class BaseHtmlLightBulbProvider<TAction>: IHtmlSuggestedActionProvider where TAction : BaseHtmlLightBulbAction, new()
    {
        #region IHtmlSuggestedActionProvider

        public IEnumerable<ISuggestedAction> GetSuggestedActions(ITextView textView, ITextBuffer textBuffer, int caretPosition, ElementNode element, AttributeNode attribute, HtmlPositionType positionType)
        {
            return new ISuggestedAction[] {
                (TAction)Activator.CreateInstance(typeof(TAction), textView, textBuffer, element, attribute, GetCaption(element, attribute))
            };
        }

        public abstract bool HasSuggestedActions(ITextView textView, ITextBuffer textBuffer, int caretPosition, ElementNode element, AttributeNode attribute, HtmlPositionType positionType);

        #endregion

        /// <summary>
        /// Get a caption for given element and attribute.
        /// </summary>
        /// <param name="element">Element</param>
        /// <param name="attribute">Attribute</param>
        /// <returns>Caption</returns>
        protected abstract string GetCaption(ElementNode element, AttributeNode attribute);

        /// <summary>
        /// Is target of action an element?
        /// </summary>
        /// <param name="element">Target element</param>
        /// <param name="attribute">Target attribute</param>
        /// <returns>Result</returns>
        protected bool IsTargetHtmlElement(ElementNode element, AttributeNode attribute)
        {
            return element != null && !String.IsNullOrEmpty(element.Name) && attribute == null;
        }

        /// <summary>
        /// Is target of action an element?
        /// </summary>
        /// <param name="element">Target element</param>
        /// <param name="attribute">Target attribute</param>
        /// <returns>Result</returns>
        protected bool IsTargetHtmlAttribute(ElementNode element, AttributeNode attribute)
        {
            return IsTargetHtmlElement(element, null) && attribute != null && !String.IsNullOrEmpty(attribute.Name);
        }
    }
}
