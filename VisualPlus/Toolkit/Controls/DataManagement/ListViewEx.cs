namespace VisualPlus.Toolkit.Controls.DataManagement
{
    #region Namespace

    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    using VisualPlus.Localization;
    using VisualPlus.Native;
    using VisualPlus.Structure;

    #endregion

    [ToolboxItem(false)]
    public class ListViewEx : ListView
    {
        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="ListViewEx" /> class.</summary>
        public ListViewEx()
        {
            View = View.Details;
        }

        public event ScrollEventHandler Scroll;

        [Category(EventCategory.Action)]
        public event ScrollEventHandler Scrolled;

        #endregion

        #region Events

        protected virtual void OnScroll(ScrollEventArgs e)
        {
            Scroll?.Invoke(this, e);
        }

        protected override void WndProc(ref Message msg)
        {
            if ((msg.Msg == Constants.WM_VSCROLL) || (msg.Msg == Constants.WM_MOUSEWHEEL))
            {
                if (Scrolled != null)
                {
                    ScrollInfo _scrollInfo = new ScrollInfo
                            {
                               fMask = Constants.SIF_ALL 
                            };

                    _scrollInfo.cbSize = Marshal.SizeOf(_scrollInfo);
                    User32.GetScrollInfo(msg.HWnd, Constants.SB_HORZ, ref _scrollInfo);

                    if ((msg.WParam.ToInt32() == Constants.SB_ENDSCROLL) || (msg.Msg == Constants.WM_MOUSEWHEEL))
                    {
                        ScrollEventArgs _scrollEventArgs = new ScrollEventArgs(ScrollEventType.EndScroll, _scrollInfo.nPos);
                        Scrolled(this, _scrollEventArgs);
                    }

                    Invalidate();
                }
            }

            base.WndProc(ref msg);
        }

        #endregion
    }
}