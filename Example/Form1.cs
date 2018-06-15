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

            ControlBox.HelpButton.Click += HelpButton_Click;
        }

        #endregion

        #region Methods

        private void HelpButton_Click(object sender, EventArgs e)
        {
            Process.Start("https://darkbyte7.github.io/VisualPlus/");
        }

        #endregion
    }
}