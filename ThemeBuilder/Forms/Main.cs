#region Namespace

using System.Diagnostics;

using VisualPlus.EventArgs;
using VisualPlus.Toolkit.Dialogs;

#endregion

namespace ThemeBuilder.Forms
{
    /// <summary>The main.</summary>
    public partial class Main : VisualForm
    {
        #region Constructors

        public Main()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void Main_HelpButtonClicked(ControlBoxEventArgs e)
        {
            Process.Start("https://darkbyte7.github.io/VisualPlus/");
        }

        #endregion
    }
}