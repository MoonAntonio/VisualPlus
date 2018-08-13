#region Namespace

using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using VisualPlus.Properties;
using VisualPlus.Toolkit.VisualBase;

#endregion

namespace VisualPlus.Toolkit.Dialogs
{
    /// <summary>The <see cref="VisualMessageBox" />.</summary>
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [DefaultEvent("Load")]
    [DefaultProperty("Text")]
    [Description("The Visual MessageBox")]
    [DesignerCategory("Form")]
    [DesignTimeVisible(false)]
    [ToolboxItem(false)]
    public partial class VisualMessageBox : VisualDialog
    {
        #region Variables

        private readonly MessageBoxButtons messageBoxButtons;
        private readonly MessageBoxIcon messageBoxIcon;

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="VisualMessageBox" /> class.</summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">
        ///     One of the <see cref="MessageBoxButtons" /> values that specifies which buttons to display in the
        ///     message box.
        /// </param>
        /// <param name="image">The icon image to display.</param>
        public VisualMessageBox(string text, string caption, MessageBoxButtons buttons, Image image) : this(text, caption, buttons)
        {
            dialogImage.Image = image;
        }

        /// <summary>Initializes a new instance of the <see cref="VisualMessageBox" /> class.</summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">
        ///     One of the <see cref="MessageBoxButtons" /> values that specifies which buttons to display in the
        ///     message box.
        /// </param>
        /// <param name="icon">
        ///     One of the <see cref="MessageBoxIcon" /> values that specifies which icon to display in the message
        ///     box.
        /// </param>
        public VisualMessageBox(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon) : this(text, caption, buttons)
        {
            messageBoxIcon = icon;
        }

        /// <summary>Initializes a new instance of the <see cref="VisualMessageBox" /> class.</summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">
        ///     One of the <see cref="MessageBoxButtons" /> values that specifies which buttons to display in the
        ///     message box.
        /// </param>
        public VisualMessageBox(string text, string caption, MessageBoxButtons buttons) : this(text, caption)
        {
            messageBoxButtons = buttons;
        }

        /// <summary>Initializes a new instance of the <see cref="VisualMessageBox" /> class.</summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        public VisualMessageBox(string text, string caption) : this(text)
        {
            Text = caption;
        }

        /// <summary>Initializes a new instance of the <see cref="VisualMessageBox" /> class.</summary>
        /// <param name="text">The text to display in the message box.</param>
        public VisualMessageBox(string text) : this()
        {
            rtbMessage.Text = text;
        }

        /// <summary>Initializes a new instance of the <see cref="VisualMessageBox" /> class.</summary>
        public VisualMessageBox()
        {
            InitializeComponent();

            messageBoxButtons = MessageBoxButtons.OK;
            messageBoxIcon = MessageBoxIcon.None;
            rtbMessage.Text = string.Empty;
            Text = string.Empty;

            MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width - (Screen.PrimaryScreen.Bounds.Width / 3), 9999);
        }

        #endregion

        #region Methods

        /// <summary>Displays a message box with the specified text.</summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">Specifies which buttons to display in the message box.</param>
        /// <returns>The <see cref="DialogResult" />.</returns>
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons)
        {
            using (VisualMessageBox messageBox = new VisualMessageBox(text, caption, buttons))
            {
                messageBox.ShowDialog();
                return messageBox.DialogResult;
            }
        }

        /// <summary>Displays a message box with the specified text.</summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">Specifies which buttons to display in the message box.</param>
        /// <param name="image">The icon image to display.</param>
        /// <returns>The <see cref="DialogResult" />.</returns>
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, Image image)
        {
            using (VisualMessageBox messageBox = new VisualMessageBox(text, caption, buttons, image))
            {
                messageBox.ShowDialog();
                return messageBox.DialogResult;
            }
        }

        /// <summary>Displays a message box with the specified text.</summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">Specifies which buttons to display in the message box.</param>
        /// <param name="icon">Specifies which icon to display in the message box.</param>
        /// <returns>The <see cref="DialogResult" />.</returns>
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            using (VisualMessageBox messageBox = new VisualMessageBox(text, caption, buttons, icon))
            {
                messageBox.ShowDialog();
                return messageBox.DialogResult;
            }
        }

        /// <summary>Displays a message box with the specified text.</summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <returns>The <see cref="DialogResult" />.</returns>
        public static DialogResult Show(string text, string caption)
        {
            using (VisualMessageBox messageBox = new VisualMessageBox(text, caption))
            {
                messageBox.ShowDialog();
                return messageBox.DialogResult;
            }
        }

        /// <summary>Displays a message box with the specified text.</summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <returns>The <see cref="DialogResult" />.</returns>
        public static DialogResult Show(string text)
        {
            using (VisualMessageBox messageBox = new VisualMessageBox(text))
            {
                messageBox.ShowDialog();
                return messageBox.DialogResult;
            }
        }

        /// <summary>Update the <see cref="MessageBoxIcon" />.</summary>
        private void UpdateBoxIcon()
        {
            switch (messageBoxIcon)
            {
                case MessageBoxIcon.None:
                    {
                        if (dialogImage.Image == null)
                        {
                            rtbMessage.Location = new Point(dialogImage.Location.X, rtbMessage.Location.Y);
                            rtbMessage.Size = new Size(btn3.Right - 13, rtbMessage.Height);
                        }

                        break;
                    }

                case MessageBoxIcon.Error:
                    {
                        dialogImage.Image = Resources.Error;
                        break;
                    }

                case MessageBoxIcon.Information:
                    {
                        dialogImage.Image = Resources.Information;
                        break;
                    }

                case MessageBoxIcon.Question:
                    {
                        dialogImage.Image = Resources.Question;
                        break;
                    }

                case MessageBoxIcon.Warning:
                    {
                        dialogImage.Image = Resources.Warning;
                        break;
                    }

                default:
                    {
                        throw new ArgumentOutOfRangeException();
                    }
            }
        }

        /// <summary>Update the <see cref="MessageBoxButtons" />.</summary>
        private void UpdateButtons()
        {
            switch (messageBoxButtons)
            {
                case MessageBoxButtons.OK:
                    {
                        btn1.Visible = false;
                        btn2.Visible = false;
                        btn3.Visible = true;

                        btn3.Text = @"OK";
                        btn3.DialogResult = DialogResult.OK;
                        break;
                    }

                case MessageBoxButtons.OKCancel:
                    {
                        btn1.Visible = false;
                        btn2.Visible = true;
                        btn3.Visible = true;

                        btn2.Text = @"OK";
                        btn3.Text = @"Cancel";
                        btn2.DialogResult = DialogResult.OK;
                        btn3.DialogResult = DialogResult.Cancel;
                        break;
                    }

                case MessageBoxButtons.AbortRetryIgnore:
                    {
                        btn1.Visible = true;
                        btn2.Visible = true;
                        btn3.Visible = true;

                        btn1.Text = @"Abort";
                        btn2.Text = @"Retry";
                        btn3.Text = @"Ignore";
                        btn1.DialogResult = DialogResult.Abort;
                        btn2.DialogResult = DialogResult.Retry;
                        btn3.DialogResult = DialogResult.Ignore;
                        break;
                    }

                case MessageBoxButtons.YesNoCancel:
                    {
                        btn1.Visible = true;
                        btn2.Visible = true;
                        btn3.Visible = true;

                        btn1.Text = @"Yes";
                        btn2.Text = @"No";
                        btn3.Text = @"Cancel";
                        btn1.DialogResult = DialogResult.Yes;
                        btn2.DialogResult = DialogResult.No;
                        btn3.DialogResult = DialogResult.Cancel;
                        break;
                    }

                case MessageBoxButtons.YesNo:
                    {
                        btn1.Visible = false;
                        btn2.Visible = true;
                        btn3.Visible = true;

                        btn2.Text = @"Yes";
                        btn3.Text = @"No";
                        btn2.DialogResult = DialogResult.Yes;
                        btn3.DialogResult = DialogResult.No;
                        break;
                    }

                case MessageBoxButtons.RetryCancel:
                    {
                        btn1.Visible = false;
                        btn2.Visible = true;
                        btn3.Visible = true;

                        btn2.Text = @"Retry";
                        btn3.Text = @"Cancel";
                        btn2.DialogResult = DialogResult.Retry;
                        btn3.DialogResult = DialogResult.Cancel;
                        break;
                    }

                default:
                    {
                        throw new ArgumentOutOfRangeException();
                    }
            }
        }

        /// <summary>Loads the <see cref="VisualMessageBox" /> form.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void VisualMessageBox_Load(object sender, EventArgs e)
        {
            UpdateBoxIcon();
            UpdateButtons();
        }

        #endregion
    }
}