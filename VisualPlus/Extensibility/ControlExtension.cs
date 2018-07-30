#region Namespace

using System.Windows.Forms;

using VisualPlus.Managers;

#endregion

namespace VisualPlus.Extensibility
{
    public static class ControlExtension
    {
        #region Methods

        /// <summary>Centers the control inside the parent control.</summary>
        /// <param name="control">The control to center.</param>
        /// <param name="centerX">Center X coordinate.</param>
        /// <param name="centerY">Center Y coordinate.</param>
        /// <returns>The <see cref="Control" />.</returns>
        public static Control ToCenter(this Control control, bool centerX, bool centerY)
        {
            ControlManager.CenterControl(control, control.Parent, centerX, centerY);
            return control;
        }

        /// <summary>Centers the control inside the parent control.</summary>
        /// <param name="control">The control to center.</param>
        /// <returns>The <see cref="Control" />.</returns>
        public static Control ToCenter(this Control control)
        {
            ControlManager.CenterControl(control, control.Parent, true, true);
            return control;
        }

        #endregion
    }
}