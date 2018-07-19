#region Namespace

using System.Drawing;

using VisualPlus.Managers;

#endregion

namespace VisualPlus.Renders
{
    public static class VisualDateTimeRenderer
    {
        #region Methods

        /// <summary>Draws the arrow.</summary>
        /// <param name="graphics">The specified graphics to draw on.</param>
        /// <param name="color">The color.</param>
        /// <param name="disabled">The disabled.</param>
        /// <param name="enabled">The enabled.</param>
        /// <param name="image">The image.</param>
        /// <param name="rectangle">The rectangle.</param>
        public static void DrawArrow(Graphics graphics, Color color, Color disabled, bool enabled, Image image, Rectangle rectangle)
        {
            if (image != null)
            {
                graphics.DrawImage(image, rectangle);
            }
            else
            {
                Color dropDownColor = enabled ? color : disabled;

                using (SolidBrush dropDownArrow = new SolidBrush(dropDownColor))
                {
                    GraphicsManager.DrawTriangle(graphics, rectangle, dropDownArrow, false);
                }
            }
        }

        #endregion
    }
}