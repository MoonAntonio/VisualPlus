#region Namespace

using System;

#endregion

namespace VisualPlus.Events
{
    public class ClipboardEventArgs : EventArgs
    {
        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="ClipboardEventArgs" /> class.</summary>
        /// <param name="clipboardText">The clipboard text.</param>
        public ClipboardEventArgs(string clipboardText)
        {
            ClipboardText = clipboardText;
        }

        #endregion

        #region Properties

        public string ClipboardText { get; set; }

        #endregion
    }
}