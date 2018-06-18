#region Namespace

using VisualPlus.Events;
using VisualPlus.Toolkit.Dialogs;

#endregion

namespace UnitTests.Tests
{
    /// <summary>The form test.</summary>
    public partial class FormTest : VisualForm
    {
        #region Constructors

        public FormTest()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void TControlBox_ToggleChanged(ToggleEventArgs e)
        {
            if (TControlBox.Toggled)
            {
                ControlBox.Visible = true;
            }
            else
            {
                ControlBox.Visible = false;
            }
        }

        private void TMaximize_ToggleChanged(ToggleEventArgs e)
        {
            if (TMaximize.Toggled)
            {
                ControlBox.MaximizeButton.Visible = true;
            }
            else
            {
                ControlBox.MaximizeButton.Visible = false;
            }
        }

        #endregion
    }
}