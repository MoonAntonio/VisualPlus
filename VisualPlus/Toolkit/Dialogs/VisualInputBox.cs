#region Namespace

using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using VisualPlus.Toolkit.Controls.Editors;
using VisualPlus.Toolkit.Controls.Interactivity;
using VisualPlus.Toolkit.VisualBase;

#endregion

namespace VisualPlus.Toolkit.Dialogs
{
    /// <summary>The <see cref="VisualInputBox" />.</summary>
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [ToolboxItem(false)]
    public class VisualInputBox : VisualDialog
    {
        #region Variables

        private VisualButton button;
        private VisualLabel label;
        private VisualTextBox textBox;

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="VisualInputBox" /> class.</summary>
        /// <param name="caption">The caption.</param>
        public VisualInputBox(string caption) : this()
        {
            Text = caption;
        }

        /// <summary>Initializes a new instance of the <see cref="VisualInputBox" /> class.</summary>
        /// <param name="caption">The caption.</param>
        /// <param name="watermark">The watermark.</param>
        public VisualInputBox(string caption, string watermark) : this()
        {
            Text = caption;
            textBox.Watermark.Text = watermark;
        }

        /// <summary>Initializes a new instance of the <see cref="VisualInputBox" /> class.</summary>
        /// <param name="text">The caption text.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="watermark">The watermark.</param>
        public VisualInputBox(string text, string caption, string watermark) : this()
        {
            Text = caption;
            textBox.Text = text;
            textBox.Watermark.Text = watermark;
        }

        /// <summary>Initializes a new instance of the <see cref="VisualInputBox" /> class.</summary>
        public VisualInputBox()
        {
            InitializeControls();
            Size = new Size(textBox.Right + Border.Distance + 2, 95);
        }

        #endregion

        #region Properties

        /// <summary>Gets or sets the button.</summary>
        [Browsable(false)]
        public VisualButton Button
        {
            get
            {
                return button;
            }

            set
            {
                button = value;
            }
        }

        /// <summary>Contains the input result.</summary>
        [Browsable(false)]
        public string InputResult
        {
            get
            {
                return textBox.Text;
            }
        }

        /// <summary>Gets or sets the label.</summary>
        [Browsable(false)]
        public VisualLabel Label
        {
            get
            {
                return label;
            }

            set
            {
                label = value;
            }
        }

        /// <summary>Gets or sets the text box.</summary>
        [Browsable(false)]
        public VisualTextBox TextBox
        {
            get
            {
                return textBox;
            }

            set
            {
                textBox = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>The button click.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        /// <summary>Initialize the controls.</summary>
        private void InitializeControls()
        {
            label = new VisualLabel
                {
                    Text = @"Enter your input: ",
                    Size = new Size(90, 25),
                    Location = new Point(BodyContainer.X, BodyContainer.Y)
                };

            textBox = new VisualTextBox
                {
                    Text = string.Empty,
                    Watermark =
                        {
                            Visible = true,
                            Text = "Enter your input..."
                        },
                    Location = new Point(label.Right, BodyContainer.Y + 2)
                };
            textBox.TextChanged += TextBox_TextChanged;

            button = new VisualButton
                {
                    Text = @"OK",
                    Size = ButtonSize,
                    Location = new Point(textBox.Right - ButtonSize.Width, textBox.Bottom + 5),
                    Enabled = false
                };

            button.Click += Button_Click;

            Controls.Add(label);
            Controls.Add(textBox);
            Controls.Add(button);
        }

        /// <summary>The input text changed.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            button.Enabled = textBox.TextLength > 0;
        }

        #endregion
    }
}