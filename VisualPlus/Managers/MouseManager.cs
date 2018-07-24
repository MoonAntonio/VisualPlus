#region Namespace

using System.Drawing;

#endregion

namespace VisualPlus.Managers
{
    public sealed class MouseManager
    {
        #region Methods

        /// <summary>Checks whether the mouse is inside the bounds.</summary>
        /// <param name="mousePoint">Mouse location.</param>
        /// <param name="bounds">The rectangle.</param>
        /// <returns>The <see cref="bool" />.</returns>
        public static bool IsMouseInBounds(Point mousePoint, Rectangle bounds)
        {
            return bounds.Contains(mousePoint);
        }

        #endregion
    }
}