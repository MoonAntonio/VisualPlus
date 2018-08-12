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
    [DefaultEvent("Load")]
    [DefaultProperty("Text")]
    [Description("The Visual Exception Dialog")]
    [DesignerCategory("Form")]
    [DesignTimeVisible(false)]
    [ToolboxItem(false)]
    public partial class VisualExceptionDialog : VisualDialog
    {
        #region Variables

        private readonly Exception _exception;

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="VisualExceptionDialog" /> class.</summary>
        /// <param name="e">The exception.</param>
        /// <param name="caption">The caption.</param>
        public VisualExceptionDialog(Exception e, string caption = "Exception Dialog") : this()
        {
            Text = caption;
            _exception = e;

            string _message = _exception?.Message ?? "The exception was null.";
            tbMessage.Text = _message;

            string _messageT = _exception?.GetType().ToString() ?? "The exception was null.";
            tbType.Text = _messageT;

            if (_exception != null)
            {
                tbStackTrace.Text = _exception.StackTrace;
            }
        }

        /// <summary>Initializes a new instance of the <see cref="VisualExceptionDialog" /> class.</summary>
        public VisualExceptionDialog()
        {
            InitializeComponent();
            dialogImage.Image = SystemIcons.Error.ToBitmap();
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

        /// <summary>The OK button is clicked.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event.</param>
        private void OKButton_Click(object sender, EventArgs e)
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