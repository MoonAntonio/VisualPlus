#region Namespace

using System.Drawing;

using VisualPlus.Structure;

#endregion

namespace VisualPlus.Renders
{
    public sealed class VisualWatermarkRenderer
    {
        #region Methods

        /// <summary>Renders the watermark.</summary>
        /// <param name="graphics">The specified graphics to draw on.</param>
        /// <param name="rectangle">The rectangle bounds.</param>
        /// <param name="stringFormat">The string format.</param>
        /// <param name="watermark">The watermark settings.</param>
        public static void RenderWatermark(Graphics graphics, Rectangle rectangle, StringFormat stringFormat, Watermark watermark)
        {
            if (watermark.Visible)
            {
                graphics.DrawString(watermark.Text, watermark.Font, watermark.Brush, rectangle, stringFormat);
            }
        }

        #endregion
    }
}