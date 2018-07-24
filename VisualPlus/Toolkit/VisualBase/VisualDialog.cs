#region Namespace

using System.Drawing;
using System.Windows.Forms;

using VisualPlus.Enumerators;
using VisualPlus.Toolkit.Dialogs;

#endregion

namespace VisualPlus.Toolkit.VisualBase
{
    public class VisualDialog : VisualForm
    {
        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="VisualDialog" /> class.</summary>
        /// <param name="text">The caption text.</param>
        public VisualDialog(string text) : this()
        {
            Text = text;
        }

        /// <summary>Initializes a new instance of the <see cref="VisualDialog" /> class.</summary>
        public VisualDialog()
        {
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ControlBox.Location = new Point(Width - 30, Border.Distance + 2);
            HelpButton = false;
            MinimizeBox = false;
            MaximizeBox = false;
            Sizable = false;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            TitleAlignment = Alignment.TextAlignment.Left;

            MinimumSize = new Size(119, 116);
            MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width - (Screen.PrimaryScreen.Bounds.Width / 3), 9999);
            Size = new Size(119, 116);
        }

        #endregion
    }
}