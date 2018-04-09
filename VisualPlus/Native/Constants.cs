namespace VisualPlus.Native
{
    internal class Constants
    {
        #region Events

        public const int SB_ENDSCROLL = 8;
        public const int SB_HORZ = 1;
        public const int SB_LEFT = 6;
        public const int SB_LINELEFT = 0;
        public const int SB_LINERIGHT = 1;
        public const int SB_PAGELEFT = 2;
        public const int SB_PAGERIGHT = 3;
        public const int SB_RIGHT = 7;
        public const int SB_THUMBPOSITION = 4;
        public const int SB_THUMBTRACK = 5;
        public const int SIF_ALL = SIF_RANGE | SIF_PAGE | SIF_POS | SIF_TRACKPOS;
        public const int SIF_PAGE = 0x2;
        public const int SIF_POS = 0x4;
        public const int SIF_RANGE = 0x1;
        public const int SIF_TRACKPOS = 0x10;
        public const int WM_HSCROLL = 0x114;
        public const int WM_MOUSEWHEEL = 0x20A;
        public const int WM_VSCROLL = 0x115;
        public const int HT_CAPTION = 0x2;
        public const int HTBOTTOM = 15;
        public const int HTBOTTOMLEFT = 16;
        public const int HTBOTTOMRIGHT = 17;
        public const int HTCLIENT = 1;
        public const int HTLEFT = 10;
        public const int HTRIGHT = 11;
        public const int HTTOP = 12;
        public const int HTTOPLEFT = 13;
        public const int HTTOPRIGHT = 14;
        public const int HTTRANSPARENT = -1;
        public const int MONITOR_DEFAULTTONEAREST = 2;
        public const int TCM_HITTEST = 0x130D;
        public const uint TPM_LEFTALIGN = 0x0000;
        public const uint TPM_RETURNCMD = 0x0100;
        public const int WM_LBUTTONDBLCLK = 0x0203;
        public const int WM_LBUTTONDOWN = 0x0201;
        public const int WM_LBUTTONUP = 0x0202;
        public const int WM_MOUSEMOVE = 0x0200;
        public const int WM_NCHITTEST = 0x84;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int WM_RBUTTONDOWN = 0x0204;
        public const int WM_SETREDRAW = 11;
        public const int WM_SYSCOMMAND = 0x0112;
        public const int WMSZ_BOTTOM = 6;
        public const int WMSZ_BOTTOMLEFT = 7;
        public const int WMSZ_BOTTOMRIGHT = 8;
        public const int WMSZ_LEFT = 1;
        public const int WMSZ_RIGHT = 2;
        public const int WMSZ_TOP = 3;
        public const int WMSZ_TOPLEFT = 4;
        public const int WMSZ_TOPRIGHT = 5;
        public const int WS_MINIMIZEBOX = 0x20000;
        public const int WS_SYSMENU = 0x00080000;

        #endregion
    }
}