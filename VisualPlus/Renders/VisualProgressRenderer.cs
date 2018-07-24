#region Namespace

using System.Drawing;
using System.Drawing.Drawing2D;

using VisualPlus.Managers;
using VisualPlus.Structure;

#endregion

namespace VisualPlus.Renders
{
    public sealed class VisualProgressRenderer
    {
        #region Methods

        /// <summary>Draws a hatch component on the specified path.</summary>
        /// <param name="graphics">The specified graphics to draw on.</param>
        /// <param name="hatch">The hatch type.</param>
        /// <param name="hatchPath">The hatch path to fill.</param>
        public static void RenderHatch(Graphics graphics, Hatch hatch, GraphicsPath hatchPath)
        {
            if (!hatch.Visible)
            {
                return;
            }

            HatchBrush hatchBrush = new HatchBrush(hatch.Style, hatch.ForeColor, hatch.BackColor);
            using (TextureBrush textureBrush = GraphicsManager.DrawTextureUsingHatch(hatchBrush))
            {
                textureBrush.ScaleTransform(hatch.Size.Width, hatch.Size.Height);
                graphics.FillPath(textureBrush, hatchPath);
            }
        }

        #endregion
    }
}