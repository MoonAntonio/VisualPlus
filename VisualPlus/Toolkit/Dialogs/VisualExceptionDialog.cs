#region Namespace

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using VisualPlus.Structure;
using VisualPlus.Toolkit.VisualBase;

#endregion

namespace VisualPlus.Toolkit.Dialogs
{
    /// <summary>The <see cref="VisualExceptionDialog" />.</summary>
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [DefaultEvent("Click")]
    [DefaultProperty("Text")]
    [Description("The Visual Exception Dialog")]
    [ToolboxBitmap(typeof(VisualExceptionDialog), "Resources.VisualExceptionDialog.bmp")]
    [ToolboxItem(false)]
    public class VisualExceptionDialog : VisualDialog
    {
        #region Variables

        private readonly Exception _exception;
        private readonly int _imageSpacing;
        private readonly int _textHeight;
        private Button _copyButton;
        private Label _descriptionLabel;
        private Label _messageLabel;
        private TextBox _messageTextBox;
        private Button _okButton;
        private PictureBox _pictureBoxImage;
        private Button _saveButton;
        private Label _stackLabel;
        private TextBox _stackTextBox;
        private Label _typeLabel;
        private TextBox _typeTextBox;

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="VisualExceptionDialog" /> class.</summary>
        /// <param name="e">The exception.</param>
        /// <param name="caption">The caption.</param>
        public VisualExceptionDialog(Exception e, string caption = "Exception Dialog")
        {
            _imageSpacing = 10;
            _textHeight = 16;

            ControlBox.Location = new Point(Width - 34, -6);

            Padding = new Padding(10);
            Size = new Size(440, 410);
            BackColor = Color.White;
            Text = caption;

            _exception = e;

            var _defaultWidth = 360;

            InitializePictureBoxImage();
            InitializeDescriptionLabel(_defaultWidth);
            InitializeMessage(_defaultWidth);
            InitializeType(_defaultWidth);
            InitializeStackTrace(_defaultWidth);
            InitializeButtons();
        }

        #endregion

        #region Properties

        /// <summary>Gets or sets the copy button.</summary>
        [Browsable(false)]
        public Button CopyButton
        {
            get
            {
                return _copyButton;
            }

            set
            {
                _copyButton = value;
            }
        }

        /// <summary>Gets or sets the description label.</summary>
        [Browsable(false)]
        public Label DescriptionLabel
        {
            get
            {
                return _descriptionLabel;
            }

            set
            {
                _descriptionLabel = value;
            }
        }

        /// <summary>Gets or sets the dialog image box.</summary>
        [Browsable(false)]
        public PictureBox DialogImage
        {
            get
            {
                return _pictureBoxImage;
            }

            set
            {
                _pictureBoxImage = value;
            }
        }

        /// <summary>Gets or sets the message label.</summary>
        [Browsable(false)]
        public Label MessageLabel
        {
            get
            {
                return _messageLabel;
            }

            set
            {
                _messageLabel = value;
            }
        }

        /// <summary>Gets or sets the message box.</summary>
        [Browsable(false)]
        public TextBox MessageTextBox
        {
            get
            {
                return _messageTextBox;
            }

            set
            {
                _messageTextBox = value;
            }
        }

        /// <summary>Gets or sets the ok button.</summary>
        [Browsable(false)]
        public Button OkButton
        {
            get
            {
                return _okButton;
            }

            set
            {
                _okButton = value;
            }
        }

        /// <summary>Gets or sets the save button.</summary>
        [Browsable(false)]
        public Button SaveButton
        {
            get
            {
                return _saveButton;
            }

            set
            {
                _saveButton = value;
            }
        }

        /// <summary>Gets or sets the stack label.</summary>
        [Browsable(false)]
        public Label StackLabel
        {
            get
            {
                return _stackLabel;
            }

            set
            {
                _stackLabel = value;
            }
        }

        /// <summary>Gets or sets the stack box.</summary>
        [Browsable(false)]
        public TextBox StackTextBox
        {
            get
            {
                return _stackTextBox;
            }

            set
            {
                _stackTextBox = value;
            }
        }

        /// <summary>Gets or sets the type label.</summary>
        [Browsable(false)]
        public Label TypeLabel
        {
            get
            {
                return _typeLabel;
            }

            set
            {
                _typeLabel = value;
            }
        }

        /// <summary>Gets or sets the type box.</summary>
        [Browsable(false)]
        public TextBox TypeTextBox
        {
            get
            {
                return _typeTextBox;
            }

            set
            {
                _typeTextBox = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>Show the exception dialog.</summary>
        /// <param name="exception">The exception.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="dialogWindow">The dialog Window.</param>
        public static void Show(Exception exception, string caption = "Exception Dialog", bool dialogWindow = true)
        {
            BackgroundWorker _backgroundWorkerShow = new BackgroundWorker();
            _backgroundWorkerShow.DoWork += BackgroundWorker_DoShowWork(exception, caption, dialogWindow);
            _backgroundWorkerShow.RunWorkerAsync();
        }

        /// <summary>Copy the log to the clipboard.</summary>
        public void CopyLogToClipboard()
        {
            Clipboard.SetText(ConsoleEx.Generate(_exception));
        }

        /// <summary>Saves the log to a file.</summary>
        /// <param name="filePath">The file Path.</param>
        public void SaveLog(string filePath)
        {
            File.WriteAllText(filePath, ConsoleEx.Generate(_exception));
        }

        /// <summary>Display the <see cref="VisualExceptionDialog" />.</summary>
        /// <param name="exception">The exception.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="dialogWindow">The dialog Window.</param>
        /// <returns>The <see cref="DoWorkEventHandler" />.</returns>
        private static DoWorkEventHandler BackgroundWorker_DoShowWork(Exception exception, string caption, bool dialogWindow)
        {
            VisualExceptionDialog _exceptionDialog = new VisualExceptionDialog(exception)
                    {
                       Text = caption 
                    };

            if (dialogWindow)
            {
                _exceptionDialog.ShowDialog();
            }
            else
            {
                _exceptionDialog.Show();
            }

            return null;
        }

        /// <summary>The Copy button is clicked.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event.</param>
        private void CopyButton_Click(object sender, EventArgs e)
        {
            CopyLogToClipboard();
        }

        /// <summary>Initializes the ok button.</summary>
        private void InitializeButtons()
        {
            var _buttonSpacing = 7;
            Size _buttonSize = new Size(75, 23);

            _okButton = new Button
                {
                    BackColor = SystemColors.Control,
                    Text = @"OK",
                    Size = _buttonSize,
                    Location = new Point(_stackTextBox.Right - _buttonSize.Width, _stackTextBox.Bottom + 10),
                    TabIndex = 0
                };

            _okButton.Click += OkButton_Click;

            Controls.Add(_okButton);

            _saveButton = new Button
                {
                    BackColor = SystemColors.Control,
                    Text = @"Save",
                    Size = _buttonSize,
                    Location = new Point(_okButton.Left - _buttonSpacing - _buttonSize.Width, _stackTextBox.Bottom + 10),
                    TabIndex = 1
                };

            _saveButton.Click += SaveButton_Click;

            Controls.Add(_saveButton);

            _copyButton = new Button
                {
                    BackColor = SystemColors.Control,
                    Text = @"Copy",
                    Size = _buttonSize,
                    Location = new Point(_saveButton.Left - _buttonSpacing - _buttonSize.Width, _stackTextBox.Bottom + 10),
                    TabIndex = 2
                };

            _copyButton.Click += CopyButton_Click;

            Controls.Add(_copyButton);
        }

        /// <summary>Initializes the description label.</summary>
        /// <param name="width">The width.</param>
        private void InitializeDescriptionLabel(int width)
        {
            _descriptionLabel = new Label
                {
                    Text = @"An unhandled exception has occurred in a component in your application.",
                    Location = new Point(_pictureBoxImage.Right + _imageSpacing, Padding.Top + BodyContainer.Y),
                    Size = new Size(width, _textHeight),
                    BorderStyle = BorderStyle.None,
                    BackColor = Background
                };

            Controls.Add(_descriptionLabel);
        }

        /// <summary>Initializes the text box message.</summary>
        /// <param name="width">The width.</param>
        private void InitializeMessage(int width)
        {
            _messageLabel = new Label
                {
                    Text = @"Message:",
                    BorderStyle = BorderStyle.None,
                    Location = new Point(_pictureBoxImage.Right + _imageSpacing, _descriptionLabel.Bottom + 10),
                    Size = new Size(width, _textHeight),
                    BackColor = Background
                };

            Controls.Add(_messageLabel);

            string _message = _exception?.Message ?? "The exception was null.";

            _messageTextBox = new TextBox
                {
                    ReadOnly = true,
                    BackColor = Background,
                    BorderStyle = BorderStyle.None,
                    Text = _message,
                    Location = new Point(_messageLabel.Location.X, _messageLabel.Bottom),
                    Size = new Size(width, 20)
                };

            Controls.Add(_messageTextBox);
        }

        /// <summary>Initializes the picture box image.</summary>
        private void InitializePictureBoxImage()
        {
            _pictureBoxImage = new PictureBox
                {
                    Image = SystemIcons.Error.ToBitmap(),
                    Location = new Point(Padding.Left + BodyContainer.X, Padding.Top + BodyContainer.Y),
                    Size = new Size(32, 32),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    BackColor = Background
                };

            Controls.Add(_pictureBoxImage);
        }

        /// <summary>Initializes the text box stack trace.</summary>
        /// <param name="width">The width.</param>
        private void InitializeStackTrace(int width)
        {
            _stackLabel = new Label
                {
                    Text = @"Stack Trace:",
                    Location = new Point(_typeTextBox.Location.X, _typeTextBox.Bottom + 10),
                    Size = new Size(width, _textHeight),
                    BorderStyle = BorderStyle.None,
                    BackColor = Background
                };

            Controls.Add(_stackLabel);

            _stackTextBox = new TextBox
                {
                    BackColor = Background,
                    Text = _exception.StackTrace,
                    ReadOnly = true,
                    Multiline = true,
                    Location = new Point(_stackLabel.Location.X, _stackLabel.Bottom),
                    Size = new Size(width, 200),
                    ScrollBars = ScrollBars.Both
                };

            Controls.Add(_stackTextBox);
        }

        /// <summary>Initializes the type message.</summary>
        /// <param name="width">The width.</param>
        private void InitializeType(int width)
        {
            _typeLabel = new Label
                {
                    Text = @"Type:",
                    Location = new Point(_pictureBoxImage.Right + _imageSpacing, _messageTextBox.Bottom + 10),
                    Size = new Size(width, _textHeight),
                    BorderStyle = BorderStyle.None,
                    BackColor = Background
                };

            Controls.Add(_typeLabel);

            string _message = _exception?.GetType().ToString() ?? "The exception was null.";

            _typeTextBox = new TextBox
                {
                    ReadOnly = true,
                    BackColor = Background,
                    BorderStyle = BorderStyle.None,
                    Text = _message,
                    Location = new Point(_pictureBoxImage.Right + _imageSpacing, _typeLabel.Bottom),
                    Size = new Size(width, 20)
                };

            Controls.Add(_typeTextBox);
        }

        /// <summary>The OK button is clicked.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event.</param>
        private void OkButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>The Copy button is clicked.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event.</param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog _saveFileDialog = new SaveFileDialog
                {
                    Title = @"Save exception log...",
                    Filter = @"Text Files|*.log;*.txt|All Files|*.*"
                };

            if (_saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveLog(_saveFileDialog.FileName);
            }
        }

        #endregion
    }
}