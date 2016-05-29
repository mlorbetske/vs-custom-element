using System;
using Microsoft.Html.Core.Tree.Nodes;

namespace VSCustomElement.Helpers
{
    /// <summary>
    /// Some html utilities.
    /// </summary>
    public static class HtmlHelper
    {
        /// <summary>
        /// Converts given string to html format.
        /// </summary>
        /// <param name="nodeName">Name of the node</param>
        /// <returns>Html formatted name</returns>
        public static string Htmlize(string nodeName)
        {
            return !String.IsNullOrEmpty(nodeName) ? nodeName.Trim().ToLower() : String.Empty;
        }

        /// <summary>
        /// Converts given tree node to html format.
        /// </summary>
        /// <param name="treeNode">Tree node</param>
        /// <returns>Html formatted name</returns>
        public static string Htmlize(TreeNode treeNode)
        {
            return treeNode != null ? Htmlize(treeNode.Name) : String.Empty;
        }
    }
}
