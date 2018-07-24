#region Namespace

using System.ComponentModel;
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
            ButtonSize = new Size(75, 23);
            ControlBox.Location = new Point(Width - 45, Border.Distance + 2);
            HelpButton = false;
            MinimizeBox = false;
            MaximizeBox = false;
            Sizable = false;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            TitleAlignment = Alignment.TextAlignment.Left;
        }

        #endregion

        #region Properties

        /// <summary>Gets or sets the button size.</summary>
        [Browsable(false)]
        public Size ButtonSize { get; set; }

        #endregion
    }
}