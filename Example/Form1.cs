namespace Example
{
    #region Namespace

    using System;
    using System.Diagnostics;

    using VisualPlus.Toolkit.Dialogs;

    #endregion

    /// <summary>The <see cref="VisualForm" /> example.</summary>
    public partial class Form1 : VisualForm
    {
        #region Constructors

        public Form1()
        {
            InitializeComponent();

            _visualControlBox.HelpButton.Click += HelpButton_Click;
        }

        #endregion

        #region Events

        private void HelpButton_Click(object sender, EventArgs e)
        {
            Process.Start("https://darkbyte7.github.io/VisualPlus/");
        }

        #endregion
    }
}