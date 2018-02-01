namespace VisualPlus.Native
{
    #region Namespace

    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Security;

    #endregion

    [SuppressUnmanagedCodeSecurity]
    internal static class Dwmapi
    {
        #region Events

        [Description("This function returns true if Aero (DWM Composition) is enabled. Generally used with the DwmExtendFrameIntoClientArea function.")]
        [DllImport("dwmapi.dll", CharSet = CharSet.Auto)]
        public static extern void DwmIsCompositionEnabled(out bool enabled);

        #endregion
    }
}