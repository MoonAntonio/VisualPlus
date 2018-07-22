#region Namespace

using System.Windows.Forms;

using VisualPlus.Attributes;
using VisualPlus.Toolkit.Controls.Interactivity;

#endregion

namespace VisualPlus.Toolkit.Dialogs
{
    public class VisualMessageBox
    {
        #region Methods

        [Test]
        /// <summary>Displays a message box with the specified text.</summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="caption">The text to display in the title bar of the message box.</param>
        /// <param name="buttons">Specifies which buttons to display in the message box.</param>
        /// <param name="icon">Specifies which icon to display in the message box.</param>
        /// <returns>The <see cref="DialogResult" />.</returns>
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.None)
        {
            DialogResult dialogResult = DialogResult.None;

            // Configure the dialog form.
            VisualForm messageBoxDialog = new VisualForm(caption);

            messageBoxDialog.MaximizeBox = false;
            messageBoxDialog.MinimizeBox = false;
            messageBoxDialog.HelpButton = false;
            messageBoxDialog.Sizable = false;

            // Configure the message label.
            VisualLabel message = new VisualLabel
                    {
                       Text = text 
                    };

            messageBoxDialog.Controls.Add(message);

            // messageBoxDialog.ShowDialog();
            return dialogResult;
        }

        #endregion
    }
}