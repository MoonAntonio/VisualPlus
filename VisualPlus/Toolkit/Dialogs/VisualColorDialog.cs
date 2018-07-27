#region Namespace

using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using VisualPlus.Events;
using VisualPlus.Toolkit.VisualBase;

#endregion

namespace VisualPlus.Toolkit.Dialogs
{
    /// <summary>The <see cref="VisualColorDialog" />.</summary>
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [DefaultEvent("Load")]
    [DefaultProperty("Text")]
    [Description("The Visual Color Dialog")]
    [DesignerCategory("Form")]
    [DesignTimeVisible(false)]
    [ToolboxItem(false)]
    public partial class VisualColorDialog : VisualDialog
    {
        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="VisualColorDialog" /> class.</summary>
        /// <param name="defaultColor">The default Color.</param>
        public VisualColorDialog(Color defaultColor) : this()
        {
            UpdateColorDialog(defaultColor);
        }

        /// <summary>Initializes a new instance of the <see cref="VisualColorDialog" /> class.</summary>
        public VisualColorDialog()
        {
            InitializeComponent();
            tilePreview.BackColor = Color.Black;
            Text = @"Color Dialog";

            UpdateColorDialog(tilePreview.BackColor);
        }

        #endregion

        #region Properties

        /// <summary>Gets the selected color.</summary>
        [Browsable(false)]
        public Color Color
        {
            get
            {
                return tilePreview.BackColor;
            }
        }

        #endregion

        #region Methods

        /// <summary>Occurs when the OK button has been pressed.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void ButtonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        /// <summary>Occurs when the numeric up/down for ARGB had a value changed.</summary>
        /// <param name="e">The event args.</param>
        private void NumericUpDownARGB_ValueChanged(ValueChangedEventArgs e)
        {
            int alpha = Convert.ToInt32(nudAlpha.Value);
            int red = Convert.ToInt32(nudRed.Value);
            int green = Convert.ToInt32(nudGreen.Value);
            int blue = Convert.ToInt32(nudBlue.Value);

            Color readColor = Color.FromArgb(alpha, red, green, blue);
            tilePreview.BackColor = readColor;
            tbHtml.Text = ColorTranslator.ToHtml(readColor);
        }

        /// <summary>Sets the color dialog color.</summary>
        /// <param name="newColor">The new color to set.</param>
        private void UpdateColorDialog(Color newColor)
        {
            nudAlpha.Value = newColor.A;
            nudRed.Value = newColor.R;
            nudGreen.Value = newColor.G;
            nudBlue.Value = newColor.B;
        }

        #endregion

        private void ColorPicker_ColorChanged(object sender, EventArgs e)
        {
            UpdateColorDialog(colorPicker.Color);
        }
    }
}