#region Namespace

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using VisualPlus.Enumerators;
using VisualPlus.Managers;
using VisualPlus.Renders;
using VisualPlus.Toolkit.Controls.Interactivity;

#endregion

namespace VisualPlus.Toolkit.Dialogs
{
    public class VisualMessageBox : VisualForm, IMessageBox
    {
        #region Variables

        private readonly int buttonPadding;
        private readonly Size defaultButtonSize;
        private readonly Size dialogImageSize;
        private readonly int extraPadding;
        private readonly MessageBoxButtons messageBoxButtons;
        private readonly MessageBoxIcon messageBoxIcon;
        private readonly string messageText;
        private VisualButton abortButton;
        private VisualButton cancelButton;
        private Image dialogImage;
        private Rectangle dialogImageRectangle;
        private VisualButton ignoreButton;
        private VisualButton noButton;
        private VisualButton okButton;
        private VisualButton retryButton;
        private VisualButton yesButton;

        #endregion

        #region Constructors

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
        /// <param name="buttons">
        ///     One of the <see cref="MessageBoxButtons" /> values that specifies which buttons to display in the
        ///     message box.
        /// </param>
        /// <param name="image">The icon image to display.</param>
        public VisualMessageBox(string text, string caption, MessageBoxButtons buttons, Image image) : this(text, caption, buttons)
        {
            dialogImage = image;
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
        public VisualMessageBox(string text, string caption) : this(text)
        {
            Text = caption;
        }

        /// <summary>Initializes a new instance of the <see cref="VisualMessageBox" /> class.</summary>
        /// <param name="text">The text to display in the message box.</param>
        public VisualMessageBox(string text) : this()
        {
            messageText = text;
        }

        /// <summary>Initializes a new instance of the <see cref="VisualMessageBox" /> class.</summary>
        public VisualMessageBox()
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
            StartPosition = FormStartPosition.CenterScreen;
            Text = string.Empty;
            TitleAlignment = Alignment.TextAlignment.Left;

            Magnetic = true;

            BackColor = Color.White;
            Background = Color.White;
            WindowBarColor = Color.White;

            MinimumSize = new Size(119, 116);
            MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width - (Screen.PrimaryScreen.Bounds.Width / 3), 9999);
            Size = new Size(119, 116);

            dialogImage = null;
            dialogImageSize = new Size(32, 32);
            extraPadding = 5;
            messageBoxButtons = MessageBoxButtons.OK;
            messageBoxIcon = MessageBoxIcon.None;
            defaultButtonSize = new Size(75, 23);
            buttonPadding = 10;

            InitializeMessageBoxButtons();
        }

        #endregion

        #region Properties

        /// <summary>Gets the buttons max width.</summary>
        [Browsable(false)]
        public int ButtonsMaxWidth
        {
            get
            {
                int width;

                switch (messageBoxButtons)
                {
                    case MessageBoxButtons.OK:
                        {
                            width = buttonPadding + okButton.Width;
                            break;
                        }

                    case MessageBoxButtons.OKCancel:
                        {
                            width = buttonPadding + okButton.Width + buttonPadding + cancelButton.Width + buttonPadding;
                            break;
                        }

                    case MessageBoxButtons.AbortRetryIgnore:
                        {
                            width = buttonPadding + abortButton.Width + buttonPadding + retryButton.Width + buttonPadding + ignoreButton.Width + buttonPadding;
                            break;
                        }

                    case MessageBoxButtons.YesNoCancel:
                        {
                            width = buttonPadding + yesButton.Width + buttonPadding + noButton.Width + buttonPadding + cancelButton.Width + buttonPadding;
                            break;
                        }

                    case MessageBoxButtons.YesNo:
                        {
                            width = buttonPadding + yesButton.Width + buttonPadding + noButton.Width + buttonPadding;
                            break;
                        }

                    case MessageBoxButtons.RetryCancel:
                        {
                            width = buttonPadding + retryButton.Width + buttonPadding + cancelButton.Width + buttonPadding;
                            break;
                        }

                    default:
                        {
                            throw new ArgumentOutOfRangeException(nameof(messageBoxButtons), messageBoxButtons, null);
                        }
                }

                return width;
            }
        }

        /// <summary>Retrieves the caption size.</summary>
        [Browsable(false)]
        public Size CaptionSize
        {
            get
            {
                Size captionSize = TextManager.MeasureText(Text, Font);
                return new Size(captionSize.Width + buttonPadding + ControlBox.CloseButton.Width, captionSize.Height);
            }
        }

        /// <summary>Retrieves the maximum display caption and text width.</summary>
        [Browsable(false)]
        public int CaptionTextMaxWidth
        {
            get
            {
                int captionTextMaxWidth = CaptionSize.Width > DisplayTextWithImageWidth ? CaptionSize.Width : DisplayTextWithImageWidth;
                return captionTextMaxWidth;
            }
        }

        /// <summary>The dialog icon image.</summary>
        [Browsable(false)]
        public Image DialogIcon
        {
            get
            {
                return dialogImage;
            }

            set
            {
                dialogImage = value;
                Invalidate();
            }
        }

        /// <summary>The dialog image visibility.</summary>
        [Browsable(false)]
        public bool DialogImageVisible
        {
            get
            {
                return dialogImage != null;
            }
        }

        /// <summary>Gets the dialog max height.</summary>
        [Browsable(false)]
        public int DialogMaxHeight
        {
            get
            {
                int dialogMaxHeight = WindowBarHeight + MessageSize.Height + buttonPadding + defaultButtonSize.Height + buttonPadding + Border.Distance;
                return dialogMaxHeight;
            }
        }

        /// <summary>Gets the dialog max width.</summary>
        [Browsable(false)]
        public int DialogMaxWidth
        {
            get
            {
                int width = CaptionTextMaxWidth > ButtonsMaxWidth ? CaptionTextMaxWidth : ButtonsMaxWidth;
                return width;
            }
        }

        /// <summary>Retrieves the maximum display text width.</summary>
        [Browsable(false)]
        public int DisplayTextWithImageWidth
        {
            get
            {
                int displayTextWithImageWidth;
                if (dialogImage != null)
                {
                    displayTextWithImageWidth = MessageSize.Width + extraPadding + dialogImageSize.Width;
                }
                else
                {
                    displayTextWithImageWidth = MessageSize.Width;
                }

                return displayTextWithImageWidth;
            }
        }

        /// <summary>Determines whether the message box is empty.</summary>
        [Browsable(false)]
        public bool IsEmpty
        {
            get
            {
                bool emptyCheck = (messageText.Length <= 0) || (Text.Length <= 0);
                return emptyCheck;
            }
        }

        /// <summary>Retrieves the message size.</summary>
        [Browsable(false)]
        public Size MessageSize
        {
            get
            {
                Size messageSize = TextManager.MeasureText(messageText, Font);

                // TODO: Maximum height is not being retrieved properly text appears to cut in some instances.
                return new Size(messageSize.Width, messageSize.Height);
            }
        }

        /// <summary>Gets the text block height.</summary>
        [Browsable(false)]
        public int TextBlockHeight
        {
            get
            {
                int textBlockHeight;

                if (BodyContainer.X + MessageSize.Height < okButton.Top)
                {
                    textBlockHeight = MessageSize.Height;
                }
                else
                {
                    textBlockHeight = WindowBarHeight + MessageSize.Height;
                }

                return textBlockHeight;
            }
        }

        /// <summary>Gets the text block width.</summary>
        [Browsable(false)]
        public int TextBlockWidth
        {
            get
            {
                int textBlockWidth;
                if (dialogImage != null)
                {
                    int xTextLocation = dialogImageRectangle.Right + extraPadding;
                    textBlockWidth = BodyContainer.Width - xTextLocation - extraPadding;
                }
                else
                {
                    textBlockWidth = BodyContainer.Right - (extraPadding * 2) - (Border.Distance * 2);
                }

                return textBlockWidth;
            }
        }

        #endregion

        #region Overrides

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graphics = e.Graphics;

            if (messageBoxIcon != MessageBoxIcon.None)
            {
                dialogImage = GetSystemIconsImage();
            }

            dialogImageRectangle = new Rectangle(BodyContainer.X + extraPadding, BodyContainer.Y, dialogImageSize.Width, dialogImageSize.Height);

            Rectangle textRectangle;

            if (dialogImage != null)
            {
                VisualImageRenderer.RenderImageFilled(graphics, dialogImageRectangle, dialogImage);

                int xTextLocation = dialogImageRectangle.Right + extraPadding;
                textRectangle = new Rectangle(xTextLocation, BodyContainer.Y, TextBlockWidth, TextBlockHeight);
            }
            else
            {
                textRectangle = new Rectangle(BodyContainer.Left + extraPadding, BodyContainer.Y, TextBlockWidth, TextBlockHeight);
            }

            StringFormat stringFormat = new StringFormat
                {
                    Alignment = StringAlignment.Near,
                    LineAlignment = StringAlignment.Center
                };

            VisualTextRenderer.RenderText(graphics, textRectangle, messageText, Font, ForeColor, stringFormat);
            UpdateButtonsVisibility();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (IsHandleCreated)
            {
                Size totalDialogSize = new Size(DialogMaxWidth, DialogMaxHeight);

                if (Size != totalDialogSize)
                {
                    Size = totalDialogSize;
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>Displays a message box with the specified text.</summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">Specifies which buttons to display in the message box.</param>
        /// <param name="icon">Specifies which icon to display in the message box.</param>
        /// <returns>The <see cref="DialogResult" />.</returns>
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, Image icon)
        {
            return new VisualMessageBox(text, caption, buttons, icon).ShowDialog();
        }

        /// <summary>Displays a message box with the specified text.</summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">Specifies which buttons to display in the message box.</param>
        /// <param name="icon">Specifies which icon to display in the message box.</param>
        /// <returns>The <see cref="DialogResult" />.</returns>
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return new VisualMessageBox(text, caption, buttons, icon).ShowDialog();
        }

        /// <summary>The abort button.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void AbortButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }

        /// <summary>The buttons ok cancel configuration.</summary>
        private void AbortRetryIgnore()
        {
            okButton.Visible = false;
            cancelButton.Visible = false;
            abortButton.Visible = true;
            noButton.Visible = false;
            retryButton.Visible = true;
            ignoreButton.Visible = true;
            yesButton.Visible = false;

            abortButton.Location = new Point(BodyContainer.Right - abortButton.Width - buttonPadding, BodyContainer.Bottom - abortButton.Height - buttonPadding);
            retryButton.Location = new Point(abortButton.Location.X - retryButton.Width - buttonPadding, abortButton.Location.Y);
            ignoreButton.Location = new Point(retryButton.Location.X - ignoreButton.Width - buttonPadding, abortButton.Location.Y);
        }

        /// <summary>The buttons ok configuration.</summary>
        private void ButtonsOK()
        {
            okButton.Visible = true;
            cancelButton.Visible = false;
            abortButton.Visible = false;
            noButton.Visible = false;
            retryButton.Visible = false;
            ignoreButton.Visible = false;
            yesButton.Visible = false;

            okButton.Location = new Point(BodyContainer.Right - okButton.Width - buttonPadding, BodyContainer.Bottom - okButton.Height - buttonPadding);
        }

        /// <summary>The buttons ok cancel configuration.</summary>
        private void ButtonsOKCancel()
        {
            okButton.Visible = true;
            cancelButton.Visible = true;
            abortButton.Visible = false;
            noButton.Visible = false;
            retryButton.Visible = false;
            ignoreButton.Visible = false;
            yesButton.Visible = false;

            cancelButton.Location = new Point(BodyContainer.Right - cancelButton.Width - buttonPadding, BodyContainer.Bottom - cancelButton.Height - buttonPadding);
            okButton.Location = new Point(cancelButton.Location.X - okButton.Width - buttonPadding, cancelButton.Location.Y);
        }

        /// <summary>The cancel button.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>Retrieves the bitmap for the associated system icons.</summary>
        /// <returns>The <see cref="Bitmap" />.</returns>
        private Bitmap GetSystemIconsImage()
        {
            Bitmap image;
            switch (messageBoxIcon)
            {
                case MessageBoxIcon.None:
                    {
                        image = null;
                        break;
                    }

                case MessageBoxIcon.Hand:
                    {
                        image = SystemIcons.Hand.ToBitmap();
                        break;
                    }

                case MessageBoxIcon.Question:
                    {
                        image = SystemIcons.Question.ToBitmap();
                        break;
                    }

                case MessageBoxIcon.Exclamation:
                    {
                        image = SystemIcons.Exclamation.ToBitmap();
                        break;
                    }

                case MessageBoxIcon.Asterisk:
                    {
                        image = SystemIcons.Asterisk.ToBitmap();
                        break;
                    }

                default:
                    {
                        throw new ArgumentOutOfRangeException();
                    }
            }

            return image;
        }

        /// <summary>The ignore button.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void IgnoreButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Ignore;
        }

        /// <summary>Initializes the message box buttons.</summary>
        private void InitializeMessageBoxButtons()
        {
            okButton = new VisualButton
                {
                    Text = @"OK",
                    Anchor = AnchorStyles.Right & AnchorStyles.Bottom,
                    TabIndex = 0,
                    Size = defaultButtonSize,
                    Location = new Point(0, 0)
                };

            okButton.Click += OkButton_Click;

            cancelButton = new VisualButton
                {
                    Text = @"Cancel",
                    Anchor = AnchorStyles.Right & AnchorStyles.Bottom,
                    TabIndex = 1,
                    Size = defaultButtonSize,
                    Location = new Point(0, 0)
                };

            cancelButton.Click += CancelButton_Click;

            abortButton = new VisualButton
                {
                    Text = @"Abort",
                    Anchor = AnchorStyles.Right & AnchorStyles.Bottom,
                    TabIndex = 0,
                    Size = defaultButtonSize,
                    Location = new Point(0, 0)
                };

            abortButton.Click += AbortButton_Click;

            noButton = new VisualButton
                {
                    Text = @"No",
                    Anchor = AnchorStyles.Right & AnchorStyles.Bottom,
                    TabIndex = 0,
                    Size = defaultButtonSize,
                    Location = new Point(0, 0)
                };

            noButton.Click += NoButton_Click;

            retryButton = new VisualButton
                {
                    Text = @"Retry",
                    Anchor = AnchorStyles.Right & AnchorStyles.Bottom,
                    TabIndex = 0,
                    Size = defaultButtonSize,
                    Location = new Point(0, 0)
                };

            retryButton.Click += RetryButton_Click;

            ignoreButton = new VisualButton
                {
                    Text = @"Ignore",
                    Anchor = AnchorStyles.Right & AnchorStyles.Bottom,
                    TabIndex = 0,
                    Size = defaultButtonSize,
                    Location = new Point(0, 0)
                };

            ignoreButton.Click += IgnoreButton_Click;

            yesButton = new VisualButton
                {
                    Text = @"Yes",
                    Anchor = AnchorStyles.Right & AnchorStyles.Bottom,
                    TabIndex = 0,
                    Size = defaultButtonSize,
                    Location = new Point(0, 0)
                };

            yesButton.Click += YesButton_Click;

            Controls.Add(okButton);
            Controls.Add(cancelButton);
            Controls.Add(abortButton);
            Controls.Add(noButton);
            Controls.Add(retryButton);
            Controls.Add(ignoreButton);
            Controls.Add(yesButton);
        }

        /// <summary>The no button.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void NoButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        /// <summary>The OK button.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void OkButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        /// <summary>The retry button.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void RetryButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Retry;
        }

        /// <summary>The buttons retry cancel configuration.</summary>
        private void RetryCancel()
        {
            okButton.Visible = false;
            cancelButton.Visible = true;
            abortButton.Visible = false;
            noButton.Visible = false;
            retryButton.Visible = true;
            ignoreButton.Visible = false;
            yesButton.Visible = false;

            cancelButton.Location = new Point(BodyContainer.Right - cancelButton.Width - buttonPadding, BodyContainer.Bottom - cancelButton.Height - buttonPadding);
            retryButton.Location = new Point(cancelButton.Location.X - retryButton.Width - buttonPadding, cancelButton.Location.Y);
        }

        DialogResult IMessageBox.Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return Show(text, caption, buttons, icon);
        }

        DialogResult IMessageBox.Show(string text, string caption, MessageBoxButtons buttons)
        {
            return Show(text, caption, buttons, MessageBoxIcon.None);
        }

        DialogResult IMessageBox.Show(string text, string caption)
        {
            return Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        DialogResult IMessageBox.Show(string text)
        {
            return Show(text, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        DialogResult IMessageBox.Show(string text, string caption, MessageBoxButtons buttons, Image icon)
        {
            return Show(text, caption, buttons, icon);
        }

        /// <summary>Updates the buttons visibility.</summary>
        private void UpdateButtonsVisibility()
        {
            switch (messageBoxButtons)
            {
                case MessageBoxButtons.OK:
                    {
                        ButtonsOK();
                        break;
                    }

                case MessageBoxButtons.OKCancel:
                    {
                        ButtonsOKCancel();
                        break;
                    }

                case MessageBoxButtons.AbortRetryIgnore:
                    {
                        AbortRetryIgnore();
                        break;
                    }

                case MessageBoxButtons.YesNoCancel:
                    {
                        YesNoCancel();
                        break;
                    }

                case MessageBoxButtons.YesNo:
                    {
                        YesNo();
                        break;
                    }

                case MessageBoxButtons.RetryCancel:
                    {
                        RetryCancel();
                        break;
                    }

                default:
                    {
                        throw new ArgumentOutOfRangeException(nameof(messageBoxButtons), messageBoxButtons, null);
                    }
            }
        }

        /// <summary>The yes button.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void YesButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        /// <summary>The buttons yes no configuration.</summary>
        private void YesNo()
        {
            okButton.Visible = false;
            cancelButton.Visible = false;
            abortButton.Visible = false;
            noButton.Visible = true;
            retryButton.Visible = false;
            ignoreButton.Visible = false;
            yesButton.Visible = true;

            noButton.Location = new Point(BodyContainer.Right - noButton.Width - buttonPadding, BodyContainer.Bottom - noButton.Height - buttonPadding);
            yesButton.Location = new Point(noButton.Location.X - yesButton.Width - buttonPadding, noButton.Location.Y);
        }

        /// <summary>The buttons yes no cancel configuration.</summary>
        private void YesNoCancel()
        {
            okButton.Visible = false;
            cancelButton.Visible = true;
            abortButton.Visible = false;
            noButton.Visible = true;
            retryButton.Visible = false;
            ignoreButton.Visible = false;
            yesButton.Visible = true;

            cancelButton.Location = new Point(BodyContainer.Right - cancelButton.Width - buttonPadding, BodyContainer.Bottom - cancelButton.Height - buttonPadding);
            noButton.Location = new Point(cancelButton.Location.X - noButton.Width - buttonPadding, cancelButton.Location.Y);
            yesButton.Location = new Point(noButton.Location.X - ignoreButton.Width - buttonPadding, cancelButton.Location.Y);
        }

        #endregion
    }
}