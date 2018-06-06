namespace VisualPlus.Native
{
    #region Namespace

    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Security;

    using VisualPlus.Structure;

    #endregion

    [SuppressUnmanagedCodeSecurity]
    internal static class Uxtheme
    {
        #region Events

        [Description("Closes an open theme data pointer.")]
        [DllImport("uxtheme.dll")]
        public static extern void CloseThemeData(IntPtr hTheme);

        [Description("Draws the background image defined by the visual style for the specified control part.")]
        [DllImport("uxtheme.dll", ExactSpelling = true)]
        public static extern void DrawThemeBackground(IntPtr hTheme, IntPtr hDC, int partId, int stateId, ref RECT rect, ref RECT clipRect);

        [Description("Draws one or more edges defined by the visual style of a rectangle.")]
        [DllImport("uxtheme.dll", ExactSpelling = true)]
        public static extern void DrawThemeEdge(IntPtr hTheme, IntPtr hDC, int partId, int stateId, ref RECT destRect, uint edge, uint flags, ref RECT contentRect);

        [Description("Draws out an icon from a currently used theme image list.")]
        [DllImport("uxtheme.dll", ExactSpelling = true)]
        public static extern void DrawThemeIcon(IntPtr hTheme, IntPtr hDC, int partId, int stateId, ref RECT rect, IntPtr hIml, int imageIndex);

        [Description("Draws the part of a parent control that is covered by a partially-transparent or alpha-blended child control.")]
        [DllImport("uxtheme.dll", ExactSpelling = true)]
        public static extern void DrawThemeParentBackground(IntPtr hWnd, IntPtr hDC, ref RECT rect);

        [Description("Draws text using the color and font defined by the visual style.")]
        [DllImport("uxtheme.dll")]
        public static extern void DrawThemeText(IntPtr hTheme, IntPtr hDC, int partId, int stateId, [MarshalAs(UnmanagedType.LPTStr)] string text, int charCount, uint textFlags, uint textFlags2, ref RECT rect);

        [Description("Returns a value if visual style is active.")]
        [DllImport("uxtheme.dll", ExactSpelling = true)]
        public static extern int IsThemeActive();

        [Description("Opens the theme data for a window and its associated class.")]
        [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr OpenThemeData(IntPtr hWnd, [MarshalAs(UnmanagedType.LPTStr)] string classList);

        [Description("Causes a window to use a different set of visual style information than its class normally uses.")]
        [DllImport("uxtheme.dll", PreserveSig = false)]
        public static extern void SetWindowTheme(IntPtr hWnd, string subAppName, string subIdList);

        #endregion
    }
}