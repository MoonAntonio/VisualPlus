#region Namespace

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

using VisualPlus.Toolkit.VisualBase;

#endregion

namespace VisualPlus.Toolkit.Dialogs
{
    /// <summary>The <see cref="VisualInputDialog" />.</summary>
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [DefaultEvent("Load")]
    [DefaultProperty("Text")]
    [Description("The Visual Input Dialog")]
    [DesignerCategory("Form")]
    [DesignTimeVisible(false)]
    [ToolboxItem(false)]
    public partial class VisualInputDialog : VisualDialog
    {
        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="VisualInputDialog" /> class.</summary>
        /// <param name="caption">The caption.</param>
        public VisualInputDialog(string caption) : this()
        {
            Text = caption;
        }

        /// <summary>Initializes a new instance of the <see cref="VisualInputDialog" /> class.</summary>
        /// <param name="caption">The caption.</param>
        /// <param name="watermark">The watermark.</param>
        public VisualInputDialog(string caption, string watermark) : this()
        {
            Text = caption;
            tbInput.Watermark.Text = watermark;
        }

        /// <summary>Initializes a new instance of the <see cref="VisualInputDialog" /> class.</summary>
        /// <param name="text">The caption text.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="watermark">The watermark.</param>
        public VisualInputDialog(string text, string caption, string watermark) : this()
        {
            Text = caption;
            tbInput.Text = text;
            tbInput.Watermark.Text = watermark;
        }

        /// <summary>Initializes a new instance of the <see cref="VisualInputDialog" /> class.</summary>
        public VisualInputDialog()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        /// <summary>Contains the input result.</summary>
        [Browsable(false)]
        public string InputResult
        {
            get
            {
                return tbInput.Text;
            }
        }

        #endregion

        #region Methods

        /// <summary>The input text changed.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void Input_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = tbInput.TextLength > 0;
        }

        #endregion
    }
}