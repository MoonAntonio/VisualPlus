#region Namespace

using System;
using System.Windows.Forms;

#endregion

namespace VisualPlus.Events
{
    public class VisualTabControlEventArgs : EventArgs
    {
        #region Variables

        public bool Cancel = false;

        #endregion

        #region Variables

        private TabPage _tabPage;
        private int _tagPageIndex;

        #endregion

        #region Constructors

        public VisualTabControlEventArgs(TabPage tabPage, int tabPageIndex) : this()
        {
            _tabPage = tabPage;
            _tagPageIndex = tabPageIndex;
        }

        public VisualTabControlEventArgs()
        {
            _tagPageIndex = -1;
        }

        #endregion

        #region Properties

        public TabPage TabPage
        {
            get
            {
                return _tabPage;
            }
        }

        public int TabPageIndex
        {
            get
            {
                return _tagPageIndex;
            }
        }

        #endregion
    }
}