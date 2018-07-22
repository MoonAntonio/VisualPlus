#region Namespace

using System;

using VisualPlus.Events;
using VisualPlus.Toolkit.Dialogs;

#endregion

namespace UnitTests.Tests
{
    /// <summary>The form test.</summary>
    public partial class VisualControlBoxTest : VisualForm
    {
        #region Constructors

        public VisualControlBoxTest()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void TClose_ToggleChanged(ToggleEventArgs e)
        {
            // CloseBox = e.State;
            ControlBox.CloseButton.Visible = e.State;
        }

        private void TControlBox_ToggleChanged(ToggleEventArgs e)
        {
            ControlBox.Visible = e.State;
        }

        private void THelp_ToggleChanged(ToggleEventArgs e)
        {
            HelpButton = e.State;
        }

        private void TMaximize_ToggleChanged_1(ToggleEventArgs e)
        {
            MaximizeBox = e.State;
        }

        private void TMinimize_ToggleChanged(ToggleEventArgs e)
        {
            MinimizeBox = e.State;
        }

        private void VisualControlBoxTest_Load(object sender, EventArgs e)
        {
        }

        #endregion
    }
}