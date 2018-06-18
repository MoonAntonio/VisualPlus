#region Namespace

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using VisualPlus.Constants;
using VisualPlus.Localization;
using VisualPlus.Native;
using VisualPlus.Structure;

#endregion

namespace VisualPlus.Toolkit.Controls.DataManagement
{
    [Obsolete]
    [ToolboxItem(false)]
    public class ListViewEx : ListView
    {
        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="ListViewEx" /> class.</summary>
        public ListViewEx()
        {
            DoubleBuffered = true;
            View = View.Details;
        }

        #endregion

        #region Events

        public event ScrollEventHandler Scroll;

        [Category(EventCategory.Action)]
        public event ScrollEventHandler Scrolled;

        #endregion

        #region Overrides

        protected override void WndProc(ref Message msg)
        {
            if ((msg.Msg == ListViewConstants.WM_VSCROLL) || (msg.Msg == ListViewConstants.WM_MOUSEWHEEL))
            {
                if (Scrolled != null)
                {
                    ScrollInfo _scrollInfo = new ScrollInfo
                            {
                               fMask = ListViewConstants.SIF_ALL 
                            };

                    _scrollInfo.cbSize = Marshal.SizeOf(_scrollInfo);
                    User32.GetScrollInfo(msg.HWnd, ListViewConstants.SB_HORZ, ref _scrollInfo);

                    if ((msg.WParam.ToInt32() == ListViewConstants.SB_ENDSCROLL) || (msg.Msg == ListViewConstants.WM_MOUSEWHEEL))
                    {
                        ScrollEventArgs _scrollEventArgs = new ScrollEventArgs(ScrollEventType.EndScroll, _scrollInfo.nPos);
                        Scrolled(this, _scrollEventArgs);
                    }

                    Invalidate();
                }
            }

            base.WndProc(ref msg);
        }

        protected virtual void OnScroll(ScrollEventArgs e)
        {
            Scroll?.Invoke(this, e);
        }

        #endregion
    }
}